namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingtypecontroller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingTypes",
                c => new
                    {
                        ShoppingTypeId = c.Int(nullable: false, identity: true),
                        ShoppingsType = c.String(),
                    })
                .PrimaryKey(t => t.ShoppingTypeId);
            
            AddColumn("dbo.Shoppings", "ShoppingTypeID_ShoppingTypeId", c => c.Int());
            CreateIndex("dbo.Shoppings", "ShoppingTypeID_ShoppingTypeId");
            AddForeignKey("dbo.Shoppings", "ShoppingTypeID_ShoppingTypeId", "dbo.ShoppingTypes", "ShoppingTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shoppings", "ShoppingTypeID_ShoppingTypeId", "dbo.ShoppingTypes");
            DropIndex("dbo.Shoppings", new[] { "ShoppingTypeID_ShoppingTypeId" });
            DropColumn("dbo.Shoppings", "ShoppingTypeID_ShoppingTypeId");
            DropTable("dbo.ShoppingTypes");
        }
    }
}
