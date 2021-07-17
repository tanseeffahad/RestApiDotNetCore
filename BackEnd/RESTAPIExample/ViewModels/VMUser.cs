using System;

namespace ViewModels
{
    public class VMUser
    {
        //public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }        
        //public DateTime Created_at { get; set; }
        //public DateTime Updated_at { get; set; }
        //public bool IsDeleted { get; set; }
    }
    public class VMLoginInput
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class VMUserResponse
    {
        public int UserId { get; set; }
        public string Email { get; set; }
    }
    public class VMUserLoginResponse
    {        
        public string jwt { get; set; }
    }
}
