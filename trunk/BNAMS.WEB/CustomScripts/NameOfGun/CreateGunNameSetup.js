﻿
var CreateGunNameSetupManager = {

    SaveGunNameSetup: function () {
        debugger;
        if ($("#txtGunName").val() == "") {
            toastr.warning("Gun Name is Required.");
        }

        else {
            $.ajax({
                type: "POST",
                url: "/NameOfGun/CreateNameOfGunSetup",
                data: JSON.stringify(GunNameSetupHelper.GetGunNameSetupData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewGunNameSetup.GetGunNameSetupDataTable();
                        GunNameSetupHelper.ClearField();
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
            url: "/NameOfGun/IsDuplicate",

            data: JSON.stringify(GunNameSetupHelper.GetGunNameSetupData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateGunNameSetupManager.SaveGunNameSetup();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var GunNameSetupHelper = {
    InitGunNameSetup: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateGunNameSetupManager.IsDuplicate();
            //GunNameSetupHelper.ClearField();

        });
        $("#btnCancel").unbind("click").click(function () {
            GunNameSetupHelper.ClearField();
        });
    },



    ClearField: function () {
        debugger;
        $("#hdnNameOfGunId").val("");
        $("#txtGunNameCode").val("");
        $("#txtGunName").val("");
        $("#txtShortName").val("");
        $("#createDate").val("");
        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetGunNameSetupData: function () {
        debugger;
        var aObj = new Object();
        aObj.NameOfGunId = $("#hdnNameOfGunId").val();
        aObj.NameOfGunCode = $("#txtGunNameCode").val();
        aObj.NameOfGun = $("#txtGunName").val();
        aObj.ShortName = $("#txtShortName").val();
        aObj.CreateDate = $("#createDate").val();
        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};