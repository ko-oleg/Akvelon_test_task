using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace akvelom_test_task.Models
{
    
    public class MyProject
    {
        public int ID { get; set; }
        [Required]
        public string name { get; set; }
        public virtual ICollection<MyTask> Tasks { get; set; }
        public DateTime start_date { get; set; }
        public DateTime finish_date { get; set; }
        public string project_state { get; set; }
        public string status = "NotStarted";

        public MyProject()
        {
            Tasks = new List<MyTask>();
        }
    }
}