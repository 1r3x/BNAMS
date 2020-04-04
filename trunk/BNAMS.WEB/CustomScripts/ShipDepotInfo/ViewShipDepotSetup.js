var viewShipDepotSetup = {

    GetShipDepotSetupDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/ShipDepot/GetAllShipDepot",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "Code", "autoWidth": true },
                { "data": "SupplierName", "autoWidth": true },
                { "data": "EnlistmintType", "autoWidth": true },
                { "data": "ContractNumber", "autoWidth": true },
                { "data": "Country", "autoWidth": true },
                { "data": "Email", "autoWidth": true },
                { "data": "IsActive", "autoWidth": true },
                { "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],
            "columnDefs1": [
                {
                    targets: [2],
                    render: function (data, type, row) {
                        alert(data);
                        return data == "true" ? "Yes" : "No";
                    }
                }
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
var viewShipDepotSetupHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#hdnLocalAgentId").val(aObj.LocalAgentId);
        $("#txtLocalAgentCode").val(aObj.Code);
        $("#txtSupplierName").val(aObj.SupplierName);
        $("#txtAddress").val(aObj.Address);
        $("#ddlEnlistmentType").val(aObj.EnlistmintType).trigger("change");
        $("#txtEmail").val(aObj.Email);
        $("#txtContractNumber").val(aObj.ContractNumber);
        $("#ddlCountry").val(aObj.Country).trigger("change");
        if (aObj.IsActive == 1) {
            $("#chkIsActive").prop("checked", "checked");
        } else {
            $("#chkIsActive").removeProp("checked", "checked");
        }


    }
}