$(document).ready(function () {
   
    UserPrivilegesHelper.InitUserPrivileges();


    $("#ddlRoleName").on("change", function (e) {
        //CreateUserPrivilegesManager.GetUserPrivilegesDataTable();
        //test purpose 

        CreateUserPrivilegesManager.GetSelectedUserPrivilegesDataTable();
    });
    
    

    $("#menuIdAll").click(function (e) {
        $(this).closest("table").find("td input:checkbox").prop("checked", this.checked);

    });

    $("#dataTable").on("click", 'input[type="checkbox"]', function () {
        var mainid = $(this).data("id");
        $(this).closest("table").find(".subMenu_" + mainid).prop("checked", this.checked);
        $(this).closest("table").find(".view_" + mainid).prop("checked", this.checked);
        $(this).closest("table").find(".edit_" + mainid).prop("checked", this.checked);
        $(this).closest("table").find(".delete_" + mainid).prop("checked", this.checked);
    });
    
    $("#dataTable").on("click", 'input[type="checkbox"]', function () {
        var mainid = $(this).data("id");
        $(this).closest("table").find("#view_" + mainid).prop("checked", this.checked);
        $(this).closest("table").find("#edit_" + mainid).prop("checked", this.checked);
        $(this).closest("table").find("#delete_" + mainid).prop("checked", this.checked);
    });


})
