namespace ExamenWeb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyInventario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventarios", "ProductosID", c => c.Int(nullable: false));
            CreateIndex("dbo.Inventarios", "ProductosID");
            AddForeignKey("dbo.Inventarios", "ProductosID", "dbo.Productos", "Id", cascadeDelete: true);
            DropColumn("dbo.Inventarios", "Producto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventarios", "Producto", c => c.String());
            DropForeignKey("dbo.Inventarios", "ProductosID", "dbo.Productos");
            DropIndex("dbo.Inventarios", new[] { "ProductosID" });
            DropColumn("dbo.Inventarios", "ProductosID");
        }
    }
}
