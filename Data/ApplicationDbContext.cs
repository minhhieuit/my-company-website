using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Models;
using MVC_Thehegeo.Models.BlogModels;

namespace MVC_Thehegeo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Timeline> TimeLines { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<FeaturedWork> FeaturedWorks { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<TeamInfo> TeamInfos { get; set; }
        public DbSet<ServiceCompany> ServiceCompanys { get; set; }
        public DbSet<SliderModel> Sliders { get; set; }
        public DbSet<Recruitment> Recruitments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Post>().ToTable("Post");
            builder.Entity<Category>().ToTable("Category");
            builder.Entity<Timeline>().ToTable("Timeline");
            builder.Entity<Partner>().ToTable("Partner");
            builder.Entity<CompanyInfo>().ToTable("CompanyInfo");
            builder.Entity<FeaturedWork>().ToTable("FeaturedWork");
            builder.Entity<About>().ToTable("About");
            builder.Entity<TeamInfo>().ToTable("TeamInfo");
            builder.Entity<ServiceCompany>().ToTable("ServiceCompany");
            builder.Entity<SliderModel>().ToTable("Slider");
            builder.Entity<Recruitment>().ToTable("Recruitment");
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
