
var CreateCapabilityOfWeaponsSetupManager = {

    SaveCapabilityOfWeaponsSetup: function () {
        debugger;
        if ($("#txtCapabilityName").val()=="") {
            toastr.warning("Capability Name is Required.");
        }
       
        else {
            $.ajax({
                type: "POST",
                url: "/CapabilityOfWeapons/CreateCapabilityOfWeapons",
                data: JSON.stringify(CapabilityOfWeaponsSetupHelper.GetCapabilityOfWeaponsSetupData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewCapabilityOfWeaponsSetup.GetCapabilityOfWeaponsSetupDataTable();
                        CapabilityOfWeaponsSetupHelper.ClearField();
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
            url: "/CapabilityOfWeapons/IsDuplicate",

            data: JSON.stringify(CapabilityOfWeaponsSetupHelper.GetCapabilityOfWeaponsSetupData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateCapabilityOfWeaponsSetupManager.SaveCapabilityOfWeaponsSetup();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var CapabilityOfWeaponsSetupHelper = {
    InitCapabilityOfWeaponsSetup: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateCapabilityOfWeaponsSetupManager.IsDuplicate();
            //CapabilityOfWeaponsSetupHelper.ClearField();

        });
        $("#btnCancel").unbind("click").click(function () {
            CapabilityOfWeaponsSetupHelper.ClearField();
        });
    },



    ClearField: function () {
        debugger;
        $("#hdnCapabilityId").val("0");
        $("#txtCapabilityCode").val("");
        $("#txtCapabilityName").val("");
        $("#txtTelephone").val("");
        $("#txtEmail").val("");
        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetCapabilityOfWeaponsSetupData: function () {
        debugger;
        var aObj = new Object();
        aObj.CapabilityOfWeaponsID = $("#hdnCapabilityId").val();
        aObj.CapabilityCode = $("#txtCapabilityCode").val();
        aObj.CapabilityName = $("#txtCapabilityName").val();
        aObj.Telephone = $("#txtTelephone").val();
        aObj.Email = $("#txtEmail").val();
        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};