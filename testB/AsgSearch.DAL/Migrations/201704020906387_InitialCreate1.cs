namespace AsgSearch.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.queries", "title", c => c.String());
            AddColumn("dbo.queries", "creationDate", c => c.String());
            AddColumn("dbo.queries", "answerCount", c => c.Int(nullable: false));
            AddColumn("dbo.queries", "displayName", c => c.String());
            AddColumn("dbo.queries", "profileImage", c => c.String());
            AddColumn("dbo.queries", "link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.queries", "link");
            DropColumn("dbo.queries", "profileImage");
            DropColumn("dbo.queries", "displayName");
            DropColumn("dbo.queries", "answerCount");
            DropColumn("dbo.queries", "creationDate");
            DropColumn("dbo.queries", "title");
        }
    }
}
