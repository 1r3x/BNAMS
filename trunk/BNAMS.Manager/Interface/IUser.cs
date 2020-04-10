using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IUser
    {
        ResponseModel CreateEmployee(UserLogin aObj);
        ResponseModel DuplicateCheck(UserLogin aObj);
        ResponseModel GetAllUser();
        ResponseModel LoadUserRole();
        ResponseModel LoadDirectorateInfo();
    }
}
