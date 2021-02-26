using System;
using System.Collections.Generic;

namespace Task_Manager.Models
{
    public partial class TaskList
    {
        public int Id { get; set; }
        public string TaskDescription { get; set; }
        public bool? CompletionStatus { get; set; }
        public DateTime? DueDate { get; set; }
        public string AssignedEmployee { get; set; }

        public virtual AspNetUsers AssignedEmployeeNavigation { get; set; }
    }
}
