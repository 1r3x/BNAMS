
var CreateRoleSetupManager = {

    SaveRoleSetup: function () {
        debugger;
        if ($("#txtRoleName").val()=="") {
            toastr.warning("Role Name is Required.");
        }
        //else if ($("#txtRoleSetupClass").val()=="") {
        //    toastr.warning("RoleSetup class is Required.");
        //}
        else {
            $.ajax({
                type: "POST",
                url: "/RoleSetup/CreateRole",
                data: JSON.stringify(RoleSetupHelper.GetRoleSetupData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewRoleSetup.GetRoleSetupDataTable();
                        RoleSetupHelper.ClearField();
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
            url: "/RoleSetup/IsDuplicate",

            data: JSON.stringify(RoleSetupHelper.GetRoleSetupData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateRoleSetupManager.SaveRoleSetup();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var RoleSetupHelper = {
    InitRoleSetup: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateRoleSetupManager.IsDuplicate();
            //RoleSetupHelper.ClearField();

        });
        $("#btnCancel").unbind("click").click(function () {
            RoleSetupHelper.ClearField();
        });
    },



    ClearField: function () {
        debugger;
        $("#hdnRoleId").val("");
        $("#txtRoleName").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetRoleSetupData: function () {
        debugger;
        var aObj = new Object();
        aObj.RoleId = $("#hdnRoleId").val();
        aObj.UserRoleName = $("#txtRoleName").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};