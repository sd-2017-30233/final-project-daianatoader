namespace bookClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre = c.Int(nullable: false),
                        AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authors", t => t.AuthorID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        BookID = c.Int(nullable: false),
                        Book_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID)
                .ForeignKey("dbo.Books", t => t.Book_ID)
                .Index(t => t.BookID)
                .Index(t => t.Book_ID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Text = c.String(),
                        BookID = c.Int(nullable: false),
                        Book_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID)
                .ForeignKey("dbo.Books", t => t.Book_ID)
                .Index(t => t.BookID)
                .Index(t => t.Book_ID);
            
            CreateTable(
                "dbo.Accounts_Books",
                c => new
                    {
                        AccountID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountID, t.BookID })
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts_Books", "BookID", "dbo.Books");
            DropForeignKey("dbo.Accounts_Books", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Reviews", "Book_ID", "dbo.Books");
            DropForeignKey("dbo.Reviews", "BookID", "dbo.Books");
            DropForeignKey("dbo.Quotes", "Book_ID", "dbo.Books");
            DropForeignKey("dbo.Quotes", "BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Accounts_Books", new[] { "BookID" });
            DropIndex("dbo.Accounts_Books", new[] { "AccountID" });
            DropIndex("dbo.Reviews", new[] { "Book_ID" });
            DropIndex("dbo.Reviews", new[] { "BookID" });
            DropIndex("dbo.Quotes", new[] { "Book_ID" });
            DropIndex("dbo.Quotes", new[] { "BookID" });
            DropIndex("dbo.Books", new[] { "AuthorID" });
            DropTable("dbo.Accounts_Books");
            DropTable("dbo.Reviews");
            DropTable("dbo.Quotes");
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
            DropTable("dbo.Accounts");
        }
    }
}
