var datatabe;

$(document).ready(function(){
    Load();
});

function Load() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/jobtype/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "40%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/jobtype/upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Edit
                                </a>
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;" onclick=Delete('/api/jobtype/'+${data})>
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                    </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        }, "width": "100%"
    });
}