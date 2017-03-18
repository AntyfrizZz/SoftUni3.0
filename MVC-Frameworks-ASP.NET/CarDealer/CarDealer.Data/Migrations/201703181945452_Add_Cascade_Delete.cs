namespace CarDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Cascade_Delete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parts", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Parts", new[] { "Supplier_Id" });
            AlterColumn("dbo.Parts", "Supplier_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Parts", "Supplier_Id");
            AddForeignKey("dbo.Parts", "Supplier_Id", "dbo.Suppliers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Parts", new[] { "Supplier_Id" });
            AlterColumn("dbo.Parts", "Supplier_Id", c => c.Int());
            CreateIndex("dbo.Parts", "Supplier_Id");
            AddForeignKey("dbo.Parts", "Supplier_Id", "dbo.Suppliers", "Id");
        }
    }
}
