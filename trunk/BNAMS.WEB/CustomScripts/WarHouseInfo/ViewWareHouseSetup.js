var viewWareHouseSetup = {

    GetWareHouseSetupDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/WarHouseInfo/GetAllWareHouse",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "WareHouseCode", "autoWidth": true },
                { "data": "WarHouseType", "autoWidth": true },
                { "data": "WareHouseName", "autoWidth": true },
                { "data": "ShipDepotName", "autoWidth": true },


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
var viewWareHouseSetupHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#hdnWareHouseId").val(aObj.WareHouseId);
        $("#txtProgramName   ").val(aObj.ProgramName);
        if (aObj.ProcessDate != null) {
            var processDateTime = new Date(parseInt(aObj.ProcessDate.substr(6)));
            var cProcessDateTime = processDateTime.getDate() + "." + (processDateTime.getMonth() + 1) + "." + processDateTime.getFullYear();
            $("#dateProcess").val(cProcessDateTime);

        }
        $("#ddlWaraHousType").val(aObj.WareHouseTypeId).trigger("change");
        $("#txtWareHouseCode").val(aObj.WareHouseCode);
        $("#txtWarehouseName").val(aObj.WareHouseName);
        $("#txtAddress1").val(aObj.Address1);
        $("#txtAdress2").val(aObj.Address2);
        $("#ddlShipDepot").val(aObj.UnitShipId).trigger("change");



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