using ItemDB.Core.Model;
using ItemDB.Core.Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDB.Storage.Repositories
{
    class ContactRepository:Repository<Contact>,IContactRepository
    {
        public ContactRepository(DbSet<Contact> contacts) : base(contacts) {

        }
    }
}
