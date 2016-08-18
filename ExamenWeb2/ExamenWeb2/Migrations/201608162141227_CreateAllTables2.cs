namespace ExamenWeb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAllTables2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Cedula", c => c.String());
            AlterColumn("dbo.Inventarios", "Cantidad", c => c.String());
            AlterColumn("dbo.Inventarios", "CantidadMinima", c => c.String());
            AlterColumn("dbo.Inventarios", "CantidadMaxima", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventarios", "CantidadMaxima", c => c.Int(nullable: false));
            AlterColumn("dbo.Inventarios", "CantidadMinima", c => c.Int(nullable: false));
            AlterColumn("dbo.Inventarios", "Cantidad", c => c.Int(nullable: false));
            AlterColumn("dbo.Clientes", "Cedula", c => c.Int(nullable: false));
        }
    }
}
