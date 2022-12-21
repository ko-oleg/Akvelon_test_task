using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace akvelom_test_task.Models
{
    
    public class MyTask
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public string tusk_state { get; set; }
        public string status = "Todo"; 
    }
}