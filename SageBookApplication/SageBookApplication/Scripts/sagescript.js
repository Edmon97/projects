var localhost = "http://paywebapp.azurewebsites.net/api/sage/";

function GetAllSages() {
    $('#sagetable > tbody').empty();
    $.ajax({
        url: localhost,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            drawTable(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

//function WriteResponse(sages) {
//    $.each(sages,
//        function (index, sage) {
//            var data = "<td>" + sage.Id + "</td>" + "<td><img src='" + sage.Image + "' alt='" + sage.Name + "' style=\"height: 100px;\"></td>" + "<td>" + sage.Name + "</td>" + "<td>" + sage.Age + "</td>";
//            var editBt = "<td><button id=\"editBt\" class=\"btn btn-info\" onclick=\"editSage(" + sage.Id + ",\'" + sage.Name + "\',\'" + sage.Image + "\'," + sage.Age + ")\" data-toggle=\"modal\" data-target=\"#editModal\">Edit</button></td>";
//            var deleteBt = "<td><button id='deleteBt' class='btn btn-warning' onclick='deleteSage(" + sage.Id + ")'>Delete</button></td>";
//            var row = "<tr>" + data + editBt + deleteBt + "</tr>";
//            $('#sagetable > tbody:last-child').append(row);
//        });
//}

function drawTable(data) {
    $("#booktable").empty();
    for (var i = 0; i < data.length; i++) {
        drawRow(data[i]);
    }
}

function drawRow(sage) {
    var row = $("<tr />");
    $("#booktable").append(row);
    row.append($("<td>" + sage.Id + "</td>"));
    row.append($("<td><img src='" + sage.Image + "' alt='" + sage.Name + "' style=\"height: 100px;\"></td>"));
    row.append($("<td>" + sage.Name + "</td>"));
    row.append($("<td>" + sage.Age + "</td>"));
    row.append($("<td><button id=\"editBt\" class=\"btn btn-info\" onclick=\"editSage(" + sage.Id + ",\'" + sage.Name + "\',\'" + sage.Image + "\'," + sage.Age + ")\" data-toggle=\"modal\" data-target=\"#editModal\">Edit</button></td>"));
    row.append($("<td><button id='deleteBt' class='btn btn-warning' onclick='deleteSage(" + sage.Id + ")'>Delete</button></td>"));
}

function editSage(id, name, image, age) {
    console.log("edit: " + id + " " + name + " " + image + " " + age);
    $("#editId").val(id);
    $("#editImage").val(image);
    $("#editName").val(name);
    $("#editAge").val(age);
}

function saveSage() {
    var sage =
    {
        Id: $("#editId").val(),
        Name: $("#editName").val(),
        Image: $("#editImage").val(),
        Age: $("#editAge").val()
    };
    console.log("save: " + sage);

    $.ajax({
        url: localhost + $("#editId").val(),
        type: 'PUT',
        data: JSON.stringify(sage),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllSages();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function deleteSage(id) {

    $.ajax({
        url: localhost + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllSages();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function createSage() {
    $("#saveBt").attr("onclick", "saveSage()");
    var sage =
    {
        Id: $("#editId").val(),
        Name: $("#editName").val(),
        Image: $("#editImage").val(),
        Age: $("#editAge").val()
    };
    console.log("create: " + sage);

    $.ajax({
        url: localhost,
        type: 'POST',
        data: JSON.stringify(sage),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllSages();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

}