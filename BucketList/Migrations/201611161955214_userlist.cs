namespace BucketList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userlist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "UserList_ListId1", "dbo.UserLists");
            DropIndex("dbo.AspNetUsers", new[] { "UserList_ListId1" });
            DropColumn("dbo.AspNetUsers", "UserList_ListId1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserList_ListId1", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "UserList_ListId1");
            AddForeignKey("dbo.AspNetUsers", "UserList_ListId1", "dbo.UserLists", "ListId");
        }
    }
}
