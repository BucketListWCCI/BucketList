namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restraunttypemodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestraurantTypes",
                c => new
                    {
                        RestraurantTypeId = c.Int(nullable: false, identity: true),
                        RestraurantsType = c.String(),
                    })
                .PrimaryKey(t => t.RestraurantTypeId);
            
            AddColumn("dbo.Restaurants", "RestraurantTypeId_RestraurantTypeId", c => c.Int());
            CreateIndex("dbo.Restaurants", "RestraurantTypeId_RestraurantTypeId");
            AddForeignKey("dbo.Restaurants", "RestraurantTypeId_RestraurantTypeId", "dbo.RestraurantTypes", "RestraurantTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "RestraurantTypeId_RestraurantTypeId", "dbo.RestraurantTypes");
            DropIndex("dbo.Restaurants", new[] { "RestraurantTypeId_RestraurantTypeId" });
            DropColumn("dbo.Restaurants", "RestraurantTypeId_RestraurantTypeId");
            DropTable("dbo.RestraurantTypes");
        }
    }
}
