
var CreateGunModelTypeSetupManager = {

    SaveGunModelTypeSetup: function () {
        debugger;
        if ($("#txtQuantityName").val() == "") {
            toastr.warning("Quantity Name is Required.");
        }

        else {
            $.ajax({
                type: "POST",
                url: "/QuantitySetup/CreateQuantitySetup",
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
            url: "/QuantitySetup/IsDuplicate",

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



    ClearField: function () {
        debugger;
        $("#hdnQuantityId").val("0");
        $("#txtQuantityCode").val("");
        $("#txtQuantityName").val("");
        $("#createDate").val("");
        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetGunModelTypeSetupData: function () {
        debugger;
        var aObj = new Object();
        aObj.QuantityId = $("#hdnQuantityId").val();
        aObj.QuantityCode = $("#txtQuantityCode").val();
        aObj.QuantityName = $("#txtQuantityName").val();
        aObj.CreateDate = $("#createDate").val();
        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};