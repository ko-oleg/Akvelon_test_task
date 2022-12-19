using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace akvelom_test_task.Models
{
    [Keyless]
    public class Project
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public virtual ICollection<Task> Tasks { get; set; }
        public DataType start_date { get; set; }
        public DataType finish_date { get; set; }
        public string project_state { get; set; }
        public string status = "NotStarted";
        
        public Project()
        {
            Tasks = new List<Task>();
        }
    }
}