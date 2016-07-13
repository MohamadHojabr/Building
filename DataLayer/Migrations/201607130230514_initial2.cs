namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "SocialInstagram", c => c.String(maxLength: 512));
            DropColumn("dbo.Profiles", "Instagram");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Instagram", c => c.String(maxLength: 512));
            DropColumn("dbo.Profiles", "SocialInstagram");
        }
    }
}
