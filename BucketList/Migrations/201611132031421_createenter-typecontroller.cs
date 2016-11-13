namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createentertypecontroller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntertainmentTypes",
                c => new
                    {
                        EntertainmentTypeId = c.Int(nullable: false, identity: true),
                        EntertainmentsType = c.String(),
                    })
                .PrimaryKey(t => t.EntertainmentTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EntertainmentTypes");
        }
    }
}
