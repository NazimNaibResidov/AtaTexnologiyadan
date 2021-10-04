$(document).ready(function () {
    $("#example").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ajax": {
            "url": "/Home/LoadData",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "name", "id": "name", "autoWidth": true },
            { "data": "name", "name": "name", "autoWidth": true },
            { "data": "surname", "name": "surname", "autoWidth": true },
            { "data": "birthDate", "name": "birthDate", "autoWidth": true,  },
            { "data": "passportNumber", "name": "passportNumber", "autoWidth": true },
            { "data": "position", "name": "position", "autoWidth": true },
            { "data": "gender", "name": "gender", "autoWidth": true },
            { "data": "contractNumber", "name": "contractNumber", "autoWidth": true },
            { "data": "contractDate", "name": "contractDate", "autoWidth": true },
            { "data": "salary", "name": "salary", "autoWidth": true },
            { "data": "department", "name": "department", "autoWidth": true },
            //{
            //    "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Home/Edit/' + full.id + '">Edit</a>'; }
            //},
            //{
            //    "render": function (data, type, full, meta) { return '<a class="btn btn-danger" href="/Home/Delete/' + full.id + '">Delete</a>'; }
            //    //data: null,
            //    //render: function (data, type, row) {
            //    //    return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + data.id + "'); >Delete</a>";
            //    //}
            //},
        ]
    });
});

function DeleteData(ID) {
    if (confirm("Are you sure you want to delete ...?")) {
        Delete(CustomerID);
    } else {
        return false;
    }
}

function Delete(CustomerID) {
    var url = "/Home/Delete";

    $.post(url, { ID: CustomerID }, function (data) {
        if (data) {
            oTable = $('#example').DataTable();
            oTable.draw();
        } else {
            alert("Something Went Wrong!");
        }
    });
}