using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManagement.Models
{
    [Table("Tbl_Task")]
    public class Tbl_Task
    {
        [Key]
        public int TaskId { get; set; }
        public string Name { get; set; }       
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public bool IsDeleted { get; set; }

    }
}
