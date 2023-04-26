using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tasktrackerBackend.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string? TaskName { get; set; }
        public string? UserID { get; set; }
        public string? PublisherName { get; set; }
        public string? Description { get; set; }
        public string? Date { get; set; }
        public string? Priority { get; set; }
        public string? Assigned { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public string? EndDate { get; set; }
        public TaskModel (){
            
        }

    }
}