namespace AsgSearch.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.queries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QueryText = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.queries");
        }
    }
}
