namespace bookClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Description", c => c.String());
            AddColumn("dbo.Reviews", "AccountID", c => c.Int(nullable: true));
            AddColumn("dbo.Reviews", "Account_ID", c => c.Int());
            CreateIndex("dbo.Reviews", "AccountID");
            CreateIndex("dbo.Reviews", "Account_ID");
            AddForeignKey("dbo.Reviews", "AccountID", "dbo.Accounts", "ID");
            AddForeignKey("dbo.Reviews", "Account_ID", "dbo.Accounts", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Account_ID", "dbo.Accounts");
            DropForeignKey("dbo.Reviews", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Reviews", new[] { "Account_ID" });
            DropIndex("dbo.Reviews", new[] { "AccountID" });
            DropColumn("dbo.Reviews", "Account_ID");
            DropColumn("dbo.Reviews", "AccountID");
            DropColumn("dbo.Books", "Description");
        }
    }
}
