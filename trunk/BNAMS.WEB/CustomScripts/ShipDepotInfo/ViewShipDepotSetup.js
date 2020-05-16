var viewShipDepotSetup = {

    GetShipDepotSetupDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/ShipDepotInfo/GetAllShipOrDepotSetup",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "ShipOrDepotCode", "autoWidth": true },
                { "data": "ShipDepotName", "autoWidth": true },
                { "data": "AuthorityName", "autoWidth": true },
                { "data": "DirectorateName", "autoWidth": true },
                {
                    "data": "DateOfCommmisson",
                    "type": "date",
                    "render": function (value) {
                        if (value === null) return "";
                        debugger;
                        var pattern = /Date\(([^)]+)\)/;
                        var results = pattern.exec(value);
                        var dt = new Date(parseFloat(results[1]));

                        return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
                    }
                },
                { "data": "CapabilityName", "autoWidth": true },
                { "data": "TypeName", "autoWidth": true },
                { "data": "CategoryName", "autoWidth": true },
                { "data": "IsActive", "autoWidth": true },
                { "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],
          
            "columnDefs": [
                {
                    targets: [8],
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
        $("#hdnShipDepotId").val(aObj.ShipOrDepotId);
        $("#txtShipDepotCode").val(aObj.ShipOrDepotCode);
        $("#ddlAdmin").val(aObj.DerectorateId).trigger("change");
        $("#ddlCategory").val(aObj.ShipDepotCategory).trigger("change");
        $("#txtShipDepotName").val(aObj.ShipDepotName);
        if (aObj.DateOfCommmisson != null) {
            var commissionDateTime = new Date(parseInt(aObj.DateOfCommmisson.substr(6)));
            var cCommissionDateTime = commissionDateTime.getDate() + "." + (commissionDateTime.getMonth() + 1) + "." + commissionDateTime.getFullYear();
            $("#dateOfCommission").val(cCommissionDateTime);

        }
        $("#txtWTCallSign").val(aObj.WTCallSign);
        $("#ddlCapabilityOfWeapons").val(aObj.CapabilityOfWeaponsId).trigger("change");
        $("#ddlTypeOfShip").val(aObj.TypeOfShip).trigger("change");
        $("#txtTelephone ").val(aObj.Telephone);
        $("#txtEmail").val(aObj.Email);
        $("#txtFaxNo").val(aObj.FaxNo);
        $("#txtWebAddress").val(aObj.WebAddress);



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