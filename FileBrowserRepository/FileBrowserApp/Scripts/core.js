Process();

//main function 
function Process() {

    angular.module('explorerApp', ['ngAnimate', 'ui.bootstrap']);
    var explorerApp = angular.module("explorerApp", []);

    explorerApp.controller('explorerCtrl', function ($scope, $http) {

        $scope.substyle = false;

        //this ajax request get root (all local drivers)
        $http.get("/api/browser/").then(function (response) {
            $scope.data = stateFunction(response.data);
            $scope.rows = showSize($scope.data.subdir);
            $scope.data.current_path = $scope.data.parent;
        });

        //this function responsible for open folder and get all directories and files in current directory
        $scope.openFolder = function (path) {

            $http.post(
                '/api/browser',
                JSON.stringify(path), {
                    headers: { 'Content-Type': 'application/json' }
                }).success(function (model) {
                    //list of files and directories, current path, parent path to back
                    $scope.data = stateFunction(model);
                    //count of files in directories and subdirectories
                    $scope.rows = showSize($scope.data.subdir);
                    //show button with text "Back" if current path isn't root
                    $scope.showBack = ($scope.data.current_path == "Computer") ? false : true;
                });

        }

        //show list of files from subdirectories by size
        $scope.showFiles = function (size) {
            var row = showList($scope.data.subdir);

            //set array of files that you need
            $scope.subfiles = (size != "l10") ? (size == "l50" ? row.list_l50 : row.list_m100) : row.list_l10;

            if ($scope.subfiles.length != 0)
                $scope.substyle = true;
        }

        //hide list of files from subdirectories
        $scope.hideFiles = function () {
            $scope.substyle = false;
        }

    });
}

//this function process data and return information about current state of explorer 
//(list of directories, files in current directory and files in subdirectories, parent path to back, current path)
function stateFunction(model) {

    var data = angular.fromJson(model);
    var state =
        {
            parent: data.parent,
            current_path: data.path,
            subdir: data.subdir,
            files: data.files,
            directories: data.directories
        };
    return state;
}

//this function return count of file sizes
function showSize(files) {

    var l10 = 0, l50 = 0, m100 = 0;

    angular.forEach(files, function (file) {
        var size = file.Size / 1024;
        if (size >= 100)
            m100++;
        else if (size <= 10)
            l10++;
        else
            l50++;
    });

    var row = [{ "l10": l10, "l50": l50, "m100": m100 }];

    return row;
}

//this function returns an array of files sorted by size
function showList(files) {
    var row = { "list_l10": [], "list_l50": [], "list_m100": [] };

    angular.forEach(files, function (file) {
        var size = file.Size / 1024;
        if (size >= 100) {
            row.list_m100.push({ "Path": file.Path, "Size": size.toFixed(5) });
        }
        else if (size <= 10) {
            row.list_l10.push({ "Path": file.Path, "Size": size.toFixed(5) });
        }
        else {
            row.list_l50.push({ "Path": file.Path, "Size": size.toFixed(5) });
        }
    });

    return row;
}