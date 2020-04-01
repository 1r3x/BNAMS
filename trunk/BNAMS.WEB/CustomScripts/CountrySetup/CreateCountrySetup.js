
var CreateCountrySetupManager = {

    SaveCountrySetup: function () {
        debugger;
        if ($("#txtCapabilityName").val() == "") {
            toastr.warning("Capability Name is Required.");
        }

        else {
            $.ajax({
                type: "POST",
                url: "/CountrySetup/CreateCountrySetup",
                data: JSON.stringify(CountrySetupHelper.GetCountrySetupData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewCountrySetup.GetCountrySetupDataTable();
                        CountrySetupHelper.ClearField();
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
            url: "/CountrySetup/IsDuplicate",

            data: JSON.stringify(CountrySetupHelper.GetCountrySetupData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateCountrySetupManager.SaveCountrySetup();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var CountrySetupHelper = {
    InitCountrySetup: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateCountrySetupManager.IsDuplicate();
            //CountrySetupHelper.ClearField();

        });
        $("#btnCancel").unbind("click").click(function () {
            CountrySetupHelper.ClearField();
        });
    },



    ClearField: function () {
        debugger;
        $("#hdnCountryId").val("");
        $("#txtCountryCode").val("");
        $("#txtCountryName").val("");
        $("#txtShortName").val("");
        $("#txtDollerType").val("");
        $("#createDate").val("");
        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetCountrySetupData: function () {
        debugger;
        var aObj = new Object();
        aObj.CountryNameId = $("#hdnCountryId").val();
        aObj.CountryCode = $("#txtCountryCode").val();
        aObj.CountryName = $("#txtCountryName").val();
        aObj.ShortName = $("#txtShortName").val();
        aObj.DollerType = $("#txtDollerType").val();
        aObj.CreateDate = $("#createDate").val();
        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};