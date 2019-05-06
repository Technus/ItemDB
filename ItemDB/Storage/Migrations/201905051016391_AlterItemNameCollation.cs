namespace ItemDB.Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterItemNameCollation : DbMigration
    {
        public override void Up()
        {
            //Only change Collation
            Sql("ALTER TABLE dbo.ItemDefinitions ALTER COLUMN Name nvarchar(255) COLLATE SQL_Latin1_General_CP1_CS_AS NULL;");
        }
        
        public override void Down()
        {
            //Only change Collation
            Sql("ALTER TABLE dbo.ItemDefinitions ALTER COLUMN Name nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL;");
        }
    }
}
