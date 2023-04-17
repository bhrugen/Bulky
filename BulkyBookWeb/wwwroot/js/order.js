﻿var dataTable;

$(document).ready(function () {
    var urlParams = new URLSearchParams(window.location.search);
    var status = urlParams.get('status');
    loadDataTable(status);
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Order/GetAll?status=" + status
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "name", "width": "25%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "applicationUser.email", "width": "15%" },
            { "data": "orderStatus", "width": "15%" },
            { "data": "orderTotal", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Order/Details?orderId=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i></a>
                      
					</div>
                        `
                },
                "width": "5%"
            }
        ]
    });
}
