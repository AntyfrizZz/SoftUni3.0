namespace CarDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Model = c.String(),
                        TravelledDistance = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(),
                        Quantity = c.Int(nullable: false),
                        Supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id)
                .Index(t => t.Supplier_Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsImporter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        IsYoungDriver = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Discount = c.Double(nullable: false),
                        Car_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Car_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.CarParts",
                c => new
                    {
                        Car_Id = c.Int(nullable: false),
                        Part_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Car_Id, t.Part_Id })
                .ForeignKey("dbo.Cars", t => t.Car_Id, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.Part_Id, cascadeDelete: true)
                .Index(t => t.Car_Id)
                .Index(t => t.Part_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Sales", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.CarParts", "Part_Id", "dbo.Parts");
            DropForeignKey("dbo.CarParts", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.Parts", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.CarParts", new[] { "Part_Id" });
            DropIndex("dbo.CarParts", new[] { "Car_Id" });
            DropIndex("dbo.Sales", new[] { "Customer_Id" });
            DropIndex("dbo.Sales", new[] { "Car_Id" });
            DropIndex("dbo.Parts", new[] { "Supplier_Id" });
            DropTable("dbo.CarParts");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Parts");
            DropTable("dbo.Cars");
        }
    }
}
