using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=89.252.185.155\\MSSQLSERVER2019;User ID=erdemoku_erdem;Password=Erdemokullari2022;Database=erdemoku_learning1;");
        }
        //Server=89.252.185.155;Database=erdemoku_learning1;Integrated Security=true;User Id=erdemoku_erdem;Trusted_Connection=Yes;Password=Erdemokullari2022
        //data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|aspnetdb.mdf;User Instance=true
        //Server=89.252.185.155;Database=erdemoku_learning1;Integrated Security=true;User Id=erdemoku_erdem;Trusted_Connection=Yes;Password=Erdemokullari2022
        //Data Source=DESKTOP-EHVPQGR;Initial Catalog=learning;Integrated Security=True;Pooling=False
        public DbSet<admin> admins { get; set; }
        public DbSet<Lesson> lessons { get; set; }
        public DbSet<Lesson_icerik>lesson_İceriks { get; set; }
        public DbSet<Contact>contacts { get; set; }
        public DbSet<Hakkımızda> hakkımızdas { get; set; }
        public DbSet<Header> headers { get; set; }
        public DbSet<Siniflar>siniflars { get; set; }
        public DbSet<LoginPhoto>loginPhotos { get; set; }

    }
}
