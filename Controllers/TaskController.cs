using Microsoft.AspNetCore.Mvc;
using tasktrackerBackend.Models;
using tasktrackerBackend.Services;

namespace tasktrackerBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
 {
        private readonly TaskService _data;
        public TaskController(TaskService dataFromService)
        {
            _data = dataFromService;
        }

     

        [HttpGet]
        [Route("GetAllBlogItems")]

        public IEnumerable<TaskModel> GetAllBlogItems()
        {
            return _data.GetAllBlogItems();
        }

      

        [HttpGet]
        [Route("GetBlogItemById/{id}")]

        public TaskModel GetBlogItemById(int id)
        {
            return _data.GetBlogItemById(id);
        }

        [HttpPost]
        [Route("UpdateTaskitem")]

        public bool UpdateBlogitem(TaskModel BlogUpdate)
        {
            return _data.UpdateBlogitem(BlogUpdate);
        }

        [HttpPost]
        [Route("DeleteTaskItem")]

        public bool DeleteBlogItem(TaskModel BlogDelete)
        {
            return _data.DeleteBlogItem(BlogDelete);
        }

          [HttpPost]
        [Route("AddTask")]
        public bool AddUser(TaskModel UserToAdd)
        {
            return _data.TaskItem(UserToAdd);
        }

    }
