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
        // private readonly DataContext _context;
        // public TaskService(DataContext context)
        // {
        //     _context = context;
        // }

        // public bool AddBlogItem(TaskModel newBlogItem)
        // {
        //     _context.Add(newBlogItem);
        //     return _context.SaveChanges() != 0;
        // }

        // public IEnumerable<TaskModel> GetAllBlogItems()
        // {
        //     return _context.BlogInfo;
        // }

        // public IEnumerable<BlogItemModel> GetItemsByUserId(int userId)
        // {
        //     return _context.BlogInfo.Where(item => item.UserID == userId);
        // }

        // public IEnumerable<BlogItemModel> GetItemsByCategory(string category)
        // {
        //     return _context.BlogInfo.Where(item => item.Category == category);
        // }

        // public IEnumerable<BlogItemModel> GetItemsByDate(string date)
        // {
        //     return _context.BlogInfo.Where(item => item.Date == date);
        // }

        // public IEnumerable<BlogItemModel> GetPublishedItems()
        // {
        //     return _context.BlogInfo.Where(item => item.isPublished);
        // }

        // public List<BlogItemModel> GetItemsByTags(string Tag)
        // {
        //     // tag1 , tag 2 , tag 3*This is the usual way this we would be entering the tags*
        //     // tag1,tag2,tag3 This is how we will do it today since it's simpler

        //     List<BlogItemModel> AllBlogsWithTags = new List<BlogItemModel>();

        //     var allItems = GetAllBlogItems().ToList();

        //     for(int i = 0; i < allItems.Count; i++)
        //     {
        //         BlogItemModel Item = allItems[i];
        //         var itemArr = Item.Tags.Split(",");

        //         for (int j = 0; j < itemArr.Length; j++)
        //         {
        //             if(itemArr[j].Contains(Tag)){
        //                 AllBlogsWithTags.Add(Item);
        //             }
        //         }
        //     }
        //     return AllBlogsWithTags;
        // }

        // public BlogItemModel GetBlogItemById(int id)
        // {
        //     return _context.BlogInfo.SingleOrDefault(item => item.Id == id);
        // }

        // public bool UpdateBlogitem(BlogItemModel BlogUpdate)
        // {
        //     _context.Update<BlogItemModel>(BlogUpdate);
        //     return _context.SaveChanges() != 0;
        // }

        // public bool DeleteBlogItem(BlogItemModel BlogDelete)
        // {
        //     BlogDelete.isDeleted = true;
        //     _context.Update<BlogItemModel>(BlogDelete);
        //     return _context.SaveChanges() != 0;
        // }
    }
}