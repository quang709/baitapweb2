using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace baitapweb2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Posts> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Title = "Gạo", Description = "Gạo" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Title = "Thịt", Description = "Thịt" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Title = "Hoa Quả", Description = "Hoa Quả" });

            modelBuilder.Entity<Posts>().HasData(new Posts
            {
                Id = 1,
                Title = "Gạo Lứt Huế",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
        
                CategoryId = 1
            });
            modelBuilder.Entity<Posts>().HasData(new Posts
            {
                Id = 2,
                Title = "Thịt  Bò",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",

                CategoryId = 2
            });
            modelBuilder.Entity<Posts>().HasData(new Posts
            {
                Id = 3,
                Title = "Táo",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",

                CategoryId = 3
            });


           
            modelBuilder.Entity<PostsTag>().HasKey(potag => new { potag.PostsId, potag.TagId });
            //seeder data tag

            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                Id = 1,
                Title = "Rẻ",


            });
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                Id = 2,
                Title = "Ngon",



            });
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                Id = 3,
                Title = "Bổ khỏe",



            });
        }
    }
}

