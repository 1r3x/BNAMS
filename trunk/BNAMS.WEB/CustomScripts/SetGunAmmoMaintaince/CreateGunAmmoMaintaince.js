
var CreateGunAmmoMaintainceManager = {

    SaveGunAmmoMaintaince: function () {
        debugger;
        if ($("#txtShipDepotName").val() == "") {
            toastr.warning("LocalAgent Name is Required.");
        }

        else {
            $.ajax({
                type: "POST",
                url: "/SetGunAmmoMaintaince/CreateGunAmmoMaintaince",
                data: JSON.stringify(GunAmmoMaintainceHelper.GetGunAmmoMaintainceData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewGunAmmoMaintaince.GetGunAmmoMaintainceDataTable();
                        GunAmmoMaintainceHelper.ClearField();
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


};


var GunAmmoMaintainceHelper = {
    InitGunAmmoMaintaince: function () {
        GunAmmoMaintainceHelper.LoadDepotDD();
        GunAmmoMaintainceHelper.LoadWeaponsTypeDD();
        GunAmmoMaintainceHelper.LoadMaintainceTypeDD();
        GunAmmoMaintainceHelper.LoadYearDD();
        $("#btnSubmit").unbind("click").click(function () {
            CreateGunAmmoMaintainceManager.SaveGunAmmoMaintaince();
        });
        $("#btnCancel").unbind("click").click(function () {
            GunAmmoMaintainceHelper.ClearField();
        });
    },
    LoadWeaponsTypeDD: function () {
        $("#ddlWeaponType").select2({
            placeholder: "Select Weapons Type"
        });
    },
    //load reg no by weapon type
    LoadRegistrationNo: function () {
        debugger;
        //var e = document.getElementById("ddlWeaponType");
        //var weaponType = e.options[e.selectedIndex].value;
        var weaponType = $("#ddlWeaponType").val();
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/SetGunAmmoMaintaince/LoadRegistrationNo",
            data: { weaponType: weaponType },
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
        $("#ddlRegNo").empty();
        $("#ddlRegNo").append(
            $("<option></option>")
        );
        var parentMenu = GunAmmoMaintainceHelper.LoadRegistrationNo();
        $("#ddlRegNo").select2({
            placeholder: "Select Reg No.",
            data: parentMenu
        });
        $("#ddlRegNo").select2("val", "");
    },

    //load weapon details by weapon id
    LoadWeaponsDetails: function () {
        debugger;
        var weaponId = $("#ddlRegNo").val();
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/SetGunAmmoMaintaince/LoadWeaponDetails",
            data: { weaponId: weaponId },
            success: function (response) {
                debugger;
                $("#txtName").val(response.data[0].NameOfGun);
                $("#txtPresentLocation").val(response.data[0].WareHouseName + " Shelf:" + response.data[0].SelfIdNo
                    + " Row:" + response.data[0].RowIdNo);
                $("#txtLastMaintainceDate").val(response.data[0].LastMaintainceDate);
                $("#txtMaintainceYear").val(response.data[0].MaintainceYear);
                $("#txtMaintainceDetails").val(response.data[0].MaintainceDetails);


            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadDepot: function () {
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/SetGunAmmoMaintaince/LoadDepot",
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
        var parentMenu = GunAmmoMaintainceHelper.LoadDepot();
        $("#ddlDepot").select2({
            placeholder: "Select Present Depot",
            data: parentMenu
        });
    },
    //
    LoadWarehouse: function () {
        debugger;
        var depotId = $("#ddlDepot").val();
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/SetGunAmmoMaintaince/LoadWareHouseUnderDepotId",
            data: { depotId: depotId },
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadWarehouseDD: function () {
        $("#ddlWarehouse").empty();
        $("#ddlWarehouse").append(
            $("<option></option>")
        );
        var parentMenu = GunAmmoMaintainceHelper.LoadWarehouse();
        $("#ddlWarehouse").select2({
            placeholder: "Select Warehouse",
            data: parentMenu
        });
        $("#ddlWarehouse").select2("val", "");
    },
    //
    LoadShelf: function () {
        debugger;
        var warehouseId = $("#ddlWarehouse").val();
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/SetGunAmmoMaintaince/LoadShelfUnderWareHouseId",
            data: { warehouseId: warehouseId },
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadShelfDD: function () {
        $("#ddlShelf").empty();
        $("#ddlShelf").append(
            $("<option></option>")
        );
        var parentMenu = GunAmmoMaintainceHelper.LoadShelf();
        $("#ddlShelf").select2({
            placeholder: "Select Shelf No.",
            data: parentMenu
        });
        $("#ddlShelf").select2("val", "");
    },
    //
    LoadRow: function () {
        debugger;
        var warehouseId = $("#ddlWarehouse").val();
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/SetGunAmmoMaintaince/LoadRowUnderWareHouseId",
            data: { warehouseId: warehouseId },
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadRowDD: function () {
        $("#ddlRow").empty();
        $("#ddlRow").append(
            $("<option></option>")
        );
        var parentMenu = GunAmmoMaintainceHelper.LoadRow();
        $("#ddlRow").select2({
            placeholder: "Select Row No.",
            data: parentMenu
        });
        $("#ddlRow").select2("val", "");
    },
    //
    LoadMaintainceType: function () {
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/SetGunAmmoMaintaince/LoadMaintainceType",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadMaintainceTypeDD: function () {
        var parentMenu = GunAmmoMaintainceHelper.LoadMaintainceType();
        $("#ddlType").select2({
            placeholder: "Select Maintaince Type",
            data: parentMenu
        });
    },

    LoadYear: function () {
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/SetGunAmmoMaintaince/GetYearForDropDown",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadYearDD: function () {
        var parentMenu = GunAmmoMaintainceHelper.LoadYear();
        $("#ddlYear").select2({
            placeholder: "Select Year",
            data: parentMenu
        });
    },




    ClearField: function () {
        $("#hdnMaintainceId").val("");
        $("#txtMaintainceCode").val("");
        $("#ddlRegNo").val("").trigger("change");
        $("#dateOfLastMaintaince").val("");
        $("#ddlYear").val("").trigger("change");
        $("#txtMaintenanceDetail").val("");
        $("#txtLocation").val("");
        $("#txtDefectInformation").val("");
        $("#ddlType").val("").trigger("change");
        $("#dateOfNextMaintainceDue ").val("");
        //
        //$("#ddlDepot").val("").trigger("change");;
        //$("#ddlWarehouse").val("").trigger("change");
        $("#ddlShelf").val("").trigger("change");
        //
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetGunAmmoMaintainceData: function () {
        debugger;
        var aObj = new Object();
        //aObj.MaintainceId = $("#hdnMaintainceId").val();
        //aObj.MaintainceCode = $("#txtMaintainceCode").val();
        aObj.WeaponInfoId = $("#ddlRegNo").val();
        //aObj.LastMaintainceDate = $("#dateOfLastMaintaince").val();
        //aObj.MaintainceYear = $("#ddlYear").val();
        //aObj.MaintainceDetails = $("#txtMaintenanceDetail").val();
        //aObj.MaintainceLocation = $("#txtLocation").val();
        //aObj.DefectInfo = $("#txtDefectInformation").val();
        //aObj.MaintainceTypeId = $("#ddlType").val();
        //aObj.NextMaintainceSchadule = $("#dateOfNextMaintainceDue ").val();
        ////
        //aObj.DepotId = $("#ddlDepot").val();
        //aObj.WareHouseId = $("#ddlWarehouse").val();
        //aObj.BinLOcationId = $("#ddlShelf").val();


        //aObj.SetUpBy = $("#hdnSetupBy").val();
        //aObj.SetUpDateTime = $("#hdnSetupDateTime").val();

        //aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};