namespace AsgSearch.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.queries", "Time", c => c.DateTime());
            AlterColumn("dbo.queries", "creationDate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.queries", "creationDate", c => c.String());
            AlterColumn("dbo.queries", "Time", c => c.DateTime(nullable: false));
        }
    }
}
