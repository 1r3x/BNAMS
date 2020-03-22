var viewMenu = {

    GetMenuDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/Menu/GetAllMenu",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "MenuName", "autoWidth": true },
                { "data": "MenuClass", "autoWidth": true },
                { "data": "MenuId", "autoWidth": true },
                { "data": "MenuUrl", "autoWidth": true },
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
var viewMenuHelper = {


    populateDataForEditButton: function (aObj) {
        debugger;
        $("#hdnMenuId").val(aObj.Id);
        $("#ddlParentMenu").val(aObj.ParentId).trigger("change");
        $("#txtMenuName").val(aObj.MenuName);
        $("#txtMenuClass").val(aObj.MenuClass);
        $("#txtMenuId").val(aObj.MenuId);
        $("#txtMenuURL").val(aObj.MenuUrl);
        if (aObj.IsActive == 1) {
            $("#chkIsActive").prop("checked", "checked");
        } else {
            $("#chkIsActive").removeProp("checked", "checked");
        }


    }
}