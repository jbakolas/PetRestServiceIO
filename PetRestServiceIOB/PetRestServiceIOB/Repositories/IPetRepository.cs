using System;
using System.Collections.Generic;
using PetRestServiceIOB.Models;

namespace PetRestServiceIOB.Repositories
{
    public interface IPetRepository : IDisposable
    {
        IEnumerable<Pet> GetPets();
        Pet Find(int petId);
        IEnumerable<Pet> GetPetsByOwnerId(int ownerId);
        IEnumerable<Pet> GetPetByAge(int nn);
        void CreateNewPet(Pet pet);
        //void DeletePet(int petId);
        void UpdateExistingPet(Pet pet);
        void Save();
    }
}