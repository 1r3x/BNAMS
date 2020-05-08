var viewGunAmmoMaintaince = {

    GetGunAmmoMaintainceDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/GunAmmoMaintaince/GetAllGunAmmoMaintaince",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "MaintainceCode", "autoWidth": true },
                { "data": "NameOfGun", "autoWidth": true },
                { "data": "MaintainceYear", "autoWidth": true },
                {
                    "data": "LastMaintainceDate",
                    "type": "date",
                    "render": function (value) {
                        if (value === null) return "";
                        debugger;
                        var pattern = /Date\(([^)]+)\)/;
                        var results = pattern.exec(value);
                        var dt = new Date(parseFloat(results[1]));

                        return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
                    }
                },
                {
                    "data": "NextMaintainceSchadule",
                    "type": "date",
                    "render": function (value) {
                        if (value === null) return "";
                        debugger;
                        var pattern = /Date\(([^)]+)\)/;
                        var results = pattern.exec(value);
                        var dt = new Date(parseFloat(results[1]));

                        return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
                    }
                },
                { "data": "IsActive", "autoWidth": true }
                //{ "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],
          
            "columnDefs": [
                {
                    targets: [5],
                    render: function (data, type, row) {
                        return data == "1" ? "Active" : "Inactive";
                    }
                }
            ]

        });

    }

}