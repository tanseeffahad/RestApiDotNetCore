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
    public class SRVTasks : ISRVTasks
    {
        private readonly RESTAPIExample_DBContext _context;
        private readonly IMapper _mapper;
        public SRVTasks(RESTAPIExample_DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Tuple<List<VMTask>, string, bool> SaveTasks(VMTask model)
        {
            try
            {

                var taskExists = _context.Tasks.Where(x => x.Name.ToLower() == model.Name.ToLower()).ToList();
                if (taskExists.Count == 0)
                {
                    Tbl_Task task = new Tbl_Task();
                    task.IsDeleted = false;
                    task.Name = model.Name;

                    task.Created_at = DateTime.Now;
                    _context.Tasks.Add(task);
                    _context.SaveChanges();
                    var userList = listOfTasks();
                    return Tuple.Create(userList.Item1, "New Task has been Created", true);
                }
                else
                {
                    var userList = listOfTasks();
                    return Tuple.Create(userList.Item1, "Task Already Exists", false);
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Tuple<List<VMTask>, string, bool> listOfTasks()
        {
            try
            {
                var tasks = _context.Tasks.Where(x=>x.IsDeleted == false).ToList();
                List<VMTask> lstVMTasks = this._mapper.Map<List<Tbl_Task>, List<VMTask>>(tasks);
                return Tuple.Create(lstVMTasks, "All Users", true);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }

        public Tuple<List<VMTask>, string, bool> UpdateTasks(List<VMTask> model)
        {
            try
            {
                List<Tbl_Task> lstTbl_Tasks = this._mapper.Map<List<VMTask>, List<Tbl_Task>>(model);
                lstTbl_Tasks.ForEach(x => { x.Updated_at = DateTime.Now; });
                _context.Tasks.UpdateRange(lstTbl_Tasks);
                _context.SaveChanges();

                var tasks = _context.Tasks.Where(x => x.IsDeleted == false).ToList();
                List<VMTask> lstVMTasks = this._mapper.Map<List<Tbl_Task>, List<VMTask>>(tasks);
                return Tuple.Create(lstVMTasks, "All Users", true);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
