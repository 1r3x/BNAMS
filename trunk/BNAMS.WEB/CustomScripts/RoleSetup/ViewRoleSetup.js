var viewRoleSetup = {

    GetRoleSetupDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/RoleSetup/LoadAllRole",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "UserRoleName", "autoWidth": true },
                { "data": "IsActive", "autoWidth": true },
                { "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],
            "columnDefs": [
                {
                    targets: [1],
                    render: function (data, type, row) {
                        return data == "1" ? "Active" : "Inactive";
                    }
                }
            ]
        });

    }

}
var viewRoleSetupHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#hdnRoleId").val(aObj.RoleId);
        $("#txtRoleName").val(aObj.UserRoleName);
        if (aObj.IsActive == 1) {
            $("#chkIsActive").prop("checked", "checked");
        } else {
            $("#chkIsActive").removeProp("checked", "checked");
        }


    }
}