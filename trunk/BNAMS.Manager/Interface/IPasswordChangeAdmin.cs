using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Entities;

namespace SR.Manager.Interface
{
    public interface IPasswordChangeAdmin
    {
        ResponseModel LoadEmpByUserId(string userName);

        ResponseModel ChangePassword(UserLogin aObj);

    }
}
