using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class VMTask
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        //public DateTime Created_at { get; set; }
        //public DateTime Updated_at { get; set; }
        public bool IsDeleted { get; set; }
    }
}
