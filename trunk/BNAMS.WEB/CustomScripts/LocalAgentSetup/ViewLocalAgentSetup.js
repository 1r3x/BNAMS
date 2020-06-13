var viewLocalAgentSetupSetup = {

    GetLocalAgentSetupSetupDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/LocalAgentSetup/GetAllLocalAgentSetup",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "Code", "autoWidth": true },
                { "data": "SupplierName", "autoWidth": true },
                { "data": "AgentType", "autoWidth": true },
                { "data": "EnlistmentType", "autoWidth": true },
                { "data": "ContractNumber", "autoWidth": true },
                { "data": "CountryName", "autoWidth": true },
                { "data": "Email", "autoWidth": true },
                { "data": "IsActive", "autoWidth": true },
                { "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],
            "columnDefs": [
                {
                    targets: [7],
                    render: function (data, type, row) {
                        return data == "1" ? "Active" : "Inactive";
                    }
                }
            ]
            
        });

    }

}
var viewLocalAgentSetupSetupHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#hdnLocalAgentId").val(aObj.LocalAgentId);
        $("#txtLocalAgentCode").val(aObj.Code);
        $("#txtSupplierName").val(aObj.SupplierName);
        $("#txtAddress").val(aObj.Address);
        $("#ddlEnlistmentType").val(aObj.EnlistmentTypeId).trigger("change");
        $("#ddlAgentType").val(aObj.AgentTypeId).trigger("change");
        $("#txtEmail").val(aObj.Email);
        $("#txtContractNumber").val(aObj.ContractNumber);
        $("#ddlCountry").val(aObj.Country).trigger("change");

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