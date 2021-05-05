var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/mentor",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { data: "fullName", width: "40%" },
            {
                data: "applicantId",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/Mentor/Home/Notes/AddNote?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> New Note
                                </a>
                    </div>`;
                }, "width": "30%"
            },
            {
                data: "applicantId",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/Mentor/Home/Notes/NoteHistory?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> See History
                                </a>
                    </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}