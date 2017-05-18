namespace AKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Message", "NumberVisits", c => c.Int(nullable: false));
            AddColumn("dbo.Message", "PersonReceiver_PersonId", c => c.Int());
            AddColumn("dbo.Message", "PersonSender_PersonId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "person_PersonId", c => c.Int());
            CreateIndex("dbo.Message", "PersonReceiver_PersonId");
            CreateIndex("dbo.Message", "PersonSender_PersonId");
            CreateIndex("dbo.AspNetUsers", "person_PersonId");
            AddForeignKey("dbo.Message", "PersonReceiver_PersonId", "dbo.Person", "PersonId");
            AddForeignKey("dbo.Message", "PersonSender_PersonId", "dbo.Person", "PersonId");
            AddForeignKey("dbo.AspNetUsers", "person_PersonId", "dbo.Person", "PersonId");
            DropColumn("dbo.Message", "AddresseeId");
            DropColumn("dbo.Message", "ReceiverId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "ReceiverId", c => c.Int(nullable: false));
            AddColumn("dbo.Message", "AddresseeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "person_PersonId", "dbo.Person");
            DropForeignKey("dbo.Message", "PersonSender_PersonId", "dbo.Person");
            DropForeignKey("dbo.Message", "PersonReceiver_PersonId", "dbo.Person");
            DropIndex("dbo.AspNetUsers", new[] { "person_PersonId" });
            DropIndex("dbo.Message", new[] { "PersonSender_PersonId" });
            DropIndex("dbo.Message", new[] { "PersonReceiver_PersonId" });
            DropColumn("dbo.AspNetUsers", "person_PersonId");
            DropColumn("dbo.Message", "PersonSender_PersonId");
            DropColumn("dbo.Message", "PersonReceiver_PersonId");
            DropColumn("dbo.Message", "NumberVisits");
        }
    }
}
