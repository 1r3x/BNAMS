var viewProfile = {

    GetProfileDataTable: function () {
        $("#dataTable").dataTable().fnDestroy();
        $("#dataTable").DataTable({

            "scrollX": true,
            "ajax": {
                "url": "/IndividualProfileEntry/GetAllProfile",
                "type": "GET",
                "datatype": "json",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                { "data": "BatchName", "width": "50px" },
                { "data": "Army_no", "autoWidth": true },
                { "data": "Army_name", "width": "50px" },
                { "data": "RankName", "width": "50px" },
                { "data": "TradeName", "width": "150px" },
                {
                    "data": "Enr_date", "width": "50px",
                    "type": "date ",
                    "render": function (value) {
                        if (value === null) return "";

                        var pattern = /Date\(([^)]+)\)/;
                        var results = pattern.exec(value);
                        var dt = new Date(parseFloat(results[1]));

                        return dt.getDate() + "-" + (dt.getMonth() + 1) + "-" + dt.getFullYear();
                    }

                },
                { "data": "RecordStatus", "width": "30px" },
            ],

            "columnDefs": [

                {
                    targets: [6],

                    render: function (data, type, row) {

                        if (row.RecordStatus == 1 && row.IsVerified == false) {
                            if (row.EntryBy == window.userId) {
                                return "<button id='btnEdit' type='button' class='btn btn-primary' disabled>EDIT</button>";
                            }
                            return "<button id='btnEdit' type='button' class='btn btn-primary'>VERIFY</button>";
                        }
                        else if (row.RecordStatus == 2 && row.IsVerified == false) {
                            if (row.EntryBy == window.userId) {
                                return "<button id='btnEdit' type='button' class='btn btn-primary' disabled>EDIT</button>";
                            }
                            return "<button id='btnEdit' type='button' class='btn btn-primary'>VERIFY</button>";
                        }
                        else if (row.RecordStatus == 3 && row.IsVerified == false) {
                            if (row.EntryBy == window.userId) {
                                return "<button id='btnDelete' type='button' class='btn btn-danger' disabled>DELETE</button>";
                            }
                            return "<button id='btnDelete' type='button' class='btn btn-danger'>DELETE Verify</button>";
                        } else {
                            return "<button id='btnEdit' type='button' class='btn btn-primary'>EDIT</button> <button id='btnDelete' type='button' class='btn btn-danger'>DELETE</button>";
                        }
                    }
                }

            ],

        });

    }

}

var viewProfileHelper = {



    JsondateConvert: function (rawDate) {

        var jsonDate = new Date(parseInt(rawDate.substr(6)));
        var cJsonDate = (jsonDate.getMonth() + 1) + "-" + jsonDate.getDate() + "-" + jsonDate.getFullYear();
        return cJsonDate;
    },

    populateDataForEditButton: function (aObj) {

        debugger;
        $("#hdnArmyId").val(aObj.Army_id);
        $("#hdnEntryBy").val(aObj.EntryBy);

        //convertion..
        var jsonDate = new Date(parseInt(aObj.EntryDateTime.substr(6)));
        var cJsonDate = (jsonDate.getMonth() + 1) + "-" + jsonDate.getDate() + "-" + jsonDate.getFullYear();
        //convert end

        $("#hdnEntryDate").val(cJsonDate);
        $("#hdnIsVerified").val(aObj.IsVerified);

        $("#ddlBatchNo").val(aObj.BatchId).trigger("change");
        $("#txtArmyNo").val(aObj.Army_no);
        $("#txtName").val(aObj.Army_name);
        $("#ddlRank").val(aObj.Rank_id).trigger("change");
        $("#ddlTrade").val(aObj.Trade_id).trigger("change");
        $("#ddlAI288").val(aObj.AI).trigger("change");
        $("#ddlAI12013").val(aObj.AI13).trigger("change");
        $("#ddlNedCat").val(aObj.NedCat).trigger("change");
        $("#txtDoB").val(viewProfileHelper.JsondateConvert(aObj.DOB));
        $("#txtDoE").val(viewProfileHelper.JsondateConvert(aObj.Enr_date));
        $("#txtDoA").val(viewProfileHelper.JsondateConvert(aObj.DoA));
        $("#ddlGender").val(aObj.GenderId).trigger("change");
        $("#ddlBloodGroup").val(aObj.blood_gp).trigger("change");
        $("#ddlHeightInch").val(aObj.height).trigger("change");
        $("#ddlRelligion").val(aObj.religion).trigger("change");
        $("#ddlPresentUnit").val(aObj.UnitId).trigger("change");
        $("#ddlGarrison").val(aObj.GarrisonId).trigger("change");

       




        //Address Section will be added here
        $("#ddlDivision").val(aObj.DivisionId).trigger("change");
        $("#ddlDistrict").val(aObj.DistrictId).trigger("change");
        $("#ddlUpazila").val(aObj.UpazilaId).trigger("change");
        $("#ddlPoliceStation").val(aObj.PoliceStationId).trigger("change");
        $("#ddlPostOffice").val(aObj.PostOfficeId).trigger("change");
        $("#txtPostCode").val(aObj.PostCode);
        $("#ddlVillage").val(aObj.VillageId).trigger("change");
        $("#txtFromDate").val(viewProfileHelper.JsondateConvert(aObj.FromDate));
        

    },
    populateDataForDeleteButton: function (aObj) {
        debugger;
        $("#hdnArmyId").val(aObj.Army_id);
        $("#hdnEntryBy").val(aObj.EntryBy);

        //convertion..
        var jsonDate = new Date(parseInt(aObj.EntryDateTime.substr(6)));
        var cJsonDate = (jsonDate.getMonth() + 1) + "-" + jsonDate.getDate() + "-" + jsonDate.getFullYear();
        //convert end

        $("#hdnEntryDate").val(cJsonDate);
        $("#hdnIsVerified").val(aObj.IsVerified);

        $("#ddlBatchNo").val(aObj.BatchId).trigger("change");
        $("#txtArmyNo").val(aObj.Army_no);
        $("#txtName").val(aObj.Army_name);
        $("#ddlRank").val(aObj.Rank_id).trigger("change");
        $("#ddlTrade").val(aObj.Trade_id).trigger("change");
        $("#ddlAI288").val(aObj.AI).trigger("change");
        $("#ddlAI12013").val(aObj.AI13).trigger("change");
        $("#ddlNedCat").val(aObj.NedCat).trigger("change");
        $("#txtDoB").val(viewProfileHelper.JsondateConvert(aObj.DOB));
        $("#txtDoE").val(viewProfileHelper.JsondateConvert(aObj.Enr_date));
        $("#txtDoA").val(viewProfileHelper.JsondateConvert(aObj.DoA));
        $("#ddlGender").val(aObj.GenderId).trigger("change");
        $("#ddlBloodGroup").val(aObj.blood_gp).trigger("change");
        $("#ddlHeightInch").val(aObj.height).trigger("change");
        $("#ddlRelligion").val(aObj.religion).trigger("change");
        $("#ddlPresentUnit").val(aObj.UnitId).trigger("change");
        $("#ddlGarrison").val(aObj.GarrisonId).trigger("change");






        //Address Section will be added here
        $("#ddlDivision").val(aObj.DivisionId).trigger("change");
        $("#ddlDistrict").val(aObj.DistrictId).trigger("change");
        $("#ddlUpazila").val(aObj.UpazilaId).trigger("change");
        $("#ddlPoliceStation").val(aObj.PoliceStationId).trigger("change");
        $("#ddlPostOffice").val(aObj.PostOfficeId).trigger("change");
        $("#txtPostCode").val(aObj.PostCode);
        $("#ddlVillage").val(aObj.VillageId).trigger("change");
        $("#txtFromDate").val(viewProfileHelper.JsondateConvert(aObj.FromDate));


        $("#btnDelete").show();
        $("#btnSave").hide();


    }
}