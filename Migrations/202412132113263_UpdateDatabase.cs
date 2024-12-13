namespace E_SHOPPING_WEB_SITE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            AddColumn("dbo.Products", "Image", c => c.String());
            AddColumn("dbo.Products", "Brand", c => c.String());
            AddColumn("dbo.Products", "SubCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "SubCategoryId");
            AddForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropColumn("dbo.Products", "SubCategoryId");
            DropColumn("dbo.Products", "Brand");
            DropColumn("dbo.Products", "Image");
            DropTable("dbo.SubCategories");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
