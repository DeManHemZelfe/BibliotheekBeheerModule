namespace BibliotheekBeheerModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFinalMG : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        Infix = c.String(),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Type = c.String(),
                        Description = c.String(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Items", new[] { "AuthorId" });
            DropTable("dbo.Types");
            DropTable("dbo.Items");
            DropTable("dbo.Authors");
        }
    }
}
