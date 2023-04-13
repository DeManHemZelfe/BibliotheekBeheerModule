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
        public async Task SeedAsync(DbContext dbContext)
        {
            using (var db = new TableDbContext())
            {
                        var authorDumpData1 = new Author{Id = Guid.NewGuid(), FirstName = "Joop", Infix = "ter", LastName = "Apel"};
                        var authorDumpData2 = new Author{Id = Guid.NewGuid(), FirstName = "Joop", Infix = "ter", LastName = "Apel"};
                        var authorDumpData3 = new Author{Id = Guid.NewGuid(), FirstName = "Joop", Infix = "ter", LastName = "Apel"};
                        var authorDumpData4 = new Author{Id = Guid.NewGuid(), FirstName = "Joop", Infix = "ter", LastName = "Apel"};
                        var authorDumpData5 = new Author{Id = Guid.NewGuid(), FirstName = "Joop", Infix = "ter", LastName = "Apel"};

                        var typeDumpDataCd = new Type { Id = Guid.NewGuid(), Name = "CD" };
                        var typeDumpDataDvd = new Type{Id = Guid.NewGuid(), Name = "DVD" };
                        var typeDumpDataBlue = new Type{Id = Guid.NewGuid(), Name = "Blue-ray" };
                        var typeDumpDataGame = new Type{Id = Guid.NewGuid(), Name = "Game" };
                        var typeDumpDataBook = new Type { Id = Guid.NewGuid(), Name = "Book" };

                        var itemDumpData1 = new Item{Id = Guid.NewGuid(), Name = "K3", Type = typeDumpDataCd.Name, Description = "Voor de kindertjes", Author = authorDumpData1.FullName,};
                        var itemDumpData2 = new Item{Id = Guid.NewGuid(), Name = "K3", Type = typeDumpDataDvd.Name, Description = "Voor de kindertjes", Author = authorDumpData2.FullName,};
                        var itemDumpData3 = new Item{Id = Guid.NewGuid(), Name = "K3", Type = typeDumpDataBlue.Name,Description = "Voor de kindertjes", Author = authorDumpData3.FullName,};
                        var itemDumpData4 = new Item{Id = Guid.NewGuid(), Name = "K3", Type = typeDumpDataGame.Name,Description = "Voor de kindertjes", Author = authorDumpData4.FullName,};
                        var itemDumpData5 = new Item{Id = Guid.NewGuid(), Name = "K3", Type = typeDumpDataBook.Name,Description = "Voor de kindertjes", Author = authorDumpData5.FullName,};

                        dbContext.Set<Author>().Add(authorDumpData1);
                        dbContext.Set<Author>().Add(authorDumpData2);
                        dbContext.Set<Author>().Add(authorDumpData3);
                        dbContext.Set<Author>().Add(authorDumpData4);
                        dbContext.Set<Author>().Add(authorDumpData5);

                        dbContext.Set<Item>().Add(itemDumpData1);
                        dbContext.Set<Item>().Add(itemDumpData2);
                        dbContext.Set<Item>().Add(itemDumpData3);
                        dbContext.Set<Item>().Add(itemDumpData4);
                        dbContext.Set<Item>().Add(itemDumpData5);
                        await dbContext.SaveChangesAsync();
            }
        }
    }
}
