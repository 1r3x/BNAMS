
var CreateWeaponsEntryManager = {

    SaveWeaponsEntry: function () {
        debugger;
        if ($("#txtAuthorityName").val() == "") {
            toastr.warning("Directorate Name is Required.");
        }
       

        else {
            $.ajax({
                type: "POST",
                url: "/WeaponsEntry/CreateWeaponsItem",
                data: JSON.stringify(WeaponsEntryHelper.GetWeaponsEntryData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewWeaponsEntry.GetWeaponsEntryDataTable();
                        WeaponsEntryHelper.ClearField();
                        $("#btnSubmit").html("Save");
                    }
                },
                error: function (response) {

                },
                dataType: "json",
                contentType: "application/json"
            });

            if (window.FormData !== undefined) {
                debugger;
                var fileUpload = $("#getFile").get(0);
                var files = fileUpload.files;

                // Create FormData object  
                var fileData = new FormData();

                // Looping over all files and add it to FormData object  
                for (var i = 0; i < files.length; i++) {
                    fileData.append(files[i].name, files[i]);
                }

                $.ajax({
                    url: "/WeaponsEntry/UploadFiles",
                    type: "POST",
                    contentType: false, // Not to set any content header  
                    processData: false, // Not to process data  
                    data: fileData,
                    success: function (result) {
                        toastr.success(result);
                    },
                    error: function (err) {
                        toastr.warning(err.statusText);
                    }
                });
            } else {
                toastr.warning("File is not supported.");
            }


        }

    },

};


var WeaponsEntryHelper = {
    InitWeaponsEntry: function () {
       
        WeaponsEntryHelper.LoadWeaponsTypeDD();

        $("#btnSubmit").unbind("click").click(function () {
            CreateWeaponsEntryManager.SaveWeaponsEntry();

        });
        $("#btnCancel").unbind("click").click(function () {
            WeaponsEntryHelper.ClearField();
        });
    },
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
        $("#ddlWeaponsType").select2({
            placeholder: "Select Weapons Type",
            data: parentMenu
        });
    },

    //weapon name
    LoadNameOfWeaponByWeaponType: function () {
        var weaponTypeId = $("#ddlWeaponsType").val();

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
        $("#ddlWeaponsName").empty();
        $("#ddlWeaponsName").append(
            $("<option></option>")
        );
        var parentMenu = WeaponsEntryHelper.LoadNameOfWeaponByWeaponType();
        $("#ddlWeaponsName").select2({
            placeholder: "Select Weapons Name",
            data: parentMenu
        });
        $("#ddlWeaponsName").select2("val", "");
    },

    //weapon model
    LoadWeaponModelByWeaponType: function () {
        var weaponTypeId = $("#ddlWeaponsType").val();

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
        $("#ddlGunModelType").empty();
        $("#ddlGunModelType").append(
            $("<option></option>")
        );
        var parentMenu = WeaponsEntryHelper.LoadWeaponModelByWeaponType();
        $("#ddlGunModelType").select2({
            placeholder: "Select Weapons Model",
            data: parentMenu
        });
        $("#ddlGunModelType").select2("val", "");
    },

    //weapon year
    LoadFiscalYear: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadFiscalYear",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadFiscalYearDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadFiscalYear();
        $("#ddlYearOfManufacture").select2({
            placeholder: "Select Fiscal Year",
            data: parentMenu
        });
    },

    //weapon country
    LoadCountry: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadCountry",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadCountryDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadCountry();
        $("#ddlCountryOfOrigin").select2({
            placeholder: "Select Country",
            data: parentMenu
        });
    },
    //for manu counry
    LoadCountryOFManuDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadCountry();
        $("#ddlCountryOfManufacture").select2({
            placeholder: "Select Country",
            data: parentMenu
        });
    },



    //year 
    LoadYear: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadYear",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadYearDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadYear();
        $("#ddlYearOfProcurement").select2({
            placeholder: "Select Year",
            data: parentMenu
        });
    },

    //price type 
    LoadPriceType: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadPriceType",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadPriceTypeDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadPriceType();
        $("#ddlPriceType").select2({
            placeholder: "Select Price Type",
            data: parentMenu
        });
    },

    //local aent  
    LoadLocalAgent: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadLocalAgent",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadLocalAgentDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadLocalAgent();
        $("#ddlLocalAgent").select2({
            placeholder: "Select Price Type",
            data: parentMenu
        });
    },


    //LoadPrincipalAgent
    LoadPrincipalAgent: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadPrincipalAgent",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadPrincipalAgentDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadPrincipalAgent();
        $("#ddlPrincipalAgent").select2({
            placeholder: "Select Principal Agent",
            data: parentMenu
        });
    },

    //LoadManuAgent
    LoadManuAgent: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadManuAgent",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadManuAgentDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadManuAgent();
        $("#ddlManufacturerAgent").select2({
            placeholder: "Select Manufacture Arent",
            data: parentMenu
        });
    },


    //LoadQuantityCategory
    LoadQuantityCategory: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadQuantityCategory",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadQuantityCategoryDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadQuantityCategory();
        $("#ddlQuantityCategory").select2({
            placeholder: "Select Quantity Category",
            data: parentMenu
        });
    },

    //LoadDepot
    LoadDepot: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadDepot",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadDepotDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadDepot();
        $("#ddlDepotName").select2({
            placeholder: "Select Depot Name",
            data: parentMenu
        });
    },

    //LoadProcurementCategory
    LoadProcurementCategory: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadProcurementCategory",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadProcurementCategoryDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadProcurementCategory();
        $("#ddlProcurementCatagory").select2({
            placeholder: "Select Procurement Category",
            data: parentMenu
        });
    },
    //LoadWareHouse
    LoadWareHouse: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadWareHouse",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadWareHouseDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadWareHouse();
        $("#ddlWarehouseName").select2({
            placeholder: "Select Procurement Category",
            data: parentMenu
        });
    },

    //LoadShelfNameByWraehouseId
    LoadShelfNameByWraehouseId: function () {
        var warehouseId = $("#ddlWarehouseName").val();

        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadShelfNameByWraehouseId",
            data: { warehouseId: warehouseId },
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadShelfNameByWraehouseIdDD: function () {
        $("#ddlShelfNo").empty();
        $("#ddlShelfNo").append(
            $("<option></option>")
        );
        var parentMenu = WeaponsEntryHelper.LoadShelfNameByWraehouseId();
        $("#ddlShelfNo").select2({
            placeholder: "Select Shelf No",
            data: parentMenu
        });
        $("#ddlShelfNo").select2("val", "");
    },

    //LoadShelfNameByWraehouseId
    LoadRowNameByWraehouseId: function () {
        var warehouseId = $("#ddlWarehouseName").val();

        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadRowNameByWraehouseId",
            data: { warehouseId: warehouseId },
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadRowNameByWraehouseIdDD: function () {
        $("#ddlRowNo").empty();
        $("#ddlRowNo").append(
            $("<option></option>")
        );
        var parentMenu = WeaponsEntryHelper.LoadRowNameByWraehouseId();
        $("#ddlRowNo").select2({
            placeholder: "Select Row No",
            data: parentMenu
        });
        $("#ddlRowNo").select2("val", "");
    },

    //LoadStatus
    LoadStatus: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadStatus",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadStatusDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadStatus();
        $("#ddlStatus").select2({
            placeholder: "Select Status",
            data: parentMenu
        });
    },


    //LoadMissilePrep
    LoadMissilePrep: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/WeaponsEntry/LoadMissilePreparationTime",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    LoadMissilePrepDD: function () {
        debugger;
        var parentMenu = WeaponsEntryHelper.LoadMissilePrep();
        $("#ddlPreparationTime").select2({
            placeholder: "Select Preparation Time",
            data: parentMenu
        });
    },


    ClearField: function () {
        debugger;
        //for image input
        var input = $("#getFile");

        input.replaceWith(input.val("").clone(true));
        $("#blah").attr("src", "http://placehold.it/180");
        $("#hdnWeaponsInfoId").val("0");
        //$("#ddlWeaponsType").val("");
        $("#ddlWeaponsName").val("").trigger("change");
        $("#").val("");
        $("#ddlGunModelType").val("").trigger("change");
        $("#txtGunRegNo").val("");
        $("#ddlYearOfManufacture").val("").trigger("change");
        $("#").val("");
        $("#ddlCountryOfOrigin").val("").trigger("change");
        $("#ddlCountryOfManufacture").val("").trigger("change");
        $("#txtPurpose").val("");
        $("#ddlYearOfProcurement").val("").trigger("change");
        $("#txtWarrentyPeriod").val("");
        $("#ddlPriceType").val("").trigger("change");
        $("#txtUnitPrice").val("");
        $("#txtQuantity").val("");
        $("#ddlQuantityCategory").val("").trigger("change");
        //todo
        $("#txtTotalPrice").val("");
        $("#ddlLocalAgent").val("").trigger("change");
        $("#ddlPrincipalAgent").val("").trigger("change");
        $("#ddlManufacturerAgent").val("").trigger("change");
        $("#ddlDepotName").val("").trigger("change");
        $("#ddlProcurementCatagory").val("").trigger("change");
        $("#ddlWarehouseName").val("").trigger("change");
        //todo
        $("#ddlShelfNo").val("").trigger("change");
        $("#ddlRowNo").val("").trigger("change");
        $("#txtTechnicalSpecification").val("");
        $("#txtWeight").val("");
        $("#txtDimentions").val("");
        $("#txtMaximumRange").val("");
        $("#txtEffectiveRange").val("");
        $("#txtMuzzleVelocity").val("");
        $("#txtBarrelLife").val("");
        $("#txtOperatingTemp").val("");
        $("#txtStoringTemp").val("");
        $("#txtPreservationTemp").val("");
        $("#ddlStatus").val("").trigger("change");
        $("#dateOfReceived").val("");
        $("#txtWorkOrder").val("");
        $("#txtRemarks").val("");
        $("#txtHumadity").val("");
        $("#txtCombatDuration").val("");
        $("#").val("");
        $("#").val("");
        $("#").val("");
        $("#").val("");
        $("#").val("");
        $("#").val("");
        $("#").val("");
        $("#").val("");
        $("#").val("");
        $("#").val("");
        $("#btnSubmit").html("Save");
    },


    GetWeaponsEntryData: function () {
        debugger;
        var aObj = new Object();
        aObj.WeaponsInfoId = $("#hdnWeaponsInfoId").val();

        if (document.getElementById("getFile").files[0] != undefined) {
            aObj.Image = document.getElementById("getFile").files[0].type.toString().replace(/application/i, "");
        } else {
            aObj.Image = $("#blah").attr("src");
        }
        
        aObj.WeaponsTypeId = $("#ddlWeaponsType").val();
        aObj.NameOfWeaponsId = $("#ddlWeaponsName").val();
        aObj.WeaponsModel = $("#ddlGunModelType").val();
        aObj.RegistrationNo = $("#txtGunRegNo").val();
        aObj.ManufactureYear = $("#ddlYearOfManufacture").val();
        aObj.FiscalYearId = $("#").val();
        aObj.OriginCountryId = $("#ddlCountryOfOrigin").val();
        aObj.ManufactureCountryId = $("#ddlCountryOfManufacture").val();
        aObj.Purpose = $("#txtPurpose").val();
        aObj.ProcurementYear = $("#ddlYearOfProcurement").val();
        aObj.WarrantyPeriod = $("#txtWarrentyPeriod").val();
        aObj.PriceTypeId = $("#ddlPriceType").val();
        aObj.UnitPrice = $("#txtUnitPrice").val();
        aObj.Quantity = $("#txtQuantity").val();
        aObj.QuantityCategoryId = $("#ddlQuantityCategory").val();
        //todo
        aObj.TotalPrice = $("#txtTotalPrice").val();
        aObj.LocalAgentId = $("#ddlLocalAgent").val();
        aObj.PrincipalAgentId = $("#ddlPrincipalAgent").val();
        aObj.ManufactureAgentId = $("#ddlManufacturerAgent").val();
        aObj.DepotId = $("#ddlDepotName").val();
        aObj.ProcurementCatId = $("#ddlProcurementCatagory").val();
        aObj.WareHouseId = $("#ddlWarehouseName").val();
        aObj.BinLocationId = $("#ddlShelfNo").val();
        aObj.TechnicalSpec = $("#txtTechnicalSpecification").val();
        aObj.Weight = $("#txtWeight").val();
        aObj.Dimention = $("#txtDimentions").val();
        aObj.MaximumRange = $("#txtMaximumRange").val();
        aObj.EffectiveRange = $("#txtEffectiveRange").val();
        aObj.MuzzeleVelocity = $("#txtMuzzleVelocity").val();
        aObj.BarrelLife = $("#txtBarrelLife").val();
        aObj.OperatingTemp = $("#txtOperatingTemp").val();
        aObj.StoringTemp = $("#txtStoringTemp").val();
        aObj.PreservatingTemp = $("#txtPreservationTemp").val();
        aObj.StatusId = $("#ddlStatus").val();
        aObj.DateAfterAcceptance = $("#dateOfReceived").val();
        aObj.WorkOrderNumber = $("#txtWorkOrder").val();
        aObj.Remarks = $("#txtRemarks").val();
        aObj.MissilTypeId = $("#").val();
        aObj.SerialNumber = $("#").val();
        aObj.ShelfLifeOfWeapon = $("#txtShelfLifeItem").val();
        aObj.ShelfLifeOfLauncher = $("#txtShelfLifeLauncher").val();
        aObj.PreparationTimeId = $("#ddlPreparationTime").val();
        aObj.CombatDuration = $("#txtCombatDuration").val();
        aObj.Caliber = $("#").val();
        aObj.AmmunitationTypeId = $("#").val();
        aObj.LotNumberId = $("#").val();
        aObj.ProofFiringStatus = $("#txtTestFiring").val();
        aObj.ProofFiringDate = $("#dateOfTestFiring").val();
        aObj.Humidity = $("#txtHumadity").val();
        aObj.Brand = $("#txtBrand").val();

        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        return aObj;
    }
};