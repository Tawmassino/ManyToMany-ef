using ManyToMany_ef.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany_ef.Database
{
    public class BookContext : DbContext
    {


        public BookContext()
        {
            //sitas konstruktorius be parametru turi buti pirmas, kad eitu migracija
        }

        public BookContext(DbContextOptions options) : base(options)
        {
        }



        //chatgpt
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddDbContext<BookContext>(options =>
        //        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        //}

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); - galima istrinti

            //configure many2many
            modelBuilder.Entity<BookCategory>().//turi turet du raktus
                HasKey(bc => new { bc.BookId, bc.CategoryId });//pK is 2 stulpeliu
            //author klasej jau nusirodem

            modelBuilder.Entity<BookCategory>()//uztikrinam join, sakom kokiu budu per koki rakta jungias i kokia lentele
                .HasOne(bc => bc.Book)//book category jungiasi su book
                .WithMany(b => b.BookCategories)
                .HasForeignKey(b => b.BookId).OnDelete(DeleteBehavior.Cascade);//per rakta bookid

            modelBuilder.Entity<BookCategory>()//si lentele jungiasi su category bet rakta categoryid
                .HasOne(bc => bc.Category)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(b => b.CategoryId).OnDelete(DeleteBehavior.Cascade);

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//konfiguruojam kokiu budu susisieja su duombaze
        //{                                                                           //reikia parodyti specifiskai kaip mes darome
        //                                                                            //nes dontent kodas neamto ka mes darome
        //                                                                            //base.OnConfiguring(optionsBuilder);default


        //    if (!optionsBuilder.IsConfigured)//reikia i if
        //    {
        //        optionsBuilder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=NETUA2BooksManytoManyMigration;Trusted_Connection=True;");
        //    }
        //    //serverio pavadinimas toks koks yra nurodytas per SQL
        //    //database - pavadinimas
        //    //kaip jungtis: kokiu useriu. autentifikacija.
        //}



    }
}
