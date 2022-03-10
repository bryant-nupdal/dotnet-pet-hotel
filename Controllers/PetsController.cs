using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;


namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            // return new List<Pet>();
            // return _context.Pet.ToList();
            return _context.Pet.Include(p => p.petOwner).OrderBy(p => p.name).ToList();
        }

        [HttpPost]
        public IActionResult addPet([FromBody] Pet pet)
        {
            _context.Add(pet);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getPetById), new { id = pet.id, pet });
        }

        [HttpGet("{id}")]
        public Pet getPetById(int id)
        {
            return _context.Pet.Find(id);
        }

        // DELETE a Pets by id
        [HttpDelete("{id}")]
        public IActionResult deletePet(int id)
        {
            Pet pet = _context.Pet.Find(id);
            if (pet == null)
            {
                return NotFound();
            }
            _context.Pet.Remove(pet);
            _context.SaveChanges();
            return NoContent();

        }

        
        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }

        [HttpPut("{id}/checkin")]
        public IActionResult checkInPet(int id)
        {
            Pet pet = _context.Pet.Find(id);
            if (pet == null)
            {
                return NotFound();
            }
            pet.checkIn();
            _context.Update(pet);
            _context.SaveChanges();
            return Ok();
        }

         [HttpPut("{id}/checkout")]
        public IActionResult checkOutPet(int id)
        {
            Pet pet = _context.Pet.Find(id);
            if (pet == null)
            {
                return NotFound();
            }
            pet.checkOut();
            _context.Update(pet);
            _context.SaveChanges();
            return Ok();
        }
    }
}
