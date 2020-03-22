using SR.Entities;

namespace SR.Manager.Interface
{
    public interface IUser
    {
        ResponseModel CreateUser(UserLogin aObj);
        ResponseModel GetAllUser();
        ResponseModel LoadUserRole();
    }
}
