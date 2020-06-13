$(document).ready(function () {
    WeaponsEntryHelper.InitWeaponsEntry();
    viewWeaponsEntry.HideField();

    function topFunction() {
        //for safari 
        document.body.scrollTop = 0;
        //for others browsers
        document.documentElement.scrollTop = 0;
    }

    $("#ddlWeaponsType").on("change", function (e) {
        debugger;
        viewWeaponsEntry.HideForSelect2();
        viewWeaponsEntry.HideField();
        var pageLoad = $("#ddlWeaponsType").val();
        if (pageLoad == "1042020WEAP137") {
            viewWeaponsEntry.ShowForGunEntry();
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 
        else if (pageLoad == "1042020WEAP145") {
            viewWeaponsEntry.ShowForWebEntry();
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 

        else if (pageLoad == "1042020WEAP138") {
            viewWeaponsEntry.ShowForSpairPartsEntry();
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 
        else if (pageLoad == "1042020WEAP139") {
            viewWeaponsEntry.ShowForAmmoEntry();
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 

        else if (pageLoad == "1042020WEAP140") {
            viewWeaponsEntry.ShowForMissileEntry();
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 

        else if (pageLoad == "1042020WEAP141") {
            viewWeaponsEntry.ShowForMissileEntry();
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 

        else if (pageLoad == "1042020WEAP142") {
            viewWeaponsEntry.ShowForMissileEntry();
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 
        else if (pageLoad == "1042020WEAP143") {
            viewWeaponsEntry.ShowForMissileEntry();
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 
        else if (pageLoad == "1042020WEAP144") {
            viewWeaponsEntry.ShowForMissileEntry();
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 
       
        //var table = $("#dataTable").DataTable();

        //table
        //    .clear()
        //    .draw();
        

    });
    $("#ddlWarehouseName").on("change", function (e) {
        debugger;
        WeaponsEntryHelper.LoadShelfNameByWraehouseIdDD();
        WeaponsEntryHelper.LoadRowNameByWraehouseIdDD();
    });
    $("#txtQuantity").on("change", function (e) {

        var unitPrice = $("#txtUnitPrice").val();
        var quantity = $("#txtQuantity").val();
        var totalPrice = unitPrice * quantity;
        $("#txtTotalPrice").val(totalPrice);
    });
    


});