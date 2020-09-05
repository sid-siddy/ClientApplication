using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagement.Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() 
        {
        }
        public ApplicationContext(DbContextOptions opts) : base(opts)
        {
        }
        public DbSet<ClientUser> Clients { get; set; }
        public DbSet<AuditRequest> Response { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
