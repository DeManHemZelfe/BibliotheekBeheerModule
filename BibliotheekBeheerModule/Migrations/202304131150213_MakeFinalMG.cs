namespace BibliotheekBeheerModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeFinalMG : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemAuthors", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemAuthors", "Author_Id", "dbo.Authors");
            DropIndex("dbo.ItemAuthors", new[] { "Item_Id" });
            DropIndex("dbo.ItemAuthors", new[] { "Author_Id" });
            AddColumn("dbo.Items", "Author_Id", c => c.Guid());
            CreateIndex("dbo.Items", "Author_Id");
            AddForeignKey("dbo.Items", "Author_Id", "dbo.Authors", "Id");
            DropTable("dbo.ItemAuthors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ItemAuthors",
                c => new
                    {
                        Item_Id = c.Guid(nullable: false),
                        Author_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Author_Id });
            
            DropForeignKey("dbo.Items", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Items", new[] { "Author_Id" });
            DropColumn("dbo.Items", "Author_Id");
            CreateIndex("dbo.ItemAuthors", "Author_Id");
            CreateIndex("dbo.ItemAuthors", "Item_Id");
            AddForeignKey("dbo.ItemAuthors", "Author_Id", "dbo.Authors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ItemAuthors", "Item_Id", "dbo.Items", "Id", cascadeDelete: true);
        }
    }
}
