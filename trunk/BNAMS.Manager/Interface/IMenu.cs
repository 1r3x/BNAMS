using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IMenu
    {
        ResponseModel CreateMenu(M_Menu aObj);
        ResponseModel GetAllMenu();
        ResponseModel LoadParentMenu();
        ResponseModel CheckDuplicate(M_Menu aObj);
    }
}
