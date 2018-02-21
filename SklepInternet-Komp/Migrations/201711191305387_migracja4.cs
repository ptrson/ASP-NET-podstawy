namespace SklepInternet_Komp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracja4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SprzetTypSprzetus", "Sprzet_IdSprzetu", "dbo.Sprzets");
            DropForeignKey("dbo.SprzetTypSprzetus", "TypSprzetu_IdTypu", "dbo.TypSprzetus");
            DropIndex("dbo.SprzetTypSprzetus", new[] { "Sprzet_IdSprzetu" });
            DropIndex("dbo.SprzetTypSprzetus", new[] { "TypSprzetu_IdTypu" });
            CreateIndex("dbo.Sprzets", "IdTypu");
            AddForeignKey("dbo.Sprzets", "IdTypu", "dbo.TypSprzetus", "IdTypu", cascadeDelete: true);
            DropTable("dbo.SprzetTypSprzetus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SprzetTypSprzetus",
                c => new
                    {
                        Sprzet_IdSprzetu = c.Int(nullable: false),
                        TypSprzetu_IdTypu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sprzet_IdSprzetu, t.TypSprzetu_IdTypu });
            
            DropForeignKey("dbo.Sprzets", "IdTypu", "dbo.TypSprzetus");
            DropIndex("dbo.Sprzets", new[] { "IdTypu" });
            CreateIndex("dbo.SprzetTypSprzetus", "TypSprzetu_IdTypu");
            CreateIndex("dbo.SprzetTypSprzetus", "Sprzet_IdSprzetu");
            AddForeignKey("dbo.SprzetTypSprzetus", "TypSprzetu_IdTypu", "dbo.TypSprzetus", "IdTypu", cascadeDelete: true);
            AddForeignKey("dbo.SprzetTypSprzetus", "Sprzet_IdSprzetu", "dbo.Sprzets", "IdSprzetu", cascadeDelete: true);
        }
    }
}
