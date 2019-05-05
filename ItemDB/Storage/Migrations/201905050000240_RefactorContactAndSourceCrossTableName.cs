namespace ItemDB.Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorContactAndSourceCrossTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContactSource", newName: "ContactToSource");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ContactToSource", newName: "ContactSource");
        }
    }
}
