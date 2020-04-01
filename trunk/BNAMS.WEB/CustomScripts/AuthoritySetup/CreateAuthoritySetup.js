
var CreateAuthoritySetupSetupManager = {

    SaveAuthoritySetupSetup: function () {
        debugger;
        if ($("#txtAuthorityName").val()=="") {
            toastr.warning("Authority Name is Required.");
        }
        else if ($("#ddlArea").val()=="") {
            toastr.warning("Area is Required.");
        }
       
        else {
            $.ajax({
                type: "POST",
                url: "/AuthoritySetup/CreateAuthority",
                data: JSON.stringify(AuthoritySetupSetupHelper.GetAuthoritySetupSetupData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewAuthoritySetupSetup.GetAuthoritySetupSetupDataTable();
                        AuthoritySetupSetupHelper.ClearField();
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
            url: "/AuthoritySetup/IsDuplicate",

            data: JSON.stringify(AuthoritySetupSetupHelper.GetAuthoritySetupSetupData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateAuthoritySetupSetupManager.SaveAuthoritySetupSetup();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var AuthoritySetupSetupHelper = {
    InitAuthoritySetupSetup: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateAuthoritySetupSetupManager.IsDuplicate();

        });
        $("#btnCancel").unbind("click").click(function () {
            AuthoritySetupSetupHelper.ClearField();
        });
    },

    LoadArea: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/AuthoritySetup/LoadAllArea",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadAreaDD: function () {
        debugger;
        var parentMenu = AuthoritySetupSetupHelper.LoadArea();
        $("#ddlArea").select2({
            placeholder: "Select Area",
            data: parentMenu
        });
    },

    ClearField: function () {
        debugger;
        $("#hdnAuthorityId").val("");
        $("#txtAuthorityCode").val("");
        $("#txtAuthorityName").val("");
        $("#ddlArea").val("").trigger("change");
        $("#txtAuthorityContract").val("");
        $("#txtAuthorityEmail").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetAuthoritySetupSetupData: function () {
        debugger;
        var aObj = new Object();
        aObj.AuthorityId = $("#hdnAuthorityId").val();
        aObj.AuthorityCode = $("#txtAuthorityCode").val();
        aObj.AuthorityName = $("#txtAuthorityName").val();
        aObj.AreaId = $("#ddlArea").val();
        aObj.Contract = $("#txtAuthorityContract").val();
        aObj.Email = $("#txtAuthorityEmail").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};