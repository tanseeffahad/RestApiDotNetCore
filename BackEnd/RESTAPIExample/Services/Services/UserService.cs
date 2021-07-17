using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using Repositories;
using Repositories.Interfaces;
using DatabaseManagement.Models;
using AutoMapper;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }
        public async Task<string> AddUser(VMUser model)
        {
            try
            {                
                    var user = new Tbl_User
                    {
                      
                        Email = model.Email,
                        Password = model.Password,
                        Created_at = DateTime.Now,
                        IsDeleted = false,                        
                    };
                    await this.repository.AddAsync(user);
                    return "success";

            }
            catch (Exception ex)
            {
                return "fail";
            }
        }
        public async Task<Tbl_User> Login(VMLoginInput model)
        {
            return await this.repository.Login(model);
        }
        public async Task<List<VMUser>> AllUsers()
        {
            var users = await this.repository.GetAllUsers();

            return _mapper.Map<List<Tbl_User>, List<VMUser>>(users);

        }
        public async Task<VMUser> GetById(int UserId)
        {
            var user = await this.repository.GetById(UserId);

            return _mapper.Map<Tbl_User, VMUser>(user);

        }
        public async Task<string> DeleteUserbyID(int Id)
        {
            var product = await this.repository.GetById(Id);
            await this.repository.Deletesync(product);
            return "success";
        }
    }
}
