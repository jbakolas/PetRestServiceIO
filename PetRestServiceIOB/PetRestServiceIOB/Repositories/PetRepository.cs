using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PetRestServiceIOB.Models;

//implementation of the Pet specific repository in order to create the quering methods
namespace PetRestServiceIOB.Repositories
{
    public class PetRepository : IPetRepository, IDisposable
    {
        private PetRestServiceIOBContext context;

        public PetRepository(PetRestServiceIOBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Pet> GetPets()
        {
            return context.Pets.ToList();
        }

        public Pet Find(int id)
        {
            return context.Pets.Find(id);
        }

        public IEnumerable<Pet> GetPetsByOwnerId(int ownerid)
        {
            var subquery = context.Pets.Select(b => b.Owner.ownerId);
            var _pets = context.Pets.Where(a => subquery.Contains(a.Owner.ownerId) && a.Owner.ownerId.Equals(ownerid));
            return _pets;
        }

        public IEnumerable<Pet> GetPetByAge(int nn)
        {
            var list = context.Pets.ToList();
            var _pets = list.Cast<Pet>().Where(p => p.BirthDate.AddYears(nn) >= DateTime.Now);
            return _pets;
        }

        public void CreateNewPet(Pet pet)
        {
            context.Pets.Add(pet);
        }

        public void DeletePet(int petId)
        {
            Pet pet = context.Pets.Find(petId);
            context.Pets.Remove(pet);
        }

        public void UpdateExistingPet(Pet pet)
        {
            context.Entry(pet).State = EntityState.Modified;
        }

        public void Save()
        {
            context?.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}