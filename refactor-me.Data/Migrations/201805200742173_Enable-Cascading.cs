namespace refactor_me.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnableCascading : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductOptions", "ProductId", "dbo.Products");
            AddForeignKey("dbo.ProductOptions", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOptions", "ProductId", "dbo.Products");
            AddForeignKey("dbo.ProductOptions", "ProductId", "dbo.Products", "Id");
        }
    }
}
