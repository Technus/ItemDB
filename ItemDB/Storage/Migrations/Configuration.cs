namespace ItemDB.Storage.Migrations
{
    using ItemDB.Core.Model;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ItemDbStorage>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = "Storage\\Migrations";
        }

        protected override void Seed(ItemDbStorage context)
        {
            context.Locations.AddOrUpdate(l => l.Name, new Location { Name = "Room A" });
            context.SaveChanges();

            context.Locations.AddOrUpdate(l => l.Name,
                    new Location { Name = "Shelf A", ParentLocationId = context.Locations.First(l => l.Name == "Room A").Id },
                    new Location { Name = "Shelf B" },
                    new Location { Name = "Shelf C" }
                );
            context.SaveChanges();

            context.Locations.AddOrUpdate(l => l.Name,
                    new Location { Name = "Box A", ParentLocationId = context.Locations.First(l => l.Name == "Shelf A").Id },
                    new Location { Name = "Box B", ParentLocationId = context.Locations.First(l => l.Name == "Shelf A").Id },
                    new Location { Name = "Box C", ParentLocationId = context.Locations.First(l => l.Name == "Shelf C").Id }
                );
            context.SaveChanges();

            context.Contacts.AddOrUpdate(c => c.Name,
                    new Contact { Name = "èdzis≥aw" },
                    new Contact { Name = "Zygmunt" },
                    new Contact { Name = "Tec" },
                    new Contact { Name = "Barbara Corp." },
                    new Contact { Name = "Java" },
                    new Contact { Name = "Hexanut" },
                    new Contact { Name = "Aperture" }
               );
            context.SaveChanges();

            context.Items.AddOrUpdate(i => i.Name,
                    new ItemDefinition { Name = "Lie Cake" },
                    new ItemDefinition
                    {
                        Name = "PZ1 Screwdriver",
                        Manufacturers = { context.Contacts.First(c => c.Name == "Barbara Corp.") }
                    },
                    new ItemDefinition {
                        Name = "Ghost",
                        Manufacturers = { context.Contacts.First(c => c.Name == "èdzis≥aw") }
                    },
                    new ItemDefinition {
                        Name = "DeprecatedClasses",
                        Manufacturers = new ObservableCollection<Contact>(
                            context.Contacts.Where(c => new List<string> { "èdzis≥aw", "Java" }.Contains(c.Name)))
                    },
                    new ItemDefinition {
                        Name = "Coffe",
                        Manufacturers = new ObservableCollection<Contact>(
                            context.Contacts.Where(c => new List<string> { "Zygmunt", "Java" }.Contains(c.Name)))
                    }
                );
            context.SaveChanges();

            context.Sources.AddOrUpdate(s => s.Name,
                    new Source
                    {
                        Name = "Az032",
                        SourcedItemId = context.Items.First(i => i.Name == "PZ1 Screwdriver").Id,
                        ContactId = context.Contacts.First(c => c.Name == "Hexanut").Id
                    },
                    new Source
                    {
                        Name = "Az033",
                        SourcedItemId = context.Items.First(i => i.Name == "PZ1 Screwdriver").Id,
                        ContactId = context.Contacts.First(c => c.Name == "Hexanut").Id
                    },
                    new Source
                    {
                        Name = "Aperture-123",
                        SourcedItemId = context.Items.First(i => i.Name == "Lie Cake").Id,
                        ContactId = context.Contacts.First(c => c.Name == "Aperture").Id
                    }
                );
            context.SaveChanges();

            context.Placements.AddOrUpdate(p => new { p.PlacedItemId, p.LocationId },
                    new Placement
                    {
                        Count = 0m,
                        LocationId = context.Locations.First(l => l.Name == "Box A").Id,
                        PlacedItemId = context.Items.First(i=>i.Name == "Lie Cake").Id
                    },
                    new Placement
                    {
                        Count = 10m,
                        LocationId=context.Locations.First(l=>l.Name=="Box b").Id,
                        PlacedItemId=context.Items.First(i=>i.Name== "PZ1 Screwdriver").Id
                    },
                    new Placement
                    {
                        Count=0.000001m,
                        LocationId=context.Locations.First(l=>l.Name=="Room A").Id,
                        PlacedItemId=context.Items.First(i=>i.Name=="Ghost").Id
                    }
                );
            context.SaveChanges();
        }
    }
}
