
var CreateDirectorateInfoManager = {

    SaveDirectorateInfo: function () {
        debugger;
        if ($("#txtAuthorityName").val() == "") {
            toastr.warning("Directorate Name is Required.");
        }
        else if ($("#ddlArea").val() == "") {
            toastr.warning("Area is Required.");
        }

        else {
            $.ajax({
                type: "POST",
                url: "/DirectorateInfo/CreateDirectorateInfo",
                data: JSON.stringify(DirectorateInfoHelper.GetDirectorateInfoData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewDirectorateInfo.GetDirectorateInfoDataTable();
                        DirectorateInfoHelper.ClearField();
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
                    url: "/DirectorateInfo/UploadFiles",
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
        $.ajax({
            type: "POST",
            url: "/DirectorateInfo/IsDuplicate",

            data: JSON.stringify(DirectorateInfoHelper.GetDirectorateInfoData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateDirectorateInfoManager.SaveDirectorateInfo();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var DirectorateInfoHelper = {
    InitDirectorateInfo: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateDirectorateInfoManager.IsDuplicate();

        });
        $("#btnCancel").unbind("click").click(function () {
            DirectorateInfoHelper.ClearField();
        });
    },

    LoadArea: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/DirectorateInfo/LoadAllArea",
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
        var parentMenu = DirectorateInfoHelper.LoadArea();
        $("#ddlArea").select2({
            placeholder: "Select Area",
            data: parentMenu
        });
    },

    ClearField: function () {
        debugger;
        //for image input
        var input = $("#getFile");

        input.replaceWith(input.val("").clone(true));
        $("#blah").attr("src", "http://placehold.it/180");

        $("#hdnDirectorateId").val("");
        $("#txtOrganizationCode").val("");
        $("#txtAuthorityName").val("");
        $("#txtAddress").val("");
        $("#txtTelephone").val("");
        $("#txtFaxNo").val("");
        $("#txtWebAddress").val("");
        $("#ddlArea").val("").trigger("change");

        $("#chkIsActive").removeAttr("checked", "checked");
        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#btnSubmit").html("Save");
    },


    GetDirectorateInfoData: function () {
        debugger;
        var aObj = new Object();


        if (document.getElementById("getFile").files[0] != undefined) {
            aObj.Logo = document.getElementById("getFile").files[0].type.toString().replace(/application/i, "");
        } else {
            aObj.Logo = document.getElementById("blah").src;    
        }
        
        //
        aObj.DirectorateID = $("#hdnDirectorateId").val();
        aObj.DirectorateCode = $("#txtOrganizationCode").val();
        aObj.DirectorateName = $("#txtAuthorityName").val();
        aObj.Address = $("#txtAddress").val();
        aObj.TelephoneNumber = $("#txtTelephone").val();
        aObj.FaxNumber = $("#txtFaxNo").val();
        aObj.WebAddress = $("#txtWebAddress").val();
        aObj.AreaId = $("#ddlArea").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        return aObj;
    }
};