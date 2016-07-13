namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Guid(nullable: false),
                        LocationType = c.Int(nullable: false),
                        State = c.String(nullable: false, maxLength: 256),
                        City = c.String(nullable: false, maxLength: 256),
                        CompleteAddress = c.String(maxLength: 1024),
                        ProfileId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                        Profile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Guid(nullable: false),
                        AreaCode = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        LocationType = c.Int(nullable: false),
                        PhoneType = c.Int(nullable: false),
                        AddressId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProfileType = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 256),
                        LastName = c.String(nullable: false, maxLength: 256),
                        ProfilePicture = c.String(),
                        Comment = c.String(maxLength: 256),
                        BirthDate = c.DateTime(),
                        SocialGooglePlus = c.String(maxLength: 512),
                        SocialFacebok = c.String(maxLength: 512),
                        SocialTwiter = c.String(maxLength: 512),
                        SocialTelegram = c.String(maxLength: 512),
                        Instagram = c.String(maxLength: 512),
                        CompanyName = c.String(),
                        RegistrationNumber = c.String(),
                        FieldOfActivity = c.String(),
                        MainCategoryId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                        MainCategory_MainCategoryId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainCategories", t => t.MainCategory_MainCategoryId)
                .ForeignKey("dbo.MainCategories", t => t.MainCategoryId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.MainCategoryId)
                .Index(t => t.MainCategory_MainCategoryId);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Summary = c.String(),
                        ArticleText = c.String(nullable: false),
                        ArticleSource = c.String(),
                        Rate = c.Int(nullable: false),
                        ThumbnailImage = c.String(),
                        ProfileId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                        Profile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.ArticleFiles",
                c => new
                    {
                        ArticleFileId = c.Guid(nullable: false),
                        FileName = c.String(),
                        NewFileName = c.String(maxLength: 1024),
                        LinkUrl = c.String(maxLength: 256),
                        Size = c.Int(nullable: false),
                        Type = c.String(maxLength: 1024),
                        Comment = c.String(maxLength: 256),
                        ArticleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleFileId)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.ImageGalleries",
                c => new
                    {
                        ImageGalleryId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Describtion = c.String(),
                        Rate = c.Int(nullable: false),
                        ProfileId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                        ImageGallery_ImageGalleryId = c.Guid(),
                        Profile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ImageGalleryId)
                .ForeignKey("dbo.ImageGalleries", t => t.ImageGallery_ImageGalleryId)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.ImageGallery_ImageGalleryId)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.MainCategories",
                c => new
                    {
                        MainCategoryId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Describtion = c.String(),
                        MarkAsDelete = c.Boolean(nullable: false),
                        ParentId = c.Guid(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.MainCategoryId)
                .ForeignKey("dbo.MainCategories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        PortfolioId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        ThumbnailImage = c.String(),
                        Describtion = c.String(),
                        Rate = c.Int(nullable: false),
                        ProfileId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                        Profile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PortfolioId)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.PortfolioFiles",
                c => new
                    {
                        PortfolioFileId = c.Guid(nullable: false),
                        FileName = c.String(),
                        NewFileName = c.String(maxLength: 1024),
                        LinkUrl = c.String(maxLength: 256),
                        Size = c.Int(nullable: false),
                        Type = c.String(maxLength: 1024),
                        Comment = c.String(maxLength: 256),
                        PortfolioId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PortfolioFileId)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioId, cascadeDelete: true)
                .Index(t => t.PortfolioId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Describtion = c.String(),
                        Rate = c.Int(nullable: false),
                        BrandId = c.Guid(nullable: false),
                        UseLocationId = c.Guid(nullable: false),
                        ProfileId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                        Profile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .ForeignKey("dbo.UseLocations", t => t.UseLocationId, cascadeDelete: true)
                .Index(t => t.BrandId)
                .Index(t => t.UseLocationId)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Describtion = c.String(maxLength: 1024),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.ProductFiles",
                c => new
                    {
                        ProductFileId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Project_ProjectId = c.Guid(),
                    })
                .PrimaryKey(t => t.ProductFileId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .Index(t => t.ProductId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.UseLocations",
                c => new
                    {
                        UseLocationId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Describtion = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.UseLocationId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FieldOfStudy = c.String(),
                        AcademicDegrees = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.VideoGalleries",
                c => new
                    {
                        VideoGalleryId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Describtion = c.String(),
                        ThumbnailImage = c.String(),
                        Rate = c.Int(nullable: false),
                        ProfileId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                        Profile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VideoGalleryId)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.VideoGalleryFiles",
                c => new
                    {
                        VideoGalleryFileId = c.Guid(nullable: false),
                        FileName = c.String(),
                        NewFileName = c.String(maxLength: 1024),
                        LinkUrl = c.String(maxLength: 256),
                        Size = c.Int(nullable: false),
                        Type = c.String(maxLength: 1024),
                        Comment = c.String(maxLength: 256),
                        VideoGalleryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.VideoGalleryFileId)
                .ForeignKey("dbo.VideoGalleries", t => t.VideoGalleryId, cascadeDelete: true)
                .Index(t => t.VideoGalleryId);
            
            CreateTable(
                "dbo.ImageGalleryFiles",
                c => new
                    {
                        ImageGalleryFileId = c.Guid(nullable: false),
                        FileName = c.String(),
                        NewFileName = c.String(maxLength: 1024),
                        LinkUrl = c.String(maxLength: 256),
                        Size = c.Int(nullable: false),
                        Type = c.String(maxLength: 1024),
                        Comment = c.String(maxLength: 256),
                        ImageGalleryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ImageGalleryFileId)
                .ForeignKey("dbo.ImageGalleries", t => t.ImageGalleryId, cascadeDelete: true)
                .Index(t => t.ImageGalleryId);
            
            CreateTable(
                "dbo.ProjectFiles",
                c => new
                    {
                        ProjectFileId = c.Guid(nullable: false),
                        FileName = c.String(maxLength: 1024),
                        NewFileName = c.String(maxLength: 1024),
                        LinkUrl = c.String(maxLength: 256),
                        Size = c.Int(nullable: false),
                        Type = c.String(maxLength: 1024),
                        Comment = c.String(maxLength: 256),
                        ProjectId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectFileId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        ThumbnailImage = c.String(),
                        Describtion = c.String(),
                        ProjectStartDate = c.DateTime(),
                        ProjectEndDate = c.DateTime(),
                        OperationPlace = c.String(),
                        Employer = c.String(maxLength: 256),
                        Testimonial = c.String(),
                        ProfileId = c.Guid(nullable: false),
                        Profile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProjectFiles", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.ProductFiles", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ImageGalleryFiles", "ImageGalleryId", "dbo.ImageGalleries");
            DropForeignKey("dbo.VideoGalleryFiles", "VideoGalleryId", "dbo.VideoGalleries");
            DropForeignKey("dbo.VideoGalleries", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Profiles", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "UseLocationId", "dbo.UseLocations");
            DropForeignKey("dbo.Products", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.ProductFiles", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Portfolios", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.PortfolioFiles", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Profiles", "MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.Profiles", "MainCategory_MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.MainCategories", "ParentId", "dbo.MainCategories");
            DropForeignKey("dbo.ImageGalleries", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.ImageGalleries", "ImageGallery_ImageGalleryId", "dbo.ImageGalleries");
            DropForeignKey("dbo.Articles", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.ArticleFiles", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Addresses", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.Contacts", "AddressId", "dbo.Addresses");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Projects", new[] { "Profile_Id" });
            DropIndex("dbo.ProjectFiles", new[] { "ProjectId" });
            DropIndex("dbo.ImageGalleryFiles", new[] { "ImageGalleryId" });
            DropIndex("dbo.VideoGalleryFiles", new[] { "VideoGalleryId" });
            DropIndex("dbo.VideoGalleries", new[] { "Profile_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ProductFiles", new[] { "Project_ProjectId" });
            DropIndex("dbo.ProductFiles", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "Profile_Id" });
            DropIndex("dbo.Products", new[] { "UseLocationId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.PortfolioFiles", new[] { "PortfolioId" });
            DropIndex("dbo.Portfolios", new[] { "Profile_Id" });
            DropIndex("dbo.MainCategories", new[] { "ParentId" });
            DropIndex("dbo.ImageGalleries", new[] { "Profile_Id" });
            DropIndex("dbo.ImageGalleries", new[] { "ImageGallery_ImageGalleryId" });
            DropIndex("dbo.ArticleFiles", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "Profile_Id" });
            DropIndex("dbo.Profiles", new[] { "MainCategory_MainCategoryId" });
            DropIndex("dbo.Profiles", new[] { "MainCategoryId" });
            DropIndex("dbo.Profiles", new[] { "Id" });
            DropIndex("dbo.Contacts", new[] { "AddressId" });
            DropIndex("dbo.Addresses", new[] { "Profile_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectFiles");
            DropTable("dbo.ImageGalleryFiles");
            DropTable("dbo.VideoGalleryFiles");
            DropTable("dbo.VideoGalleries");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UseLocations");
            DropTable("dbo.ProductFiles");
            DropTable("dbo.Brands");
            DropTable("dbo.Products");
            DropTable("dbo.PortfolioFiles");
            DropTable("dbo.Portfolios");
            DropTable("dbo.MainCategories");
            DropTable("dbo.ImageGalleries");
            DropTable("dbo.ArticleFiles");
            DropTable("dbo.Articles");
            DropTable("dbo.Profiles");
            DropTable("dbo.Contacts");
            DropTable("dbo.Addresses");
        }
    }
}
