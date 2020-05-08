
var CreateStatusAfterMaintainceManager = {

    SaveStatusAfterMaintaince: function () {
        debugger;
        if ($("#txtBinLocationName").val() == "") {
            toastr.warning("Ware House Name is Required.");
        } else {
            $.ajax({
                type: "POST",
                url: "/StatusAfterMaintaince/CreateStatusAfterMaintaince",
                data: JSON.stringify(StatusAfterMaintainceHelper.GetStatusAfterMaintainceData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewStatusAfterMaintaince.GetStatusAfterMaintainceDataTable();
                        StatusAfterMaintainceHelper.ClearField();
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


    LoadWareHoueDetailsByWareHouseCode: function () {
        var warehouseCode = $("#txtWarehouseCode").val();
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/BinLocation/LoadWareHouseByCode",
            data: { wareHouseCode: warehouseCode },
            success: function (response) {
                debugger;
                if (response.data.length != 0) {

                    $("#hdnWareHouseId").val(response.data[0].WareHouseId);
                    $("#txtWarehouseName").val(response.data[0].WareHouseName);
                } else {
                    $("#hdnWareHouseId").val("");
                    $("#txtWarehouseName").val("No Warehouse Found");
                }

            },
            error: function (response) {

            }
        });

    }

};


var StatusAfterMaintainceHelper = {
    InitStatusAfterMaintaince: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateStatusAfterMaintainceManager.SaveStatusAfterMaintaince();

        });
        $("#btnCancel").unbind("click").click(function () {
            StatusAfterMaintainceHelper.ClearField();
        });
    },

    LoadRegistartionNumberOfGuns: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/StatusAfterMaintaince/LoadRegistrationNo",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadRegistartionNumberOfGunsDD: function () {
        debugger;
        var parentMenu = StatusAfterMaintainceHelper.LoadRegistartionNumberOfGuns();
        $("#ddlRegistrationNo").select2({
            placeholder: "Select Registration Number",
            data: parentMenu
        });
    },

    LoadMaintainceStatus: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/StatusAfterMaintaince/LoadStatus",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadMaintainceStatusDD: function () {
        debugger;
        var parentMenu = StatusAfterMaintainceHelper.LoadMaintainceStatus();
        $("#ddlMaintainceStatus").select2({
            placeholder: "Select Maintaince Status",
            data: parentMenu
        });
    },

    LoadMaintainceDetailsByregistrationNo: function () {
        debugger;
        var weaponsInfoId = $("#ddlRegistrationNo").val();
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/StatusAfterMaintaince/LoadMaintainceDetailsByRegistrationNo",
            data: { weaponsInfoId: weaponsInfoId },
            success: function (response) {
                debugger;
                if (response.data.length != 0) {
                    $("#txtMaintainceResult")
                        .val(response.data[0].MaintainceDetails + " Defect Information:" + response.data[0].DefectInfo);

                   
                } else {
                    $("#txtMaintainceResult")
                        .val("No Information Found.");
                }
               

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    ClearField: function () {
        $("#hdnStatusAfterMaintainceId").val("0");
        $("#txtMaintainceCode").val("");
        $("#ddlRegistrationNo").val("").trigger("change");
        $("#ddlMaintainceStatus").val("").trigger("change");
        $("#txtRemarks").val("");

        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#btnSubmit").html("Save");
    },


    GetStatusAfterMaintainceData: function () {
        debugger;
        var aObj = new Object();

        aObj.AfterMaintainceStatusId = $("#hdnStatusAfterMaintainceId").val();
        aObj.AfterMaintainceStatusCode = $("#txtMaintainceCode").val();
        aObj.WeaponsInfoId = $("#ddlRegistrationNo").val();
        aObj.MaintainceStatusId = $("#ddlMaintainceStatus").val();
        aObj.Remarks = $("#txtRemarks").val();

        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        
        return aObj;
    }
};