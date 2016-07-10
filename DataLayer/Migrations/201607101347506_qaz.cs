namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qaz : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MainCategories", "ParentId");
            RenameColumn(table: "dbo.MainCategories", name: "Parent_MainCategoryId", newName: "ParentId");
            RenameIndex(table: "dbo.MainCategories", name: "IX_Parent_MainCategoryId", newName: "IX_ParentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MainCategories", name: "IX_ParentId", newName: "IX_Parent_MainCategoryId");
            RenameColumn(table: "dbo.MainCategories", name: "ParentId", newName: "Parent_MainCategoryId");
            AddColumn("dbo.MainCategories", "ParentId", c => c.Guid());
        }
    }
}
