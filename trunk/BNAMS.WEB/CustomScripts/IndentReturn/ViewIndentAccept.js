var viewIndent = {

    GetIndentDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({
            "scrollX": true,
            "ajax": {
                "url": "/IndentReturn/GetAllIndent",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "IndentNo", "autoWidth": true },
                { "data": "indentFrom", "autoWidth": true },
                { "data": "issueTo", "autoWidth": true },
                { "data": "NameOfGun", "autoWidth": true },
                { "data": "CompositeName", "autoWidth": true },
                {
                    "data": "IndentValidity",
                    "type": "date",
                    "render": function(value) {
                        if (value === null) return "";

                        var pattern = /Date\(([^)]+)\)/;
                        var results = pattern.exec(value);
                        var dt = new Date(parseFloat(results[1]));

                        return dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear();
                    }
                },
                { "data": "IsActive", "autoWidth": true },
                {
                    "defaultContent":
                        '<button class="btn btn-primary glyphicon glyphicon-open" id="btnEdit" type="button"></button>'
                }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],
           
            "columnDefs": [
                {
                    targets: [6],
                    render: function (data, type, row) {

                        debugger;
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
        $("#txtProgramId").val(aObj.ProgramId);
        $("#txtIndentNo").val(aObj.IndentNo);
        $("#ddlIndentFrom").val(aObj.IndentFrom).trigger("change");
        $("#ddlIssuePerson").val(aObj.IssueTo).trigger("change");
        $("#ddlItemCode").val(aObj.ItemId).trigger("change");
        $("#ddlCompositeCode").val(aObj.CompositeId).trigger("change");
        $("#txtIdentQuantiry").val(aObj.IndentQuantity);


        if (aObj.IndentValidity != null) {
            var indentValidity = new Date(parseInt(aObj.IndentValidity.substr(6)));
            var cindentValidity = indentValidity.getDate() + "." + (indentValidity.getMonth() + 1) + "." + indentValidity.getFullYear();
            $("#dateOfIndentValidity").val(cindentValidity);

        }



        $("#txtOtherOptions").val(aObj.OtherOptions);


        $("#hdnSetupBy").val(aObj.SetUpBy);
        if (aObj.SetUpDateTime != null) {
            var setUpDateTime = new Date(parseInt(aObj.SetUpDateTime.substr(6)));
            var cSetUpDateTime = setUpDateTime.getDate() + "." + (setUpDateTime.getMonth() + 1) + "." + setUpDateTime.getFullYear();
            $("#hdnSetupDateTime").val(cSetUpDateTime);

        }

    }
}