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
    public class TaskRepository : GenericRepository<Tbl_Task>, ITaskRepository
    {
        public TaskRepository(RESTAPIExample_DBContext context) : base(context)
        {
        }

        public async Task<List<Tbl_Task>> GetAllTask()
        {
            return await GetAll().ToListAsync();
        }
    }
}
