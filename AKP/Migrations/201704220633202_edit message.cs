namespace AKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editmessage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Message", "PersonReceiver_PersonId", "dbo.Person");
            DropForeignKey("dbo.Message", "PersonSender_PersonId", "dbo.Person");
            DropIndex("dbo.Message", new[] { "PersonReceiver_PersonId" });
            DropIndex("dbo.Message", new[] { "PersonSender_PersonId" });
            AddColumn("dbo.Message", "PersonReceiverId", c => c.Int(nullable: false));
            AddColumn("dbo.Message", "PersonSenderId", c => c.Int(nullable: false));
            DropColumn("dbo.Message", "PersonReceiver_PersonId");
            DropColumn("dbo.Message", "PersonSender_PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "PersonSender_PersonId", c => c.Int());
            AddColumn("dbo.Message", "PersonReceiver_PersonId", c => c.Int());
            DropColumn("dbo.Message", "PersonSenderId");
            DropColumn("dbo.Message", "PersonReceiverId");
            CreateIndex("dbo.Message", "PersonSender_PersonId");
            CreateIndex("dbo.Message", "PersonReceiver_PersonId");
            AddForeignKey("dbo.Message", "PersonSender_PersonId", "dbo.Person", "PersonId");
            AddForeignKey("dbo.Message", "PersonReceiver_PersonId", "dbo.Person", "PersonId");
        }
    }
}
