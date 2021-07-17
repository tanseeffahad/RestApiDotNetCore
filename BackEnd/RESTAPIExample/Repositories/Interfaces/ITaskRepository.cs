using DatabaseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Interfaces
{
    public interface ITaskRepository : IGenericRepository<Tbl_Task>
    {
        Task<List<Tbl_Task>> GetAllTask();        
    }
}
