
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
                        UserHelper.ClearField();

                        $("#btnSubmit").html("Save");
                    }
                },
                error: function (response) {

                },
                dataType: "json",
                contentType: "application/json"
            });

            if (window.FormData !== undefined) {
                debugger;
                var fileUpload = $("#getFile").get(0);
                var files = fileUpload.files;

                // Create FormData object  
                var fileData = new FormData();

                // Looping over all files and add it to FormData object  
                for (var i = 0; i < files.length; i++) {
                    fileData.append(files[i].name, files[i]);
                }

                $.ajax({
                    url: "/User/UploadFiles",
                    type: "POST",
                    contentType: false, // Not to set any content header  
                    processData: false, // Not to process data  
                    data: fileData,
                    success: function (result) {
                        toastr.success(result);
                    },
                    error: function (err) {
                        toastr.warning(err.statusText);
                    }
                });
            } else {
                toastr.warning("File is not supported.");
            }

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
        UserHelper.LoadDirectorateDD();
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


    LoadDirectorate: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/User/LoadDirectorateInfo",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadDirectorateDD: function () {
        debugger;
        var parentUser = UserHelper.LoadDirectorate();
        $("#ddlDirectorate").select2({
            placeholder: "Under Directorate",
            data: parentUser
        });
    },


    ClearField: function () {
        //for image
        var input = $("#getFile");

        input.replaceWith(input.val("").clone(true));
        $("#blah").attr("src", "http://placehold.it/180");


        $("#hdnEmployeeId").val("");
        $("#hdnPasswordBearer").val("");
        $("#txtFirstName").val("");
        $("#txtLastName").val("");
        $("#txtEmpIdNumber").val("");
        $("#txtEmployeeEmail").val("");
        $("#txtEmployeePhone").val("");
        $("#txtEmployeeUserName").val("");
        $("#ddlUserRole").val("").trigger("change");
        $("#ddlDirectorate").val("").trigger("change");


        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },

    GetUserData: function () {
        debugger;
        var aObj = new Object();
        //for image
        if (document.getElementById("getFile").files[0] != undefined) {
            aObj.EmpImage = document.getElementById("getFile").files[0].type.toString().replace(/application/i, "");
        } else {
            aObj.EmpImage = $("#blah").attr("src");
        }



        aObj.Id = $("#hdnEmployeeId").val();
        aObj.Password = $("#hdnPasswordBearer").val();
        aObj.SetUpBy=$("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();



        aObj.FirstName = $("#txtFirstName").val();
        aObj.LastName = $("#txtLastName").val();
        aObj.EmpIdNumber = $("#txtEmpIdNumber").val();
        aObj.Email = $("#txtEmployeeEmail").val();
        aObj.PhoneNo = $("#txtEmployeePhone").val();
        aObj.UserName = $("#txtEmployeeUserName").val();
        aObj.UserRole = $("#ddlUserRole").val();
        aObj.DirectorateId = $("#ddlDirectorate").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") === true) ? 1 : 0;
        return aObj;
    }
};