namespace BibliotheekBeheerModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ItemDTOes", newName: "Items");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Items", newName: "ItemDTOes");
        }
    }
}
