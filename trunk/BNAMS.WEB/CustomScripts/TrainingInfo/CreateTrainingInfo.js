
var CreateTrainingInfoManager = {

    SaveTrainingInfo: function () {
        debugger;
        if ($("#txtAuthorityName").val()=="") {
            toastr.warning("Authority Name is Required.");
        }
       
        else {
            $.ajax({
                type: "POST",
                url: "/TrainingInfo/CreateTrainingInfo",
                data: JSON.stringify(TrainingInfoHelper.GetTrainingInfoData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewTrainingInfo.GetTrainingInfoDataTable();
                        TrainingInfoHelper.ClearField();
                        $("#btnSubmit").html("Save");
                    }
                },
                error: function (response) {

                },
                dataType: "json",
                contentType: "application/json"
            });
        }
       
    }

};


var TrainingInfoHelper = {
    InitTrainingInfo: function () {
        TrainingInfoHelper.LoadPnoDD();
        TrainingInfoHelper.LoadCountryDD();
        TrainingInfoHelper.LoadOrganizationDD();
        TrainingInfoHelper.LoadWeaponsTypeDD();

        $("#btnSubmit").unbind("click").click(function () {
            CreateTrainingInfoManager.SaveTrainingInfo();
        });
        $("#btnCancel").unbind("click").click(function () {
            TrainingInfoHelper.ClearField();
        });
    },
    LoadWeaponsType: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/TrainingInfo/LoadEquipment",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadWeaponsTypeDD: function () {
        debugger;
        var parentMenu = TrainingInfoHelper.LoadWeaponsType();
        $("#ddlWeaponType").select2({
            placeholder: "Select Equipment",
            data: parentMenu
        });
    },


    LoadCountry: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/TrainingInfo/LoadCounry",
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
        var parentMenu = TrainingInfoHelper.LoadCountry();
        $("#ddlCountry").select2({
            placeholder: "Select Country",
            data: parentMenu
        });
    },


    LoadPno: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/TrainingInfo/LoadPno",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadPnoDD: function () {
        debugger;
        var parentMenu = TrainingInfoHelper.LoadPno();
        $("#ddlPno").select2({
            placeholder: "Select P.NO/O.NO",
            data: parentMenu
        });
    },


    LoadOrganization: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/TrainingInfo/LoadTraningOrg",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadOrganizationDD: function () {
        debugger;
        var parentMenu = TrainingInfoHelper.LoadOrganization();
        $("#ddlOrganization").select2({
            placeholder: "Select Organization",
            data: parentMenu
        });
    },

    ClearField: function () {
        debugger;
        $("#hdnTrainingInfoId").val("0");
        $("#txtTrainingCode").val("");
        $("#ddlWeaponType").val("").trigger("change");
        $("#txtCourseName").val("");
        $("#txtCourseRefNo").val("");
        $("#ddlPno").val("").trigger("change");
        $("#dateOfStart").val("");
        $("#dateOfEnd").val("");
        $("#ddlCountry").val("").trigger("change");
        $("#ddlOrganization").val("").trigger("change");
        $("#txtLocal").val("");

        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetTrainingInfoData: function () {
        debugger;
        var aObj = new Object();
        aObj.TrainingId = $("#hdnTrainingInfoId").val();
        aObj.TraningCode = $("#txtTrainingCode").val();
        aObj.WeaponTypeId = $("#ddlWeaponType").val();
        aObj.CourseName = $("#txtCourseName").val();
        aObj.RefNo = $("#txtCourseRefNo").val();
        aObj.TraningPersonBioId = $("#ddlPno").val();
        aObj.StartDate = $("#dateOfStart").val();
        aObj.EndDate = $("#dateOfEnd").val();
        aObj.CounryId = $("#ddlCountry").val();
        aObj.OrganizationId = $("#ddlOrganization").val();
        aObj.LocalAbroadStatus = $("#txtLocal").val();

        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};