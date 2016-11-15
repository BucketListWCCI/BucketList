namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sportstrypemodelcontroller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SportsTypes",
                c => new
                    {
                        SportsTypeId = c.Int(nullable: false, identity: true),
                        SportType = c.String(),
                    })
                .PrimaryKey(t => t.SportsTypeId);
            
            AddColumn("dbo.Sports", "SportsTypeId_SportsTypeId", c => c.Int());
            CreateIndex("dbo.Sports", "SportsTypeId_SportsTypeId");
            AddForeignKey("dbo.Sports", "SportsTypeId_SportsTypeId", "dbo.SportsTypes", "SportsTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sports", "SportsTypeId_SportsTypeId", "dbo.SportsTypes");
            DropIndex("dbo.Sports", new[] { "SportsTypeId_SportsTypeId" });
            DropColumn("dbo.Sports", "SportsTypeId_SportsTypeId");
            DropTable("dbo.SportsTypes");
        }
    }
}
