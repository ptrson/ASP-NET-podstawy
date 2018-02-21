namespace SklepInternet_Komp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracja1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SprzetProducents",
                c => new
                    {
                        Sprzet_IdSprzetu = c.Int(nullable: false),
                        Producent_IdProducenta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sprzet_IdSprzetu, t.Producent_IdProducenta })
                .ForeignKey("dbo.Sprzets", t => t.Sprzet_IdSprzetu, cascadeDelete: true)
                .ForeignKey("dbo.Producents", t => t.Producent_IdProducenta, cascadeDelete: true)
                .Index(t => t.Sprzet_IdSprzetu)
                .Index(t => t.Producent_IdProducenta);
            
            AddColumn("dbo.Sprzets", "IdProducenta", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SprzetProducents", "Producent_IdProducenta", "dbo.Producents");
            DropForeignKey("dbo.SprzetProducents", "Sprzet_IdSprzetu", "dbo.Sprzets");
            DropIndex("dbo.SprzetProducents", new[] { "Producent_IdProducenta" });
            DropIndex("dbo.SprzetProducents", new[] { "Sprzet_IdSprzetu" });
            DropColumn("dbo.Sprzets", "IdProducenta");
            DropTable("dbo.SprzetProducents");
        }
    }
}
