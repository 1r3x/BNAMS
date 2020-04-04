
var CreateShipDepotSetupManager = {

    SaveShipDepotSetup: function () {
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
                url: "/ShipDepot/CreateShipDepot",
                data: JSON.stringify(ShipDepotSetupHelper.GetShipDepotSetupData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewShipDepotSetup.GetShipDepotSetupDataTable();
                        ShipDepotSetupHelper.ClearField();
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
            url: "/ShipDepot/IsDuplicate",

            data: JSON.stringify(ShipDepotSetupHelper.GetShipDepotSetupData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateShipDepotSetupManager.SaveShipDepotSetup();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var ShipDepotSetupHelper = {
    InitShipDepotSetup: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateShipDepotSetupManager.IsDuplicate();

        });
        $("#btnCancel").unbind("click").click(function () {
            ShipDepotSetupHelper.ClearField();
        });
    },

    LoadCountry: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/ShipDepot/LoadCountry",
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
        var parentMenu = ShipDepotSetupHelper.LoadCountry();
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


    GetShipDepotSetupData: function () {
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