
var CreateProductCategoryManager = {

    SaveProductCategory: function () {
        debugger;
        if ($("#txtProductCategoryName").val()=="") {
            toastr.warning("Category Name is Required.");
        }
       
        else {
            $.ajax({
                type: "POST",
                url: "/ProductCategory/CreateProductCaegoryMasterSetup",
                data: JSON.stringify(ProductCategoryHelper.GetProductCategoryData()),
                success: function (response) {
                    debugger;
                    if (response != null) {

                        toastr.success(response.data.Message);
                        viewProductCategory.GetProductCategoryDataTable();
                        ProductCategoryHelper.ClearField();
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

    IsDuplicate: function () {
        $.ajax({
            type: "POST",
            url: "/ProductCategory/IsDuplicate",

            data: JSON.stringify(ProductCategoryHelper.GetProductCategoryData()),
            success: function (response) {
                debugger;
                if (response.data.Status == true) {
                    toastr.warning(response.data.Message);

                } else if (response.data.Status == false) {
                    CreateProductCategoryManager.SaveProductCategory();

                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    }

};


var ProductCategoryHelper = {
    InitProductCategory: function () {

        $("#btnSubmit").unbind("click").click(function () {
            CreateProductCategoryManager.IsDuplicate();
            //ProductCategoryHelper.ClearField();

        });
        $("#btnCancel").unbind("click").click(function () {
            ProductCategoryHelper.ClearField();
        });
    },



    ClearField: function () {
        debugger;
        $("#hdnProductCategoryId").val("0");
        $("#txtProductCategoryName").val("");
        $("#hdnSetupBy").val("");
        $("#hdnSetupDateTime").val("");
        $("#chkIsActive").removeAttr("checked", "checked");
        $("#btnSubmit").html("Save");
    },


    GetProductCategoryData: function () {
        debugger;
        var aObj = new Object();
        aObj.ProductCategoryId = $("#hdnProductCategoryId").val();
        aObj.ProductCtegoryName = $("#txtProductCategoryName").val();
        aObj.SetUpBy = $("#hdnSetupBy").val();
        aObj.SetUpDateTime = $("#hdnSetupDateTime").val();
        aObj.IsActive = ($("#chkIsActive").prop("checked") == true) ? 1 : 0;
        return aObj;
    }
};