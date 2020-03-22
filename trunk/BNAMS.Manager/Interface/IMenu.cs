using SR.Entities;

namespace SR.Manager.Interface
{
    public interface IMenu
    {
        ResponseModel CreateMenu(M_Menu aObj);
        ResponseModel GetAllMenu();
        ResponseModel LoadParentMenu();
    }
}
