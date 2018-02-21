namespace SklepInternet_Komp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracja3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SprzetTypSprzetus",
                c => new
                    {
                        Sprzet_IdSprzetu = c.Int(nullable: false),
                        TypSprzetu_IdTypu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sprzet_IdSprzetu, t.TypSprzetu_IdTypu })
                .ForeignKey("dbo.Sprzets", t => t.Sprzet_IdSprzetu, cascadeDelete: true)
                .ForeignKey("dbo.TypSprzetus", t => t.TypSprzetu_IdTypu, cascadeDelete: true)
                .Index(t => t.Sprzet_IdSprzetu)
                .Index(t => t.TypSprzetu_IdTypu);
            
            AddColumn("dbo.Sprzets", "IdTypu", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SprzetTypSprzetus", "TypSprzetu_IdTypu", "dbo.TypSprzetus");
            DropForeignKey("dbo.SprzetTypSprzetus", "Sprzet_IdSprzetu", "dbo.Sprzets");
            DropIndex("dbo.SprzetTypSprzetus", new[] { "TypSprzetu_IdTypu" });
            DropIndex("dbo.SprzetTypSprzetus", new[] { "Sprzet_IdSprzetu" });
            DropColumn("dbo.Sprzets", "IdTypu");
            DropTable("dbo.SprzetTypSprzetus");
        }
    }
}
