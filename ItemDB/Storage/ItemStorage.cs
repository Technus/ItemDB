namespace ItemDB.Storage
{
    using ItemDB.Core.Model;
    using ItemDB.Core.Storage;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ItemDbStorage : DbContext
    {
        // Your context has been configured to use a 'ItemStorage' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ItemDB.ItemStorage' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ItemStorage' 
        // connection string in the application configuration file.
        public ItemDbStorage() : base("name=ItemStorage")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.


        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Placement> Placements { get; set; }

        public virtual DbSet<Source> Sources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasMany(i => i.Sources).WithRequired(s => s.SourcedItem);
            modelBuilder.Entity<Item>().HasMany(i => i.Placements).WithRequired(p => p.PlacedItem);

            modelBuilder.Entity<Location>().HasMany(l => l.ItemPlacements).WithRequired(p => p.Location);
            modelBuilder.Entity<Location>().HasMany(l => l.ChildLocations).WithOptional(l => l.ParentLocation);

            modelBuilder.Entity<Contact>().HasMany(c => c.ItemSources).WithRequired(s => s.Contact);
            modelBuilder.Entity<Contact>().HasMany(c => c.ItemsManufactured).WithMany(i => (ICollection<Contact>)i.Sources).Map(m =>
                m.ToTable(nameof(Contact) + nameof(Source)).MapLeftKey(nameof(Contact)+"Id").MapRightKey(nameof(Source)+"Id"));

            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}