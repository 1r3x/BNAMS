$(document).ready(function () {
    WeaponsEntryHelper.InitWeaponsEntry();




    $("#ddlWeaponsType").on("change", function (e) {
        debugger;
        //var table = $("#dataTable").DataTable();

        //table
        //    .clear()
        //    .draw();
        viewWeaponsEntry.GetWeaponsEntryDataTable();
        WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
        WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
    });
    $("#ddlWarehouseName").on("change", function (e) {
        debugger;
        WeaponsEntryHelper.LoadShelfNameByWraehouseIdDD();
        WeaponsEntryHelper.LoadRowNameByWraehouseIdDD();
    });
    


});