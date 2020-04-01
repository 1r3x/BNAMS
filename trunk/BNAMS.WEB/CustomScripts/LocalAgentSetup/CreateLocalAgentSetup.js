
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

    LoadEnlistmentDD: function () {
        $("#ddlEnlistmentType").select2({
            placeholder: "Select Enlistment Type",
        });
    },

    ClearField: function () {
        debugger;
        $("#hdnLocalAgentId").val();
        $("#txtLocalAgentCode").val();
        $("#txtSupplierName").val();
        $("#txtAddress").val();
        $("#ddlEnlistmentType").val();
        $("#txtEmail").val();
        $("#txtContractNumber").val();
        $("#ddlCountry").val();
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
        aObj.Email = $("#txtEmail").val();
        aObj.ContractNumber = $("#txtContractNumber").val();
        aObj.Country = $("#ddlCountry").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};