using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using DatabaseManagement.CommonUtills;
using DatabaseManagement.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DatabaseManagement.Interfaces;

namespace DatabaseManagement.Services
{
    public class SRVUsers : ISRVUser
    {
        private readonly RESTAPIExample_DBContext _context;
        private readonly IMapper _mapper;
        public SRVUsers(RESTAPIExample_DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Tuple<List<VMUserResponse>, string, bool> SaveUsers(VMUser model)
        {
            try
            {

                var UserExists = _context.Users.Where(x => x.Email.ToLower() == model.Email.ToLower()).ToList();
                if (UserExists.Count == 0)
                {
                    Tbl_User user = new Tbl_User();
                    user.Password = model.Password;
                    user.IsDeleted = false;
                    user.Email = model.Email;

                    user.Created_at = DateTime.Now;
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    var userList = listOfUser();
                    return Tuple.Create(userList.Item1, "New user has been Created", true);
                }
                else
                {
                    var userList = listOfUser();
                    return Tuple.Create(userList.Item1, "UserName Already Exists", false);
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Tuple<List<VMUserResponse>, string, bool> listOfUser()
        {
            try
            {
                var users = _context.Users.ToList();
                List<VMUserResponse> lstVMUsers = this._mapper.Map<List<Tbl_User>, List<VMUserResponse>>(users);
                return Tuple.Create(lstVMUsers, "All Users", true);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }
    }
}
