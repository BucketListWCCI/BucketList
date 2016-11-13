namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createentertainmenttype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entertainments",
                c => new
                    {
                        EntertainmentId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        Location = c.String(),
                        EntertainmentIsComplete = c.String(),
                        EntertainmentTypeId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EntertainmentId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 256),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Bio = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Museums",
                c => new
                    {
                        MuseumId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        Location = c.String(),
                        MuseumIsComplete = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MuseumId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        Location = c.String(),
                        RestaurantsIsComplete = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RestaurantId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Shoppings",
                c => new
                    {
                        ShoppingId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        Link = c.String(),
                        IsComplete = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ShoppingId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        SportsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        SportsIsComplete = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SportsId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sports", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shoppings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Restaurants", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Museums", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Entertainments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Sports", new[] { "User_Id" });
            DropIndex("dbo.Shoppings", new[] { "User_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Restaurants", new[] { "User_Id" });
            DropIndex("dbo.Museums", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Entertainments", new[] { "User_Id" });
            DropTable("dbo.Sports");
            DropTable("dbo.Shoppings");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Museums");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Entertainments");
        }
    }
}
