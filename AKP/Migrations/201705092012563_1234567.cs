namespace AKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1234567 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Message", new[] { "person_PersonId" });
            AddColumn("dbo.Message", "PersonReceiverId", c => c.Int(nullable: false));
            CreateIndex("dbo.Message", "Person_PersonId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Message", new[] { "Person_PersonId" });
            DropColumn("dbo.Message", "PersonReceiverId");
            CreateIndex("dbo.Message", "person_PersonId");
        }
    }
}
