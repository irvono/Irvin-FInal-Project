namespace OnoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.AlbumID);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        PhotoID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhotoFile = c.String(),
                        AlbumID = c.Int(nullable: false),
                        OnerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoID)
                .ForeignKey("dbo.Album", t => t.AlbumID, cascadeDelete: true)
                .ForeignKey("dbo.Oner", t => t.OnerID, cascadeDelete: true)
                .Index(t => t.AlbumID)
                .Index(t => t.OnerID);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        OnerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Oner", t => t.OnerID, cascadeDelete: true)
                .Index(t => t.OnerID);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.Video",
                c => new
                    {
                        VideoID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        GenreID = c.Int(nullable: false),
                        OnerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VideoID)
                .ForeignKey("dbo.Genre", t => t.GenreID, cascadeDelete: true)
                .ForeignKey("dbo.Oner", t => t.OnerID, cascadeDelete: true)
                .Index(t => t.GenreID)
                .Index(t => t.OnerID);
            
            CreateTable(
                "dbo.Oner",
                c => new
                    {
                        OnerID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        Skill = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.OnerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Video", "OnerID", "dbo.Oner");
            DropForeignKey("dbo.Photo", "OnerID", "dbo.Oner");
            DropForeignKey("dbo.Event", "OnerID", "dbo.Oner");
            DropForeignKey("dbo.Video", "GenreID", "dbo.Genre");
            DropForeignKey("dbo.Photo", "AlbumID", "dbo.Album");
            DropIndex("dbo.Video", new[] { "OnerID" });
            DropIndex("dbo.Video", new[] { "GenreID" });
            DropIndex("dbo.Event", new[] { "OnerID" });
            DropIndex("dbo.Photo", new[] { "OnerID" });
            DropIndex("dbo.Photo", new[] { "AlbumID" });
            DropTable("dbo.Oner");
            DropTable("dbo.Video");
            DropTable("dbo.Genre");
            DropTable("dbo.Event");
            DropTable("dbo.Photo");
            DropTable("dbo.Album");
        }
    }
}
