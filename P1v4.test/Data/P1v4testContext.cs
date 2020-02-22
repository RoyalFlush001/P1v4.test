using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P1v4.test.Models;

namespace P1v4.test.Data
{
    public class P1v4testContext : DbContext
    {
        public P1v4testContext (DbContextOptions<P1v4testContext> options)
            : base(options)
        {
        }

        public DbSet<P1v4.test.Models.User> User { get; set; }

        public DbSet<P1v4.test.Models.Entry> Entry { get; set; }
    }
}
