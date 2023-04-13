using BibliotheekBeheerModule.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotheekBeheerModule.DbContexts
{
    public class DbContextSeed
    {
        public async Task SeedAsync(DbContext dbContext)
        {
            using (var db = new TableDbContext())
            {
                if (db.Items.Count() == 0)
                {
                    if (db.Authors.Count() > 0) 
                    {
                        var author = new Author
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Joop",
                            Infix = "ter",
                            LastName = "Apel"
                        };
                        dbContext.Set<Author>().Add(author);
                        var item = new Item
                        {
                            Id = Guid.NewGuid(),
                            Name = "K3",
                            Type = "CD",
                            Description = "Voor de kindertjes",
                            Author = author.FullName,
                        };
                        dbContext.Set<Author>().Add(author);
                        dbContext.Set<Item>().Add(item);
                        await dbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
