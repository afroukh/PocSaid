namespace Isa.Infrastructures.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixrelationships : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceHeaders", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.InvoiceHeaders", "ClientId");
            AddForeignKey("dbo.InvoiceHeaders", "ClientId", "dbo.Clients", "ClientId", cascadeDelete: true);
            DropColumn("dbo.Clients", "InvoiceHeaderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "InvoiceHeaderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.InvoiceHeaders", "ClientId", "dbo.Clients");
            DropIndex("dbo.InvoiceHeaders", new[] { "ClientId" });
            DropColumn("dbo.InvoiceHeaders", "ClientId");
        }
    }
}
