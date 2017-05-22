using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.DataModel.Models.Accounts;
using TodoList.DataModel.Models;

namespace TodoList.DataModel.Context
{
    public class AccountsContext : IdentityDbContext<CustomUser, CustomRole, string>
    {
        public AccountsContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=AccountsDatabase;Integrated Security=True");
        }
    }
}
