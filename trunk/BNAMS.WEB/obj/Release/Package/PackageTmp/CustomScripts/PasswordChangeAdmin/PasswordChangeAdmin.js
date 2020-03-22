$(document).ready(function () {
    PasswordChangeAdminHelper.InitPasswordChangeAdmin();

    $("#txtUserId").on("change", function (e) {
        
        CreatePasswordChangeAdminManager.GetCredential();


    });
});


var CreatePasswordChangeAdminManager = {

    ChangePassword: function () {
        if ($("#txtVerifyNewPassword").val() == "") {

        } else {
            $.ajax({
                type: "POST",
                url: "/PasswordChangeAdmin/ChangePassword",
                data: JSON.stringify(PasswordChangeAdminHelper.GetPasswordChangeAdminData()),

                success: function (response) {
                    debugger;
                    //window.location.href = "/UserLogins/Logout";
                    if (response != null) {

                        if (response.data.status) {
                            alert(response.data);

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
        var empIdNumber = $("#txtUserId").val();
        $.ajax({
            type: "GET",
            url: "/PasswordChangeAdmin/GetUserNameAndId",
            data: { empIdNumber:empIdNumber},

            success: function (response) {
                debugger;
                if (response.data[0] != null) {
                    $("#hdnEmpId").val(response.data[0].EmpId);
                    $("#txtUserName").val(response.data[0].EmpFName + " " + response.data[0].EmpLastName);
                } else {
                    $("#txtUserName").val("No Data");
                }
            },
            error: function (response) {


            },
            dataType: "json",
            contentType: "application/json"
        });
    }


};
var PasswordChangeAdminHelper = {
    InitPasswordChangeAdmin: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreatePasswordChangeAdminManager.ChangePassword();
        });

        $("#btnCancel").unbind("click").click(function () {

        });
    },
    GetPasswordChangeAdminData: function () {
        var aObj = new Object();
        aObj.EmpId = $("#hdnEmpId").val();
        aObj.Password = $("#txtVerifyNewPassword").val();
        return aObj;
    }

};