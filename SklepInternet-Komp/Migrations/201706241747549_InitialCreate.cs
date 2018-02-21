namespace SklepInternet_Komp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producents",
                c => new
                    {
                        IdProducenta = c.Int(nullable: false, identity: true),
                        NazwaProducenta = c.String(nullable: false, maxLength: 20),
                        RokZalozenia = c.Int(nullable: false),
                        Panstwo = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.IdProducenta);
            
            CreateTable(
                "dbo.Sprzets",
                c => new
                    {
                        IdSprzetu = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, maxLength: 60),
                        RokProdukcji = c.Int(nullable: false),
                        Kolor = c.String(nullable: false, maxLength: 10),
                        Cena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSprzetu);
            
            CreateTable(
                "dbo.TypSprzetus",
                c => new
                    {
                        IdTypu = c.Int(nullable: false, identity: true),
                        NazwaTypu = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.IdTypu);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TypSprzetus");
            DropTable("dbo.Sprzets");
            DropTable("dbo.Producents");
        }
    }
}
