var viewUser = {

    GetUserDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/User/GetAllUser",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                 {
                     "title": "SL...",
                     render: function (data, type, row, meta) {
                         return meta.row + meta.settings._iDisplayStart + 1;
                     }
                 },
                //{ "data": "Email", "autoWidth": true },
                //{ "data": "EmailIsConfirmed", "autoWidth": true },
                { "data": "UserFullName", "autoWidth": true },
                { "data": "UserName", "autoWidth": true },
                //{ "data": "Password", "autoWidth": true },
                //{ "data": "UserRole", "autoWidth": true },
                //{ "data": "PhoneNo", "autoWidth": true },
                //{ "data": "UserPhoto", "autoWidth": true },
                { "data": "IsActive", "autoWidth": true },
                { "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],
            "columnDefs": [
                {
                    targets: [3],
                    render: function (data, type, row) {
                        return data == "1" ? "Active" : "Inactive";
                    }
                }
            ]
        });

    }

}
var viewUserHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#hdnUserId").val(aObj.Id);
        //$("#ddlParentUser").val(aObj.ParentId).trigger("change");
        $("#txtUserFullName").val(aObj.UserFullName);
        $("#ddlEmail").val(aObj.Email);
        $("#ddlEmailIsConfirmed").val(aObj.EmailIsConfirmed);
        $("#txtUserName").val(aObj.UserName);
        $("#txtPassword").val(aObj.Password);
        //$("#ddlUserRole").val(aObj.UserRole);
        $("#ddlUserRole").val(aObj.UserRole).trigger("change");
        $("#txtPhoneNo").val(aObj.PhoneNo);
        $("#getFile").val(aObj.UserPhoto);
        if (aObj.IsActive === 1) {
            $("#chkIsActive").prop("checked", "checked");
        } else {
            $("#chkIsActive").removeProp("checked", "checked");
        }


    }
}