var viewCapabilityOfWeaponsSetup = {

    GetCapabilityOfWeaponsSetupDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/CapabilityOfWeapons/LoadAllCapabilityOfWeapons",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "CapabilityCode", "autoWidth": true },
                { "data": "CapabilityName", "autoWidth": true },
                { "data": "Telephone", "autoWidth": true },
                { "data": "Email", "autoWidth": true },
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
var viewCapabilityOfWeaponsSetupHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#hdnCapabilityId").val(aObj.CapabilityOfWeaponsID);
        $("#txtCapabilityCode").val(aObj.CapabilityCode);
        $("#txtCapabilityName").val(aObj.CapabilityName);
        $("#txtTelephone").val(aObj.Telephone);
        $("#txtEmail").val(aObj.Email);
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