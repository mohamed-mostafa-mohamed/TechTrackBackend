using CMS.DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CMS.DAL.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Roadmap> Roadmaps { get; set; }
        public DbSet<RoadmapStep> RoadmapSteps { get; set; }
        public DbSet<InterviewQuestion> InterviewQuestions { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyTechnology> CompanyTechnologies { get; set; }
        public DbSet<UserTechnologyReview> UserTechnologyReviews { get; set; }
        public DbSet<User> Users { get; set; } // if you added User


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SubCategory>()
                .HasOne(s => s.Category)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<Track>()
                .HasOne(t => t.SubCategory)
                .WithMany(s => s.Tracks)
                .HasForeignKey(t => t.SubCategoryId);

            modelBuilder.Entity<Technology>()
                .HasOne(t => t.Track)
                .WithMany(tr => tr.Technologies)
                .HasForeignKey(t => t.TrackId);
        }
    }
}
