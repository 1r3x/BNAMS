using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IIndent
    {
        ResponseModel CreateIndent(I_Indent aObj);
        ResponseModel GetAllIndent();

        ResponseModel LoadAllDepotAndShipForIndentFrom();
        ResponseModel LoadAllDepotAndShipForIssue();
        ResponseModel LoadItemCode(string depotShipId);
        ResponseModel LoadItemDetails(string itemId);
        ResponseModel LoadCompositCode();
        ResponseModel LoadCompositNameByCompositId(string compositCodeId);
        ResponseModel LoadIndentType();
        ResponseModel CheckIsItAmmo(string itemId);


        ResponseModel CheckItemQuantity(string weaponInfoId);
    }
}
