using Kutuphane.Core.Kutuphane.Entities.Concrete;
using Kutuphane.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.DataAccess.Concrete.EntityFramework.Context
{
    public class KutuphaneContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=FURKAN-PC\SQLEXPRESS;Database=DbKutuphane; Trusted_Connection=true");
        }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Penaltie> Penalties { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}