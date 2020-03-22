var ProfileHelper = {

    InitProfile: function () {
        $("#btnSave").unbind("click").click(function () {
            debugger;
            CreateProfileManager.IsDuplicateProfile(ProfileHelper.GetProfileData());
        });
        $("#btnDelete").unbind("click").click(function () {
            debugger;
            CreateProfileManager.DeleteProfile(ProfileHelper.GetProfileData());
        });

        $("#btnReset").unbind("click").click(function () {
            ProfileHelper.ClearField();
        });



        //=============Main DDL=============
        ProfileHelper.LoadBatchDDL();
        ProfileHelper.LoadRankDDL();
        ProfileHelper.LoadTradeDDL();
        ProfileHelper.LoadGenderDDL();
        ProfileHelper.LoadBloodGroupDDL();
        ProfileHelper.LoadHeightDDL();
        ProfileHelper.LoadRelligionDDL();
        ProfileHelper.LoadUnitDDL();

        ProfileHelper.LoadGarrisonDDL();
        
        //==========Address DDL=================


        ProfileHelper.LoadDivisionDDL();
        ProfileHelper.LoadDistrictDDL();
        ProfileHelper.LoadUpazilaDDL();
        ProfileHelper.LoadPoliceStationDDL();
        ProfileHelper.LoadPostOfficeDDL();
        ProfileHelper.LoadVillageDDL();


        //==========Family DDL=================
        ProfileHelper.LoadRelationDDL();

        //==========Degree/Certificate DDL=================
        ProfileHelper.LoadDegreeDDL();
        ProfileHelper.LoadGroupDDL();
        ProfileHelper.LoadSubjectDDL();
        ProfileHelper.LoadResultDDL();
        ProfileHelper.LoadBoardDDL();

    },

    GetProfileData: function () {
        var aObj = new Object();
        ////debugger;
        aObj.IsVerified = $("#hdnIsVerified").val();
        aObj.EntryBy = $("#hdnEntryBy").val();
        aObj.EntryDateTime = $("#hdnEntryDate").val();
        aObj.Army_id = $("#hdnArmyId").val();
        aObj.RecordStatus = $("#hdnRecordStatus").val();

        aObj.BatchId = $("#ddlBatchNo").val();
        aObj.Army_no = $("#txtArmyNo").val();
        aObj.Army_name = $("#txtName").val();
        aObj.AI = $("#ddlAI288").val();
        aObj.AI13 = $("#ddlAI12013").val();
        aObj.Rank_id = $("#ddlRank").val();
        aObj.Trade_id = $("#ddlTrade").val();
        aObj.NedCat = $("#ddlNedCat").val();
        aObj.DOB = $("#txtDoB").val();
        aObj.Enr_date = $("#txtDoE").val();
        aObj.DoA = $("#txtDoA").val();
        aObj.GenderId = $("#ddlGender").val();
        aObj.blood_gp = $("#ddlBloodGroup").val();
        aObj.height = $("#ddlHeightInch").val();
        aObj.religion = $("#ddlRelligion").val();
        aObj.UnitId = $("#ddlPresentUnit").val();
        aObj.GarrisonId = $("#ddlGarrison").val();
        aObj.Photo = $("#getFile").val().replace(/C:\\fakepath\\/i, "/Uploads/Photo/");


        // Address
        aObj.AddressId = $("#hdnAddressId").val();
        aObj.DivisionId = $("#ddlDivision").val();
        aObj.DistrictId = $("#ddlDistrict").val();
        aObj.UpazilaId = $("#ddlUpazila").val();
        aObj.PoliceStationId = $("#ddlPoliceStation").val();
        aObj.PostOfficeId = $("#ddlPostOffice").val();
        aObj.PostCode = $("#txtPostCode").val();
        aObj.VillageId = $("#ddlVillage").val();
        aObj.FromDate = $("#txtFromDate").val();

        return aObj;
    },

    ClearField: function () {
        debugger;
        $("#btnDeleteGarrison").hide();
        $("#btnSaveGarrison").show();
        $("#hdnIsVerifiedGarrison").val("0");
        $("#hdnGarrisonId").val("0");
        $("#hdnEntryByGarrison").val("0");
        $("#hdnEntryDateGarrison").val("0");

        $("#hdnArmyId").val("0");

        $("#ddlBatchNo").val("").trigger("change");
        $("#txtArmyNo").val("");
        $("#txtName").val("");
        $("#ddlRank").val("").trigger("change");
        $("#ddlTrade").val("").trigger("change");
        $("#ddlAI288").val("").trigger("change");
        $("#ddlAI12013").val("").trigger("change");
        $("#ddlNedCat").val("").trigger("change");
        $("#txtDoB").val("");
        $("#txtDoE").val("");
        $("#txtDoA").val("");
        $("#ddlGender").val("").trigger("change");
        $("#ddlBloodGroup").val("").trigger("change");
        $("#ddlHeightInch").val("").trigger("change");
        $("#ddlRelligion").val("").trigger("change");
        $("#ddlPresentUnit").val("").trigger("change");
        $("#ddlGarrison").val("").trigger("change");

        $("#ddlGarrison").val("").trigger("change");
        $("#btnSaveGarrison").html("Save");


        //Address
        $("#hdnIsVerifiedAddress").val("0");
        $("#hdnEntryByAddress").val("0");
        $("#hdnEntryDateAddress").val("0");
        $("#hdnAddressId").val("0");

        $("#ddlDivision").val("").trigger("change");
        $("#ddlDistrict").val("").trigger("change");
        $("#ddlUpazila").val("").trigger("change");
        $("#ddlPoliceStation").val("").trigger("change");
        $("#ddlPostOffice").val("").trigger("change");
        $("#txtPostCode").val("").trigger("change");
        $("#ddlVillage").val("").trigger("change");
        $("#txtFromDate").val("").trigger("change");
    },

    LoadBatchDDL: function () {
        ////debugger;
        var batch = CreateProfileManager.LoadBatch();
        $("#ddlBatchNo").select2({
            placeholder: "Select Batch",
            data: batch
        });
    },

    LoadRankDDL: function () {
        ////debugger;
        var rank = CreateProfileManager.LoadRank();
        $("#ddlRank").select2({
            placeholder: "Select Rank",
            data: rank
        });
    },

    LoadTradeDDL: function () {
        ////debugger;
        var trade = CreateProfileManager.LoadTrade();
        $("#ddlTrade").select2({
            placeholder: "Select Trade",
            data: trade
        });
    },

    LoadGenderDDL: function () {
        ////debugger;
        var gender = CreateProfileManager.LoadGender();
        $("#ddlGender").select2({
            placeholder: "Select Gender",
            data: gender
        });
        $("#ddlGenderFamily").select2({
            placeholder: "Select Gender",
            data: gender
        });
    },

    LoadBloodGroupDDL: function () {
        ////debugger;
        var bg = CreateProfileManager.LoadBloodGroup();
        $("#ddlBloodGroup").select2({
            placeholder: "Select Blood Group",
            data: bg
        });
        $("#ddlBloodGroupFamily").select2({
            placeholder: "Select Blood Group",
            data: bg
        });
    },

    LoadHeightDDL: function () {
        ////debugger;
        var height = CreateProfileManager.LoadHeight();
        $("#ddlHeightInch").select2({
            placeholder: "Select Height",
            data: height
        });
    },

    LoadRelligionDDL: function () {
        ////debugger;
        var relligion = CreateProfileManager.LoadRelligion();
        $("#ddlRelligion").select2({
            placeholder: "Select Relligion",
            data: relligion
        });
    },

    LoadUnitDDL: function () {
        ////debugger;
        var unit = CreateProfileManager.LoadUnit();
        $("#ddlPresentUnit").select2({
            placeholder: "Select Unit",
            data: unit
        });
    },

    LoadGarrisonDDL: function () {
        ////debugger;
        var garrison = CreateProfileManager.LoadGarrison();
        $("#ddlGarrison").select2({
            placeholder: "Select garrison",
            data: garrison
        });
    },


    //==========Address DDL=================


    LoadDivisionDDL: function () {
        ////debugger;
        var division = CreateProfileManager.LoadDivision();
        $("#ddlDivision").select2({
            placeholder: "Select Division",
            data: division
        });
    },
    LoadDistrictDDL: function () {
        //debugger;
        //var district = CreateProfileManager.LoadDistrict();
        $("#ddlDistrict").select2({
            placeholder: "Select Division First",
            //data: district
        });
    },
    LoadDistrictByDivisionDDL: function () {

        $("#ddlDistrict").empty();
        $("#ddlDistrict").append(
            $("<option></option>")
        );
        ////debugger;
        var district = CreateProfileManager.LoadDistrictByDivision();
        ////debugger;
        $("#ddlDistrict").select2({
            placeholder: "Select a District",
            data: district
        });
        $("#ddlDistrict").select2("val", "");
    },
    LoadUpazilaDDL: function () {
        ////debugger;
        //var upazila = CreateProfileManager.LoadUpazila();
        $("#ddlUpazila").select2({
            placeholder: "Select District First",
            //data: upazila
        });
    },
    LoadUpazillaByDistrictDDL: function () {

        $("#ddlUpazila").empty();

        $("#ddlUpazila").append(
            $("<option></option>")
        );
        var upazila = CreateProfileManager.LoadUpazilaByDistrict();
        $("#ddlUpazila").select2({
            placeholder: "Select a Upazilla",
            data: upazila
        });
        $("#ddlUpazila").select2("val", "");
    },
    LoadPoliceStationDDL: function () {
        ////debugger;
        //var ps = CreateProfileManager.LoadPoliceStation();
        $("#ddlPoliceStation").select2({
            placeholder: "Select Upazila First",
            //data: ps
        });
    },
    LoadPoliceStationByUpazillaDDL: function () {

        $("#ddlPoliceStation").empty();
        $("#ddlPoliceStation").append(
            $("<option></option>")
        );
        var policeStation = CreateProfileManager.LoadPoliceStationByUpazilla();
        $("#ddlPoliceStation").select2({
            placeholder: "Select a Police Station",
            data: policeStation
        });
        $("#ddlPoliceStation").select2("val", "");
    },
    LoadPostOfficeDDL: function () {
        ////debugger;
        //var po = CreateProfileManager.LoadPostOffice();
        $("#ddlPostOffice").select2({
            placeholder: "Select Police Station First",
            //data: po
        });
    },
    LoadPostOfficeByPoliceStationDDL: function () {

        $("#ddlPostOffice").empty();
        $("#ddlPostOffice").append(
            $("<option></option>")
        );
        var postOffice = CreateProfileManager.LoadPostOfficeByPoliceStation();
        $("#ddlPostOffice").select2({
            placeholder: "Select a Post Office",
            data: postOffice
        });
        $("#ddlPostOffice").select2("val", "");

        $("#txtPostCode").val("");
    },
    LoadVillageDDL: function () {
        ////debugger;
        //var village = CreateProfileManager.LoadVillage();
        $("#ddlVillage").select2({
            placeholder: "Select Postoffice First",
            //data: village
        });
    },
    LoadVillageByPostOfficeDDL: function () {

        $("#ddlVillage").empty();
        $("#ddlVillage").append(
            $("<option></option>")
        );
        var village = CreateProfileManager.LoadVillageByPostOffice();




        $("#ddlVillage").select2({
            placeholder: "Select a Village",
            data: village
        });
        $("#ddlVillage").select2("val", "");
    },




    //==========Family DDL=================

    LoadRelationDDL: function () {
        ////debugger;
        var relation = CreateProfileManager.LoadRelation();
        $("#ddlRelation").select2({
            placeholder: "Select Relation",
            data: relation
        });
    },

    //==========Education DDL=================

    LoadDegreeDDL: function () {
        ////debugger;
        var degree = CreateProfileManager.LoadDegree();
        $("#ddlDegree").select2({
            placeholder: "Select Degree",
            data: degree
        });
    },


    LoadGroupDDL: function () {
        ////debugger;
        var group = CreateProfileManager.LoadGroup();
        $("#ddlGroup").select2({
            placeholder: "Select Group",
            data: group
        });
    },

    LoadSubjectDDL: function () {
        ////debugger;
        var subject = CreateProfileManager.LoadSubject();
        $("#ddlSubject").select2({
            placeholder: "Select Subject",
            data: subject
        });
    },

    LoadResultDDL: function () {
        ////debugger;
        var result = CreateProfileManager.LoadResult();
        $("#ddlResult").select2({
            placeholder: "Select Result",
            data: result
        });
    },

    LoadBoardDDL: function () {
        ////debugger;
        var board = CreateProfileManager.LoadResult();
        $("#ddlEducationBoard").select2({
            placeholder: "Select Board/University",
            data: board
        });
    },

};

var CreateProfileManager = {



    SaveProfile: function (aObj) {
        ////debugger;
        $.ajax({
            type: "POST",
            url: "/IndividualProfileEntry/CreateProfile",
            data: JSON.stringify(aObj),

            success: function (response) {
                ProfileHelper.ClearField();
                window.viewProfile.GetProfileDataTable();
                if (response != null) {
                    CreateProfileManager.SaveProfilePhotoEntry();
                    alert("Data Saved Successfully");

                    $("#myModal #modal-body #headerId").html(response.data.message);

                    //alert("Data Saved Successfully...!");
                    $("#myModal").appendTo("body").modal("show");

                    //todo get data table refreshed..

                    setTimeout(function () {
                        $("#myModal").modal("hide");
                    }, 2000);

                    if (response.data.status) {
                        //todo clear form..

                        $("#btnSaveProfile").html("Save");
                    }
                }
            },
            error: function (response) {
                alert("Data Save Failed...!");

                $("#dialog_simple").html(response.data.Message);
                $("#dialog_simple").dialog("open");
                setTimeout(function () {
                    $("#myModal").modal("hide");
                }, 2000);
            },
            dataType: "json",
            contentType: "application/json"
        });
    },

    SaveProfilePhotoEntry: function () {

        var files = $("#getFile").get(0).files;
        var fileData = new FormData();

        for (var i = 0; i < files.length; i++) {
            fileData.append("getFile", files[i]);
        }

        $.ajax({
            type: "POST",
            url: "/IndividualProfileEntry/UploadPhoto",
            dataType: "json",
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            data: fileData,
            success: function (result, status, xhr) {
                alert(result);
            },
            error: function (xhr, status, error) {
                alert(status);
            }
        });
    },

    IsDuplicateProfile: function (aObj) {

        ////debugger;
        $.ajax({
            type: "POST",
            url: "/IndividualProfileEntry/IsDuplicateProfile",

            data: JSON.stringify(aObj),
            success: function (response) {
                //////debugger;
                if (response.data == true) {
                    ProfileHelper.ClearField();
                    alert("The Profile is already exist.");

                } else if (response.data == false) {
                    CreateProfileManager.SaveProfile(ProfileHelper.GetProfileData());
                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"

        });
    },

    DeleteProfile: function (aObj) {
        ////debugger;
        $.ajax({
            type: "POST",
            url: "/IndividualProfileEntry/DeleteProfile",
            data: JSON.stringify(aObj),

            success: function (response) {
                ProfileHelper.ClearField();
                window.viewProfile.GetProfileDataTable();
                if (response != null) {
                    //todo get data table refreshed..

                    if (response.data.status) {
                        //todo clear form..

                        $("#btnSave").html("Save");
                    }
                }
            },
            error: function (response) {

            },
            dataType: "json",
            contentType: "application/json"
        });
    },



    //============Main DDL================

    LoadBatch: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadBatch",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadRank: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadRank",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadTrade: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadTrade",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadGender: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadGender",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {

                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadBloodGroup: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadBloodGroup",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadHeight: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadHeight",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadRelligion: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadRelligion",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadUnit: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadUnit",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadGarrison: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadGarrison",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadGarrisonAgainstUnit: function () {
        var b = [];
        //////debugger;
        var UnitId = $("#ddlPresentUnit").val();
        $.ajax({
            url: "/IndividualProfileEntry/LoadGarrisonAgainstUnit",
            type: "POST",
            data: JSON.stringify({ UnitId: UnitId }),
            dataType: "json",
            contentType: "application/json;charset:utf-8",
            success: function (data) {
                //////debugger;
                b = data.data;
                $("#txtGarrison").val(b[0].GarName);
            }
        });
    },





    //==========Address DDL=================

    LoadDivision: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadDivision",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadDistrict: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadDistrict",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadDistrictByDivision: function () {
        ////debugger;
        var divId = $("#ddlDivision").val();
        var b = [];

        $.ajax({
            url: "/IndividualProfileEntry/LoadDistrictAgainstDivision",
            type: "POST",
            dataType: "json",
            data: JSON.stringify({ divId: divId }),
            cache: true,
            async: false,
            contentType: "application/json;charset:utf-8",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadUpazila: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadUpazila",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadUpazilaByDistrict: function () {
        ////debugger;
        var disId = $("#ddlDistrict").val();
        var b = [];

        $.ajax({
            url: "/IndividualProfileEntry/LoadUpazilaAgainstDistrict",
            type: "POST",
            dataType: "json",
            cache: true,
            async: false,
            data: JSON.stringify({ disId: disId }),
            contentType: "application/json;charset:utf-8",
            success: function (response) {
                ////debugger;
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadPoliceStation: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadPoliceStation",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadPoliceStationByUpazilla: function () {
        ////debugger;
        var upzId = $("#ddlUpazila").val();
        var b = [];

        $.ajax({
            url: "/IndividualProfileEntry/LoadPoliceStationAgainstUpazila",
            type: "POST",
            dataType: "json",
            cache: true,
            async: false,
            data: JSON.stringify({ upzId: upzId }),
            contentType: "application/json;charset:utf-8",
            success: function (response) {
                ////debugger;
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadPostOffice: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadPostOffice",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadPostOfficeByPoliceStation: function () {
        //debugger;
        var psId = $("#ddlPoliceStation").val();
        var b = [];

        $.ajax({
            url: "/IndividualProfileEntry/LoadPostOfficeAgainstPoliceStation",
            type: "POST",
            dataType: "json",
            cache: true,
            async: false,
            data: JSON.stringify({ psId: psId }),
            contentType: "application/json;charset:utf-8",
            success: function (response) {
                //debugger;
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadVillage: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadVillage",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadVillageByPostOffice: function () {
        ////debugger;
        var poId = $("#ddlPostOffice").val();
        var b = [];

        $.ajax({
            url: "/IndividualProfileEntry/LoadVillageAgainstPostOffice",
            type: "POST",
            dataType: "json",
            cache: true,
            async: false,
            data: JSON.stringify({ poId: poId }),
            contentType: "application/json;charset:utf-8",
            success: function (response) {
                debugger;
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },
    //extra 
    LoadPostCodeAgainstPostOffice: function () {
        var b = [];
        ////debugger;
        var poId = $("#ddlPostOffice").val();
        $.ajax({
            url: "/IndividualProfileEntry/LoadPostCodeAgainstPostOffice",
            type: "POST",
            data: JSON.stringify({ poId: poId }),
            dataType: "json",
            contentType: "application/json;charset:utf-8",
            success: function (data) {
                ////debugger;
                b = data.data;
                $("#txtPostCode").val(b[0].PoCode);
            }
        });
    },








    //==========Family DDL=================

    LoadRelation: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadRelation",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    //==========Education DDL=================

    LoadDegree: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadDegree",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadGroup: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadGroup",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadSubject: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadSubject",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadResult: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadResult",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

    LoadBoard: function () {
        ////debugger;
        var b = [];
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: true,
            async: false,
            url: "/IndividualProfileEntry/LoadBoard",
            success: function (response) {
                b = response.data;
            },
            error: function (response) {
                b = { id: 0, text: "No Data" }
            }
        });
        return b;
    },

};


