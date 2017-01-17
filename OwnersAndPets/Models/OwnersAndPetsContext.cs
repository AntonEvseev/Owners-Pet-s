using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OwnersAndPets.Models
{
    public class OwnersAndPetsContext : DbContext
    {
        public OwnersAndPetsContext() : base("OwnersAndPetsContext")
        {}

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}