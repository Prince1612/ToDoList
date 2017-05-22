using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoList.DataModel.Models;

namespace TodoList.DataModel.Context
{
    public class TodoListContext : DbContext
    {
        public TodoListContext()
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=TodoListDatabase;Integrated Security=True");
        }
    }
}
