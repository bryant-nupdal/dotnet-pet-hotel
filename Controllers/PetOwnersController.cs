using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPetOwners() {
            return _context.PetOwner.ToList();
        }

        [HttpPost] 
        public IActionResult addOwner([FromBody] PetOwner owner) {
            _context.PetOwner.Add(owner);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getOwnerById), new {id = owner.id}, owner);
        }

        [HttpGet("{id}")]
        public PetOwner getOwnerById(int id) {
            return _context.PetOwner.Find(id);
        }

    [HttpDelete("{id}")] // DELETE /api/petowner
    public IActionResult deletePetOwner( int id ) {
        PetOwner petowner = _context.PetOwner.Find(id);
        if( petowner == null ) {
            return NotFound();
        }
        _context.PetOwner.Remove(petowner);
        _context.SaveChanges();
        return NoContent();
    }
 
        
    }

}
