using DatabaseManagement.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Repositories
{
    public class UserRepository : GenericRepository<Tbl_User>, IUserRepository
    {
        public UserRepository(RESTAPIExample_DBContext context) : base(context)
        {
        }
        public async Task<Tbl_User> Login(VMLoginInput model)
        {
            return await GetAll().FirstOrDefaultAsync(u => u.Email.ToLower() == model.Email.ToLower() && u.Password == model.Password);
        }
        public async Task<List<Tbl_User>> GetAllUsers()
        {
            return await GetAll().ToListAsync();
        }
    }
}
