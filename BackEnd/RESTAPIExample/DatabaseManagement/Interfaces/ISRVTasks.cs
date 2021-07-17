using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace DatabaseManagement.Interfaces
{
   public interface ISRVTasks
    {

        public Tuple<List<VMTask>, string, bool> SaveTasks(VMTask model);
        public Tuple<List<VMTask>, string, bool> listOfTasks();
        Tuple<List<VMTask>, string, bool> UpdateTasks(List<VMTask> model);
    }
}
