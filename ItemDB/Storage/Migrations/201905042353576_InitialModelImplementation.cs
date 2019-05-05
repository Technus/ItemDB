namespace ItemDB.Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelImplementation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemDefinitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Placements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlacedItemId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        Count = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.ItemDefinitions", t => t.PlacedItemId, cascadeDelete: true)
                .Index(t => t.PlacedItemId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentLocationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.ParentLocationId)
                .Index(t => t.ParentLocationId);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactId = c.Int(nullable: false),
                        SourcedItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemDefinitions", t => t.SourcedItemId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.SourcedItemId);
            
            CreateTable(
                "dbo.ContactSource",
                c => new
                    {
                        ContactId = c.Int(nullable: false),
                        SourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ContactId, t.SourceId })
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.ItemDefinitions", t => t.SourceId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.SourceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sources", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactSource", "SourceId", "dbo.ItemDefinitions");
            DropForeignKey("dbo.ContactSource", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Sources", "SourcedItemId", "dbo.ItemDefinitions");
            DropForeignKey("dbo.Placements", "PlacedItemId", "dbo.ItemDefinitions");
            DropForeignKey("dbo.Placements", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "ParentLocationId", "dbo.Locations");
            DropIndex("dbo.ContactSource", new[] { "SourceId" });
            DropIndex("dbo.ContactSource", new[] { "ContactId" });
            DropIndex("dbo.Sources", new[] { "SourcedItemId" });
            DropIndex("dbo.Sources", new[] { "ContactId" });
            DropIndex("dbo.Locations", new[] { "ParentLocationId" });
            DropIndex("dbo.Placements", new[] { "LocationId" });
            DropIndex("dbo.Placements", new[] { "PlacedItemId" });
            DropTable("dbo.ContactSource");
            DropTable("dbo.Sources");
            DropTable("dbo.Locations");
            DropTable("dbo.Placements");
            DropTable("dbo.ItemDefinitions");
            DropTable("dbo.Contacts");
        }
    }
}
