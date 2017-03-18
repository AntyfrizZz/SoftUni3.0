namespace CarDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_User_FK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logins", "UserId", "dbo.Users");
            DropIndex("dbo.Logins", new[] { "UserId" });
            RenameColumn(table: "dbo.Logins", name: "UserId", newName: "User_Id");
            AlterColumn("dbo.Logins", "User_Id", c => c.Int());
            CreateIndex("dbo.Logins", "User_Id");
            AddForeignKey("dbo.Logins", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "User_Id", "dbo.Users");
            DropIndex("dbo.Logins", new[] { "User_Id" });
            AlterColumn("dbo.Logins", "User_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Logins", name: "User_Id", newName: "UserId");
            CreateIndex("dbo.Logins", "UserId");
            AddForeignKey("dbo.Logins", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
