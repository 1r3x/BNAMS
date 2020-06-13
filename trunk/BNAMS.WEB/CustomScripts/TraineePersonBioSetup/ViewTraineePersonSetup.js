var viewTraineePersonBioSetup = {

    GetTraineePersonBioSetupDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/TraineePersonBioSetup/GetAllTraineeBio",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "BioDataCode", "autoWidth": true },
                { "data": "Pno", "autoWidth": true },
                { "data": "RankName", "autoWidth": true },
                { "data": "Name", "autoWidth": true },
                { "data": "IsActive", "autoWidth": true },
                { "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],
            "columnDefs": [
                {
                    targets: [4],
                    render: function (data, type, row) {
                        return data == "1" ? "Active" : "Inactive";
                    }
                }
            ]
        });

    }

}
var viewTraineePersonBioSetupHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#hdnTraineePersonBioId").val(aObj.TraningPersonId);
        $("#txtBioDataCode").val(aObj.BioDataCode);
        $("#txtPNo").val(aObj.Pno);
        $("#ddlRank").val(aObj.RankId).trigger("change");
        $("#txtName").val(aObj.Name);

        $("#hdnSetupBy").val(aObj.SetUpBy);
        if (aObj.SetUpDateTime != null) {
            var setUpDateTime = new Date(parseInt(aObj.SetUpDateTime.substr(6)));
            var cSetUpDateTime = setUpDateTime.getDate() + "." + (setUpDateTime.getMonth() + 1) + "." + setUpDateTime.getFullYear();
            $("#hdnSetupDateTime").val(cSetUpDateTime);

        }
        if (aObj.IsActive == 1) {
            $("#chkIsActive").prop("checked", "checked");
        } else {
            $("#chkIsActive").removeProp("checked", "checked");
        }


    }
}