namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editcontext : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "PersonalProfile_PersonalProfileId" });
            DropIndex("dbo.AspNetUsers", new[] { "CompanyProfile_CompanyProfileId" });
            AlterColumn("dbo.AspNetUsers", "PersonalProfile_PersonalProfileId", c => c.Guid());
            AlterColumn("dbo.AspNetUsers", "CompanyProfile_CompanyProfileId", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "PersonalProfile_PersonalProfileId");
            CreateIndex("dbo.AspNetUsers", "CompanyProfile_CompanyProfileId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", new[] { "CompanyProfile_CompanyProfileId" });
            DropIndex("dbo.AspNetUsers", new[] { "PersonalProfile_PersonalProfileId" });
            AlterColumn("dbo.AspNetUsers", "CompanyProfile_CompanyProfileId", c => c.Guid(nullable: false));
            AlterColumn("dbo.AspNetUsers", "PersonalProfile_PersonalProfileId", c => c.Guid(nullable: false));
            CreateIndex("dbo.AspNetUsers", "CompanyProfile_CompanyProfileId");
            CreateIndex("dbo.AspNetUsers", "PersonalProfile_PersonalProfileId");
        }
    }
}
