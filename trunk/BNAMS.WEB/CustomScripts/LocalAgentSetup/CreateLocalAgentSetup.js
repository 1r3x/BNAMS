
var CreateLocalAgentSetupSetupManager = {

    SaveLocalAgentSetupSetup: function () {
        debugger;
        if ($("#txtLocalAgentName").val()=="") {
            toastr.warning("LocalAgent Name is Required.");
        }
        else if ($("#ddlArea").val()=="") {
            toastr.warning("Area is Required.");
        }
       
        else {
            $.ajax({
                type: "POST",
                url: "/LocalAgentSetup/CreateLocalAgentSetup",
                data: JSON.stringify(LocalAgentSetupSetupHelper.GetLocalAgentSetupSetupData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewLocalAgentSetupSetup.GetLocalAgentSetupSetupDataTable();
                        LocalAgentSetupSetupHelper.ClearField();
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
            url: "/LocalAgentSetup/IsDuplicate",

            data: JSON.stringify(LocalAgentSetupSetupHelper.GetLocalAgentSetupSetupData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateLocalAgentSetupSetupManager.SaveLocalAgentSetupSetup();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var LocalAgentSetupSetupHelper = {
    InitLocalAgentSetupSetup: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateLocalAgentSetupSetupManager.IsDuplicate();

        });
        $("#btnCancel").unbind("click").click(function () {
            LocalAgentSetupSetupHelper.ClearField();
        });
    },

    LoadCountry: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/LocalAgentSetup/LoadCountry",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadCountryDD: function () {
        debugger;
        var parentMenu = LocalAgentSetupSetupHelper.LoadCountry();
        $("#ddlCountry").select2({
            placeholder: "Select Country",
            data: parentMenu
        });
    },

    LoadAgentType: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/LocalAgentSetup/LoadAgentType",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadAgentTypeDD: function () {
        debugger;
        var parentMenu = LocalAgentSetupSetupHelper.LoadAgentType();
        $("#ddlAgentType").select2({
            placeholder: "Select Agent Type",
            data: parentMenu
        });
    },

    LoadEnlistment: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/LocalAgentSetup/LoadEstimationTypeType",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadEnlistmentDD: function () {
        debugger;
        var parentMenu = LocalAgentSetupSetupHelper.LoadEnlistment();
        $("#ddlEnlistmentType").select2({
            placeholder: "Select Estimation Type",
            data: parentMenu
        });
    },

    ClearField: function () {
        debugger;
        $("#hdnLocalAgentId").val("");
        $("#txtLocalAgentCode").val("");
        $("#txtSupplierName").val("");
        $("#txtAddress").val("");
        $("#ddlEnlistmentType").val("").trigger("change");
        $("#ddlAgentType").val("").trigger("change");
        $("#txtEmail").val("");
        $("#txtContractNumber").val("");
        $("#ddlCountry").val("").trigger("change");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetLocalAgentSetupSetupData: function () {
        debugger;
        var aObj = new Object();
        aObj.LocalAgentId = $("#hdnLocalAgentId").val();
        aObj.Code = $("#txtLocalAgentCode").val();
        aObj.SupplierName = $("#txtSupplierName").val();
        aObj.Address = $("#txtAddress").val();
        aObj.EnlistmintType = $("#ddlEnlistmentType").val();
        aObj.AgentTypeId = $("#ddlAgentType").val();
        aObj.Email = $("#txtEmail").val();
        aObj.ContractNumber = $("#txtContractNumber").val();
        aObj.Country = $("#ddlCountry").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};