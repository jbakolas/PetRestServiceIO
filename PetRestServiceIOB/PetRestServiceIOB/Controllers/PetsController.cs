using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PetRestServiceIOB.Models;
using PetRestServiceIOB.Repositories;

namespace PetRestServiceIOB.Controllers
{
    //[System.Web.Http.RoutePrefix("api/Pets")]

    // [System.Web.Http.Authorize]
    public class PetsController : ApiController
    {
        private readonly IPetRepository _petRepository;

        public PetsController()
        {
            this._petRepository = new PetRepository(new PetRestServiceIOBContext());
        }

        public PetsController(PetRepository petRepository)
        {
            this._petRepository = petRepository;
        }

        // GET: api/Pets
        public IEnumerable<Pet> GetPets()
        {
            IEnumerable<Pet> pet = _petRepository.GetPets();
            return pet;

        }

        // GET: api/Pets/1 
        [ResponseType(typeof(Pet))]
        public async Task<IHttpActionResult> GetPetById(int id)
        {
            Pet pet = _petRepository.Find(id);
            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        // POST: api/Pets
        [ResponseType(typeof(Pet))]
#pragma warning disable 1998
        public async Task<IHttpActionResult> PostPet(Pet pet)
#pragma warning restore 1998
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _petRepository.CreateNewPet(pet);
                _petRepository.Save();

            }
            catch (DataException)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log. 
                ModelState.AddModelError(string.Empty,
                    "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return CreatedAtRoute("DefaultApi", new {id = pet.petId}, pet);
        }

        // PUT: api/Pets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPet(int id, Pet pet)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pet.petId)
            {
                return BadRequest();
            }

            _petRepository.UpdateExistingPet(pet);

            try
            {
                _petRepository.Save();

            }
            catch (DataException)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log. 
                ModelState.AddModelError(string.Empty,
                    "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }

            return Ok(pet);

        }

        [System.Web.Http.Route("api/Pets/Age/{lcid:int?}")]
        //[ResponseType(typeof(Pet))]
        public IEnumerable<Pet> GetPetsAge(int nn)
        {
            IEnumerable<Pet> pets = _petRepository.GetPetByAge(nn);
            return pets;

        }

        [System.Web.Http.Route("api/Pets/Owner/{lcid:int?}")]
        //[ResponseType(typeof(Pet))]
        public IEnumerable<Pet> GetPetByAge(int ownerid)
        {
            IEnumerable<Pet> pets = _petRepository.GetPetsByOwnerId(ownerid);
            return pets;

        }
    }
}