using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using akvelom_test_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace akvelom_test_task.Controllers
{
    [Route("/api/[controller]")]
    public class WorkContoller : Controller
    {
        private readonly ApplicationContext _db;
        public WorkContoller(ApplicationContext context)
        {
            _db = context;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var tasks = _db.MyProjects.Include(u => u.Tasks).ToList();
            return Ok(tasks);
        }
        [HttpGet("GetAllProjects")]
        public IActionResult GetAllProjects()
        {
            return Ok(_db.MyProjects);
        }
        
        
        [HttpPost("GetTusks")]
        public  IActionResult GetTusks()
        {
            return Ok(_db.Tasks);
        }
        
        [HttpPost("CreateProject")]
        public  IActionResult CreateProject (MyProject myProject)

        {
            _db.MyProjects.AddRange(myProject);
            _db.SaveChanges();
            return Ok(myProject);
        }
        
        [HttpPost("CreateTask")]
        public  IActionResult CreateTask (MyTask myTask)
        {
            _db.Tasks.AddRange(myTask);
            _db.SaveChanges();
            return Ok(myTask);
        }
        
        
        [HttpPost("TakeTaskIdForProject")]
        public  IActionResult TakeTaskIdForProject (int idProject, int idTask)
        
        {
            
            var includtask = _db.Tasks.SingleOrDefault(p => p.ID == idTask);
            var includProject = _db.MyProjects.SingleOrDefault(p => p.ID == idProject);
            includProject.Tasks = new [] {includtask};
            _db.SaveChanges();
            return Ok(includProject);
        }
        
        
        [HttpPut("UpdateProject")]
        public IActionResult UpdateProject(MyProject myProject)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updateResult = _db.MyProjects.SingleOrDefault(p => p.ID == myProject.ID);
            if (updateResult == null) return NotFound();

            updateResult.ID = myProject.ID;
            updateResult.name = myProject.name;
            updateResult.Tasks = myProject.Tasks;
            updateResult.start_date = myProject.start_date;
            updateResult.finish_date = myProject.finish_date;
            updateResult.status = myProject.status;
            _db.SaveChanges();
            return Ok(updateResult);
        }
        
        [HttpPut("UpdateTask")]
        public IActionResult UpdateTask(MyTask myTask)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updateResult = _db.Tasks.SingleOrDefault(p => p.ID == myTask.ID);
            if (updateResult == null) return NotFound();

            updateResult.ID = myTask.ID;
            updateResult.Name = myTask.Name;
            updateResult.description = myTask.description;
            updateResult.tusk_state = myTask.tusk_state;
            updateResult.status = myTask.status;
            _db.SaveChanges();
            return Ok(updateResult);
        }
        
        [HttpDelete("DeleteProject")]
        public IActionResult Delete(int id)
        {
            _db.MyProjects.Remove(_db.MyProjects.SingleOrDefault(p => p.ID == id));
            _db.SaveChanges();
            return Ok();
        }
        
        [HttpDelete("DeleteTask")]
        public IActionResult DeleteTask(int id)
        {
            _db.Tasks.Remove(_db.Tasks.SingleOrDefault(p => p.ID == id));
            _db.SaveChanges();
            return Ok();
        }
    }
}