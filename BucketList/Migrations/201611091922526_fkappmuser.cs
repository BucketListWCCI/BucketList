namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkappmuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Shopping_ShoppingId", "dbo.Shoppings");
            DropIndex("dbo.AspNetUsers", new[] { "Shopping_ShoppingId" });
            AddColumn("dbo.Shoppings", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Shoppings", "User_Id");
            AddForeignKey("dbo.Shoppings", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Shopping_ShoppingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Shopping_ShoppingId", c => c.Int());
            DropForeignKey("dbo.Shoppings", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Shoppings", new[] { "User_Id" });
            DropColumn("dbo.Shoppings", "User_Id");
            CreateIndex("dbo.AspNetUsers", "Shopping_ShoppingId");
            AddForeignKey("dbo.AspNetUsers", "Shopping_ShoppingId", "dbo.Shoppings", "ShoppingId");
        }
    }
}
