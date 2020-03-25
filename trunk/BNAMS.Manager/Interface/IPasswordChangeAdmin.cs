using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IPasswordChangeAdmin
    {
        ResponseModel LoadEmpByUserId(string userName);

        ResponseModel ChangePassword(UserLogin aObj);

    }
}
