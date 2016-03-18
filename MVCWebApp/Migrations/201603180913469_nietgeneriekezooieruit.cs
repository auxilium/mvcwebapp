namespace MVCWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nietgeneriekezooieruit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EntryPoints", "group_ID", "dbo.EntryPointGroups");
            DropForeignKey("dbo.EntryPoints", "Product_ID", "dbo.Products");
            DropIndex("dbo.EntryPoints", new[] { "group_ID" });
            DropIndex("dbo.EntryPoints", new[] { "Product_ID" });
            AddColumn("dbo.Products", "Type", c => c.Int());
            DropColumn("dbo.Products", "IntellectualPropertyType");
            DropColumn("dbo.Products", "HostingType");
            DropTable("dbo.EntryPointGroups");
            DropTable("dbo.EntryPoints");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EntryPoints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                        group_ID = c.Int(),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EntryPointGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Products", "HostingType", c => c.Int());
            AddColumn("dbo.Products", "IntellectualPropertyType", c => c.Int());
            DropColumn("dbo.Products", "Type");
            CreateIndex("dbo.EntryPoints", "Product_ID");
            CreateIndex("dbo.EntryPoints", "group_ID");
            AddForeignKey("dbo.EntryPoints", "Product_ID", "dbo.Products", "ID");
            AddForeignKey("dbo.EntryPoints", "group_ID", "dbo.EntryPointGroups", "ID");
        }
    }
}
