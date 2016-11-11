namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsportscontroller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.sports",
                c => new
                    {
                        SportsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        SportsType = c.String(),
                        Link = c.String(),
                        SportsIsComplete = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SportsId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.sports", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.sports", new[] { "User_Id" });
            DropTable("dbo.sports");
        }
    }
}
