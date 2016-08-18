namespace ExamenWeb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAllTables3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facturacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MontoTotal = c.Double(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        Detalle = c.String(),
                        ClienteID = c.Int(nullable: false),
                        ProductosID = c.Int(nullable: false),
                        InventarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Inventarios", t => t.InventarioID, cascadeDelete: true)
                .Index(t => t.ClienteID)
                .Index(t => t.InventarioID);
            
            AddColumn("dbo.Productos", "Facturacion_Id", c => c.Int());
            CreateIndex("dbo.Productos", "Facturacion_Id");
            AddForeignKey("dbo.Productos", "Facturacion_Id", "dbo.Facturacions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "Facturacion_Id", "dbo.Facturacions");
            DropForeignKey("dbo.Facturacions", "InventarioID", "dbo.Inventarios");
            DropForeignKey("dbo.Facturacions", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Productos", new[] { "Facturacion_Id" });
            DropIndex("dbo.Facturacions", new[] { "InventarioID" });
            DropIndex("dbo.Facturacions", new[] { "ClienteID" });
            DropColumn("dbo.Productos", "Facturacion_Id");
            DropTable("dbo.Facturacions");
        }
    }
}
