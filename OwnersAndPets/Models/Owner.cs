using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OwnersAndPets.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; }
        public Owner()
        {
            Pets = new List<Pet>();
        }
    }
}