using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IUser
    {
        ResponseModel CreateEmployee(Emp_BasicInfo aObj);
        ResponseModel DuplicateCheck(Emp_BasicInfo aObj);
        ResponseModel GetAllUser();
        ResponseModel LoadUserRole();
    }
}
