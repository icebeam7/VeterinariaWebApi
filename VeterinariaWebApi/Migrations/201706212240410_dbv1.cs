namespace VeterinariaWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerroGato = c.String(),
                        Nombre = c.String(),
                        Raza = c.String(),
                        Edad = c.Int(nullable: false),
                        Genero = c.String(),
                        Imagen = c.String(),
                        Esterilizado = c.Boolean(nullable: false),
                        IdDueno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cartillas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Concepto = c.String(),
                        Nombre = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        IdAnimal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Cartillas");
            DropTable("dbo.Animals");
        }
    }
}
