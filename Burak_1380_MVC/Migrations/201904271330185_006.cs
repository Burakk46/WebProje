namespace Burak_1380_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _006 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdminKullanicis", "KullaniciRole", c => c.String());
            AddColumn("dbo.Uruns", "UrunEkleyen", c => c.String());
            DropColumn("dbo.Kullanicis", "KullaniciAdi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kullanicis", "KullaniciAdi", c => c.String());
            DropColumn("dbo.Uruns", "UrunEkleyen");
            DropColumn("dbo.AdminKullanicis", "KullaniciRole");
        }
    }
}
