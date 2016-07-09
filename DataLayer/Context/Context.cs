using System;
using System.Data.Entity;
using System.Web;
using DomainClasses;
using DomainClasses.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataLayer.Context
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWork
    {
        public ApplicationDbContext()
            : base("Context", false)
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
                .WithOptionalPrincipal(ad => ad.CompanyProfile);
                // mark RelatedUser property as required in CompanyProfile entity. Cannot save CompanyProfile without Student

            modelBuilder.Entity<PersonalProfile>()
                .HasOptional(s => s.RelatedUser)
                .WithOptionalPrincipal(ad => ad.PersonalProfile);

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

        public override int SaveChanges()
        {
            //ApplyCorrectYeKe();
            AuditFields();
            //SaveAllChanges();
            return base.SaveChanges();
        }

        public void RejectChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        private void AuditFields()
        {
            var auditUser = "Not Authenticated"; // in web apps
            if (HttpContext.Current != null && HttpContext.Current.User != null)
            {
                auditUser = HttpContext.Current.User.Identity.Name; // Todo: check if username is editable or not
            }

            var auditDate = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                // Note: You must add a reference to assembly : System.Data.Entity
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = auditDate;
                        entry.Entity.ModifiedOn = auditDate;
                        entry.Entity.CreatedBy = auditUser;
                        entry.Entity.ModifiedBy = auditUser;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedOn = auditDate;
                        entry.Entity.ModifiedBy = auditUser;
                        break;
                }
            }
        }

        #region IUnitOfWork Members

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        #endregion

    }
}