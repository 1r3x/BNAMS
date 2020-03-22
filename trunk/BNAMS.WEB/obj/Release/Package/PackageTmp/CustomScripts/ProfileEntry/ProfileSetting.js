$(document).ready(function () {
    $("#btnDelete").hide();
    window.ProfileHelper.InitProfile();


    //ddl on cgange Event 
    //postcode load 
    $("#ddlPostOffice").on("change", function (e) {
        CreateProfileManager.LoadPostCodeAgainstPostOffice();
    });

    //cascading dropdown

    $("#ddlDivision").on("change", function (e) {
        ProfileHelper.LoadDistrictByDivisionDDL();
    });

    $("#ddlDistrict").on("change", function (e) {
        ProfileHelper.LoadUpazillaByDistrictDDL();
    });

    $("#ddlUpazila").on("change", function (e) {
        debugger;
        ProfileHelper.LoadPoliceStationByUpazillaDDL();
    });

    $("#ddlPoliceStation").on("change", function (e) {
        debugger;
        ProfileHelper.LoadPostOfficeByPoliceStationDDL();
    });

    $("#ddlPostOffice").on("change", function (e) {
        debugger;
        ProfileHelper.LoadVillageByPostOfficeDDL();
    }); 




    //end of events






    //set the test boxes
    $("#dataTable tfoot th").each(function () {
        debugger;
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    //Load data table
    window.viewProfile.GetProfileDataTable();

    // DataTable
    var table = $("#dataTable").DataTable();

    // Apply the search
    table.columns().every(function () {
        debugger;
        var that = this;

        $("input", this.footer()).on("keyup change clear", function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });


    //this function is for go to top of the page
    function topFunction() {
        //for safari 
        document.body.scrollTop = 0;
        //for others browsers
        document.documentElement.scrollTop = 0;
    }

    $("#dataTable tbody").on("click", "#btnEdit", function (e) {

        topFunction();
        var table = $("#dataTable").DataTable();
        var data = table.row($(this).parents("tr")).data();
        debugger;
        if (data.EntryBy == window.userId) {
            if (data.IsVerified == true) {
                window.viewProfileHelper.populateDataForEditButton(data);
                $("#btnSave").html("Update");
            } else {
                alert("Data Not yet Verified");
            }
        } else {
            if (data.IsVerified == true) {
                window.viewProfileHelper.populateDataForEditButton(data);
                $("#btnSave").html("Update");
            } else {
                window.viewProfileHelper.populateDataForEditButton(data);
                $("#btnSave").html("Verify");
            }

        }


    });

    $("#dataTable tbody").on("click", "#btnDelete", function (e) {

        topFunction();
        var table = $("#dataTable").DataTable();
        var data = table.row($(this).parents("tr")).data();
        window.viewProfileHelper.populateDataForDeleteButton(data);

    });

    $(".date").datepicker({
        format: "dd/mm/yyyy"
    });


    //Load Passing Year

    var select = "";
    for (i = 1990; i <= 2019; i++) {
        select += "<option val=" + i + ">" + i + "</option>";
    }
    $("#ddlYear").html(select);

    //Result Validation:
    $("#txtGPA").prop("disabled", true);
    $("#ddlOutOf").prop("disabled", true);

    $("#ddlResult").change(function () {
        if ($("#ddlResult").val() == "11") {
            $("#txtGPA").prop("disabled", false);
            $("#ddlOutOf").prop("disabled", false);
        }
        else {
            $("#txtGPA").prop("disabled", true);
            $("#ddlOutOf").prop("disabled", true);

            $("#txtGPA").val("");
            $("#ddlOutOf").val("");
        }
    });

});

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $("#imgPhoto")
                .attr("src", e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

function readURLFamily(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $("#imgPhotoFamily")
                .attr("src", e.target.result);
        };

        reader.readAsDataURL(input.files[0]);
    }
}
