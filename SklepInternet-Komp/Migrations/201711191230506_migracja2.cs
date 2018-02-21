namespace SklepInternet_Komp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracja2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SprzetProducents", "Sprzet_IdSprzetu", "dbo.Sprzets");
            DropForeignKey("dbo.SprzetProducents", "Producent_IdProducenta", "dbo.Producents");
            DropIndex("dbo.SprzetProducents", new[] { "Sprzet_IdSprzetu" });
            DropIndex("dbo.SprzetProducents", new[] { "Producent_IdProducenta" });
            CreateIndex("dbo.Sprzets", "IdProducenta");
            AddForeignKey("dbo.Sprzets", "IdProducenta", "dbo.Producents", "IdProducenta", cascadeDelete: true);
            DropTable("dbo.SprzetProducents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SprzetProducents",
                c => new
                    {
                        Sprzet_IdSprzetu = c.Int(nullable: false),
                        Producent_IdProducenta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sprzet_IdSprzetu, t.Producent_IdProducenta });
            
            DropForeignKey("dbo.Sprzets", "IdProducenta", "dbo.Producents");
            DropIndex("dbo.Sprzets", new[] { "IdProducenta" });
            CreateIndex("dbo.SprzetProducents", "Producent_IdProducenta");
            CreateIndex("dbo.SprzetProducents", "Sprzet_IdSprzetu");
            AddForeignKey("dbo.SprzetProducents", "Producent_IdProducenta", "dbo.Producents", "IdProducenta", cascadeDelete: true);
            AddForeignKey("dbo.SprzetProducents", "Sprzet_IdSprzetu", "dbo.Sprzets", "IdSprzetu", cascadeDelete: true);
        }
    }
}
