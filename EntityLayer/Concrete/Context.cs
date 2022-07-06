using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EHVPQGR;Initial Catalog=learning;Integrated Security=True;Pooling=False");
        }

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
