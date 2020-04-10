
var CreateWareHouseSetupManager = {

    SaveWareHouseSetup: function () {
        debugger;
        if ($("#txtWarehouseName").val()=="") {
            toastr.warning("Ware House Name is Required.");
        }
       
        else {
            $.ajax({
                type: "POST",
                url: "/WarHouseInfo/CreateWareHouse",
                data: JSON.stringify(WareHouseSetupHelper.GetWareHouseSetupData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewWareHouseSetup.GetWareHouseSetupDataTable();
                        WareHouseSetupHelper.ClearField();
                        $("#btnSubmit").html("Save");
                    }
                },
                error: function (response) {

                },
                dataType: "json",
                contentType: "application/json"
            });
        }
       
    },

    IsDuplicate: function () {
        $.ajax({
            type: "POST",
            url: "/WarHouseInfo/IsDuplicate",

            data: JSON.stringify(WareHouseSetupHelper.GetWareHouseSetupData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateWareHouseSetupManager.SaveWareHouseSetup();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var WareHouseSetupHelper = {
    InitWareHouseSetup: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateWareHouseSetupManager.IsDuplicate();

        });
        $("#btnCancel").unbind("click").click(function () {
            WareHouseSetupHelper.ClearField();
        });
    },

    LoadWareHouseType: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WarHouseInfo/LoadWareHouseType",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadWareHouseTypeDD: function () {
        debugger;
        var parentMenu = WareHouseSetupHelper.LoadWareHouseType();
        $("#ddlWaraHousType").select2({
            placeholder: "Select WareHouse Type",
            data: parentMenu
        });
    },



    LoadShipDepot: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "WarHouseInfo/LoadUnitDepotShip",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadShipDepotDD: function () {
        debugger;
        var parentMenu = WareHouseSetupHelper.LoadShipDepot();
        $("#ddlShipDepot").select2({
            placeholder: "Select Unit/Ship/Depot",
            data: parentMenu
        });
    },


    ClearField: function () {
        debugger;
        $("#hdnWareHouseId").val("");
        $("#txtProgramName   ").val("");
        $("#dateProcess").val("");
        $("#ddlWaraHousType").val("").trigger("change");
        $("#txtWareHouseCode").val("");
        $("#txtWarehouseName").val("");
        $("#txtAddress1").val("");
        $("#txtAdress2").val("");
        $("#ddlShipDepot").val("").trigger("change");

        $("#hdnSetupBy").val();
        $("#hdnSetupDateTime").val();
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetWareHouseSetupData: function () {
        debugger;
        var aObj = new Object();
        aObj.WareHouseId = $("#hdnWareHouseId").val();
        aObj.ProgramName = $("#txtProgramName   ").val();
        aObj.ProcessDate = $("#dateProcess").val();
        aObj.WareHouseTypeId = $("#ddlWaraHousType").val();
        aObj.WareHouseCode = $("#txtWareHouseCode").val();
        aObj.WareHouseName = $("#txtWarehouseName").val();
        aObj.Address1 = $("#txtAddress1").val();
        aObj.Address2 = $("#txtAdress2").val();
        aObj.UnitShipId = $("#ddlShipDepot").val();
       
        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();

        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};