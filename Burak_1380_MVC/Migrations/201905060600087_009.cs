namespace Burak_1380_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _009 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategoris", "KategoriSira", c => c.String());
            AddColumn("dbo.Uruns", "KategoriId", c => c.String(nullable: false));
            AddColumn("dbo.Uruns", "Kategori_KategoriId", c => c.Int());
            CreateIndex("dbo.Uruns", "Kategori_KategoriId");
            AddForeignKey("dbo.Uruns", "Kategori_KategoriId", "dbo.Kategoris", "KategoriId");
            DropColumn("dbo.Uruns", "UrunKategori");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Uruns", "UrunKategori", c => c.String(nullable: false));
            DropForeignKey("dbo.Uruns", "Kategori_KategoriId", "dbo.Kategoris");
            DropIndex("dbo.Uruns", new[] { "Kategori_KategoriId" });
            DropColumn("dbo.Uruns", "Kategori_KategoriId");
            DropColumn("dbo.Uruns", "KategoriId");
            DropColumn("dbo.Kategoris", "KategoriSira");
        }
    }
}
