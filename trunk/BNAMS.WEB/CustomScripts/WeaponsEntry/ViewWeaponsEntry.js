var viewWeaponsEntry = {

    GetWeaponsEntryDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({
            "scrollX": true,
            "ajax": {
                "url": "/WeaponsEntry/GetAllWeaponsByTypeId",
                data: {
                    "weaponsTypeId": $("#ddlWeaponsType").val()
    },
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "WeaponsType", "autoWidth": true },
                { "data": "NameOfGun", "autoWidth": true },
                { "data": "TrackingNo", "autoWidth": true },
                { "data": "IsActive", "autoWidth": true },
                //{ "defaultContent": '<button class="btn btn-primary glyphicon glyphicon-edit" id="btnEdit" type="button"></button>' }
                //{ "defaultContent": '<button class="btn btn-danger glyphicon glyphicon-remove" id="btnDelete" type="button"></button>' }
            ],
            "columnDefs": [
                {
                    targets: [3],
                    render: function (data, type, row) {
                        return data == "1" ? "Active" : "Inactive";
                    }
                }
            ]
        });

    },
     HideField: function () {



         $("#imageDiv").hide();
         $("#btnSubmit").hide();
         $("#btnCancel").hide();
         $("#ddlWeaponsName").hide();
         $("#ddlWeaponsNameL").hide();
         $("#ddlGunModelType").hide();
         $("#ddlGunModelTypeL").hide();
         $("#txtBrand").hide();
         $("#txtBrandL").hide();
         $("#txtGunRegNo").hide();
         $("#txtGunRegNoL").hide();
         $("#ddlYearOfManufacture").hide();
         $("#ddlYearOfManufactureL").hide();
         $("#ddlCountryOfManufacture").hide();
         $("#ddlCountryOfManufactureL").hide();
         $("#ddlCountryOfOrigin").hide();
         $("#ddlCountryOfOriginL").hide();
         $("#txtPurpose").hide();
         $("#txtPurposeL").hide();
         $("#ddlYearOfProcurement").hide();
         $("#ddlYearOfProcurementL").hide();
         $("#txtWarrentyPeriod").hide();
         $("#txtWarrentyPeriodL").hide();
         $("#ddlPriceType").hide();
         $("#ddlPriceTypeL").hide();
         $("#txtUnitPrice").hide();
         $("#txtUnitPriceL").hide();
         $("#txtQuantity").hide();
         $("#txtQuantityL").hide();
         $("#ddlQuantityCategory").hide();
         $("#ddlQuantityCategoryL").hide();
         //todo
         $("#txtTotalPrice").hide();
         $("#txtTotalPriceL").hide();
         $("#ddlLocalAgent").hide();
         $("#ddlLocalAgentL").hide();
         $("#ddlPrincipalAgent").hide();
         $("#ddlPrincipalAgentL").hide();
         $("#ddlManufacturerAgent").hide();
         $("#ddlManufacturerAgentL").hide();
         $("#ddlDepotName").hide();
         $("#ddlDepotNameL").hide();
         $("#ddlProcurementCatagory").hide();
         $("#ddlProcurementCatagoryL").hide();
         $("#ddlWarehouseName").hide();
         $("#ddlWarehouseNameL").hide();
         $("#ddlPreparationTime").hide();
         $("#ddlPreparationTimeL").hide();
         //todo
         $("#ddlShelfNo").hide();
         $("#ddlShelfNoL").hide();
         $("#ddlRowNo").hide();
         $("#ddlRowNoL").hide();
         $("#txtTechnicalSpecification").hide();
         $("#txtTechnicalSpecificationL").hide();
         $("#txtWeight").hide();
         $("#txtWeightL").hide();
         $("#txtDimentions").hide();
         $("#txtDimentionsL").hide();
         $("#txtMaximumRange").hide();
         $("#txtMaximumRangeL").hide();
         $("#txtEffectiveRange").hide();
         $("#txtEffectiveRangeL").hide();
         $("#txtMuzzleVelocity").hide();
         $("#txtMuzzleVelocityL").hide();
         $("#txtBarrelLife").hide();
         $("#txtBarrelLifeL").hide();
         $("#txtOperatingTemp").hide();
         $("#txtOperatingTempL").hide();
         $("#txtStoringTemp").hide();
         $("#txtStoringTempL").hide();
         $("#txtPreservationTemp").hide();
         $("#txtPreservationTempL").hide();
         $("#txtHumadity").hide();
         $("#txtHumadityL").hide();
         $("#ddlStatus").hide();
         $("#ddlStatusL").hide();
         $("#dateOfReceived").hide();
         $("#dateOfReceivedL").hide();
         $("#txtWorkOrder").hide();
         $("#txtWorkOrderL").hide();
         $("#txtShelfLifeItem").hide();
         $("#txtShelfLifeItemL").hide();
         $("#txtShelfLifeLauncherL").hide();
         $("#txtShelfLifeLauncher").hide();
         $("#txtRemarks").hide();
         $("#txtRemarksL").hide();
         $("#txtTestFiring").hide();
         $("#txtTestFiringL").hide();
         $("#dateOfTestFiring").hide();
         $("#dateOfTestFiringL").hide();
         $("#txtCombatDuration").hide();
         $("#txtCombatDurationL").hide();
    },

    ShowForGunEntry: function () {
        $("#btnSubmit").show();
        $("#btnCancel").show();


        $("#imageDiv").show();
        $("#ddlWeaponsName").show();
        $("#ddlWeaponsNameL").show();
        $("#ddlGunModelType").show();
        $("#ddlGunModelTypeL").show();
        $("#txtGunRegNo").show();
        $("#txtGunRegNoL").show();
        $("#ddlYearOfManufacture").show();
        $("#ddlYearOfManufactureL").show();
        $("#ddlCountryOfOrigin").show();
        $("#ddlCountryOfOriginL").show();
        $("#txtPurpose").show();
        $("#txtPurposeL").show();
        $("#ddlYearOfProcurement").show();
        $("#ddlYearOfProcurementL").show();
        $("#txtWarrentyPeriod").show();
        $("#txtWarrentyPeriodL").show();
        $("#ddlPriceType").show();
        $("#ddlPriceTypeL").show();
        $("#txtUnitPrice").show();
        $("#txtUnitPriceL").show();
        $("#txtQuantity").show();
        $("#txtQuantityL").show();
        $("#ddlQuantityCategory").show();
        $("#ddlQuantityCategoryL").show();
        //todo
        $("#txtTotalPrice").show();
        $("#txtTotalPriceL").show();
        $("#ddlLocalAgent").show();
        $("#ddlLocalAgentL").show();
        $("#ddlPrincipalAgent").show();
        $("#ddlPrincipalAgentL").show();
        $("#ddlManufacturerAgent").show();
        $("#ddlManufacturerAgentL").show();
        $("#ddlDepotName").show();
        $("#ddlDepotNameL").show();
        $("#ddlProcurementCatagory").show();
        $("#ddlProcurementCatagoryL").show();
        $("#ddlWarehouseName").show();
        $("#ddlWarehouseNameL").show();
        //todo
        $("#ddlShelfNo").show();
        $("#ddlShelfNoL").show();
        $("#ddlRowNo").show();
        $("#ddlRowNoL").show();
        $("#txtTechnicalSpecification").show();
        $("#txtTechnicalSpecificationL").show();
        $("#txtWeight").show();
        $("#txtWeightL").show();
        $("#txtDimentions").show();
        $("#txtDimentionsL").show();
        $("#txtMaximumRange").show();
        $("#txtMaximumRangeL").show();
        $("#txtEffectiveRange").show();
        $("#txtEffectiveRangeL").show();
        $("#txtMuzzleVelocity").show();
        $("#txtMuzzleVelocityL").show();
        $("#txtBarrelLife").show();
        $("#txtBarrelLifeL").show();
        $("#txtOperatingTemp").show();
        $("#txtOperatingTempL").show();
        $("#txtStoringTemp").show();
        $("#txtStoringTempL").show();
        $("#txtPreservationTemp").show();
        $("#txtPreservationTempL").show();
        $("#ddlStatus").show();
        $("#ddlStatusL").show();
        $("#dateOfReceived").show();
        $("#dateOfReceivedL").show();
        $("#txtWorkOrder").show();
        $("#txtWorkOrderL").show();
        $("#txtRemarks").show();
        $("#txtRemarksL").show();


  
        WeaponsEntryHelper.LoadFiscalYearDD();
        WeaponsEntryHelper.LoadCountryDD();
        WeaponsEntryHelper.LoadYearDD();
        WeaponsEntryHelper.LoadPriceTypeDD();
        WeaponsEntryHelper.LoadLocalAgentDD();
        WeaponsEntryHelper.LoadPrincipalAgentDD();
        WeaponsEntryHelper.LoadManuAgentDD();
        WeaponsEntryHelper.LoadQuantityCategoryDD();
        WeaponsEntryHelper.LoadDepotDD();
        WeaponsEntryHelper.LoadProcurementCategoryDD();
        WeaponsEntryHelper.LoadWareHouseDD();
        WeaponsEntryHelper.LoadStatusDD();
    },

    ShowForWebEntry: function () {
        $("#btnSubmit").show();
        $("#btnCancel").show();


        $("#imageDiv").show();
        $("#ddlWeaponsName").show();
        $("#ddlWeaponsNameL").show();
        $("#ddlGunModelType").show();
        $("#ddlGunModelTypeL").show();
        $("#txtGunRegNo").show();
        $("#txtGunRegNoL").show();
        $("#ddlYearOfManufacture").show();
        $("#ddlYearOfManufactureL").show();
        $("#ddlCountryOfOrigin").show();
        $("#ddlCountryOfOriginL").show();
        $("#ddlCountryOfManufacture").show();
        $("#ddlCountryOfManufactureL").show();
        $("#txtPurpose").show();
        $("#txtPurposeL").show();
        $("#ddlYearOfProcurement").show();
        $("#ddlYearOfProcurementL").show();
        $("#txtWarrentyPeriod").show();
        $("#txtWarrentyPeriodL").show();
        $("#ddlPriceType").show();
        $("#ddlPriceTypeL").show();
        $("#txtUnitPrice").show();
        $("#txtUnitPriceL").show();
        $("#txtQuantity").show();
        $("#txtQuantityL").show();
        $("#ddlQuantityCategory").show();
        $("#ddlQuantityCategoryL").show();
        $("#txtTotalPrice").show();
        $("#txtTotalPriceL").show();
        $("#ddlLocalAgent").show();
        $("#ddlLocalAgentL").show();
        $("#ddlPrincipalAgent").show();
        $("#ddlPrincipalAgentL").show();
        $("#ddlManufacturerAgent").show();
        $("#ddlManufacturerAgentL").show();
        $("#ddlDepotName").show();
        $("#ddlDepotNameL").show();
        $("#ddlProcurementCatagory").show();
        $("#ddlProcurementCatagoryL").show();
        $("#ddlWarehouseName").show();
        $("#ddlWarehouseNameL").show();
        $("#ddlShelfNo").show();
        $("#ddlShelfNoL").show();
        $("#ddlRowNo").show();
        $("#ddlRowNoL").show();
        $("#txtTechnicalSpecification").show();
        $("#txtTechnicalSpecificationL").show();
        $("#txtWeight").show();
        $("#txtWeightL").show();
        $("#ddlStatus").show();
        $("#ddlStatusL").show();
        $("#txtRemarks").show();
        $("#txtRemarksL").show();



        WeaponsEntryHelper.LoadFiscalYearDD();
        WeaponsEntryHelper.LoadCountryDD();
        WeaponsEntryHelper.LoadYearDD();
        WeaponsEntryHelper.LoadPriceTypeDD();
        WeaponsEntryHelper.LoadLocalAgentDD();
        WeaponsEntryHelper.LoadPrincipalAgentDD();
        WeaponsEntryHelper.LoadManuAgentDD();
        WeaponsEntryHelper.LoadQuantityCategoryDD();
        WeaponsEntryHelper.LoadDepotDD();
        WeaponsEntryHelper.LoadProcurementCategoryDD();
        WeaponsEntryHelper.LoadWareHouseDD();
        WeaponsEntryHelper.LoadStatusDD();
        WeaponsEntryHelper.LoadCountryOFManuDD();
    },

    ShowForSpairPartsEntry: function () {
        $("#btnSubmit").show();
        $("#btnCancel").show();


        $("#imageDiv").show();
        $("#ddlWeaponsName").show();
        $("#ddlWeaponsNameL").show();
        $("#ddlGunModelType").show();
        $("#ddlGunModelTypeL").show();
        $("#txtBrand").show();
        $("#txtBrandL").show();
        $("#ddlYearOfManufacture").show();
        $("#ddlYearOfManufactureL").show();
        $("#ddlCountryOfOrigin").show();
        $("#ddlCountryOfOriginL").show();
        $("#ddlCountryOfManufacture").show();
        $("#ddlCountryOfManufactureL").show();
        $("#txtPurpose").show();
        $("#txtPurposeL").show();
        $("#ddlYearOfProcurement").show();
        $("#ddlYearOfProcurementL").show();
        $("#txtWarrentyPeriod").show();
        $("#txtWarrentyPeriodL").show();
        $("#ddlPriceType").show();
        $("#ddlPriceTypeL").show();
        $("#txtUnitPrice").show();
        $("#txtUnitPriceL").show();
        $("#txtQuantity").show();
        $("#txtQuantityL").show();
        $("#ddlQuantityCategory").show();
        $("#ddlQuantityCategoryL").show();
        ////todo
        $("#txtTotalPrice").show();
        $("#txtTotalPriceL").show();
        $("#ddlLocalAgent").show();
        $("#ddlLocalAgentL").show();
        $("#ddlPrincipalAgent").show();
        $("#ddlPrincipalAgentL").show();
        $("#ddlManufacturerAgent").show();
        $("#ddlManufacturerAgentL").show();
        $("#ddlDepotName").show();
        $("#ddlDepotNameL").show();
        $("#ddlProcurementCatagory").show();
        $("#ddlProcurementCatagoryL").show();
        $("#ddlWarehouseName").show();
        $("#ddlWarehouseNameL").show();
        $("#ddlShelfNo").show();
        $("#ddlShelfNoL").show();
        $("#ddlRowNo").show();
        $("#ddlRowNoL").show();
        $("#txtTechnicalSpecification").show();
        $("#txtTechnicalSpecificationL").show();
        $("#txtWeight").show();
        $("#txtWeightL").show();
        $("#txtOperatingTemp").show();
        $("#txtOperatingTempL").show();
        $("#txtStoringTemp").show();
        $("#txtStoringTempL").show();
        $("#txtPreservationTemp").show();
        $("#txtPreservationTempL").show();
        $("#ddlStatus").show();
        $("#ddlStatusL").show();
        $("#dateOfReceived").show();
        $("#dateOfReceivedL").show();
        $("#txtRemarks").show();
        $("#txtRemarksL").show();



        WeaponsEntryHelper.LoadFiscalYearDD();
        WeaponsEntryHelper.LoadCountryDD();
        WeaponsEntryHelper.LoadYearDD();
        WeaponsEntryHelper.LoadPriceTypeDD();
        WeaponsEntryHelper.LoadLocalAgentDD();
        WeaponsEntryHelper.LoadPrincipalAgentDD();
        WeaponsEntryHelper.LoadManuAgentDD();
        WeaponsEntryHelper.LoadQuantityCategoryDD();
        WeaponsEntryHelper.LoadDepotDD();
        WeaponsEntryHelper.LoadProcurementCategoryDD();
        WeaponsEntryHelper.LoadWareHouseDD();
        WeaponsEntryHelper.LoadStatusDD();
        WeaponsEntryHelper.LoadCountryOFManuDD();
    },

    ShowForAmmoEntry: function () {
        $("#btnSubmit").show();
        $("#btnCancel").show();


        $("#imageDiv").show();
        $("#ddlWeaponsName").show();
        $("#ddlWeaponsNameL").show();
        $("#ddlGunModelType").show();
        $("#ddlGunModelTypeL").show();
        $("#ddlYearOfManufacture").show();
        $("#ddlYearOfManufactureL").show();
        $("#ddlCountryOfOrigin").show();
        $("#ddlCountryOfOriginL").show();
        $("#ddlCountryOfManufacture").show();
        $("#ddlCountryOfManufactureL").show();
        $("#ddlYearOfProcurement").show();
        $("#ddlYearOfProcurementL").show();
        $("#txtWarrentyPeriod").show();
        $("#txtWarrentyPeriodL").show();
        $("#ddlPriceType").show();
        $("#ddlPriceTypeL").show();
        $("#txtUnitPrice").show();
        $("#txtUnitPriceL").show();
        $("#txtQuantity").show();
        $("#txtQuantityL").show();
        //lot number
        $("#txtTotalPrice").show();
        $("#txtTotalPriceL").show();
        $("#ddlLocalAgent").show();
        $("#ddlLocalAgentL").show();
        $("#ddlPrincipalAgent").show();
        $("#ddlPrincipalAgentL").show();
        $("#ddlManufacturerAgent").show();
        $("#ddlManufacturerAgentL").show();
        $("#ddlDepotName").show();
        $("#ddlDepotNameL").show();
        $("#ddlWarehouseName").show();
        $("#ddlWarehouseNameL").show();
        $("#ddlShelfNo").show();
        $("#ddlShelfNoL").show();
        $("#ddlRowNo").show();
        $("#ddlRowNoL").show();
        $("#txtTechnicalSpecification").show();
        $("#txtTechnicalSpecificationL").show();
        $("#txtTestFiring").show();
        $("#txtTestFiringL").show();
        $("#dateOfTestFiring").show();
        $("#dateOfTestFiringL").show();
        
        $("#txtOperatingTemp").show();
        $("#txtOperatingTempL").show();
        $("#txtStoringTemp").show();
        $("#txtStoringTempL").show();
        $("#txtPreservationTemp").show();
        $("#txtPreservationTempL").show();
        $("#txtHumadity").show();
        $("#txtHumadityL").show();
        $("#ddlStatus").show();
        $("#ddlStatusL").show();
        
        $("#txtRemarks").show();
        $("#txtRemarksL").show();



        WeaponsEntryHelper.LoadFiscalYearDD();
        WeaponsEntryHelper.LoadCountryDD();
        WeaponsEntryHelper.LoadYearDD();
        WeaponsEntryHelper.LoadPriceTypeDD();
        WeaponsEntryHelper.LoadLocalAgentDD();
        WeaponsEntryHelper.LoadPrincipalAgentDD();
        WeaponsEntryHelper.LoadManuAgentDD();
        WeaponsEntryHelper.LoadDepotDD();
        WeaponsEntryHelper.LoadWareHouseDD();
        WeaponsEntryHelper.LoadStatusDD();
        WeaponsEntryHelper.LoadCountryOFManuDD();
    },

    ShowForMissileEntry: function () {
        $("#btnSubmit").show();
        $("#btnCancel").show();


        $("#imageDiv").show();
        $("#ddlWeaponsName").show();
        $("#ddlWeaponsNameL").show();
        $("#ddlGunModelType").show();
        $("#ddlGunModelTypeL").show();
       
        $("#ddlYearOfManufacture").show();
        $("#ddlYearOfManufactureL").show();
        $("#ddlCountryOfOrigin").show();
        $("#ddlCountryOfOriginL").show();
        $("#ddlCountryOfManufacture").show();
        $("#ddlCountryOfManufactureL").show();
        $("#txtPurpose").show();
        $("#txtPurposeL").show();
        $("#ddlYearOfProcurement").show();
        $("#ddlYearOfProcurementL").show();
        $("#txtShelfLifeItem").show();
        $("#txtShelfLifeItemL").show();
        $("#txtShelfLifeLauncherL").show();
        $("#txtShelfLifeLauncher").show();
        $("#ddlPreparationTime").show();
        $("#ddlPreparationTimeL").show();
        $("#txtCombatDuration").show();
        $("#txtCombatDurationL").show();
        $("#txtTestFiring").show();
        $("#txtTestFiringL").show();
        $("#dateOfTestFiringL").show();
        $("#dateOfTestFiring").show();

        $("#txtWarrentyPeriod").show();
        $("#txtWarrentyPeriodL").show();
        $("#ddlPriceType").show();
        $("#ddlPriceTypeL").show();
        $("#txtUnitPrice").show();
        $("#txtUnitPriceL").show();
        $("#txtQuantity").show();
        $("#txtQuantityL").show();
        //serial number
       
        $("#txtTotalPrice").show();
        $("#txtTotalPriceL").show();
        $("#ddlLocalAgent").show();
        $("#ddlLocalAgentL").show();
        $("#ddlPrincipalAgent").show();
        $("#ddlPrincipalAgentL").show();
        $("#ddlManufacturerAgent").show();
        $("#ddlManufacturerAgentL").show();
        $("#ddlDepotName").show();
        $("#ddlDepotNameL").show();
        
        $("#ddlWarehouseName").show();
        $("#ddlWarehouseNameL").show();
        $("#ddlShelfNo").show();
        $("#ddlShelfNoL").show();
        $("#ddlRowNo").show();
        $("#ddlRowNoL").show();
        $("#txtTechnicalSpecification").show();
        $("#txtTechnicalSpecificationL").show();
        
        $("#txtOperatingTemp").show();
        $("#txtOperatingTempL").show();
        $("#txtStoringTemp").show();
        $("#txtStoringTempL").show();
        $("#txtHumadity").show();
        $("#txtHumadityL").show();
        $("#ddlStatus").show();
        $("#ddlStatusL").show();
        $("#dateOfReceived").show();
        $("#dateOfReceivedL").show();
        $("#txtRemarks").show();
        $("#txtRemarksL").show();



        WeaponsEntryHelper.LoadFiscalYearDD();
        WeaponsEntryHelper.LoadCountryDD();
        WeaponsEntryHelper.LoadYearDD();
        WeaponsEntryHelper.LoadPriceTypeDD();
        WeaponsEntryHelper.LoadLocalAgentDD();
        WeaponsEntryHelper.LoadPrincipalAgentDD();
        WeaponsEntryHelper.LoadManuAgentDD();
        WeaponsEntryHelper.LoadDepotDD();
        WeaponsEntryHelper.LoadWareHouseDD();
        WeaponsEntryHelper.LoadStatusDD();
        WeaponsEntryHelper.LoadCountryOFManuDD();
        WeaponsEntryHelper.LoadMissilePrepDD();
    },


}
