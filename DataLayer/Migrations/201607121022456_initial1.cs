namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileFiles",
                c => new
                    {
                        ProfileFileId = c.Guid(nullable: false),
                        FileName = c.String(),
                        NewFileName = c.String(maxLength: 1024),
                        LinkUrl = c.String(maxLength: 256),
                        Size = c.Int(nullable: false),
                        Type = c.String(maxLength: 1024),
                        Comment = c.String(maxLength: 256),
                        ProfileId = c.Guid(nullable: false),
                        Profile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProfileFileId)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileFiles", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.ProfileFiles", new[] { "Profile_Id" });
            DropTable("dbo.ProfileFiles");
        }
    }
}
