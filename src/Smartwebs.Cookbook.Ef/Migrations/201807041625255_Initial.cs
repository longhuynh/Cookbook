namespace Smartwebs.Cookbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeVersions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RecipeId = c.Long(),
                        ModifiedDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RecipeVersions");
            DropTable("dbo.Recipes");
        }
    }
}
