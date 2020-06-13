
var CreateBinLocationSetupManager = {
    SaveBinLocationSetup: function () {
        debugger;
        if ($("#txtBinLocationName").val() == "") {
            toastr.warning("Ware House Name is Required.");
        } else {
            $.ajax({
                type: "POST",
                url: "/BinLocation/CreateBinLocation",
                data: JSON.stringify(BinLocationSetupHelper.GetBinLocationSetupData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewBinLocationSetup.GetBinLocationSetupDataTable();
                        BinLocationSetupHelper.ClearField();
                        $("#btnSubmit").html("Save");
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
            url: "/BinLocation/LoadWareHouseByCode",
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


var BinLocationSetupHelper = {
    InitBinLocationSetup: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateBinLocationSetupManager.SaveBinLocationSetup();

        });
        $("#btnCancel").unbind("click").click(function () {
            BinLocationSetupHelper.ClearField();
        });
    },

    LoadProductCategory: function () {
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/BinLocation/LoadProductCategory",
            success: function (response) {

                b = response.data;

            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadProductCategoryDD: function () {
        debugger;
        var parentMenu = BinLocationSetupHelper.LoadProductCategory();
        $("#ddlProductCategory").select2({
            placeholder: "Select Product Category",
            data: parentMenu
        });
    },



    ClearField: function () {
        debugger;
        //$("#hdnWareHouseId").val("0");
        //$("#txtWarehouseName").val("");
        //$("#txtWarehouseCode").val("");

        $("#hdnBinLocationId").val("0");
        $("#txtProgramName   ").val("");
        $("#dateProcess").val("");
        $("#txtWarehouseCode").val("");
        $("#txtWarehouseName").val("");
        $("#hdnWareHouseId").val("");
        $("#txtSehlfId").val("");
        $("#txtRowId").val("");
        $("#ddlProductCategory").val("").trigger("change");

        $("#hdnSetupBy").val();
        $("#hdnSetupDateTime").val();
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetBinLocationSetupData: function () {
        debugger;
        var aObj = new Object();

        aObj.BinLocationId = $("#hdnBinLocationId").val();
        aObj.ProgramName = $("#txtProgramName").val();
        aObj.ProcessDate = $("#dateProcess").val();
        aObj.WareHouseId = $("#hdnWareHouseId").val();
        aObj.SelfIdNo = $("#txtSehlfId").val();
        aObj.RowIdNo = $("#txtRowId").val();
        aObj.ProductCategoryId = $("#ddlProductCategory").val();

        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();

        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};