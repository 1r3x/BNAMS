
var CreateTraineePersonBioSetupManager = {

    SaveTraineePersonBioSetup: function () {
        debugger;
        if ($("#txtAuthorityName").val()=="") {
            toastr.warning("Authority Name is Required.");
        }
       
        else {
            $.ajax({
                type: "POST",
                url: "/TraineePersonBioSetup/CreateTraineeBio",
                data: JSON.stringify(TraineePersonBioSetupHelper.GetTraineePersonBioSetupData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewTraineePersonBioSetup.GetTraineePersonBioSetupDataTable();
                        TraineePersonBioSetupHelper.ClearField();
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
            url: "/TraineePersonBioSetup/IsDuplicate",

            data: JSON.stringify(TraineePersonBioSetupHelper.GetTraineePersonBioSetupData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateTraineePersonBioSetupManager.SaveTraineePersonBioSetup();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var TraineePersonBioSetupHelper = {
    InitTraineePersonBioSetup: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateTraineePersonBioSetupManager.IsDuplicate();

        });
        $("#btnCancel").unbind("click").click(function () {
            TraineePersonBioSetupHelper.ClearField();
        });
    },

    LoadRank: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/TraineePersonBioSetup/LoadRank",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadRankDD: function () {
        debugger;
        var parentMenu = TraineePersonBioSetupHelper.LoadRank();
        $("#ddlRank").select2({
            placeholder: "Select Rank",
            data: parentMenu
        });
    },

    ClearField: function () {
        debugger;
        $("#hdnTraineePersonBioId").val("0");
        $("#txtBioDataCode").val("");
        $("#txtPNo").val("");
        $("#ddlRank").val("").trigger("change");
        $("#txtName").val("");
        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");


        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetTraineePersonBioSetupData: function () {
        debugger;
        var aObj = new Object();
        aObj.TraningPersonId = $("#hdnTraineePersonBioId").val();
        aObj.BioDataCode = $("#txtBioDataCode").val();
        aObj.Pno = $("#txtPNo").val();
        aObj.RankId = $("#ddlRank").val();
        aObj.Name = $("#txtName").val();
        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};