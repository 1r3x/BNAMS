var viewTrainingInfo = {

    GetTrainingInfoDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/TrainingInfo/GetAllTrainingInfo",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "WeaponsType", "autoWidth": true },
                { "data": "TraningCode", "autoWidth": true },
                { "data": "RefNo", "autoWidth": true },
                { "data": "Pno", "autoWidth": true },
                {
                    "data": "StartDate",
                    "type": "date",
                    "render": function (value) {
                        if (value === null) return "";

                        var pattern = /Date\(([^)]+)\)/;
                        var results = pattern.exec(value);
                        var dt = new Date(parseFloat(results[1]));

                        return dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear();
                    }
                },
                {
                    "data": "EndDate",
                    "type": "date",
                    "render": function (value) {
                        if (value === null) return "";

                        var pattern = /Date\(([^)]+)\)/;
                        var results = pattern.exec(value);
                        var dt = new Date(parseFloat(results[1]));

                        return dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear();
                    }
                },
                { "data": "IsActive", "autoWidth": true },
                { "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],
            "columnDefs": [
                {
                    targets: [6],
                    render: function (data, type, row) {
                        return data == "1" ? "Active" : "Inactive";
                    }
                }
            ]
        });

    }

}
var viewTrainingInfoHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#hdnTrainingInfoId").val(aObj.TrainingId);
        $("#txtTrainingCode").val(aObj.TraningCode); 
        $("#ddlWeaponType").val(aObj.WeaponTypeId).trigger("change");
        $("#txtCourseName").val(aObj.CourseName);
        $("#txtCourseRefNo").val(aObj.RefNo);
        $("#ddlPno").val(aObj.TraningPersonBioId).trigger("change");
        if (aObj.StartDate != null) {
            var startDate = new Date(parseInt(aObj.StartDate.substr(6)));
            var cStartDate = startDate.getDate() + "." + (startDate.getMonth() + 1) + "." + startDate.getFullYear();
            $("#dateOfStart").val(cStartDate);

        }
        if (aObj.EndDate != null) {
            var endDate = new Date(parseInt(aObj.EndDate.substr(6)));
            var cEndDate = endDate.getDate() + "." + (endDate.getMonth() + 1) + "." + endDate.getFullYear();
            $("#dateOfEnd").val(cEndDate);

        }
        $("#ddlCountry").val(aObj.CounryId).trigger("change");
        $("#ddlOrganization").val(aObj.OrganizationId).trigger("change");
        $("#txtLocal").val(aObj.LocalAbroadStatus);

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