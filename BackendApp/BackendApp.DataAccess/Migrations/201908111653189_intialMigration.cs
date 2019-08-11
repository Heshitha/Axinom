namespace BackendApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ZipArchives",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ArchiveName = c.String(),
                        SavedFileName = c.String(),
                        ArchiveHirachy = c.String(),
                        SavedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ZipArchives");
            DropTable("dbo.Users");
        }
    }
}
