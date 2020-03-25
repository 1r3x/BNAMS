using SR.Entities.ViewModels;

namespace BNAMS.Manager.Interface
{
    public interface IProfile
    {
        //==================Main Form=====================
        //Garrison
        ResponseModel CreateProfile(ProfileAddressViewModel aObj);
        ResponseModel IsDuplicateProfile(int army_id, int army_no);
        ResponseModel GetAllProfile();
        ResponseModel DeleteProfile(ProfileAddressViewModel aObj);
        ResponseModel LoadBatch();
        ResponseModel LoadRank();
        ResponseModel LoadTrade();
        ResponseModel LoadGender();
        ResponseModel LoadBloodGroup();
        ResponseModel LoadHeight();
        ResponseModel LoadRelligion();
        ResponseModel LoadUnit();
        ResponseModel LoadGarrison();
        ResponseModel LoadGarrisonAgainstUnit(int UnitId);

        //===============Address=============================
        ResponseModel LoadDivision();
        ResponseModel LoadDistrict();
        ResponseModel LoadDistrictAgainstDivision(int DivId);
        ResponseModel LoadUpazila();
        ResponseModel LoadUpazilaAgainstDistrict(int DisId);
        ResponseModel LoadPoliceStation();
        ResponseModel LoadPoliceStationAgainstUpazila(int UpzId);
        ResponseModel LoadPostOffice();
        ResponseModel LoadPostOfficeAgainstPoliceStation(int PsId);
        ResponseModel LoadVillage();
        ResponseModel LoadVillageAgainstPostOffice(int PoId);
        ResponseModel LoadPostCodeAgainstPostOffice(int PoId);

        //Family DDL
        ResponseModel LoadRelation();

        //Education DDL
        ResponseModel LoadDegree();
        ResponseModel LoadGroup();
        ResponseModel LoadSubject();
        ResponseModel LoadResult();
        ResponseModel LoadBoard();

    }
}
