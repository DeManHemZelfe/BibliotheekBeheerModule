using BibliotheekBeheerModule.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = BibliotheekBeheerModule.Model.Type;

namespace BibliotheekBeheerModule.DbContexts
{
    public class DbContextSeed
    {
        // Give the database some data when the database has no records.
        public async Task SeedAsync(DbContext dbContext)
        {
            using (var db = new TableDbContext())
            {
                if (db.Authors.Count() == 0 || db.Items.Count() == 0) 
                {
                    var authorDumpData1 = new Author { Id = Guid.NewGuid(), FirstName = "Aphex", Infix = "", LastName = "Twin" };
                    var authorDumpData2 = new Author { Id = Guid.NewGuid(), FirstName = "Polygon", Infix = "", LastName = "Window" };
                    var authorDumpData3 = new Author { Id = Guid.NewGuid(), FirstName = "Green", Infix = "", LastName = "Calx" };

                    var typeDumpDataCd = new Type { Id = Guid.NewGuid(), Name = "CD" };
                    var typeDumpDataDvd = new Type { Id = Guid.NewGuid(), Name = "DVD" };
                    var typeDumpDataBlue = new Type { Id = Guid.NewGuid(), Name = "Blue-ray" };
                    var typeDumpDataGame = new Type { Id = Guid.NewGuid(), Name = "Game" };
                    var typeDumpDataBook = new Type { Id = Guid.NewGuid(), Name = "Book" };

                    var itemDumpData1 = new Item { Id = Guid.NewGuid(), Name = "Xtal", Type = typeDumpDataCd.Name, Description = "Selected Ambient Works 85–92", AuthorId = authorDumpData1.Id };
                    var itemDumpData2 = new Item { Id = Guid.NewGuid(), Name = "Tha", Type = typeDumpDataCd.Name, Description = "Selected Ambient Works 85–92", AuthorId = authorDumpData2.Id };
                    var itemDumpData3 = new Item { Id = Guid.NewGuid(), Name = "Pulsewidth", Type = typeDumpDataCd.Name, Description = "Selected Ambient Works 85–92", AuthorId = authorDumpData3.Id };

                    dbContext.Set<Author>().Add(authorDumpData1);
                    dbContext.Set<Author>().Add(authorDumpData2);
                    dbContext.Set<Author>().Add(authorDumpData3);

                    dbContext.Set<Item>().Add(itemDumpData1);
                    dbContext.Set<Item>().Add(itemDumpData2);
                    dbContext.Set<Item>().Add(itemDumpData3);

                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
