$(document).ready(function () {
    $("#chkIsActive").prop("checked", true);
    debugger;
    GunAmmoMaintainceHelper.InitGunAmmoMaintaince();
   
    //this function is for go to top of the page
    function topFunction() {
        //for safari 
        document.body.scrollTop = 0;
        //for others browsers
        document.documentElement.scrollTop = 0;
    }

    $("#dataTable tbody").on("click", "#btnEdit", function (e) {
        $("#btnSubmit").html("Update");
        topFunction();
        var table = $("#dataTable").DataTable();
        var data = table.row($(this).parents("tr")).data();
        viewGunAmmoMaintainceHelper.populateDataForEditButton(data);
    });

    $("#ddlWeaponType").on("change", function (e) {
        debugger;
        GunAmmoMaintainceHelper.LoadRegistrationNoDD();
    });

    $("#ddlRegNo").on("change", function (e) {
        debugger;
        GunAmmoMaintainceHelper.LoadWeaponsDetails();
    });

    $("#ddlDepot").on("change", function (e) {
        debugger;
        GunAmmoMaintainceHelper.LoadWarehouseDD();
    });

    $("#ddlWarehouse").on("change", function (e) {
        debugger;
        GunAmmoMaintainceHelper.LoadShelfDD();
        GunAmmoMaintainceHelper.LoadRowDD();
    });

});