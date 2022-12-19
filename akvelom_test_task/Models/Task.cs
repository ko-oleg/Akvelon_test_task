using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace akvelom_test_task.Models
{
    [Keyless]
    public class Task
    {
        public int id_card { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        public string tusk_state { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        //public string status = "Todo"; 
        
        public Task()
        {
            Projects = new List<Project>();
        }
    }
}