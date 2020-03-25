
var CreateUserPrivilegesManager = {
    

    CreateUserPrivileges: function () {

        $.ajax({
            type: "POST",
            url: "/UserPrivileges/CreateUserPrivileges",
            data: JSON.stringify(UserPrivilegesHelper.GetUserPrivilegesData()),
            success: function (response) {
                if (response != null) {
                    UserPrivilegesHelper.ClearField();
                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });

    },
    //no use 
    GetUserPrivilegesDataTable: function () {
        var b = [];
        debugger;
        $.ajax({
            url: "/UserPrivileges/GetAllMenuAndSubMenu",
            type: "POST",
            success: function (data) {
                b = data.data;
                var row = "";
                $("#menuList").html("");
                $.each(b, function (index, item) {
                    if (item.ParentId==0) {
                        row += "<tr>" +
                            "<td><input type='checkbox' class='mainMenu'  data-id='" + item.Id + "' id='menuId_" + index + "'/>" + item.MenuName + " </td>" +
                            "<td></td>" +
                            "<td></td>" +
                            "<td></td>" +
                            "<td></td>" +
                            "</tr>'";
                        $("#menuList").html(row);
                    } else {
                        row += "<tr>" +
                            "<td></td>" +
                            "<td><input type='checkbox' class='subMenu_" + item.ParentId + "'  id='subMenuId_" + index +
                            "'data-id='" + index + "' value='"+ item.Id + "'/>" + item.MenuName + "</td>" +
                            "<td><input type='checkbox' class='view_" + item.ParentId + "' id='view_" + index + "'/></td>" +
                            "<td><input type='checkbox' class='edit_" + item.ParentId + "' id='edit_" + index + "'/></td>" +
                            "<td><input type='checkbox' class='delete_" + item.ParentId + "' id='delete_" + index + "'/></td>" +
                            "</tr>'";
                        $("#menuList").html(row);
                    }
                    

                });
            }

        });
    },

    //for selected the select checkBox
    GetSelectedUserPrivilegesDataTable: function () {
        var b = [];
        debugger;
        var roleId = $("#ddlRoleName").val();
        $.ajax({
            url: "/UserPrivileges/GetAllSelectedMenuAndSubMenu",
            type: "POST",
            data: JSON.stringify({ roleId: roleId }),
            dataType: "json",
            contentType: "application/json;charset:utf-8",
            success: function (data) {
                b = data.data;
                var row = "";
                $("#menuList").html("");
                $.each(b, function (index, item) {

                    if (item.ParentId == 0) {
                        var menuSelected = (item.Selected != null) ? "checked" : "";
                        //alert(selected);
                        row += "<tr>" +
                            "<td><input " +
                            menuSelected
                            +" type='checkbox' class='mainMenu'  data-id='" + item.Id + "' id='menuId_" + index + "' value='" + item.Id + "'/>" + item.MenuName + " </td>" +
                            "<td></td>" +
                            "<td></td>" +
                            "<td></td>" +
                            "<td></td>" +
                            "</tr>'";
                        $("#menuList").html(row);
                    } else {
                        var selected = (item.Selected !=null) ? "checked" : "";
                        //alert(selected);
                        row += "<tr>" +
                            "<td></td>" +
                            "<td><input " +
                            selected
                            +" type='checkbox' class='subMenu_" + item.ParentId + "'  id='subMenuId_" + index +
                            "'data-id='" + index + "' value='" + item.Id + "'/>" + item.MenuName + "</td>" +


                            "<td><input type='checkbox' class='view_" + item.ParentId + "' id='view_" + index + "'/></td>" +
                            "<td><input type='checkbox' class='edit_" + item.ParentId + "' id='edit_" + index + "'/></td>" +
                            "<td><input type='checkbox' class='delete_" + item.ParentId + "' id='delete_" + index + "'/></td>" +
                            "</tr>'";
                        $("#menuList").html(row);
                    }


                });
            }

        });
    },

    LoadRole: function () {

        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/UserPrivileges/GetAllRoleType",
            success: function (response) {

                b = response.data;
            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    }

};

var UserPrivilegesHelper = {

    InitUserPrivileges: function () {
        UserPrivilegesHelper.loadRoleDD();

        $("#btnSubmit").unbind("click").click(function () {
            CreateUserPrivilegesManager.CreateUserPrivileges();
        });


        $("#btnCancel").unbind("click").click(function () {
            UserPrivilegesHelper.ClearField();
        });
    },
    loadRoleDD: function () {
        var shift = CreateUserPrivilegesManager.LoadRole();
        $("#ddlRoleName").select2({
            placeholder: "Select a Role",
            data: shift
        });
    },

    ClearField: function () {
        //$("#ddlOfficeName").val("").trigger("change");
        //$("#ddlDepartment").val("").trigger("change");
        //$("#ddlDesignation").val("").trigger("change");
        //$("#ddlShift").val("").trigger("change");
        //$("#startDate").val("");
        //$("#endDate").val("");
        //$("#restTime").val("");
        //$("#chkIsOT").prop("checked", false);
        //$("#EmployeeList").html("");
    },

    GetUserPrivilegesData: function () {
        debugger;
        var userPrivileges = new Array();
        $("#menuList tr").each(function (index) {
            var row = $("#menuList");

            var role = {};

            if($("#menuId_" + index).is(":checked") == true) {
                debugger;
                var id = row.find("#MenuId_" + index).val();
                role.RoleId = $("#ddlRoleName").val();
                role.MenuId = id;
                userPrivileges.push(role);
            }

            if ($("#subMenuId_" + index).is(":checked") == true) {
                debugger;
                var id = row.find("#subMenuId_" + index).val();
                var view = ($("#view_" + index).prop("checked") == true) ? 1 : 0;
                var edit = ($("#edit_" + index).prop("checked") == true) ? 1 : 0;
                var del = ($("#delete_" + index).prop("checked") == true) ? 1 : 0;
                role.RoleId = $("#ddlRoleName").val();
                role.MenuId = id;
                role.IsEdit = edit;
                role.IsDelete = del;
                role.IsCreate = view;
                userPrivileges.push(role);
            }
            

        });

        return userPrivileges;

    }
};