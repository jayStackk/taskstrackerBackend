// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace tasktrackerBackend.Services
// {
//     public class TaskService
//     {
        
//     }
// }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasktrackerBackend.Models;
// using BlogBackEnd.Models.DTO;
// using BlogBackEnd.Services.Context;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using tasktrackerBackend.Services.Context;
using tasktrackerBackend.Models.DTO;

namespace tasktrackerBackend.Services
{
   public class TaskService
    {
        private readonly DataContext _context;
        public TaskService(DataContext context)
        {
            _context = context;
        }

        public bool AddBlogItem(TaskModel newBlogItem)
        {
            _context.Add(newBlogItem);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<TaskModel> GetAllBlogItems()
        {
            return _context.BlogInfo;
        }



        public IEnumerable<TaskModel> GetItemsByDate(string date)
        {
            return _context.BlogInfo.Where(item => item.Date == date);
        }

   

        public TaskModel GetBlogItemById(int id)
        {
            return _context.BlogInfo.SingleOrDefault(item => item.Id == id);
        }

        public bool UpdateBlogitem(TaskModel BlogUpdate)
        {
            _context.Update<TaskModel>(BlogUpdate);
            return _context.SaveChanges() != 0;
        }

        public bool DeleteBlogItem(TaskModel BlogDelete)
        {
            BlogDelete.IsDeleted = true;
            _context.Update<TaskModel>(BlogDelete);
            return _context.SaveChanges() != 0;
        }
   

    }
}