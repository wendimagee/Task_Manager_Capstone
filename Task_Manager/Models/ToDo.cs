using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string TaskDescription { get; set; }
        public bool? CompletionStatus { get; set; }
        public DateTime? DueDate { get; set; }
        public string TaskUser { get; set; }

        public virtual AspNetUsers TaskUserNavigation { get; set; }
    }
}

