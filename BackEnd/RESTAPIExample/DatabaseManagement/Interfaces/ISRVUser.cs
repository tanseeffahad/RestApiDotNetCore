using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace DatabaseManagement.Interfaces
{
   public interface ISRVUser
    {

        public Tuple<List<VMUserResponse>, string, bool> SaveUsers(VMUser model);
        public Tuple<List<VMUserResponse>, string, bool> listOfUser();
    }
}
