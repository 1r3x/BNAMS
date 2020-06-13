var viewAuthoritySetupSetup = {

    GetAuthoritySetupSetupDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/AuthoritySetup/LoadAllAuthority",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "AuthorityCode", "autoWidth": true },
                { "data": "AuthorityName", "autoWidth": true },
                { "data": "AreaName", "autoWidth": true },
                { "data": "Contract", "autoWidth": true },
                { "data": "Email", "autoWidth": true },
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
var viewAuthoritySetupSetupHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#hdnAuthorityId").val(aObj.AuthorityId);
        $("#txtAuthorityCode").val(aObj.AuthorityCode);
        $("#txtAuthorityName").val(aObj.AuthorityName);
        $("#ddlArea").val(aObj.AreaId).trigger("change");
        $("#txtAuthorityContract").val(aObj.Contract);
        $("#txtAuthorityEmail").val(aObj.Email);
        //for
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