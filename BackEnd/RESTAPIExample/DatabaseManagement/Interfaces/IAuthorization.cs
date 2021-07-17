using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace DatabaseManagement.Interfaces
{
    public interface IAuthorization
    {
        Task<Tuple<VMUserLoginResponse, string, bool>> Signin(VMLoginInput model);
    }
}
