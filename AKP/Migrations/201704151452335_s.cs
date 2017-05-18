namespace AKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Message", "cos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "cos", c => c.Int(nullable: false));
        }
    }
}
