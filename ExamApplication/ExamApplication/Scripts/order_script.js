var localhost = "http://localhost:44261/api/Orders/";

function GetAllOrders() {
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
    $("#ordtable").empty();
    for (var i = 0; i < data.length; i++) {
        drawRow(data[i]);
    }
}

function drawRow(order) {
    var row = $("<tr />");
    $("#ordtable").append(row);
    row.append($("<td>" + order.Id + "</td>"));
    row.append($("<td>" + order.Provider.Name + "</td>"));
    row.append($("<td>" + order.Detail.Name + "</td>"));
    row.append($("<td>" + order.Project.Name + "</td>"));
    row.append($("<td>" + order.Detail.Name + "</td>"));
    row.append($("<td>" + order.Count + "</td>"));
    row.append($("<td><button id=\"editBt\" class=\"btn btn-info\" onclick=\"editOrder(" + order.Id + ",\'" + project.Name + "\',\'" + project.City + "\')\" data-toggle=\"modal\" data-target=\"#editModal\">Edit</button></td>"));
    row.append($("<td><button id='deleteBt' class='btn btn-warning' onclick='deleteOrder(" + order.Id + ")'>Delete</button></td>"));
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
            GetAllOrders();
        }
    });
}

function deleteOrder(id) {

    $.ajax({
        url: localhost + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            
        }
    });
}

function createOrder() {
    //$("#saveBt").attr("onclick", "saveOrder()");
    var order =
    {
        Id: $("#editId").val(),
        Provider: $("#editProvider").val(),
        Detail: $("#editDetail").val(),
        Project: $("#editProject").val(),
        Count: $("#editCount").val(),
    };
    alert("create: " + order);

    //$.ajax({
    //    url: localhost,
    //    type: 'POST',
    //    data: JSON.stringify(order),
    //    contentType: "application/json;charset=utf-8",
    //    success: function (data) {
    //        GetAllOrders();
    //    },
    //    error: function (x, y, z) {
    //        alert(x + '\n' + y + '\n' + z);
    //    }
    //});

}

function changeClick() {
    $("#editId").empty();
    $("#editProvider").empty();
    $("#editDetail").empty();
    $("#editProject").empty();
    $("#editCount").empty();
    $("#saveBt").attr("onclick", "createOrder()");
}