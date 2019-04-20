namespace Isa.Infrastructures.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        InvoiceHeaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.InvoiceHeaders",
                c => new
                    {
                        InvoiceHeaderId = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceHeaderId);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        InvoiceItemId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        InvoiceHeaderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceItemId)
                .ForeignKey("dbo.InvoiceHeaders", t => t.InvoiceHeaderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.InvoiceHeaderId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.InvoiceItems", "InvoiceHeaderId", "dbo.InvoiceHeaders");
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceHeaderId" });
            DropIndex("dbo.InvoiceItems", new[] { "ProductId" });
            DropTable("dbo.Products");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.InvoiceHeaders");
            DropTable("dbo.Clients");
        }
    }
}
