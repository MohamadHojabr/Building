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

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(s => s.Profile)
                .WithRequired(u => u.RelatedUser);
            base.OnModelCreating(modelBuilder);
            //         modelBuilder.Entity<Profile>()
            //.HasRequired(e => e.RelatedUser)
            //.WithRequiredDependent(u => u.Profile);

            modelBuilder.Entity<Profile>()
                .HasRequired(d => d.MainCategory)
                .WithMany()
                .HasForeignKey(d => d.MainCategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MainCategory>()
                        .HasOptional(x => x.Parent)
                        .WithMany(x => x.Children)
                        .HasForeignKey(x => x.ParentId)
                        .WillCascadeOnDelete(false);
        }
        public DbSet<Profile> Profiles { set; get; }
        public DbSet<MainCategory> Categories { set; get; }
        public DbSet<Address> Addresses { set; get; }
        public DbSet<Article> Articles { set; get; }
        public DbSet<ArticleFile> ArticleFiles { set; get; }
        public DbSet<Brand> Brands { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<ImageGallery> ImageGalleries { set; get; }
        public DbSet<ImageGalleryFile> ImageGalleryFiles { set; get; }
        public DbSet<Portfolio> Portfolios { set; get; }
        public DbSet<PortfolioFile> PortfolioFiles { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductFile> ProductFiles { set; get; }
        public DbSet<Project> Projects { set; get; }
        public DbSet<ProjectFile> ProjectFiles { set; get; }
        public DbSet<UseLocation> UserLocations { set; get; }
        public DbSet<VideoGallery> VideoGalleries { set; get; }
        public DbSet<VideoGalleryFile> VideoGalleryFiles { set; get; }
        public DbSet<ProfileFile> ProfileFiles { set; get; }


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