namespace ItemDB.Storage.Migrations
{
    using ItemDB.Core.Model;
    using System;
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
            context.Locations.AddOrUpdate(l=>l.Name,new Location { Name = "Room A" });
            context.SaveChanges();
            context.Locations.AddOrUpdate(l => l.Name, 
                new Location { Name = "Shelf A", ParentLocationId = context.Locations.First(l => l.Name == "Room A").Id },
                new Location { Name = "Shelf B" },
                new Location { Name = "Shelf C" });
            context.SaveChanges();
            context.Locations.AddOrUpdate(l => l.Name, 
                new Location { Name = "Box A", ParentLocationId = context.Locations.First(l => l.Name == "Shelf A").Id },
                new Location { Name = "Box B", ParentLocationId = context.Locations.First(l => l.Name == "Shelf A").Id },
                new Location { Name = "Box C", ParentLocationId = context.Locations.First(l => l.Name == "Shelf C").Id });
        }
    }
}
