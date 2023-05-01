using Microsoft.EntityFrameworkCore;
using MyStore_MAUI.Models;

namespace MyStore_MAUI.Context
{
    public class Application_Context : DbContext
    {
        private const string DatabaseName = "pr.db3";

        public Application_Context()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String databasePath;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", DatabaseName);
                    break;

                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DatabaseName);
                    break;

                case Device.UWP:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseName);
                    break;

                default:
                    throw new NotImplementedException("Platform not supported");
            }
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }

        public DbSet<Naruto> Personajes => Set<Naruto>();
        public DbSet<MClient> Client { get; set; }
        public DbSet<MProduct> Product { get; set; }
        public DbSet<MAuth> Auth { get; set; }
        public DbSet<MCart> Cart { get; set; }
        public DbSet<MCodeApp> CodeApp { get; set; }
        public DbSet<MCompany> Company { get; set; }
        public DbSet<MDetailsCart> DetailsCart { get; set; }
        public DbSet<MReport> Reports { get; set; }
    }
}