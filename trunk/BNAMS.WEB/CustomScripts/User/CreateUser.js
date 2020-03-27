
var CreateUserManager = {


    SaveUser: function () {
        debugger;
        if ($("#txtEmployeeUserName").val() == "") {
            toastr.warning("Employee User Name is Required.");
        }
        //else if ($("#txtMenuClass").val()=="") {
        //    toastr.warning("Menu class is Required.");
        //}
        else {
            $.ajax({
                type: "POST",
                url: "/User/CreateUser",
                data: JSON.stringify(UserHelper.GetUserData()),

                success: function (response) {

                    if (response != null) {
                            toastr.success(response.data.Message);
                            viewUser.GetUserDataTable();
                            MenuHelper.ClearField();

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
        debugger;
        $.ajax({
            type: "POST",
            url: "/User/CheckDuplicate",

            data: JSON.stringify(UserHelper.GetUserData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateUserManager.SaveUser();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    },


};


var UserHelper = {
    InitUser: function () {
        UserHelper.LoadAllRoleDD();
        $("#btnSubmit").unbind("click").click(function () {
            CreateUserManager.IsDuplicate();
            //UserHelper.ClearField();
        });
        $("#btnCancel").unbind("click").click(function () {
            UserHelper.ClearField();
        });
    },

    LoadMasterUser: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/User/LoadAllRole",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadAllRoleDD: function () {
        debugger;
        var parentUser = UserHelper.LoadMasterUser();
        $("#ddlUserRole").select2({
            placeholder: "Select Master",
            data: parentUser
        });
    },
    
    ClearField: function () {
        $("#hdnEmployeeId").val("");
        $("#txtFirstName").val("");
        $("#txtLastName").val("");
        $("#txtEmpIdNumber").val("");
        $("#txtEmployeeEmail").val("");
        $("#txtEmployeePhone").val("");
        $("#txtEmployeeUserName").val("");
        $("#ddlUserRole").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },
    
    GetUserData: function () {
        debugger;
        var aObj = new Object();
        aObj.EmpId = $("#hdnEmployeeId").val();
        aObj.EmpFName = $("#txtFirstName").val();
        aObj.EmpLastName = $("#txtLastName").val();
        aObj.EmpIdNumber = $("#txtEmpIdNumber").val();
        aObj.EmpEmail = $("#txtEmployeeEmail").val();
        aObj.EmpCell = $("#txtEmployeePhone").val();
        aObj.EmpUserName = $("#txtEmployeeUserName").val();
        aObj.RoleId = $("#ddlUserRole").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") === true) ? 1 : 0;
        return aObj;
    }
};