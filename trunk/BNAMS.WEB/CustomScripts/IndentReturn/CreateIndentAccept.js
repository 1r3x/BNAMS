﻿
var CreateIndentManager = {

    SaveIndent: function () {
        debugger;
        if ($("#txtBinLocationName").val() == "") {
            toastr.warning("Ware House Name is Required.");
        } else {
            $.ajax({
                type: "POST",
                url: "/IndentReturn/CreateIndentReturn",
                data: JSON.stringify(IndentHelper.GetIndentData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewIndent.GetIndentDataTable();
                        IndentHelper.ClearField();
                        $("#btnSubmit").hide();
                        $("#btnAbort").hide();
                    }
                },
                error: function (response) {

                },
                dataType: "json",
                contentType: "application/json"
            });
        }

    },
    CancelIndent: function () {
        debugger;
        if ($("#txtBinLocationName").val() == "") {
            toastr.warning("Ware House Name is Required.");
        } else {
            $.ajax({
                type: "POST",
                url: "/IndentReturn/CreateIndentCancel",
                data: JSON.stringify(IndentHelper.GetIndentData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewIndent.GetIndentDataTable();
                        IndentHelper.ClearField();
                        $("#btnSubmit").hide();
                        $("#btnAbort").hide();
                    }
                },
                error: function (response) {

                },
                dataType: "json",
                contentType: "application/json"
            });
        }

    },

    LoadWareHoueDetailsByWareHouseCode: function () {
        var warehouseCode = $("#txtWarehouseCode").val();
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndentReturn/LoadWareHouseByCode",
            data: { wareHouseCode: warehouseCode },
            success: function (response) {
                debugger;
                if (response.data.length != 0) {

                    $("#hdnWareHouseId").val(response.data[0].WareHouseId);
                    $("#txtWarehouseName").val(response.data[0].WareHouseName);
                } else {
                    $("#hdnWareHouseId").val("");
                    $("#txtWarehouseName").val("No Warehouse Found");
                }

            },
            error: function (response) {

            }
        });

    }

};


var IndentHelper = {
    InitIndent: function () {
        IndentHelper.LoadAllDepotAndShipForIndentFromDD();
        IndentHelper.LoadAllDepotAndShipForIssueDD();
        IndentHelper.LoadCompositCodeDD();
        IndentHelper.LoadIndentTypeDD();
        IndentHelper.LoadLocalAgentsDD();
        IndentHelper.LoadItemCodeDD();
        $("#ddlIndentFrom").attr("disabled", true);
        $("#ddlIssuePerson").attr("disabled", true);
        $("#ddlItemCode").attr("disabled", true);
        $("#ddlCompositeCode").attr("disabled", true);

        $("#btnSubmit").unbind("click").click(function () {
            CreateIndentManager.SaveIndent();

        });

        $("#btnAbort").unbind("click").click(function () {
            CreateIndentManager.CancelIndent();

        });
        //$("#btnCancel").unbind("click").click(function () {
        //    IndentHelper.ClearField();

        //});
    },

    LoadAllDepotAndShipForIndentFrom: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Indent/LoadAllDepotAndShipForIndentFrom",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadAllDepotAndShipForIndentFromDD: function () {
        debugger;
        var parentMenu = IndentHelper.LoadAllDepotAndShipForIndentFrom();
        $("#ddlIndentFrom").select2({
            placeholder: "Select Indent No",
            data: parentMenu
        });
    },

    LoadAllDepotAndShipForIssue: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Indent/LoadAllDepotAndShipForIssue",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadAllDepotAndShipForIssueDD: function () {
        debugger;
        var parentMenu = IndentHelper.LoadAllDepotAndShipForIssue();
        $("#ddlIssuePerson").select2({
            placeholder: "Select Issue Person",
            data: parentMenu
        });
    },

    LoadItemCode: function () {
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndentReturn/LoadAllItem",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadItemCodeDD: function () {
       
        var parentMenu = IndentHelper.LoadItemCode();
        $("#ddlItemCode").select2({
            placeholder: "Select Lot/Registration No.",
            data: parentMenu
        });
        
    },
    //on change item name load
    LoadItemNameByItemCode: function () {
        debugger;
        var itemId = $("#ddlItemCode").val();
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Indent/LoadItemDetails",
            data: { itemId: itemId },
            success: function (response) {
                debugger;
                if (response.data.length != 0) {
                    $("#txtItemName")
                        .val(response.data[0].NameOfGun);
                    $("#txtProductSupplierName")
                        .val(response.data[0].SupplierName);

                } else {
                    $("#txtItemName")
                        .val("No Information Found.");
                    $("#txtProductSupplierName")
                        .val("No Information Found.");
                }


            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadCompositCode: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Indent/LoadCompositCode",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadCompositCodeDD: function () {
        debugger;
        var parentMenu = IndentHelper.LoadCompositCode();
        $("#ddlCompositeCode").select2({
            placeholder: "Select Composite Code",
            data: parentMenu
        });
    },

    LoadCompositNameByCompositId: function () {
        debugger;
        var compositCodeId = $("#ddlCompositeCode").val();
        var b = [];
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Indent/LoadCompositNameByCompositId",
            data: { compositCodeId: compositCodeId },
            success: function (response) {
                debugger;
                if (response.data.length != 0) {
                    $("#txtCompositeName")
                        .val(response.data[0].CompositeName);

                } else {
                    $("#txtCompositeName")
                        .val("No Information Found.");
                }


            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    //ident type load
    LoadIndentType: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Indent/LoadIndentType",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadIndentTypeDD: function () {
        debugger;
        var parentMenu = IndentHelper.LoadIndentType();
        $("#ddlIndentType").select2({
            placeholder: "Select Indent Type",
            data: parentMenu
        });
    },

    //load local agents
    LoadLocalAgents: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Indent/",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadLocalAgentsDD: function () {
        debugger;
        var parentMenu = IndentHelper.LoadLocalAgents();
        $("#ddlProductSupplierName").select2({
            placeholder: "Select Product Supplier Name",
            data: parentMenu
        });
    },

    CheckIsitAnAmmo: function () {

        var itemId = $("#ddlItemCode").val();
        $.ajax({
            type: "Get",
            dataType: "json",
            cache: true,
            async: false,
            url: "/Indent/CheckIsItAmmo",
            data: { itemId: itemId },
            success: function (response) {
                debugger;
                if (response.data == true) {
                    debugger;
                    $("#txtIdentQuantiryDiv").show();
                }

            },
            error: function (response) {

            }
        });
    },



    ClearField: function () {

        $("#hdnIndentId").val("");
        $("#ddlIndentType").val("").trigger("change");
        $("#txtProgramId").val("");
        $("#txtIndentNo").val("");
        $("#ddlIndentFrom").val("").trigger("change");
        $("#ddlIssuePerson").val("").trigger("change");
        $("#ddlItemCode").val("").trigger("change");
        $("#ddlCompositeCode").val("").trigger("change");
        $("#txtIdentQuantiry").val("");
        $("#dateOfIndentValidity").val("");
        $("#txtOtherOptions").val("");
        //aObj.Remarks = $("#txtInspectionMethod").val();
        //aObj.IndentStatusId = $("#txtInspectionBy").val();
        //aObj.IndentStatusDate = $("#txtCommence").val();

        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#btnSubmit").html("Save");
    },


    GetIndentData: function () {
        debugger;
        var aObj = new Object();

        aObj.IndentId = $("#hdnIndentId").val();
        aObj.IndentType = $("#ddlIndentType").val();
        aObj.ProgramId = $("#txtProgramId").val();
        aObj.IndentNo = $("#txtIndentNo").val();
        aObj.IndentFrom = $("#ddlIndentFrom").val();
        aObj.IssueTo = $("#ddlIssuePerson").val();
        aObj.ItemId = $("#ddlItemCode").val();
        aObj.CompositeId = $("#ddlCompositeCode").val();
        aObj.IndentQuantity = $("#txtIdentQuantiry").val();
        aObj.IndentValidity = $("#dateOfIndentValidity").val();
        aObj.OtherOptions = $("#txtOtherOptions").val();
        //aObj.Remarks = $("#txtInspectionMethod").val();
        //aObj.IndentStatusId = $("#txtInspectionBy").val();
        //aObj.IndentStatusDate = $("#txtCommence").val();

        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();

        return aObj;
    }



};