$(document).ready(function () {
    $("#chkIsActive").prop("checked", true);

    TrainingInfoHelper.InitTrainingInfo();
    viewTrainingInfo.GetTrainingInfoDataTable();
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
        viewTrainingInfoHelper.populateDataForEditButton(data);
    });

});