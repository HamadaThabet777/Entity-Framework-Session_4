using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_4_EF.Data.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }

        public DateOnly CreationDate { get; set; }
        // دا التاريخ اللي اتعمل فيه البروجكت
    }
}
