using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Task_Manager.Models
{
    public partial class ToDos
    {
        public int Id { get; set; }
        public string TaskDescription { get; set; }
        public bool? CompletionStatus { get; set; }
        public DateTime? DueDate { get; set; }
        public string TaskUser { get; set; }

        public virtual AspNetUsers TaskUserNavigation { get; set; }
    }
}
