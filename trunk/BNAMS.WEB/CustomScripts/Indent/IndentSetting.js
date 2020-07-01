$(document).ready(function () {
    debugger;

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
        $("#btnSubmit").html("Update");
        topFunction();
        var table = $("#dataTable").DataTable();
        var data = table.row($(this).parents("tr")).data();
        viewIndentHelper.populateDataForEditButton(data);
    });

    $("#ddlIndentFrom").change(function () {
        if ($("#ddlIndentFrom").val()!="") {

            IndentHelper.LoadItemCodeDD();
        }
    });

    $("#ddlItemCode").change(function () {
        if ($("#ddlIndentFrom").val()!= "") {

            IndentHelper.LoadItemNameByItemCode();
            IndentHelper.CheckIsitAnAmmo();
        }
       
    });

    $("#ddlCompositeCode").change(function () {
        if ($("#ddlIndentFrom").val() != "") {
            IndentHelper.LoadCompositNameByCompositId();
        }
        
    });


    $("#ddlIssuePerson").change(function () {
        if ($("#ddlIndentFrom").val() != "") {
            IndentHelper.CheckIsItSameId();
        }

        
    });
    $("#ddlIndentFrom").change(function () {
        if ($("#ddlIssuePerson").val() != "") {
            IndentHelper.CheckIsItSameId();
        }


    });


});