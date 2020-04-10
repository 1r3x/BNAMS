var viewBinLocationSetup = {

    GetBinLocationSetupDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/BinLocation/GetAllBinLocation",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "WareHouseName", "autoWidth": true },
                { "data": "SelfIdNo", "autoWidth": true },
                { "data": "RowIdNo", "autoWidth": true },
                { "data": "ProductCtegoryName", "autoWidth": true },

                { "data": "IsActive", "autoWidth": true },
                { "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],

            "columnDefs": [
                {
                    targets: [4],
                    render: function (data, type, row) {
                        return data == "1" ? "Active" : "Inactive";
                    }
                }
            ]

        });

    }

}
var viewBinLocationSetupHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#txtWarehouseCode").val(aObj.WareHouseCode);
        $("#txtWarehouseName").val(aObj.WareHouseName);

        $("#hdnBinLocationId").val(aObj.BinLocationId);
        $("#txtProgramName   ").val(aObj.ProgramName);
        $("#hdnWareHouseId").val(aObj.WareHouseId);
        $("#txtSehlfId").val(aObj.SelfIdNo);
        $("#txtRowId").val(aObj.RowIdNo);
        $("#ddlProductCategory").val(aObj.ProductCategoryId).trigger("change");

        if (aObj.ProcessDate != null) {
            var processDateTime = new Date(parseInt(aObj.ProcessDate.substr(6)));
            var cProcessDateTime = processDateTime.getDate() + "." + (processDateTime.getMonth() + 1) + "." + processDateTime.getFullYear();
            $("#dateProcess").val(cProcessDateTime);

        }

        $("#hdnSetupBy").val(aObj.SetUpBy);
        if (aObj.SetUpDateTime != null) {
            var setUpDateTime = new Date(parseInt(aObj.SetUpDateTime.substr(6)));
            var cSetUpDateTime = setUpDateTime.getDate() + "." + (setUpDateTime.getMonth() + 1) + "." + setUpDateTime.getFullYear();
            $("#hdnSetupDateTime").val(cSetUpDateTime);

        }
        if (aObj.IsActive == 1) {
            $("#chkIsActive").prop("checked", "checked");
        } else {
            $("#chkIsActive").removeProp("checked", "checked");
        }


    }
}