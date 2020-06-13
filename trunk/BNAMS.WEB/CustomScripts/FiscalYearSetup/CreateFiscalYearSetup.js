
var CreateFiscalYearSetupManager = {

    SaveFiscalYearSetup: function () {
        debugger;
        if ($("#txtFiscalYearName").val()=="") {
            toastr.warning("Fiscal Year Name is Required.");
        }
        else if ($("#txtFiscalYearShortName").val()=="") {
            toastr.warning("Short Name is Required.");
        }
        else if ($("#startDate").val() == "") {
            toastr.warning("Start Date is Required.");
        }
        else if ($("#endDate").val() == "") {
            toastr.warning("End Date is Required.");
        }
        else {
            $.ajax({
                type: "POST",
                url: "/FiscalYearSetup/CreateFiscalYear",
                data: JSON.stringify(FiscalYearSetupHelper.GetFiscalYearSetupData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewFiscalYearSetup.GetFiscalYearSetupDataTable();
                        FiscalYearSetupHelper.ClearField();
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
            url: "/FiscalYearSetup/IsDuplicate",

            data: JSON.stringify(FiscalYearSetupHelper.GetFiscalYearSetupData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateFiscalYearSetupManager.SaveFiscalYearSetup();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var FiscalYearSetupHelper = {
    InitFiscalYearSetup: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateFiscalYearSetupManager.IsDuplicate();
            //FiscalYearSetupHelper.ClearField();

        });
        $("#btnCancel").unbind("click").click(function () {
            FiscalYearSetupHelper.ClearField();
        });
    },



    ClearField: function () {
        debugger;
        $("#FiscalYearId").val("0");
        $("#txtFiscalYearCode").val("");
        $("#txtFiscalYearName").val("");
        $("#txtFiscalYearShortName").val("");
        $("#startDate").val("");
        $("#endDate").val("");
        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetFiscalYearSetupData: function () {
        debugger;
        var aObj = new Object();
        aObj.FiscalYearId = $("#hdnFiscalId").val();
        aObj.FiscalYearCode = $("#txtFiscalYearCode").val();
        aObj.Name = $("#txtFiscalYearName").val();
        aObj.ShortName = $("#txtFiscalYearShortName").val();
        aObj.StartDate = $("#startDate").val();
        aObj.EndDate = $("#endDate").val();
        // for 
        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};