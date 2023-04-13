namespace BibliotheekBeheerModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeMG : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Author");
        }
    }
}
