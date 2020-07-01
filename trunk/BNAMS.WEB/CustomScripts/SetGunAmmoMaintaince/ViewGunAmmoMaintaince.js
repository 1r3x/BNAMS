var viewGunAmmoMaintaince = {

    GetGunAmmoMaintainceDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/SetGunAmmoMaintaince/GetAllGunAmmoMaintaince",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "RegistrationNo", "autoWidth": true },
                { "data": "IsActive", "autoWidth": true }
               
                //{ "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],
          
            "columnDefs": [
                {
                    targets: [1],
                    render: function (data, type, row) {
                        return data == "1" ? "Active" : "Inactive";
                    }
                }
            ]

        });

    }

}