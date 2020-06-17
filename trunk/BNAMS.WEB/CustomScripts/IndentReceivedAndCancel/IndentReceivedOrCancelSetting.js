$(document).ready(function () {
    debugger;
    $("#btnSubmit").hide();
    $("#btnAbort").hide();
    $("#txtIdentQuantiryDiv").hide();
    IndentHelper.InitIndent();
    viewIndent.GetIndentDataTable();
   
    //this function is for go to top of the page
    function topFunction() {
        //for safari 
        document.body.scrollTop = 0;
        //for others browsers
        document.documentElement.scrollTop = 0;
    }

    $("#dataTable tbody").on("click", "#btnEdit", function (e) {
        //$("#btnSubmit").html("Update");
        $("#btnSubmit").show();
        $("#btnAbort").show();

        topFunction();
        var table = $("#dataTable").DataTable();
        var data = table.row($(this).parents("tr")).data();
        viewIndentHelper.populateDataForEditButton(data);
    });

    $("#ddlIndentFrom").change(function () {
        IndentHelper.LoadItemCodeDD();
    });

    $("#ddlItemCode").change(function () {
        IndentHelper.LoadItemNameByItemCode();
        IndentHelper.CheckIsitAnAmmo();
    });

    $("#ddlCompositeCode").change(function () {
        IndentHelper.LoadCompositNameByCompositId();
    });
   


});