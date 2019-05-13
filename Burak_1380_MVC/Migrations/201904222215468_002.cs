namespace Burak_1380_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Kullanicis", newName: "AdminKullanicis");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AdminKullanicis", newName: "Kullanicis");
        }
    }
}
