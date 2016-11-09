namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedController : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shoppings",
                c => new
                    {
                        ShoppingId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ShoppingType = c.String(),
                        Location = c.String(),
                        Link = c.String(),
                        IsComplete = c.Boolean(nullable: false),
                        ApplicatinUserID = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ShoppingId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shoppings", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Shoppings", new[] { "User_Id" });
            DropTable("dbo.Shoppings");
        }
    }
}
