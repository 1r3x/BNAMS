var viewDirectorateInfo = {

    GetDirectorateInfoDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/DirectorateInfo/GetAllDirectorateInfo",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "DirectorateCode", "autoWidth": true },
                { "data": "DirectorateName", "autoWidth": true },
                { "data": "AreaName", "autoWidth": true },
                { "data": "FaxNumber", "autoWidth": true },
                { "data": "TelephoneNumber", "autoWidth": true },
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
var viewDirectorateInfoHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        //for image
        if (aObj.Logo != null) {
            $("#blah").attr("src", aObj.Logo);
        }

        $("#hdnDirectorateId").val(aObj.DirectorateID);
        $("#txtOrganizationCode").val(aObj.DirectorateCode);
        $("#txtAuthorityName").val(aObj.DirectorateName);
        $("#txtAddress").val(aObj.Address);
        $("#txtTelephone").val(aObj.TelephoneNumber);
        $("#txtFaxNo").val(aObj.FaxNumber);
        $("#txtWebAddress").val(aObj.WebAddress);
        $("#ddlArea").val(aObj.AreaId).trigger("change");
        if (aObj.IsActive == 1) {
            $("#chkIsActive").prop("checked", "checked");
        } else {
            $("#chkIsActive").removeProp("checked", "checked");
        }

        $("#hdnSetupBy").val(aObj.SetUpBy);
        if (aObj.SetUpDateTime != null) {
            var setUpDateTime = new Date(parseInt(aObj.SetUpDateTime.substr(6)));
            var cSetUpDateTime = setUpDateTime.getDate() + "." + (setUpDateTime.getMonth() + 1) + "." + setUpDateTime.getFullYear();
            $("#hdnSetupDateTime").val(cSetUpDateTime);

        }


    }
}