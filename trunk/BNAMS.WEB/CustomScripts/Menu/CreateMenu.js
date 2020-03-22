
var CreateMenuManager = {

    SaveMenu: function () {
        debugger;
        $.ajax({
            type: "POST",
            url: "/Menu/CreateMenu",
            data: JSON.stringify(MenuHelper.GetMenuData()),
            dataType: "json",
            contentType: "application/json"
        });
    }

};


var MenuHelper = {
    InitMenu: function () {
        
        $("#btnSubmit").unbind("click").click(function () {
            CreateMenuManager.SaveMenu();
            viewMenu.GetMenuDataTable();
            MenuHelper.ClearField();
        });
        $("#btnCancel").unbind("click").click(function () {
            MenuHelper.ClearField();
        });
    },

    LoadMasterMenu: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Menu/LoadAllMenu",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    loadMasterMenuDD: function () {
        debugger;
        var parentMenu = MenuHelper.LoadMasterMenu();
        $("#ddlParentMenu").select2({
            placeholder: "Select Master",
            data: parentMenu
        });
    },
    
    

    ClearField: function () {
        $("#hdnMenuId").val("");
        $("#ddlParentMenu").val("").trigger("change");
        $("#txtMenuName").val("");
        $("#txtMenuClass").val("");
        $("#txtMenuId").val("");
        $("#txtMenuURL").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetMenuData: function () {
        var aObj = new Object();
        aObj.Id = $("#hdnMenuId").val();
        aObj.ParentId = $("#ddlParentMenu").val();
        aObj.MenuName = $("#txtMenuName").val();
        aObj.MenuClass = $("#txtMenuClass").val();
        aObj.MenuId = $("#txtMenuId").val();
        aObj.MenuUrl = $("#txtMenuURL").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};