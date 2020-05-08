
var CreateInspactionManager = {

    SaveInspaction: function () {
        debugger;
        if ($("#txtBinLocationName").val() == "") {
            toastr.warning("Ware House Name is Required.");
        } else {
            $.ajax({
                type: "POST",
                url: "/Inspaction/CreateInspection",
                data: JSON.stringify(InspactionHelper.GetInspactionData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewInspaction.GetInspactionDataTable();
                        InspactionHelper.ClearField();
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


var InspactionHelper = {
    InitInspaction: function () {
        InspactionHelper.LoadDepotDD();
        InspactionHelper.LoadItemCategoryDD();


        $("#btnSubmit").unbind("click").click(function () {
            CreateInspactionManager.SaveInspaction();

        });
        $("#btnCancel").unbind("click").click(function () {
            InspactionHelper.ClearField();

        });
    },

    LoadDepot: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Inspaction/LoadDepot",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadDepotDD: function () {
        debugger;
        var parentMenu = InspactionHelper.LoadDepot();
        $("#ddlDepot").select2({
            placeholder: "Select Depot",
            data: parentMenu
        });
    },

    LoadItemCategory: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Inspaction/LoadItemType",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadItemCategoryDD: function () {
        debugger;
        var parentMenu = InspactionHelper.LoadItemCategory();
        $("#ddlItemCategory").select2({
            placeholder: "Select Item Category",
            data: parentMenu
        });
    },

    LoadRegistrationNo: function () {
        debugger;

        var itemTypeId = $("#ddlItemCategory").val();
        var depotId = $("#ddlDepot").val();
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Inspaction/LoadRegistrationNo",
            data: { itemTypeId: itemTypeId, depotId: depotId },
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadRegistrationNoDD: function () {
        $("#ddlRegistration").empty();
        $("#ddlRegistration").append(
            $("<option></option>")
        );
        var parentMenu = InspactionHelper.LoadRegistrationNo();
        $("#ddlRegistration").select2({
            placeholder: "Select Lot/Registration No.",
            data: parentMenu
        });
        $("#ddlRegistration").select2("val", "");
    },

    LoadMaintainceDetailsByregistrationNo: function () {
        debugger;
        var itemId = $("#ddlRegistration").val();
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Inspaction/LoadWeaponDetails",
            data: { itemId: itemId },
            success: function (response) {
                debugger;
                if (response.data.length != 0) {
                    $("#txtSupplierInfo")
                        .val(response.data[0].SupplierName);
                    $("#txtItemName")
                        .val(response.data[0].NameOfGun);
                    $("#txtWarrantyDate")
                        .val(response.data[0].WarrantyPeriod);


                } else {
                    $("#txtSupplierInfo")
                        .val("No Information Found.");
                }


            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadLastMaintainceDate: function () {
        debugger;
        var itemId = $("#ddlRegistration").val();
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Inspaction/LoadLastMaintainceDate",
            data: { itemId: itemId },
            success: function (response) {
                debugger;
                if (response.data.length != 0) {

                    var lastMaintainceDate = new Date(parseInt(response.data[0].LastMaintainceDate.substr(6)));
                    var clastMaintainceDate = lastMaintainceDate.getDate() + "." + (lastMaintainceDate.getMonth() + 1) + "." + lastMaintainceDate.getFullYear();

                    $("#txtLastMaintainceDate")
                        .val(clastMaintainceDate);


                } else {
                    $("#txtLastMaintainceDate")
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

        $("#hdnInspactionId").val("");
        $("#txtProgramCode").val("");
        $("#ddlDepot").val("").trigger("change");
        $("#ddlItemCategory").val("").trigger("change");
        $("#ddlRegistration").val("").trigger("change");
        $("#dateOfNextInspection").val("");
        $("#dateOfInstall").val("");
        $("#txtInstallBy").val("");
        $("#txtInstallAt").val("");
        $("#dateOfInspaction").val("");
        $("#txtInspectionMethod").val("");
        $("#txtInspectionBy").val("");
        $("#txtCommence").val("");

        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#btnSubmit").html("Save");
    },


    GetInspactionData: function () {
        debugger;
        var aObj = new Object();

        aObj.InspectionId = $("#hdnInspactionId").val();
        aObj.ProgramId = $("#txtProgramCode").val();
        aObj.DepotId = $("#ddlDepot").val();
        aObj.ItemCategoryId = $("#ddlItemCategory").val();
        aObj.ItemId = $("#ddlRegistration").val();
        aObj.NextInspectionDate = $("#dateOfNextInspection").val();
        aObj.INstallDate = $("#dateOfInstall").val();
        aObj.InstallBy = $("#txtInstallBy").val();
        aObj.InstallAt = $("#txtInstallAt").val();
        aObj.InspectionDate = $("#dateOfInspaction").val();
        aObj.InspectionMethod = $("#txtInspectionMethod").val();
        aObj.InspectionBy = $("#txtInspectionBy").val();
        aObj.Commence = $("#txtCommence").val();

        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();

        return aObj;
    }
};