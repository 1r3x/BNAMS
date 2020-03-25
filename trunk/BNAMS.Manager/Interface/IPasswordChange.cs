using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IPasswordChange
    {
        ResponseModel ChangePassword(UserLogin aObj);
        ResponseModel GetCurrentPassword();
    }
}
