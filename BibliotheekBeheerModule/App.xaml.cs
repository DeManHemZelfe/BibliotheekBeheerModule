using BibliotheekBeheerModule.DbContexts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BibliotheekBeheerModule
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize database context and seeding class
            var dbContext = new TableDbContext();
            var dbContextSeed = new DbContextSeed();

            // Create the database if it doesn't exist
            dbContext.Database.CreateIfNotExists();

            // Seed the database with data
            await dbContextSeed.SeedAsync(dbContext);
        }
    }
}
