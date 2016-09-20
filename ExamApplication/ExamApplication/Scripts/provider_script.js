var localhost = "http://localhost:44261/api/Providers/";

function GetAllProviders() {
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
    $("#prvtable").empty();
    for (var i = 0; i < data.length; i++) {
        drawRow(data[i]);
    }
}

function drawRow(provider) {
    var row = $("<tr />");
    $("#prvtable").append(row);
    row.append($("<td>" + provider.Id + "</td>"));
    row.append($("<td>" + provider.Name+ "</td>"));
    row.append($("<td>" + provider.Status + "</td>"));
    row.append($("<td>" + provider.City + "</td>"));
    row.append($("<td><button id=\"editBt\" class=\"btn btn-info\" onclick=\"editProvider(" + provider.Id + ",\'" + provider.Name + "\',\'" + provider.Status + "\',\'" + provider.City + "\')\" data-toggle=\"modal\" data-target=\"#editModal\">Edit</button></td>"));
    row.append($("<td><button id='deleteBt' class='btn btn-warning' onclick='deleteProvider(" + provider.Id + ")'>Delete</button></td>"));
}

function editProvider(id, name, status, city) {
    //alert("edit: " + id + " " + name + " " + status + " " + city);
    $("#editId").val(id);
    $("#editName").val(name);
    $("#editStatus").val(status);
    $("#editCity").val(city);
}

function saveProvider() {
    var provider =
    {
        Id: $("#editId").val(),
        Name: $("#editName").val(),
        Status: $("#editStatus").val(),
        City: $("#editCity").val()
    };
    //console.log("save: " + provider);
    //alert(localhost + $("#editId").val());
    $.ajax({
        url: localhost + $("#editId").val(),
        type: 'PUT',
        data: JSON.stringify(provider),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllProviders();
        }
    });
}

function deleteProvider(id) {

    $.ajax({
        url: localhost + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllProviders();
        }
    });
}

function createProvider() {
    $("#saveBt").attr("onclick", "saveProvider()");
    var provider =
    {
        Id: $("#editId").val(),
        Name: $("#editName").val(),
        Status: $("#editStatus").val(),
        City: $("#editCity").val()
    };
    console.log("create: " + provider);

    $.ajax({
        url: localhost,
        type: 'POST',
        data: JSON.stringify(provider),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllProviders();
        }
    });

}

function changeClick() {
    $("#editId").empty();
    $("#editName").empty();
    $("#editStatus").empty();
    $("#editCity").empty();
    $("#saveBt").attr("onclick", "createProvider()");
}