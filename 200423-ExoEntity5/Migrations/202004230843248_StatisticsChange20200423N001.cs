namespace _200423_ExoEntity5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatisticsChange20200423N001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Amount", c => c.Single(nullable: false));
            AddColumn("dbo.Carts", "DateBought", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cities", "Country", c => c.String());
            AddColumn("dbo.Products", "Name", c => c.String());
            AddColumn("dbo.Products", "Price", c => c.Single(nullable: false));
            DropColumn("dbo.Carts", "Total");
            DropColumn("dbo.Carts", "DateAchat");
            DropColumn("dbo.Cities", "Pays");
            DropColumn("dbo.Products", "Nom");
            DropColumn("dbo.Products", "Prix");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Prix", c => c.Single(nullable: false));
            AddColumn("dbo.Products", "Nom", c => c.String());
            AddColumn("dbo.Cities", "Pays", c => c.String());
            AddColumn("dbo.Carts", "DateAchat", c => c.DateTime(nullable: false));
            AddColumn("dbo.Carts", "Total", c => c.Single(nullable: false));
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "Name");
            DropColumn("dbo.Cities", "Country");
            DropColumn("dbo.Carts", "DateBought");
            DropColumn("dbo.Carts", "Amount");
        }
    }
}
