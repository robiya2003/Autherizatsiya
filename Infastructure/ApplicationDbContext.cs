using Domains.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure
{
    internal class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) 
        {
            Database.Migrate();
        }
        public DbSet<CustomerModel> customers { get; set; }
        public DbSet<AdminModel> admins { get; set; }
    }
}
