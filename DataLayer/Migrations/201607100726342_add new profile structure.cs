namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewprofilestructure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.Articles", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.Addresses", "PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.Articles", "PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.ImageGalleries", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.ImageGalleries", "PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.CompanyProfiles", "MainCategory_MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.PersonalProfiles", "MainCategory_MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.PersonalProfiles", "MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.Portfolios", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.Portfolios", "PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.Products", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.Products", "PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.AspNetUsers", "PersonalProfile_PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.VideoGalleries", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.VideoGalleries", "PersonalProfileId", "dbo.PersonalProfiles");
            DropForeignKey("dbo.CompanyProfiles", "MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.AspNetUsers", "CompanyProfile_CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.Projects", "CompanyProfileId", "dbo.CompanyProfiles");
            DropForeignKey("dbo.Projects", "PersonalProfileId", "dbo.PersonalProfiles");
            DropIndex("dbo.Addresses", new[] { "PersonalProfileId" });
            DropIndex("dbo.Addresses", new[] { "CompanyProfileId" });
            DropIndex("dbo.CompanyProfiles", new[] { "MainCategoryId" });
            DropIndex("dbo.CompanyProfiles", new[] { "MainCategory_MainCategoryId" });
            DropIndex("dbo.Articles", new[] { "PersonalProfileId" });
            DropIndex("dbo.Articles", new[] { "CompanyProfileId" });
            DropIndex("dbo.PersonalProfiles", new[] { "MainCategoryId" });
            DropIndex("dbo.PersonalProfiles", new[] { "MainCategory_MainCategoryId" });
            DropIndex("dbo.ImageGalleries", new[] { "PersonalProfileId" });
            DropIndex("dbo.ImageGalleries", new[] { "CompanyProfileId" });
            DropIndex("dbo.Portfolios", new[] { "PersonalProfileId" });
            DropIndex("dbo.Portfolios", new[] { "CompanyProfileId" });
            DropIndex("dbo.Products", new[] { "PersonalProfileId" });
            DropIndex("dbo.Products", new[] { "CompanyProfileId" });
            DropIndex("dbo.AspNetUsers", new[] { "PersonalProfile_PersonalProfileId" });
            DropIndex("dbo.AspNetUsers", new[] { "CompanyProfile_CompanyProfileId" });
            DropIndex("dbo.VideoGalleries", new[] { "PersonalProfileId" });
            DropIndex("dbo.VideoGalleries", new[] { "CompanyProfileId" });
            DropIndex("dbo.Projects", new[] { "PersonalProfileId" });
            DropIndex("dbo.Projects", new[] { "CompanyProfileId" });
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.Guid(nullable: false),
                        ProfileType = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 256),
                        LastName = c.String(nullable: false, maxLength: 256),
                        ProfilePicture = c.String(),
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
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.MainCategories", t => t.MainCategory_MainCategoryId)
                .ForeignKey("dbo.MainCategories", t => t.MainCategoryId)
                .Index(t => t.MainCategoryId)
                .Index(t => t.MainCategory_MainCategoryId);
            
            AddColumn("dbo.Addresses", "ProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Articles", "ProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.ImageGalleries", "ProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Portfolios", "ProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "ProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.AspNetUsers", "ProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.AspNetUsers", "Profile_ProfileId", c => c.Guid());
            AddColumn("dbo.VideoGalleries", "ProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Projects", "ProfileId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Addresses", "ProfileId");
            CreateIndex("dbo.Articles", "ProfileId");
            CreateIndex("dbo.ImageGalleries", "ProfileId");
            CreateIndex("dbo.Portfolios", "ProfileId");
            CreateIndex("dbo.Products", "ProfileId");
            CreateIndex("dbo.AspNetUsers", "Profile_ProfileId");
            CreateIndex("dbo.VideoGalleries", "ProfileId");
            CreateIndex("dbo.Projects", "ProfileId");
            AddForeignKey("dbo.Addresses", "ProfileId", "dbo.Profiles", "ProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Articles", "ProfileId", "dbo.Profiles", "ProfileId", cascadeDelete: true);
            AddForeignKey("dbo.ImageGalleries", "ProfileId", "dbo.Profiles", "ProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Portfolios", "ProfileId", "dbo.Profiles", "ProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "ProfileId", "dbo.Profiles", "ProfileId", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "Profile_ProfileId", "dbo.Profiles", "ProfileId");
            AddForeignKey("dbo.VideoGalleries", "ProfileId", "dbo.Profiles", "ProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "ProfileId", "dbo.Profiles", "ProfileId", cascadeDelete: true);
            DropColumn("dbo.Addresses", "PersonalProfileId");
            DropColumn("dbo.Addresses", "CompanyProfileId");
            DropColumn("dbo.Articles", "PersonalProfileId");
            DropColumn("dbo.Articles", "CompanyProfileId");
            DropColumn("dbo.ImageGalleries", "PersonalProfileId");
            DropColumn("dbo.ImageGalleries", "CompanyProfileId");
            DropColumn("dbo.Portfolios", "PersonalProfileId");
            DropColumn("dbo.Portfolios", "CompanyProfileId");
            DropColumn("dbo.Products", "PersonalProfileId");
            DropColumn("dbo.Products", "CompanyProfileId");
            DropColumn("dbo.AspNetUsers", "PersonalProfile_PersonalProfileId");
            DropColumn("dbo.AspNetUsers", "CompanyProfile_CompanyProfileId");
            DropColumn("dbo.VideoGalleries", "PersonalProfileId");
            DropColumn("dbo.VideoGalleries", "CompanyProfileId");
            DropColumn("dbo.Projects", "PersonalProfileId");
            DropColumn("dbo.Projects", "CompanyProfileId");
            DropTable("dbo.CompanyProfiles");
            DropTable("dbo.PersonalProfiles");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.PersonalProfileId);
            
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
                .PrimaryKey(t => t.CompanyProfileId);
            
            AddColumn("dbo.Projects", "CompanyProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Projects", "PersonalProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.VideoGalleries", "CompanyProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.VideoGalleries", "PersonalProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.AspNetUsers", "CompanyProfile_CompanyProfileId", c => c.Guid());
            AddColumn("dbo.AspNetUsers", "PersonalProfile_PersonalProfileId", c => c.Guid());
            AddColumn("dbo.Products", "CompanyProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "PersonalProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Portfolios", "CompanyProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Portfolios", "PersonalProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.ImageGalleries", "CompanyProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.ImageGalleries", "PersonalProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Articles", "CompanyProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Articles", "PersonalProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Addresses", "CompanyProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Addresses", "PersonalProfileId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Projects", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.VideoGalleries", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.AspNetUsers", "Profile_ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Products", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Portfolios", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.Profiles", "MainCategory_MainCategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.ImageGalleries", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Articles", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Addresses", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Projects", new[] { "ProfileId" });
            DropIndex("dbo.VideoGalleries", new[] { "ProfileId" });
            DropIndex("dbo.AspNetUsers", new[] { "Profile_ProfileId" });
            DropIndex("dbo.Products", new[] { "ProfileId" });
            DropIndex("dbo.Portfolios", new[] { "ProfileId" });
            DropIndex("dbo.ImageGalleries", new[] { "ProfileId" });
            DropIndex("dbo.Articles", new[] { "ProfileId" });
            DropIndex("dbo.Profiles", new[] { "MainCategory_MainCategoryId" });
            DropIndex("dbo.Profiles", new[] { "MainCategoryId" });
            DropIndex("dbo.Addresses", new[] { "ProfileId" });
            DropColumn("dbo.Projects", "ProfileId");
            DropColumn("dbo.VideoGalleries", "ProfileId");
            DropColumn("dbo.AspNetUsers", "Profile_ProfileId");
            DropColumn("dbo.AspNetUsers", "ProfileId");
            DropColumn("dbo.Products", "ProfileId");
            DropColumn("dbo.Portfolios", "ProfileId");
            DropColumn("dbo.ImageGalleries", "ProfileId");
            DropColumn("dbo.Articles", "ProfileId");
            DropColumn("dbo.Addresses", "ProfileId");
            DropTable("dbo.Profiles");
            CreateIndex("dbo.Projects", "CompanyProfileId");
            CreateIndex("dbo.Projects", "PersonalProfileId");
            CreateIndex("dbo.VideoGalleries", "CompanyProfileId");
            CreateIndex("dbo.VideoGalleries", "PersonalProfileId");
            CreateIndex("dbo.AspNetUsers", "CompanyProfile_CompanyProfileId");
            CreateIndex("dbo.AspNetUsers", "PersonalProfile_PersonalProfileId");
            CreateIndex("dbo.Products", "CompanyProfileId");
            CreateIndex("dbo.Products", "PersonalProfileId");
            CreateIndex("dbo.Portfolios", "CompanyProfileId");
            CreateIndex("dbo.Portfolios", "PersonalProfileId");
            CreateIndex("dbo.ImageGalleries", "CompanyProfileId");
            CreateIndex("dbo.ImageGalleries", "PersonalProfileId");
            CreateIndex("dbo.PersonalProfiles", "MainCategory_MainCategoryId");
            CreateIndex("dbo.PersonalProfiles", "MainCategoryId");
            CreateIndex("dbo.Articles", "CompanyProfileId");
            CreateIndex("dbo.Articles", "PersonalProfileId");
            CreateIndex("dbo.CompanyProfiles", "MainCategory_MainCategoryId");
            CreateIndex("dbo.CompanyProfiles", "MainCategoryId");
            CreateIndex("dbo.Addresses", "CompanyProfileId");
            CreateIndex("dbo.Addresses", "PersonalProfileId");
            AddForeignKey("dbo.Projects", "PersonalProfileId", "dbo.PersonalProfiles", "PersonalProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "CompanyProfileId", "dbo.CompanyProfiles", "CompanyProfileId", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "CompanyProfile_CompanyProfileId", "dbo.CompanyProfiles", "CompanyProfileId");
            AddForeignKey("dbo.CompanyProfiles", "MainCategoryId", "dbo.MainCategories", "MainCategoryId");
            AddForeignKey("dbo.VideoGalleries", "PersonalProfileId", "dbo.PersonalProfiles", "PersonalProfileId", cascadeDelete: true);
            AddForeignKey("dbo.VideoGalleries", "CompanyProfileId", "dbo.CompanyProfiles", "CompanyProfileId", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "PersonalProfile_PersonalProfileId", "dbo.PersonalProfiles", "PersonalProfileId");
            AddForeignKey("dbo.Products", "PersonalProfileId", "dbo.PersonalProfiles", "PersonalProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CompanyProfileId", "dbo.CompanyProfiles", "CompanyProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Portfolios", "PersonalProfileId", "dbo.PersonalProfiles", "PersonalProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Portfolios", "CompanyProfileId", "dbo.CompanyProfiles", "CompanyProfileId", cascadeDelete: true);
            AddForeignKey("dbo.PersonalProfiles", "MainCategoryId", "dbo.MainCategories", "MainCategoryId");
            AddForeignKey("dbo.PersonalProfiles", "MainCategory_MainCategoryId", "dbo.MainCategories", "MainCategoryId");
            AddForeignKey("dbo.CompanyProfiles", "MainCategory_MainCategoryId", "dbo.MainCategories", "MainCategoryId");
            AddForeignKey("dbo.ImageGalleries", "PersonalProfileId", "dbo.PersonalProfiles", "PersonalProfileId", cascadeDelete: true);
            AddForeignKey("dbo.ImageGalleries", "CompanyProfileId", "dbo.CompanyProfiles", "CompanyProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Articles", "PersonalProfileId", "dbo.PersonalProfiles", "PersonalProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "PersonalProfileId", "dbo.PersonalProfiles", "PersonalProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Articles", "CompanyProfileId", "dbo.CompanyProfiles", "CompanyProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "CompanyProfileId", "dbo.CompanyProfiles", "CompanyProfileId", cascadeDelete: true);
        }
    }
}
