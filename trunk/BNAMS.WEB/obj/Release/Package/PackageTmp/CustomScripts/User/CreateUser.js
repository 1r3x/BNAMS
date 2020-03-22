
var CreateUserManager = {

    SaveUser: function () {
        debugger;
        $.ajax({
            type: "POST",
            url: "/User/CreateUser",
            data: JSON.stringify(UserHelper.GetUserData()),

            success: function (response) {

                if (response != null) {
                    $("#myModal #modal-body #headerId").html(response.data.message);

                    $("#myModal").appendTo("body").modal("show");

                    //todo get data table refreshed..

                    setTimeout(function () {
                        $("#myModal").modal("hide");
                    }, 2000);

                    if (response.data.status) {
                        //todo clear form..

                        $("#btnSubmit").html("Save");
                    }
                }
            },
            error: function (response) {
                $("#dialog_simple").html(response.data.Message);
                $("#dialog_simple").dialog("open");
                setTimeout(function () {
                    $("#myModal").modal("hide");
                }, 2000);
            },
            dataType: "json",
            contentType: "application/json"
        });
    }

};


var UserHelper = {
    InitUser: function () {
        UserHelper.LoadAllRoleDD();
        $("#btnSubmit").unbind("click").click(function () {
            CreateUserManager.SaveUser();
            UserHelper.ClearField();
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
        $("#hdnUserId").val("");
        $("#txtUserFullName").val("");
        $("#ddlEmail").val("").trigger("change");
        $("#ddlEmailIsConfirmed").val("");
        $("#txtUserName").val("");
        $("#password").val("");
        $("#ddlUserRole").val("");
        $("#txtPhoneNo").val("");
        $("#getFile").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetUserData: function () {
        var aObj = new Object();
        aObj.Id = $("#hdnUserId").val();
        aObj.UserFullName = $("#txtUserFullName").val();
        aObj.Email = $("#ddlEmail").val();
        aObj.EmailIsConfirmed = $("#ddlEmailIsConfirmed").val();
        aObj.UserName = $("#txtUserName").val();
        aObj.Password = $("#password").val();
        aObj.UserRole = $("#ddlUserRole").val();
        aObj.PhoneNo = $("#txtPhoneNo").val();
        aObj.UserPhoto = $("#getFile").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") === true) ? 1 : 0;
        return aObj;
    }
};