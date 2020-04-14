var viewWeaponsEntry = {

    GetWeaponsEntryDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({
            "scrollX": true,
            "ajax": {
                "url": "/WeaponsEntry/GetAllWeaponsByTypeId",
                data: {
                    "weaponsTypeId": $("#ddlWeaponsType").val()
    },
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "WeaponsType", "autoWidth": true },
                { "data": "NameOfGun", "autoWidth": true },
                { "data": "TrackingNo", "autoWidth": true },
                { "data": "IsActive", "autoWidth": true },
                //{ "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],
            "columnDefs": [
                {
                    targets: [3],
                    render: function (data, type, row) {
                        return data == "1" ? "Active" : "Inactive";
                    }
                }
            ]
        });

    }

}
