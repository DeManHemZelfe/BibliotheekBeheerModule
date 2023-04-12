namespace BibliotheekBeheerModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ffff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        Infix = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Type = c.String(),
                        Author = c.String(),
                        Author_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Items", new[] { "Author_Id" });
            DropTable("dbo.Items");
            DropTable("dbo.Authors");
        }
    }
}
