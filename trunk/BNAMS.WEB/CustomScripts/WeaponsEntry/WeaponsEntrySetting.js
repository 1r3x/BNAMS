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
            //forgun
            viewWeaponsEntry.ShowForGunEntry();
            $("#txtQuantity").prop("readonly", true);
            $("#txtQuantity").val("1");
            
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 
        else if (pageLoad == "1042020WEAP145") {
            viewWeaponsEntry.ShowForWebEntry();
            $("#txtQuantity").prop("readonly", true);
            $("#txtQuantity").val("1");
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 

        else if (pageLoad == "1042020WEAP138") {
            //Spare Parts
            viewWeaponsEntry.ShowForSpairPartsEntry();
            $("#txtQuantity").prop("readonly", true);
            $("#txtQuantity").val("1");
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 
        else if (pageLoad == "1042020WEAP139") {
            //ammo
            viewWeaponsEntry.ShowForAmmoEntry();
            $("#txtQuantity").prop("readonly", false);
            //$("#txtQuantity").readOnly();
            $("#txtQuantity").val("1");
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 

        else if (pageLoad == "1042020WEAP140") {
            viewWeaponsEntry.ShowForMissileEntry();
            $("#txtQuantity").prop("readonly", true);
            $("#txtQuantity").val("1");
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 

        else if (pageLoad == "1042020WEAP141") {
            viewWeaponsEntry.ShowForMissileEntry();
            $("#txtQuantity").prop("readonly", true);
            $("#txtQuantity").val("1");
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 

        else if (pageLoad == "1042020WEAP142") {
            viewWeaponsEntry.ShowForMissileEntry();
            $("#txtQuantity").prop("readonly", true);
            $("#txtQuantity").val("1");
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 
        else if (pageLoad == "1042020WEAP143") {
            viewWeaponsEntry.ShowForMissileEntry();
            $("#txtQuantity").prop("readonly", true);
            $("#txtQuantity").val("1");
            viewWeaponsEntry.GetWeaponsEntryDataTable();
            WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
            WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
        } 
        else if (pageLoad == "1042020WEAP144") {
            viewWeaponsEntry.ShowForMissileEntry();
            $("#txtQuantity").prop("readonly", true);
            $("#txtQuantity").val("1");
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

    $("#ddlDepotName").on("change", function (e) {
        debugger;
        WeaponsEntryHelper.LoadWareHouseDD();
    });
    $("#txtQuantity").on("change", function (e) {

        var unitPrice = $("#txtUnitPrice").val();
        var quantity = $("#txtQuantity").val();
        var totalPrice = unitPrice * quantity;
        $("#txtTotalPrice").val(totalPrice);
    });
    $("#txtUnitPrice").on("change", function (e) {

        var unitPrice = $("#txtUnitPrice").val();
        var quantity = $("#txtQuantity").val();
        var totalPrice = unitPrice * quantity;
        $("#txtTotalPrice").val(totalPrice);
    });

   
});