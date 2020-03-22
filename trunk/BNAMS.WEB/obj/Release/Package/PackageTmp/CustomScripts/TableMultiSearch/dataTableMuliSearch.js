$(document).ready(function () {





    // Setup - add a text input to each footer cell
    $("#example tfoot th").each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });


    viewRank.GetRankDataTable();





    // DataTable



    var table = $("#example").DataTable();

    // Apply the search
    table.columns().every(function () {
        var that = this;

        $("input", this.footer()).on("keyup change clear", function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });




});


var viewRank = {

    GetRankDataTable: function () {
        $("#example").dataTable().fnDestroy();
        $("#example").DataTable({
            "scrollX": true,
            "ajax": {
                "url": "/Rank/GetAllRank",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                {
                    "title": "SL.",
                    render: function (data, type, row, meta) {
                        return meta.row + meta.settings._iDisplayStart + 1;
                    }
                },
                { "data": "RankName", "autoWidth": true },
                { "data": "RankGroupName", "autoWidth": true },
                { "data": "RecStatus", "autoWidth": true }
            ],
            "columnDefs": [

                {
                    targets: [3],

                    render: function (data, type, row) {
                        debugger;

                        if (row.RecStatus == 1 && row.IsVerified == false) {
                            if (row.EntryBy == window.userId) {
                                return "<button id='btnEdit' type='button' class='btn btn-primary' disabled>EDIT</button>";
                            }
                            return "<button id='btnEdit' type='button' class='btn btn-primary'>VERIFY</button>";
                        }
                        else if (row.RecStatus == 2 && row.IsVerified == false) {
                            if (row.EntryBy == window.userId) {
                                return "<button id='btnEdit' type='button' class='btn btn-primary' disabled>EDIT</button>";
                            }
                            return "<button id='btnEdit' type='button' class='btn btn-primary'>VERIFY</button>";
                        }
                        else if (row.RecStatus == 3 && row.IsVerified == false) {
                            if (row.EntryBy == window.userId) {
                                return "<button id='btnDelete' type='button' class='btn btn-danger' disabled>DELETE</button>";
                            }
                            return "<button id='btnDelete' type='button' class='btn btn-danger'>DELETE</button>";
                        } else {
                            return "<button id='btnEdit' type='button' class='btn btn-primary'>EDIT</button> <button id='btnDelete' type='button' class='btn btn-danger'>DELETE</button>";
                        }
                    }
                }



            ]

        });

    }

}
