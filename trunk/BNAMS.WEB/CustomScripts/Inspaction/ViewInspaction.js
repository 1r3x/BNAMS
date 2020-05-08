var viewInspaction = {

    GetInspactionDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/Inspaction/GetInspectionAll",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "ProgramId", "autoWidth": true },
                { "data": "ShipDepotName", "autoWidth": true },
                { "data": "WeaponsType", "autoWidth": true },
                { "data": "NameOfGun", "autoWidth": true },
                { "data": "INstallDate", "autoWidth": true },
                { "data": "NextInspectionDate", "autoWidth": true },

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
var viewInspactionHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;

        $("#hdnInspactionId").val(aObj.InspectionId);
        $("#txtProgramCode").val(aObj.ProgramId);
        $("#ddlDepot").val(aObj.DepotId);
        $("#ddlItemCategory").val(aObj.ItemCategoryId);
        $("#ddlRegistration").val(aObj.ItemId);
        $("#dateOfNextInspection").val(aObj.NextInspectionDate);
        $("#dateOfInstall").val(aObj.INstallDate);
        $("#txtInstallBy").val(aObj.InstallBy);
        $("#txtInstallAt").val(aObj.InstallAt);
        $("#dateOfInspaction").val(aObj.InspectionDate);
        $("#txtInspectionMethod").val(aObj.InspectionMethod);
        $("#txtInspectionBy").val(aObj.InspectionBy);
        $("#txtCommence").val(aObj.Commence);


        if (aObj.StartDate != null) {
            var startDate = new Date(parseInt(aObj.StartDate.substr(6)));
            var cStartDate = startDate.getDate() + "." + (startDate.getMonth() + 1) + "." + startDate.getFullYear();
            $("#startDate").val(cStartDate);
        }
        if (aObj.EndDate != null) {
            var endDate = new Date(parseInt(aObj.EndDate.substr(6)));
            var cEndDate = endDate.getDate() + "." + (endDate.getMonth() + 1) + "." + endDate.getFullYear();
            $("#endDate").val(cEndDate);
        }

    }
}