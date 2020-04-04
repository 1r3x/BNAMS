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
                { "data": "EmployeeFullName", "autoWidth": true },
                { "data": "EmpUserName", "autoWidth": true },
                { "data": "IsActive", "autoWidth": true },
                { "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
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
        //for image
        if (aObj.EmpImage != null) {
            $("#blah").attr("src", aObj.EmpImage);
        }

        $("#hdnEmployeeId").val(aObj.EmpId);
        $("#txtFirstName").val(aObj.EmpFName);
        $("#txtLastName").val(aObj.EmpLastName);
        $("#txtEmpIdNumber").val(aObj.EmpIdNumber);
        $("#txtEmployeeEmail").val(aObj.EmpEmail);
        $("#txtEmployeePhone").val(aObj.EmpCell);
        $("#txtEmployeeUserName").val(aObj.EmpUserName);
        $("#ddlUserRole").val(aObj.RoleId).trigger("change");
        if (aObj.IsActive == 1) {
            $("#chkIsActive").prop("checked", "checked");
        } else {
            $("#chkIsActive").removeProp("checked", "checked");
        }


    }
}