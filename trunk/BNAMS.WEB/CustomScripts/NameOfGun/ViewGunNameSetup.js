var viewGunNameSetup = {

    GetGunNameSetupDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/NameOfGun/GetAllNameOfGunSetup",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "WeaponsType", "autoWidth": true },
                { "data": "NameOfGunCode", "autoWidth": true },
                { "data": "NameOfGun", "autoWidth": true },
                { "data": "ShortName", "autoWidth": true },
                {
                    "data": "CreateDate",
                    "type": "date",
                    "render": function (value) {
                        if (value === null) return "";

                        var pattern = /Date\(([^)]+)\)/;
                        var results = pattern.exec(value);
                        var dt = new Date(parseFloat(results[1]));

                        return dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear();
                    }
                },
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
var viewGunNameSetupHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#hdnNameOfGunId").val(aObj.NameOfGunId);
        $("#ddlWeaponsType").val(aObj.WeaponsTypeId).trigger("change");
        $("#txtGunNameCode").val(aObj.NameOfGunCode);
        $("#txtGunName").val(aObj.NameOfGun);
        $("#txtShortName").val(aObj.ShortName);
        if (aObj.CreateDate != null) {
            var createDate = new Date(parseInt(aObj.CreateDate.substr(6)));
            var cCreateDate = createDate.getDate() + "." + (createDate.getMonth() + 1) + "." + createDate.getFullYear();
            $("#createDate").val(cCreateDate);

        }
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