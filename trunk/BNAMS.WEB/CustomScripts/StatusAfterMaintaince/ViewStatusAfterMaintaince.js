var viewStatusAfterMaintaince = {

    GetStatusAfterMaintainceDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/StatusAfterMaintaince/GetAllStatusAfterMaintaince",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "NameOfGun", "autoWidth": true },
                { "data": "AfterMaintainceStatusCode", "autoWidth": true },
                { "data": "Remarks", "autoWidth": true },
                { "data": "Status", "autoWidth": true },

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
var viewStatusAfterMaintainceHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#hdnStatusAfterMaintainceId").val(aObj.AfterMaintainceStatusId);
        $("#txtMaintainceCode").val(aObj.AfterMaintainceStatusCode);
        $("#ddlRegistrationNo").val(aObj.WeaponsInfoId).trigger("change");
        $("#ddlMaintainceStatus").val(aObj.MaintainceStatusId).trigger("change");
        $("#txtRemarks").val(aObj.Remarks);
        if (aObj.IsActive == 1) {
            $("#chkIsActive").prop("checked", "checked");
        } else {
            $("#chkIsActive").removeProp("checked", "checked");
        }


    }
}