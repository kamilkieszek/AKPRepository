namespace AKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Message123 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Message", "PersonReceiverId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "PersonReceiverId", c => c.Int(nullable: false));
        }
    }
}
