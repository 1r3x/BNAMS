var viewFiscalYearSetup = {

    GetFiscalYearSetupDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/FiscalYearSetup/LoadAllFiscalYear",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "FiscalYearCode", "autoWidth": true },
                { "data": "Name", "autoWidth": true },
                { "data": "ShortName", "autoWidth": true },
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
                    targets: [5],
                    render: function (data, type, row) {
                        return data == "1" ? "Active" : "Inactive";
                    }
                }
            ]
        });

    }

}
var viewFiscalYearSetupHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#hdnFiscalId").val(aObj.FiscalYearId);
        $("#txtFiscalYearCode").val(aObj.FiscalYearCode);
        $("#txtFiscalYearName").val(aObj.Name);
        $("#txtFiscalYearShortName").val(aObj.ShortName);
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
        if (aObj.IsActive == 1) {
            $("#chkIsActive").prop("checked", "checked");
        } else {
            $("#chkIsActive").removeProp("checked", "checked");
        }


    }
}