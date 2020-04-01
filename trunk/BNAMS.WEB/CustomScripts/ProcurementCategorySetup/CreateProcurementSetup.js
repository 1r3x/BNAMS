
var CreateGunModelTypeSetupManager = {

    SaveGunModelTypeSetup: function () {
        debugger;
        if ($("#txtProcurementName").val() == "") {
            toastr.warning("Procurement Name is Required.");
        }

        else {
            $.ajax({
                type: "POST",
                url: "/ProcurementCategorySetup/CreateProcurementSetup",
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
            url: "/ProcurementCategorySetup/IsDuplicate",

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
        $("#hdnProcurementId").val("");
        $("#txtProcurementCode").val("");
        $("#txtProcurementName").val("");
        $("#createDate").val("");
        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetGunModelTypeSetupData: function () {
        debugger;
        var aObj = new Object();
        aObj.ProcurementId = $("#hdnProcurementId").val();
        aObj.ProcurementCode = $("#txtProcurementCode").val();
        aObj.ProcurementName = $("#txtProcurementName").val();
        aObj.CreateDate = $("#createDate").val();
        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};