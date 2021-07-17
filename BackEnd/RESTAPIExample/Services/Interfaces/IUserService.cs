using DatabaseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<string> AddUser(VMUser model);
        Task<Tbl_User> Login(VMLoginInput model);
        Task<List<VMUser>> AllUsers();
        Task<VMUser> GetById(int UserId);
        Task<string> DeleteUserbyID(int Id);
    }
}
