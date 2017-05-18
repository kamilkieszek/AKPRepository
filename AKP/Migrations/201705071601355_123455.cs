namespace AKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123455 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Message", new[] { "Person_PersonId" });
            CreateIndex("dbo.Message", "person_PersonId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Message", new[] { "person_PersonId" });
            CreateIndex("dbo.Message", "Person_PersonId");
        }
    }
}
