using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotheekBeheerModule.Model;

namespace BibliotheekBeheerModule.DbContexts
{
    public class TableDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
