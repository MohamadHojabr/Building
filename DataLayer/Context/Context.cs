using System.Data.Entity;
using DomainClasses.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataLayer.Context
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWork
    {
        public ApplicationDbContext()
            : base("Context", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Configure CompanyProfile & RelatedUser entity
            modelBuilder.Entity<CompanyProfile>()
                        .HasOptional(s => s.RelatedUser) // Mark RelatedUser property optional in CompanyProfile entity
                        .WithRequired(ad => ad.CompanyProfile); // mark RelatedUser property as required in CompanyProfile entity. Cannot save CompanyProfile without Student

            modelBuilder.Entity<PersonalProfile>()
            .HasOptional(s => s.RelatedUser) 
            .WithRequired(ad => ad.PersonalProfile);

            modelBuilder.Entity<PersonalProfile>()
    .HasRequired(d => d.MainCategory)
    .WithMany()
    .HasForeignKey(d => d.MainCategoryId)
    .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfile>()
.HasRequired(d => d.MainCategory)
.WithMany()
.HasForeignKey(d => d.MainCategoryId)
.WillCascadeOnDelete(false);


        }

        public DbSet<MainCategory> Categories { set; get; }
        public DbSet<Address> Addresses { set; get; }
        public DbSet<Article> Articles { set; get; }
        public DbSet<ArticleFile> ArticleFiles { set; get; }
        public DbSet<Brand> Brands { set; get; }
        public DbSet<CompanyProfile> CompanyProfiles { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<ImageGallery> ImageGalleries { set; get; }
        public DbSet<ImageGalleryFile> ImageGalleryFiles { set; get; }
        public DbSet<PersonalProfile> PersonalProfiles { set; get; }
        public DbSet<Portfolio> Portfolios { set; get; }
        public DbSet<PortfolioFile> PortfolioFiles { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductFile> ProductFiles { set; get; }
        public DbSet<Project> Projects { set; get; }
        public DbSet<ProjectFile> ProjectFiles { set; get; }
        public DbSet<UseLocation> UserLocations { set; get; }
        public DbSet<VideoGallery> VideoGalleries { set; get; }
        public DbSet<VideoGalleryFile> VideoGalleryFiles { set; get; }

    #region IUnitOfWork Members
    public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        #endregion

    }
}