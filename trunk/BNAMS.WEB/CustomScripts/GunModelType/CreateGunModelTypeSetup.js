
var CreateGunModelTypeSetupManager = {

    SaveGunModelTypeSetup: function () {
        debugger;
        if ($("#ddlWeaponsType").val() == "") {
            toastr.warning("Weapon Type is Required.");
        }
        else if ($("#txtGunModelType").val() == "") {
            toastr.warning("Model Type is Required.");
        }

        else {
            $.ajax({
                type: "POST",
                url: "/GunModelType/CreateGunModelTypeSetup",
                data: JSON.stringify(GunModelTypeSetupHelper.GetGunModelTypeSetupData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewGunModelTypeSetup.GetGunModelTypeSetupDataTable();
                        GunModelTypeSetupHelper.ClearField();
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
            url: "/GunModelType/IsDuplicate",

            data: JSON.stringify(GunModelTypeSetupHelper.GetGunModelTypeSetupData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateGunModelTypeSetupManager.SaveGunModelTypeSetup();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var GunModelTypeSetupHelper = {
    InitGunModelTypeSetup: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateGunModelTypeSetupManager.IsDuplicate();
            //GunModelTypeSetupHelper.ClearField();

        });
        $("#btnCancel").unbind("click").click(function () {
            GunModelTypeSetupHelper.ClearField();
        });
    },

    LoadWeaponsType: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/GunModelType/LoadWeaponsType",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadWeaponsTypeDD: function () {
        debugger;
        var parentMenu = GunModelTypeSetupHelper.LoadWeaponsType();
        $("#ddlWeaponsType").select2({
            placeholder: "Select Weapons Type",
            data: parentMenu
        });
    },




    ClearField: function () {
        debugger;
        $("#hdnGunModelTypeId").val("0");
        $("#ddlWeaponsType").val("").trigger("change");
        $("#txtGunModelTypeCode").val("");
        $("#txtGunModelType").val("");
        $("#txtShortName").val("");
        $("#createDate").val("");
        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetGunModelTypeSetupData: function () {
        debugger;
        var aObj = new Object();
        aObj.GunModelId = $("#hdnGunModelTypeId").val();
        aObj.WeaponsTypeId = $("#ddlWeaponsType").val();
        aObj.GunModelCode = $("#txtGunModelTypeCode").val();
        aObj.GunModelName = $("#txtGunModelType").val();
        aObj.ShortName = $("#txtShortName").val();
        aObj.CreateDate = $("#createDate").val();
        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};