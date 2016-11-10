namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmuseumcontroller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.museums",
                c => new
                    {
                        MuseumId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        MuseumType = c.String(),
                        Link = c.String(),
                        Location = c.String(),
                        MuseumIsComplete = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MuseumId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.museums", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.museums", new[] { "User_Id" });
            DropTable("dbo.museums");
        }
    }
}
