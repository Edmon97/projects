var localhost = "http://localhost:44261/api/Projects/";

function GetAllProjects() {
    $.ajax({
        url: localhost,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            drawTable(data);
        }
    });
}

function drawTable(data) {
    $("#prjtable").empty();
    for (var i = 0; i < data.length; i++) {
        drawRow(data[i]);
    }
}

function drawRow(project) {
    var row = $("<tr />");
    $("#prjtable").append(row);
    row.append($("<td>" + project.Id + "</td>"));
    row.append($("<td>" + project.Name + "</td>"));
    row.append($("<td>" + project.City + "</td>"));
    row.append($("<td><button id=\"editBt\" class=\"btn btn-info\" onclick=\"editProject(" + project.Id + ",\'" + project.Name + "\',\'" + project.City + "\')\" data-toggle=\"modal\" data-target=\"#editModal\">Edit</button></td>"));
    row.append($("<td><button id='deleteBt' class='btn btn-warning' onclick='deleteProject(" + project.Id + ")'>Delete</button></td>"));
}

function editProject(id, name, city) {
    //alert("edit: " + id + " " + name + " " + status + " " + city);
    $("#editId").val(id);
    $("#editName").val(name);
    $("#editCity").val(city);
}

function saveProject() {
    var project =
    {
        Id: $("#editId").val(),
        Name: $("#editName").val(),
        City: $("#editCity").val()
    };
    //console.log("save: " + provider);
    //alert(localhost + $("#editId").val());
    $.ajax({
        url: localhost + $("#editId").val(),
        type: 'PUT',
        data: JSON.stringify(project),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllProjects();
        }
    });
}

function deleteProject(id) {

    $.ajax({
        url: localhost + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllProjects();
        }
    });
}

function createProject() {
    $("#saveBt").attr("onclick", "saveProject()");
    var project =
    {
        Id: $("#editId").val(),
        Name: $("#editName").val(),
        City: $("#editCity").val()
    };
    console.log("create: " + project);

    $.ajax({
        url: localhost,
        type: 'POST',
        data: JSON.stringify(project),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllProjects();
        }
    });

}

function changeClick() {
    $("#editId").empty();
    $("#editName").empty();
    $("#editCity").empty();
    $("#saveBt").attr("onclick", "createProject()");
}