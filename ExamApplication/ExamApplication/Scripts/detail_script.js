var localhost = "http://localhost:44261/api/Details/";

function GetAllDetails() {
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
    $("#dtlstable").empty();
    for (var i = 0; i < data.length; i++) {
        drawRow(data[i]);
    }
}

function drawRow(detail) {
    var row = $("<tr />");
    $("#dtlstable").append(row);
    row.append($("<td>" + detail.Id + "</td>"));
    row.append($("<td>" + detail.Name + "</td>"));
    row.append($("<td>" + detail.Color + "</td>"));
    row.append($("<td>" + detail.Weight + "</td>"));
    row.append($("<td>" + detail.City + "</td>"));
    row.append($("<td><button id=\"editBt\" class=\"btn btn-info\" onclick=\"editDetail(" + detail.Id + ",\'" + detail.Name + "\',\'" + detail.Color + "\',\'" + detail.City + "\'," + detail.Weight + ")\" data-toggle=\"modal\" data-target=\"#editModal\">Edit</button></td>"));
    row.append($("<td><button id='deleteBt' class='btn btn-warning' onclick='deleteDetail(" + detail.Id + ")'>Delete</button></td>"));
}

function editDetail(id, name, color, city, weight) {
    //alert("edit: " + id + " " + name + " " + color + " " + city + " " + weight);
    $("#editId").val(id);
    $("#editName").val(name);
    $("#editColor").val(color);
    $("#editWeight").val(weight);
    $("#editCity").val(city);
}

function saveDetail() {
    var detail =
    {
        Id: $("#editId").val(),
        Name: $("#editName").val(),
        Color: $("#editColor").val(),
        Weight: $("#editWeight").val(),
        City: $("#editCity").val()
    };
    //console.log("save: " + provider);
    $.ajax({
        url: localhost + $("#editId").val(),
        type: 'PUT',
        data: JSON.stringify(detail),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllDetails();
        }
    });
}

function deleteDetail(id) {

    $.ajax({
        url: localhost + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllDetails();
        }
    });
}

function createDetail() {
    $("#saveBt").attr("onclick", "saveDetail()");
    var detail =
    {
        Id: $("#editId").val(),
        Name: $("#editName").val(),
        Color: $("#editColor").val(),
        Weight: $("#editWeight").val(),
        City: $("#editCity").val()
    };
    console.log("create: " + detail);

    $.ajax({
        url: localhost,
        type: 'POST',
        data: JSON.stringify(detail),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllDetails();
        }
    });

}

function changeClick() {
    $("#editId").empty();
    $("#editName").empty();
    $("#editColor").empty();
    $("#editWeight").empty();
    $("#editCity").empty();
    $("#saveBt").attr("onclick", "createDetail()");
}