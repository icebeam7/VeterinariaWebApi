namespace VeterinariaWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv1_1_fks : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Animals", "IdDueno");
            CreateIndex("dbo.Cartillas", "IdAnimal");
            AddForeignKey("dbo.Animals", "IdDueno", "dbo.Duenoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cartillas", "IdAnimal", "dbo.Animals", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cartillas", "IdAnimal", "dbo.Animals");
            DropForeignKey("dbo.Animals", "IdDueno", "dbo.Duenoes");
            DropIndex("dbo.Cartillas", new[] { "IdAnimal" });
            DropIndex("dbo.Animals", new[] { "IdDueno" });
        }
    }
}
