namespace AKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ad", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ad", "Name");
        }
    }
}
