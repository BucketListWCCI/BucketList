namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
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
                        EntertainmentTypeId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EntertainmentId)
                .ForeignKey("dbo.EntertainmentTypes", t => t.EntertainmentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.EntertainmentTypeId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.EntertainmentTypes",
                c => new
                    {
                        EntertainmentTypeId = c.Int(nullable: false, identity: true),
                        EntertainmentsType = c.String(),
                    })
                .PrimaryKey(t => t.EntertainmentTypeId);
            
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
                        UserList_ListId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserLists", t => t.UserList_ListId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.UserList_ListId);
            
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
                "dbo.ListCategories",
                c => new
                    {
                        ListCategoryId = c.Int(nullable: false, identity: true),
                        ListCategories = c.String(),
                    })
                .PrimaryKey(t => t.ListCategoryId);
            
            CreateTable(
                "dbo.UserLists",
                c => new
                    {
                        ListId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ItemCategory = c.String(),
                        Link = c.String(),
                        Location = c.String(),
                        UserIsComplete = c.Boolean(nullable: false),
                        ApplicationUserId = c.String(),
                        ListCategoryId = c.Int(nullable: false),
                        UserName_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ListId)
                .ForeignKey("dbo.ListCategories", t => t.ListCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserName_Id)
                .Index(t => t.ListCategoryId)
                .Index(t => t.UserName_Id);
            
            CreateTable(
                "dbo.Museums",
                c => new
                    {
                        MuseumId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        Location = c.String(),
                        MuseumTypeId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MuseumId)
                .ForeignKey("dbo.MuseumTypes", t => t.MuseumTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.MuseumTypeId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.MuseumTypes",
                c => new
                    {
                        MuseumTypeId = c.Int(nullable: false, identity: true),
                        MuseumsType = c.String(),
                    })
                .PrimaryKey(t => t.MuseumTypeId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        Location = c.String(),
                        RestraurantTypeId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RestaurantId)
                .ForeignKey("dbo.RestraurantTypes", t => t.RestraurantTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.RestraurantTypeId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.RestraurantTypes",
                c => new
                    {
                        RestraurantTypeId = c.Int(nullable: false, identity: true),
                        RestraurantsType = c.String(),
                    })
                .PrimaryKey(t => t.RestraurantTypeId);
            
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
                        ShoppingTypeID = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ShoppingId)
                .ForeignKey("dbo.ShoppingTypes", t => t.ShoppingTypeID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.ShoppingTypeID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ShoppingTypes",
                c => new
                    {
                        ShoppingTypeId = c.Int(nullable: false, identity: true),
                        ShoppingsType = c.String(),
                    })
                .PrimaryKey(t => t.ShoppingTypeId);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        SportsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        SportTypeId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SportsId)
                .ForeignKey("dbo.SportsTypes", t => t.SportTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.SportTypeId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.SportsTypes",
                c => new
                    {
                        SportsTypeId = c.Int(nullable: false, identity: true),
                        SportType = c.String(),
                    })
                .PrimaryKey(t => t.SportsTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sports", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sports", "SportTypeId", "dbo.SportsTypes");
            DropForeignKey("dbo.Shoppings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shoppings", "ShoppingTypeID", "dbo.ShoppingTypes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Restaurants", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Restaurants", "RestraurantTypeId", "dbo.RestraurantTypes");
            DropForeignKey("dbo.Museums", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Museums", "MuseumTypeId", "dbo.MuseumTypes");
            DropForeignKey("dbo.UserLists", "UserName_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLists", "ListCategoryId", "dbo.ListCategories");
            DropForeignKey("dbo.AspNetUsers", "UserList_ListId", "dbo.UserLists");
            DropForeignKey("dbo.Entertainments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Entertainments", "EntertainmentTypeId", "dbo.EntertainmentTypes");
            DropIndex("dbo.Sports", new[] { "User_Id" });
            DropIndex("dbo.Sports", new[] { "SportTypeId" });
            DropIndex("dbo.Shoppings", new[] { "User_Id" });
            DropIndex("dbo.Shoppings", new[] { "ShoppingTypeID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Restaurants", new[] { "User_Id" });
            DropIndex("dbo.Restaurants", new[] { "RestraurantTypeId" });
            DropIndex("dbo.Museums", new[] { "User_Id" });
            DropIndex("dbo.Museums", new[] { "MuseumTypeId" });
            DropIndex("dbo.UserLists", new[] { "UserName_Id" });
            DropIndex("dbo.UserLists", new[] { "ListCategoryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "UserList_ListId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Entertainments", new[] { "User_Id" });
            DropIndex("dbo.Entertainments", new[] { "EntertainmentTypeId" });
            DropTable("dbo.SportsTypes");
            DropTable("dbo.Sports");
            DropTable("dbo.ShoppingTypes");
            DropTable("dbo.Shoppings");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RestraurantTypes");
            DropTable("dbo.Restaurants");
            DropTable("dbo.MuseumTypes");
            DropTable("dbo.Museums");
            DropTable("dbo.UserLists");
            DropTable("dbo.ListCategories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.EntertainmentTypes");
            DropTable("dbo.Entertainments");
        }
    }
}
