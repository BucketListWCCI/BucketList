namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addentertainmentcontroller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.entertainments",
                c => new
                    {
                        EntertainmentId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        EntertainmentType = c.String(),
                        Link = c.String(),
                        Location = c.String(),
                        EntertainmentIsComplete = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EntertainmentId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.entertainments", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.entertainments", new[] { "User_Id" });
            DropTable("dbo.entertainments");
        }
    }
}
