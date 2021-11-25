using Microsoft.EntityFrameworkCore;
using Sockerbagare2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sockerbagare2.Context
{
    public class Sockerbagare2Context : DbContext
    {
        public Sockerbagare2Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RecievedOrder> RecievedOrders { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Provider> Providers { get; set; }
    }
}
