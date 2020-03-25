using BNAMS.Entities;
using SR.Manager;

namespace BNAMS.Manager.Interface
{
    public interface IUser
    {
        ResponseModel CreateEmployee(Emp_BasicInfo aObj);
        ResponseModel DuplicateCheck(int empId,string userName);
        ResponseModel GetAllUser();
        ResponseModel LoadUserRole();
    }
}
