namespace Burak_1380_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _004 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        KullaniciId = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        KullaniciDogumTarihi = c.DateTime(nullable: false),
                        KullaniciAdi = c.String(),
                        KullaniciSifre = c.String(),
                        KullaniciSifreTekrar = c.String(),
                        KullaniciEmail = c.String(),
                        KullaniciTelefon = c.String(),
                        Cinsiyet = c.String(),
                    })
                .PrimaryKey(t => t.KullaniciId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kullanicis");
        }
    }
}
