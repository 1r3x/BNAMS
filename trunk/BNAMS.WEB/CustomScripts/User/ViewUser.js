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
                
                { "data": "EmployeeFullName", "autoWidth": true },
                { "data": "UserName", "autoWidth": true },
                { "data": "UserRoleName", "autoWidth": true },
                { "data": "DirectorateName", "autoWidth": true },
                { "data": "IsActive", "autoWidth": true },
                { "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
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
var viewUserHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        //for image
        if (aObj.EmpImage != null) {
            $("#blah").attr("src", aObj.EmpImage);
        }

        $("#hdnEmployeeId").val(aObj.Id);
        $("#hdnPasswordBearer").val(aObj.Password);
        $("#txtFirstName").val(aObj.FirstName);
        $("#txtLastName").val(aObj.LastName);
        $("#txtEmpIdNumber").val(aObj.EmpIdNumber);
        $("#txtEmployeeEmail").val(aObj.Email);
        $("#txtEmployeePhone").val(aObj.PhoneNo);
        $("#txtEmployeeUserName").val(aObj.UserName);
        $("#ddlUserRole").val(aObj.UserRole).trigger("change");
        $("#ddlDirectorate").val(aObj.DirectorateId).trigger("change");




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