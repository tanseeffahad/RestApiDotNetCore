using DatabaseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<Tbl_User>
    {
        Task<Tbl_User> Login(VMLoginInput model);
        Task<List<Tbl_User>> GetAllUsers();
    }
}
