namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRestaurantsController : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        RestaurantType = c.String(),
                        Link = c.String(),
                        Location = c.String(),
                        RestaurantsIsComplete = c.Boolean(nullable: false),
                        ApplicatinUserID = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RestaurantId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Restaurants", new[] { "User_Id" });
            DropTable("dbo.Restaurants");
        }
    }
}
