namespace Burak_1380_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        KullaniciId = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(),
                        KullaniciSifre = c.String(),
                    })
                .PrimaryKey(t => t.KullaniciId);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        UrunId = c.Int(nullable: false, identity: true),
                        UrunAdi = c.String(nullable: false),
                        UrunStok = c.Int(nullable: false),
                        UrunKategori = c.String(nullable: false),
                        UrunAciklama = c.String(nullable: false),
                        UrunFiyat = c.Double(nullable: false),
                        UrunResim = c.String(nullable: false),
                        UrunTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UrunId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uruns");
            DropTable("dbo.Kullanicis");
            DropTable("dbo.Kategoris");
        }
    }
}
