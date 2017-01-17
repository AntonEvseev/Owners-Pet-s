using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OwnersAndPets.Models
{
    public class OwnersViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PetCount { get; set; }
    }
}