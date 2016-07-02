namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
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
                        PersonalProfileId = c.Guid(nullable: false),
                        CompanyProfileId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.CompanyProfiles", t => t.CompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PersonalProfiles", t => t.PersonalProfileId, cascadeDelete: true)
                .Index(t => t.PersonalProfileId)
                .Index(t => t.CompanyProfileId);
            
            CreateTable(
                "dbo.CompanyProfiles",
                c => new
                    {
                        CompanyProfileId = c.Guid(nullable: false),
                        CompanyName = c.String(nullable: false),
                        RegistrationNumber = c.String(),
                        FieldOfActivity = c.String(nullable: false),
                        ProfilePicture = c.String(),
                        SocialGooglePlus = c.String(maxLength: 512),
                        SocialFacebok = c.String(maxLength: 512),
                        SocialTwiter = c.String(maxLength: 512),
                        SocialTelegram = c.String(maxLength: 512),
                        Socialinstagram = c.String(maxLength: 512),
                        MainCategoryId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                        MainCategory_MainCategoryId = c.Guid(),
                    })
                .PrimaryKey(t => t.CompanyProfileId)
                .ForeignKey("dbo.MainCategories", t => t.MainCategory_MainCategoryId)
                .ForeignKey("dbo.MainCategories", t => t.MainCategoryId)
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
                        PersonalProfileId = c.Guid(nullable: false),
                        CompanyProfileId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.CompanyProfiles", t => t.CompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PersonalProfiles", t => t.PersonalProfileId, cascadeDelete: true)
                .Index(t => t.PersonalProfileId)
                .Index(t => t.CompanyProfileId);
            
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
                "dbo.PersonalProfiles",
                c => new
                    {
                        PersonalProfileId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        LastName = c.String(nullable: false, maxLength: 256),
                        ProfilePicture = c.String(),
                        SocialGooglePlus = c.String(maxLength: 512),
                        SocialFacebok = c.String(maxLength: 512),
                        SocialTwiter = c.String(maxLength: 512),
                        SocialTelegram = c.String(maxLength: 512),
                        MainCategoryId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                        MainCategory_MainCategoryId = c.Guid(),
                    })
                .PrimaryKey(t => t.PersonalProfileId)
                .ForeignKey("dbo.MainCategories", t => t.MainCategory_MainCategoryId)
                .ForeignKey("dbo.MainCategories", t => t.MainCategoryId)
                .Index(t => t.MainCategoryId)
                .Index(t => t.MainCategory_MainCategoryId);
            
            CreateTable(
                "dbo.ImageGalleries",
                c => new
                    {
                        ImageGalleryId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Describtion = c.String(),
                        Rate = c.Int(nullable: false),
                        PersonalProfileId = c.Guid(nullable: false),
                        CompanyProfileId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                        ImageGallery_ImageGalleryId = c.Guid(),
                    })
                .PrimaryKey(t => t.ImageGalleryId)
                .ForeignKey("dbo.CompanyProfiles", t => t.CompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.ImageGalleries", t => t.ImageGallery_ImageGalleryId)
                .ForeignKey("dbo.PersonalProfiles", t => t.PersonalProfileId, cascadeDelete: true)
                .Index(t => t.PersonalProfileId)
                .Index(t => t.CompanyProfileId)
                .Index(t => t.ImageGallery_ImageGalleryId);
            
            CreateTable(
                "dbo.MainCategories",
                c => new
                    {
                        MainCategoryId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Describtion = c.String(),
                        ParentId = c.Int(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                        Parent_MainCategoryId = c.Guid(),
                    })
                .PrimaryKey(t => t.MainCategoryId)
                .ForeignKey("dbo.MainCategories", t => t.Parent_MainCategoryId)
                .Index(t => t.Parent_MainCategoryId);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        PortfolioId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        ThumbnailImage = c.String(),
                        Describtion = c.String(),
                        Rate = c.Int(nullable: false),
                        PersonalProfileId = c.Guid(nullable: false),
                        CompanyProfileId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.PortfolioId)
                .ForeignKey("dbo.CompanyProfiles", t => t.CompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PersonalProfiles", t => t.PersonalProfileId, cascadeDelete: true)
                .Index(t => t.PersonalProfileId)
                .Index(t => t.CompanyProfileId);
            
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
                        PersonalProfileId = c.Guid(nullable: false),
                        CompanyProfileId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.CompanyProfiles", t => t.CompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PersonalProfiles", t => t.PersonalProfileId, cascadeDelete: true)
                .ForeignKey("dbo.UseLocations", t => t.UseLocationId, cascadeDelete: true)
                .Index(t => t.BrandId)
                .Index(t => t.UseLocationId)
                .Index(t => t.PersonalProfileId)
                .Index(t => t.CompanyProfileId);
            
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
                        PersonalProfile_PersonalProfileId = c.Guid(nullable: false),
                        CompanyProfile_CompanyProfileId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalProfiles", t => t.PersonalProfile_PersonalProfileId)
                .ForeignKey("dbo.CompanyProfiles", t => t.CompanyProfile_CompanyProfileId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.PersonalProfile_PersonalProfileId)
                .Index(t => t.CompanyProfile_CompanyProfileId);
            
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
                        PersonalProfileId = c.Guid(nullable: false),
                        CompanyProfileId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.VideoGalleryId)
                .ForeignKey("dbo.CompanyProfiles", t => t.CompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PersonalProfiles", t => t.PersonalProfileId, cascadeDelete: true)
                .Index(t => t.PersonalProfileId)
                .Index(t => t.CompanyProfileId);
            
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
                        PersonalProfileId = c.Guid(nullable: false),
                        CompanyProfileId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.CompanyProfiles", t => t.CompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PersonalProfiles", t => t.PersonalProfileId, cascadeDelete: true)
                .Index(t => t.PersonalProfileId)
                .Index(t => t.CompanyProfileId);
            
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
            DropForeignKey("dbo.ProductFiles", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.Projects", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.ImageGalleryFiles", "ImageGalleryId", "dbo.ImageGalleries");
            DropForeignKey("dbo.Contacts", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.AspNetUsers", "CompanyProfile_CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.CompanyProfiles", "MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.VideoGalleryFiles", "VideoGalleryId", "dbo.VideoGalleries");
            DropForeignKey("dbo.VideoGalleries", "PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.VideoGalleries", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.AspNetUsers", "PersonalProfile_PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "UseLocationId", "dbo.UseLocations");
            DropForeignKey("dbo.ProductFiles", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.Products", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.PortfolioFiles", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Portfolios", "PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.Portfolios", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.PersonalProfiles", "MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.PersonalProfiles", "MainCategory_MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.CompanyProfiles", "MainCategory_MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.MainCategories", "Parent_MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.ImageGalleries", "PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.ImageGalleries", "ImageGallery_ImageGalleryId", "dbo.ImageGalleries");
            DropForeignKey("dbo.ImageGalleries", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.Articles", "PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.Addresses", "PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.Articles", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.ArticleFiles", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Addresses", "CompanyProfileId", "dbo.CompanyProfiles");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Projects", new[] { "CompanyProfileId" });
            DropIndex("dbo.Projects", new[] { "PersonalProfileId" });
            DropIndex("dbo.ProjectFiles", new[] { "ProjectId" });
            DropIndex("dbo.ImageGalleryFiles", new[] { "ImageGalleryId" });
            DropIndex("dbo.Contacts", new[] { "AddressId" });
            DropIndex("dbo.VideoGalleryFiles", new[] { "VideoGalleryId" });
            DropIndex("dbo.VideoGalleries", new[] { "CompanyProfileId" });
            DropIndex("dbo.VideoGalleries", new[] { "PersonalProfileId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "CompanyProfile_CompanyProfileId" });
            DropIndex("dbo.AspNetUsers", new[] { "PersonalProfile_PersonalProfileId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ProductFiles", new[] { "Project_ProjectId" });
            DropIndex("dbo.ProductFiles", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CompanyProfileId" });
            DropIndex("dbo.Products", new[] { "PersonalProfileId" });
            DropIndex("dbo.Products", new[] { "UseLocationId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.PortfolioFiles", new[] { "PortfolioId" });
            DropIndex("dbo.Portfolios", new[] { "CompanyProfileId" });
            DropIndex("dbo.Portfolios", new[] { "PersonalProfileId" });
            DropIndex("dbo.MainCategories", new[] { "Parent_MainCategoryId" });
            DropIndex("dbo.ImageGalleries", new[] { "ImageGallery_ImageGalleryId" });
            DropIndex("dbo.ImageGalleries", new[] { "CompanyProfileId" });
            DropIndex("dbo.ImageGalleries", new[] { "PersonalProfileId" });
            DropIndex("dbo.PersonalProfiles", new[] { "MainCategory_MainCategoryId" });
            DropIndex("dbo.PersonalProfiles", new[] { "MainCategoryId" });
            DropIndex("dbo.ArticleFiles", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "CompanyProfileId" });
            DropIndex("dbo.Articles", new[] { "PersonalProfileId" });
            DropIndex("dbo.CompanyProfiles", new[] { "MainCategory_MainCategoryId" });
            DropIndex("dbo.CompanyProfiles", new[] { "MainCategoryId" });
            DropIndex("dbo.Addresses", new[] { "CompanyProfileId" });
            DropIndex("dbo.Addresses", new[] { "PersonalProfileId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectFiles");
            DropTable("dbo.ImageGalleryFiles");
            DropTable("dbo.Contacts");
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
            DropTable("dbo.PersonalProfiles");
            DropTable("dbo.ArticleFiles");
            DropTable("dbo.Articles");
            DropTable("dbo.CompanyProfiles");
            DropTable("dbo.Addresses");
        }
    }
}
