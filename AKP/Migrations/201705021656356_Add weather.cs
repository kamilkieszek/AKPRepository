namespace AKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addweather : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeatherItem",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cod = c.Int(nullable: false),
                        name = c.String(),
                        coord_lon = c.Single(nullable: false),
                        coord_lat = c.Single(nullable: false),
                        main_temp_min = c.String(),
                        main_temp = c.String(),
                        main_pressure = c.Single(nullable: false),
                        main_humidity = c.Int(nullable: false),
                        main_temp_max = c.String(),
                        main_sea_level = c.String(),
                        main_grnd_level = c.String(),
                        wind_speed = c.String(),
                        wind_deg = c.String(),
                        clauds_all = c.Int(nullable: false),
                        sys_message = c.String(),
                        sys_country = c.String(),
                        sys_sunrise = c.Int(nullable: false),
                        sys_sunset = c.Int(nullable: false),
                        dt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Ad", "City", c => c.String());
            AddColumn("dbo.Ad", "Temp", c => c.String());
            AddColumn("dbo.Ad", "Speed", c => c.String());
            AddColumn("dbo.Ad", "Humidity", c => c.String());
            AddColumn("dbo.Ad", "Clauds", c => c.String());
            AddColumn("dbo.Ad", "EUR", c => c.Single(nullable: false));
            AddColumn("dbo.Ad", "USD", c => c.Single(nullable: false));
            AddColumn("dbo.Ad", "CHF", c => c.Single(nullable: false));
            AddColumn("dbo.Ad", "GBP", c => c.Single(nullable: false));
            AddColumn("dbo.Ad", "Ad_AdId", c => c.Int());
            CreateIndex("dbo.Ad", "Ad_AdId");
            AddForeignKey("dbo.Ad", "Ad_AdId", "dbo.Ad", "AdId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ad", "Ad_AdId", "dbo.Ad");
            DropIndex("dbo.Ad", new[] { "Ad_AdId" });
            DropColumn("dbo.Ad", "Ad_AdId");
            DropColumn("dbo.Ad", "GBP");
            DropColumn("dbo.Ad", "CHF");
            DropColumn("dbo.Ad", "USD");
            DropColumn("dbo.Ad", "EUR");
            DropColumn("dbo.Ad", "Clauds");
            DropColumn("dbo.Ad", "Humidity");
            DropColumn("dbo.Ad", "Speed");
            DropColumn("dbo.Ad", "Temp");
            DropColumn("dbo.Ad", "City");
            DropTable("dbo.WeatherItem");
        }
    }
}
