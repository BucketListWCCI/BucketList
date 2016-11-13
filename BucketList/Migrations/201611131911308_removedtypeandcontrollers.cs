namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedtypeandcontrollers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.entertainments", "EntertainmentType");
            DropColumn("dbo.museums", "MuseumType");
            DropColumn("dbo.restaurants", "RestaurantType");
            DropColumn("dbo.Shoppings", "ShoppingType");
            DropColumn("dbo.sports", "SportsType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.sports", "SportsType", c => c.String());
            AddColumn("dbo.Shoppings", "ShoppingType", c => c.String());
            AddColumn("dbo.restaurants", "RestaurantType", c => c.String());
            AddColumn("dbo.museums", "MuseumType", c => c.String());
            AddColumn("dbo.entertainments", "EntertainmentType", c => c.String());
        }
    }
}
