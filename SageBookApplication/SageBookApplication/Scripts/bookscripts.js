var localhost = "http://paywebapp.azurewebsites.net/api/book/";

function GetAllBooks() {
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

//function WriteResponse(books) {
//    $.each(books,
//        function (index, book) {
//            var data = "<td>" + book.Id + "</td>" + "<td><img src='" + book.Image + "' alt='" + book.Name + "' style=\"height: 100px;\"></td>" + "<td>" + book.Name + "</td>" + "<td>" + book.Count + "</td>";
//            var editBt = "<td><button id=\"editBt\" class=\"btn btn-info\" onclick=\"editBook(" + book.Id + ",\'" + book.Name + "\',\'" + book.Image + "\'," + book.Count + ")\" data-toggle=\"modal\" data-target=\"#editModal\">Edit</button></td>";
//            var deleteBt = "<td><button id='deleteBt' class='btn btn-warning' onclick='deleteBook(" + book.Id + ")'>Delete</button></td>";
//            var row = "<tr>" + data + editBt + deleteBt + "</tr>";
//            $('#booktable > tbody:last-child').append(row);
//        });
//}

function drawTable(data) {
    $("#booktable").empty();
    for (var i = 0; i < data.length; i++) {
        drawRow(data[i]);
    }
}

function drawRow(book) {
    var row = $("<tr />");
    $("#booktable").append(row);
    row.append($("<td>" + book.Id + "</td>"));
    row.append($("<td><img src='" + book.Image + "' alt='" + book.Name + "' style=\"height: 100px;\"></td>"));
    row.append($("<td>" + book.Name + "</td>"));
    row.append($("<td>" + book.Count + "</td>"));
    row.append($("<td><button id=\"editBt\" class=\"btn btn-info\" onclick=\"editBook(" + book.Id + ",\'" + book.Name + "\',\'" + book.Image + "\'," + book.Count + ")\" data-toggle=\"modal\" data-target=\"#editModal\">Edit</button></td>"));
    row.append($("<td><button id='deleteBt' class='btn btn-warning' onclick='deleteBook(" + book.Id + ")'>Delete</button></td>"));
}

function editBook(id, name, image, count) {
    console.log("edit: " + id + " " + name + " " + image + " " + count);
    $("#editId").val(id);
    $("#editImage").val(image);
    $("#editName").val(name);
    $("#editCount").val(count);
}

function saveBook() {
    var book =
    {
        Id: $("#editId").val(),
        Name: $("#editName").val(),
        Image: $("#editImage").val(),
        Count: $("#editCount").val()
    };
    console.log("save: " + book);

    $.ajax({
        url: localhost + $("#editId").val(),
        type: 'PUT',
        data: JSON.stringify(book),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllBooks();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function deleteBook(id) {

    $.ajax({
        url: localhost + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllBooks();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function createBook() {
    $("#saveBt").attr("onclick", "saveBook()");
    var book =
    {
        Id: $("#editId").val(),
        Name: $("#editName").val(),
        Image: $("#editImage").val(),
        Count: $("#editCount").val()
    };
    console.log("create: " + book);

    $.ajax({
        url: localhost,
        type: 'POST',
        data: JSON.stringify(book),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllBooks();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

}

function changeClick() {
    $("#editId").empty();
    $("#editImage").empty();
    $("#editName").empty();
    $("#editCount").empty();
    $("#saveBt").attr("onclick", "createBook()");
}

function sort(field) {
    var value = $('#sort' + field).val();
    //alert(value);
    if (value == "asc") {
        $('#sort' + field).val("desc");
    } else {
        $('#sort' + field).val("asc");
    }
    value = $('#sort' + field).val();
    //?$orderby=Rating asc
    $.ajax({
        url: "http://localhost:1690//api/book?$orderby=" + field + " " + value,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            drawTable(data);
        }
    });
}