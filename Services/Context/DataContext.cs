using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tasktrackerBackend.Models;

namespace tasktrackerBackend.Services.Context
{
    public class DataContext : DbContext
    {
        public DbSet<TaskModel> UserInfo { get; set; }
        public DbSet<UserModel> BlogInfo { get; set; }

        public DataContext(DbContextOptions options): base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
        }
    }
}