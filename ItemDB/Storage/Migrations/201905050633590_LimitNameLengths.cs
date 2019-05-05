namespace ItemDB.Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LimitNameLengths : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.ItemDefinitions", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Locations", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Sources", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sources", "Name", c => c.String());
            AlterColumn("dbo.Locations", "Name", c => c.String());
            AlterColumn("dbo.ItemDefinitions", "Name", c => c.String());
            AlterColumn("dbo.Contacts", "Name", c => c.String());
        }
    }
}
