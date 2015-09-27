namespace HomeCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 200),
                        IdentityCard = c.String(nullable: false, maxLength: 50),
                        UniqueKey = c.Guid(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Mobile = c.String(maxLength: 10),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 2000),
                        Image = c.String(),
                        GenreId = c.Int(nullable: false),
                        Director = c.String(nullable: false, maxLength: 100),
                        Writer = c.String(nullable: false, maxLength: 50),
                        Producer = c.String(nullable: false, maxLength: 50),
                        ReleaseDate = c.DateTime(nullable: false),
                        Rating = c.Byte(nullable: false),
                        TrailerURI = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MovieID = c.Int(nullable: false),
                        UniqueKey = c.Guid(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movie", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.MovieID);
            
            CreateTable(
                "dbo.Rental",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        StockID = c.Int(nullable: false),
                        RentalDate = c.DateTime(nullable: false),
                        ReturnedDate = c.DateTime(),
                        Status = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Stock", t => t.StockID, cascadeDelete: true)
                .Index(t => t.StockID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 200),
                        HashedPassword = c.String(nullable: false, maxLength: 200),
                        Salt = c.String(nullable: false, maxLength: 200),
                        IsLocked = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserID", "dbo.User");
            DropForeignKey("dbo.Rental", "StockID", "dbo.Stock");
            DropForeignKey("dbo.Stock", "MovieID", "dbo.Movie");
            DropForeignKey("dbo.Movie", "GenreId", "dbo.Genre");
            DropIndex("dbo.UserRole", new[] { "UserID" });
            DropIndex("dbo.Rental", new[] { "StockID" });
            DropIndex("dbo.Stock", new[] { "MovieID" });
            DropIndex("dbo.Movie", new[] { "GenreId" });
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.Rental");
            DropTable("dbo.Stock");
            DropTable("dbo.Movie");
            DropTable("dbo.Genre");
            DropTable("dbo.Error");
            DropTable("dbo.Customer");
        }
    }
}
