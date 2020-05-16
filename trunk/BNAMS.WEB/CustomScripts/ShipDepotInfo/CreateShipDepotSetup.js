
var CreateShipDepotSetupManager = {

    SaveShipDepotSetup: function () {
        debugger;
        if ($("#txtShipDepotName").val()=="") {
            toastr.warning("Ship/Depot Name is Required.");
        }
        else if ($("#ddlAdmin").val() == "") {
            toastr.warning("Derectorate Name is Required.");
        }
        else if ($("#ddlCategory").val() == "") {
            toastr.warning("Category is Required.");
        }
        else if ($("#dateOfCommission").val() == "") {
            toastr.warning("Date of commison is Required.");
        }
       
        else {
            $.ajax({
                type: "POST",
                url: "/ShipDepotInfo/CreateShipOrDepotSetup",
                data: JSON.stringify(ShipDepotSetupHelper.GetShipDepotSetupData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewShipDepotSetup.GetShipDepotSetupDataTable();
                        ShipDepotSetupHelper.ClearField();
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
            url: "/ShipDepotInfo/IsDuplicate",

            data: JSON.stringify(ShipDepotSetupHelper.GetShipDepotSetupData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateShipDepotSetupManager.SaveShipDepotSetup();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var ShipDepotSetupHelper = {
    InitShipDepotSetup: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateShipDepotSetupManager.IsDuplicate();

        });
        $("#btnCancel").unbind("click").click(function () {
            ShipDepotSetupHelper.ClearField();
        });
    },

    LoadAdmin: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/ShipDepotInfo/LoadAdminAuth",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadAdminDD: function () {
        debugger;
        var parentMenu = ShipDepotSetupHelper.LoadAdmin();
        $("#ddlAdmin").select2({
            placeholder: "Select Derectorate",
            data: parentMenu
        });
    },
    LoadCapOfWeapons: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/ShipDepotInfo/LoadCapbilityOfWeapons",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadCapOfWeaponsDD: function () {
        debugger;
        var parentMenu = ShipDepotSetupHelper.LoadCapOfWeapons();
        $("#ddlCapabilityOfWeapons").select2({
            placeholder: "Select Cap. Of Weapons",
            data: parentMenu
        });
    },

    LoadCategory: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/ShipDepotInfo/LoadShipOrdepotCategory",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadCategoryDD: function () {
        debugger;
        var parentMenu = ShipDepotSetupHelper.LoadCategory();
        $("#ddlCategory").select2({
            placeholder: "Select Category",
            data: parentMenu
        });
    },

    LoadType: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/ShipDepotInfo/LoadShipOrdepoType",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadTypeDD: function () {
        debugger;
        var parentMenu = ShipDepotSetupHelper.LoadType();
        $("#ddlTypeOfShip").select2({
            placeholder: "Select Type",
            data: parentMenu
        });
    },


    ClearField: function () {
        debugger;
        $("#hdnShipDepotId").val("");
        $("#txtShipDepotCode").val("");
        $("#ddlAdmin").val("").trigger("change");
        $("#ddlCategory").val("").trigger("change");
        $("#txtShipDepotName").val("");
        $("#dateOfCommission").val("");
        $("#txtWTCallSign").val("");
        $("#ddlCapabilityOfWeapons").val("").trigger("change");
        $("#ddlTypeOfShip").val("").trigger("change");
        $("#txtTelephone ").val("");
        $("#txtEmail").val("");
        $("#txtFaxNo").val("");
        $("#txtWebAddress").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetShipDepotSetupData: function () {
        debugger;
        var aObj = new Object();
        aObj.ShipOrDepotId = $("#hdnShipDepotId").val();
        aObj.ShipOrDepotCode = $("#txtShipDepotCode").val();
        aObj.DirectorateId = $("#ddlAdmin").val();
        aObj.ShipDepotCategory = $("#ddlCategory").val();
        aObj.ShipDepotName = $("#txtShipDepotName").val();
        aObj.DateOfCommmisson = $("#dateOfCommission").val();
        aObj.WTCallSign = $("#txtWTCallSign").val();
        aObj.CapabilityOfWeaponsId = $("#ddlCapabilityOfWeapons").val();
        aObj.TypeOfShip = $("#ddlTypeOfShip").val();
        aObj.Telephone = $("#txtTelephone ").val();
        aObj.Email = $("#txtEmail").val();
        aObj.FaxNo = $("#txtFaxNo").val();
        aObj.WebAddress = $("#txtWebAddress").val();


        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();

        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};