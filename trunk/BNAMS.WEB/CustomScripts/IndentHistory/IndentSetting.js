$(document).ready(function () {
    viewIndent.GetIndentDataTable();
    WeaponsEntryHelper.LoadWeaponsTypeDD();
   
    $("#ddlItemType").on("change", function (e) {
        debugger;
        WeaponsEntryHelper.LoadNameOfWeaponByWeaponTypeDD();
        WeaponsEntryHelper.LoadWeaponModelByWeaponTypeDD();
    });
    $("#ddlItemModel").on("change", function (e) {
        viewIndent.GetIndentDataTable();
    });
});


var WeaponsEntryHelper =
{
    //weapon type
    LoadWeaponsType: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadWeaponsType",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadWeaponsTypeDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadWeaponsType();
        $("#ddlItemType").select2({
            placeholder: "Select Weapons Type",
            data: parentMenu
        });
    },

    //weapon name
    LoadNameOfWeaponByWeaponType: function () {
        var weaponTypeId = $("#ddlItemType").val();

        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadWeaponsByType",
            data: { weaponTypeId: weaponTypeId },
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadNameOfWeaponByWeaponTypeDD: function () {
        $("#ddlItemName").empty();
        $("#ddlItemName").append(
            $("<option></option>")
        );
        var parentMenu = WeaponsEntryHelper.LoadNameOfWeaponByWeaponType();
        $("#ddlItemName").select2({
            placeholder: "Select Weapons Name",
            data: parentMenu
        });
        $("#ddlItemName").select2("val", "");
    },

    //weapon model
    LoadWeaponModelByWeaponType: function () {
        var weaponTypeId = $("#ddlItemType").val();

        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadWeaponModelByWeaponId",
            data: { weaponTypeId: weaponTypeId },
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadWeaponModelByWeaponTypeDD: function () {
        $("#ddlItemModel").empty();
        $("#ddlItemModel").append(
            $("<option></option>")
        );
        var parentMenu = WeaponsEntryHelper.LoadWeaponModelByWeaponType();
        $("#ddlItemModel").select2({
            placeholder: "Select Weapons Model",
            data: parentMenu
        });
        $("#ddlItemModel").select2("val", "");
    },
}
