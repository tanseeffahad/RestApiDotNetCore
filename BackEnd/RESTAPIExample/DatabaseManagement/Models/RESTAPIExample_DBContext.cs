using DatabaseManagement.CommonUtills;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatabaseManagement.Models
{
    public class RESTAPIExample_DBContext : DbContext
    {
        public RESTAPIExample_DBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Tbl_User> Users { get; set; }
        public DbSet<Tbl_Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppSettings.Instance.ConnectionString);
            }
        }
    }
}
