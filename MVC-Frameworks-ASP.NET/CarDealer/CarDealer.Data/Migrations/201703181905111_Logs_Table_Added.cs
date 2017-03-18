namespace CarDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Logs_Table_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Operation = c.Int(nullable: false),
                        ModifiedTableName = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "User_Id", "dbo.Users");
            DropIndex("dbo.Logs", new[] { "User_Id" });
            DropTable("dbo.Logs");
        }
    }
}
