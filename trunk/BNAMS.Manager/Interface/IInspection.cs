using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;
using BNAMS.Entities.ViewModels;

namespace BNAMS.Manager.Interface
{
    public interface IInspection
    {
        ResponseModel CreateInspection(W_Inspection aObj);
        ResponseModel GetInspectionAll();

        ResponseModel LoadDepot();
        ResponseModel LoadItemType();
        ResponseModel LoadRegistrationNo(string itemTypeId,string depotId);
        ResponseModel LoadWeaponDetails(string itemId);
        ResponseModel LoadLastMaintainceDate(string itemId);
        

        
    }
}
