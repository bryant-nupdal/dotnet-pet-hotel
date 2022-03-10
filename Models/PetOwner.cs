using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace pet_hotel
{
    public class PetOwner {
        public int id { get; set; }

        
        [Required]
        public string name { get; set; }

        [Required]

        public string emailAddress { get; set; }
        
       [JsonIgnore] // ignores the pet when generating the api
       public List<Pet> pets { get; set;}

       public int petCount {
            get {
                return (this.pets != null) ? this.pets.Count : 0;
            }
        } 

        // public int petCount {get; set;}

        // public void addPet() {
        //     this.petCount++;
        // }

        // public void removePet() {
        //     this.petCount--;
        // }
    
    }
}
