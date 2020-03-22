$(document).ready(function () {
    PasswordChangeHelper.InitPasswordChange();

});


var CreatePasswordChangeManager = {

    ChangePassword: function () {
        if ($("#txtVerifyNewPassword").val() == "") {
            
        } else {
            $.ajax({
                type: "POST",
                url: "/PasswordChange/ChangePassword",
                data: JSON.stringify(PasswordChangeHelper.GetPasswordChangeData()),

                success: function (response) {
                    debugger;
                    window.location.href = "/UserLogins/Logout";
                    if (response != null) {
                        
                        alert(response.data);
                        
                        if (response.data.status) {
                            
                            
                        }
                    }
                },
                error: function (response) {


                },
                dataType: "json",
                contentType: "application/json"
            });
        }
        
    },
    GetCredential: function () {
        $.ajax({
            type: "GET",
            url: "/PasswordChange/GetAllCredential",
            data: JSON.stringify(),

            success: function (response) {
                debugger;
                if (response != null) {
                    $("#hdnEmpId").val(response.data[0].EmpId);
                    $("#hdnPassword").val(response.data[0].Password);
                    $("#txtUserName").val(response.data[0].UserName);
                }
            },
            error: function (response) {


            },
            dataType: "json",
            contentType: "application/json"
        });
    }


};
var PasswordChangeHelper = {
    InitPasswordChange: function () {


        CreatePasswordChangeManager.GetCredential();
        $("#btnSubmit").unbind("click").click(function () {
            CreatePasswordChangeManager.ChangePassword();
        });

        $("#btnCancel").unbind("click").click(function () {
            
        });
    },
    GetPasswordChangeData: function () {
        var aObj = new Object();
        aObj.EmpId = $("#hdnEmpId").val();
        aObj.Password = $("#txtVerifyNewPassword").val();
        return aObj;
    }

};