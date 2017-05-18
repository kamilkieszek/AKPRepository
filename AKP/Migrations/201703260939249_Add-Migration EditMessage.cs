namespace AKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationEditMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Message", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Message", "Name");
        }
    }
}
