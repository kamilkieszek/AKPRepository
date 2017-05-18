namespace AKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Identity2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "person_PersonId", "dbo.Person");
            DropIndex("dbo.AspNetUsers", new[] { "person_PersonId" });
            DropColumn("dbo.AspNetUsers", "person_PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "person_PersonId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "person_PersonId");
            AddForeignKey("dbo.AspNetUsers", "person_PersonId", "dbo.Person", "PersonId");
        }
    }
}
