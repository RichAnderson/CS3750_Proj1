namespace Project1Todo.Migrations.CMS
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToDo1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListId = c.Int(nullable: false, identity: true),
                        ListName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ListId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        Complete = c.Boolean(nullable: false),
                        CompletionDate = c.DateTime(),
                        ListId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Lists", t => t.ListId)
                .Index(t => t.ListId);
            
            CreateTable(
                "dbo.ListCategories",
                c => new
                    {
                        List_ListId = c.Int(nullable: false),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.List_ListId, t.Category_CategoryId })
                .ForeignKey("dbo.Lists", t => t.List_ListId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .Index(t => t.List_ListId)
                .Index(t => t.Category_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ListId", "dbo.Lists");
            DropForeignKey("dbo.ListCategories", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ListCategories", "List_ListId", "dbo.Lists");
            DropIndex("dbo.ListCategories", new[] { "Category_CategoryId" });
            DropIndex("dbo.ListCategories", new[] { "List_ListId" });
            DropIndex("dbo.Items", new[] { "ListId" });
            DropTable("dbo.ListCategories");
            DropTable("dbo.Items");
            DropTable("dbo.Lists");
            DropTable("dbo.Categories");
        }
    }
}
