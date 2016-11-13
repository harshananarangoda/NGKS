namespace NGKS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Header = c.String(nullable: false, maxLength: 50),
                        Tags = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        VideoURL = c.String(),
                        CaptionURL = c.String(),
                        UpVotes = c.Int(),
                        DownVotes = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 200),
                        Salt = c.String(nullable: false, maxLength: 200),
                        IsLocked = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        ParentCommentID = c.Int(nullable: false),
                        Message = c.String(nullable: false, maxLength: 500),
                        AddedDate = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Post", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: false)
                .Index(t => t.PostID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        DateTimeOccured = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "UserID", "dbo.User");
            DropForeignKey("dbo.Comment", "PostID", "dbo.Post");
            DropForeignKey("dbo.Post", "UserID", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserID", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleID", "dbo.Role");
            DropForeignKey("dbo.Post", "CategoryID", "dbo.Category");
            DropIndex("dbo.Comment", new[] { "UserID" });
            DropIndex("dbo.Comment", new[] { "PostID" });
            DropIndex("dbo.UserRole", new[] { "UserID" });
            DropIndex("dbo.UserRole", new[] { "RoleID" });
            DropIndex("dbo.Post", new[] { "UserID" });
            DropIndex("dbo.Post", new[] { "CategoryID" });
            DropTable("dbo.Error");
            DropTable("dbo.Comment");
            DropTable("dbo.Role");
            DropTable("dbo.UserRole");
            DropTable("dbo.User");
            DropTable("dbo.Post");
            DropTable("dbo.Category");
        }
    }
}
