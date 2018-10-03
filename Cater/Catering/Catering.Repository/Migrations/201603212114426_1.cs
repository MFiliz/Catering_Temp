namespace Catering.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Biletler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Isim = c.String(),
                        EPosta = c.String(),
                        Telefon = c.String(),
                        Baslik = c.String(),
                        Mesaj = c.String(),
                        OkunduMu = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Iletisim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdresBaslik = c.String(),
                        Adres1 = c.String(),
                        Adres2 = c.String(),
                        Semt = c.String(),
                        Il = c.String(),
                        Telefon1 = c.String(),
                        Telefon2 = c.String(),
                        Telefon3 = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Instagram = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Iletisim");
            DropTable("dbo.Biletler");
        }
    }
}
