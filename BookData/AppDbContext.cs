using BookData.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookData
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<PublisherEntity> Publishers { get; set; }

        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "booksdb.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string ADMIN_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();



            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Name = "user",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });

            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "mateusz@books.pl",
                NormalizedEmail = "MATEUSZ@BOOKS.PL",
                EmailConfirmed = true,
                UserName = "Mateusz",
                NormalizedUserName = "MATEUSZ"
            };

            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "krystian@books.pl",
                NormalizedEmail = "KRYSTIAN@BOOKS.PL",
                EmailConfirmed = true,
                UserName = "Krystian",
                NormalizedUserName = "KRYSTIAN"
            };

            PasswordHasher<IdentityUser> passHasher = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = passHasher.HashPassword(admin, "Secret23!");
            user.PasswordHash = passHasher.HashPassword(user, "Mystery23!");

            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityUser>().HasData(user);


            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>()
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                });
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>()
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });
            modelBuilder.Entity<BookEntity>()
                .HasOne(c => c.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(c => c.PublisherId);

            modelBuilder.Entity<PublisherEntity>().HasData(
                new { Id = 1, Name = "Znak", Phone = "123456789" },
                new { Id = 2, Name = "Greg", Phone = "987654321" }
                );

            modelBuilder.Entity<BookEntity>().HasData(
                new { BookId = 1, Title = "Atlas Zbuntowany", Author = "Ayn Rand", ISBN = "123141412", PublicationDate = 2000, BookType = 2, PublisherId = 1 },
                new { BookId = 2, Title = "Solaris", Author = "Stanisław Lem", ISBN = "5443332154", PublicationDate = 2003, BookType = 1, PublisherId = 2 }
            );

            modelBuilder.Entity<PublisherEntity>()
                .OwnsOne(p => p.Address)
                .HasData(
                new
                {
                    PublisherEntityId = 1,
                    City = "Kraków",
                    Street = "ul.Sienkiewicza",
                    PostalCode = "31-234"
                },
                new
                {
                    PublisherEntityId = 2,
                    City = "Poznań",
                    Street = "ul.Mickiewicza",
                    PostalCode = "31-555"
                }
                );
        }
    }
}
