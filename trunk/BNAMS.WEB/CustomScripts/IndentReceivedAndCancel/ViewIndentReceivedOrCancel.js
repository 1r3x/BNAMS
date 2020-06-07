var viewIndent = {

    GetIndentDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/Indent/GetAllIndent",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "ProgramId", "autoWidth": true },
                { "data": "IndentNo", "autoWidth": true },
                { "data": "indentFrom", "autoWidth": true },
                { "data": "issueTo", "autoWidth": true },
                { "data": "NameOfGun", "autoWidth": true },
                { "data": "CompositeName", "autoWidth": true },
                { "data": "IndentValidity", "autoWidth": true },


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
var viewIndentHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;

        $("#hdnIndentId").val(aObj.IndentId);
        $("#ddlIndentType").val(aObj.IndentType).trigger("change");
        $("#txtProgramId").val(aObj.ProgramId);
        $("#txtIndentNo").val(aObj.IndentNo);
        $("#ddlIndentFrom").val(aObj.IndentFrom).trigger("change");
        $("#ddlIssuePerson").val(aObj.IssueTo).trigger("change");
        $("#ddlItemCode").val(aObj.ItemId).trigger("change");
        $("#ddlCompositeCode").val(aObj.CompositeCodeId).trigger("change");
        $("#txtIdentQuantiry").val(aObj.IndentQuantity);
        $("#dateOfIndentValidity").val(aObj.IndentValidity);
        $("#txtOtherOptions").val(aObj.OtherOptions);


        $("#hdnSetupBy").val(aObj.SetUpBy);
        if (aObj.SetUpDateTime != null) {
            var setUpDateTime = new Date(parseInt(aObj.SetUpDateTime.substr(6)));
            var cSetUpDateTime = setUpDateTime.getDate() + "." + (setUpDateTime.getMonth() + 1) + "." + setUpDateTime.getFullYear();
            $("#hdnSetupDateTime").val(cSetUpDateTime);

        }

    }
}