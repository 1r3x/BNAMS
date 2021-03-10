var viewIndent = {

    GetIndentDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/IndentHistory/GetAllIndentHistory",
                data: {
                    "weaponType": $("#ddlItemType").val(),
                    "weaponName": $("#ddlItemName").val(),
                    "weaponModel": $("#ddlItemModel").val()
                },
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "IndentNo", "autoWidth": true },
                { "data": "indentFrom", "autoWidth": true },
                { "data": "issueTo", "autoWidth": true },
                { "data": "NameOfGun", "autoWidth": true },
                { "data": "CompositeName", "autoWidth": true },
                {
                    "data": "IndentValidity",
                    "type": "date",
                    "render": function (value) {
                        if (value === null) return "";

                        var pattern = /Date\(([^)]+)\)/;
                        var results = pattern.exec(value);
                        var dt = new Date(parseFloat(results[1]));

                        return dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear();
                    }
                },
                { "data": "RegistrationNo", "autoWidth": true },
                { "data": "GunModelName", "autoWidth": true },
                { "data": "IndentQuantity", "autoWidth": true },
                { "data": "ShipDepotName", "autoWidth": true },
                { "data": "WareHouseName", "autoWidth": true },
                { "data": "OperatingTemp", "autoWidth": true },
                { "data": "UnitPrice", "autoWidth": true },
                { "data": "IsActive", "autoWidth": true },
                //{ "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],

            "columnDefs": [
                {
                    targets: [13],
                    render: function (data, type, row) {
                        return data == "1" ? "Active" : "Inactive";
                    }
                }
            ]

        });

    }

}
