namespace _200423_ExoEntity5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCartProdAssociation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartProductAssociations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartProductAssociations", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CartProductAssociations", "CartId", "dbo.Carts");
            DropIndex("dbo.CartProductAssociations", new[] { "ProductId" });
            DropIndex("dbo.CartProductAssociations", new[] { "CartId" });
            DropTable("dbo.CartProductAssociations");
        }
    }
}
