
var CreateCompositeCodeManager = {

    SaveCompositeCode: function () {
        debugger;
        if ($("#txtCompositeCodeName").val()=="") {
            toastr.warning("Composite Name is Required.");
        }
        else if ($("#txtCompositeCode").val() == "") {
            toastr.warning("Composite Code is Required.");
        }
       
        else {
            $.ajax({
                type: "POST",
                url: "/CompositeCodeMaster/CreateCompositeCodeMasterSetup",
                data: JSON.stringify(CompositeCodeHelper.GetCompositeCodeData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewCompositeCode.GetCompositeCodeDataTable();
                        CompositeCodeHelper.ClearField();
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
            url: "/CompositeCodeMaster/IsDuplicate",

            data: JSON.stringify(CompositeCodeHelper.GetCompositeCodeData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateCompositeCodeManager.SaveCompositeCode();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var CompositeCodeHelper = {
    InitCompositeCode: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateCompositeCodeManager.IsDuplicate();
            //CompositeCodeHelper.ClearField();

        });
        $("#btnCancel").unbind("click").click(function () {
            CompositeCodeHelper.ClearField();
        });
    },



    ClearField: function () {
        debugger;
        $("#hdnCompositeCodeId").val("");
        $("#txtCompositeCode").val("");
        $("#txtCompositeName").val("");
        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetCompositeCodeData: function () {
        debugger;
        var aObj = new Object();
        aObj.CompositeId = $("#hdnCompositeCodeId").val();
        aObj.CompositeCode = $("#txtCompositeCode").val();
        aObj.CompositeName = $("#txtCompositeName").val();
        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};