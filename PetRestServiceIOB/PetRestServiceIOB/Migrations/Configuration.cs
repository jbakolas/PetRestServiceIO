using System.Collections.Generic;
using PetRestServiceIOB.Models;

namespace PetRestServiceIOB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetRestServiceIOB.Models.PetRestServiceIOBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PetRestServiceIOB.Models.PetRestServiceIOBContext context)
        {
            context.Owners.AddOrUpdate(o => o.ownerId,
                new Owner()
                {
                    ownerId = 1,
                    firstName = "Giannis",
                    lastName = "Bakolas",
                    email = "jbakolas@gmail.com",
                    Pets = new List<Pet>() {
                       new Pet() { petId = 1, name = "Simba",BirthDate = new DateTime(2010,08,22)},
                       new Pet() { petId = 2, name = "Zouzou",BirthDate = new DateTime(2005,03,17)}
                    }
                },
                new Owner()
                {
                    ownerId = 2,
                    firstName = "john",
                    lastName = "VanJohn",
                    email = "VanJohn@xmail.com",
                    Pets = new List<Pet>() {
                       new Pet() { petId = 3, name = "Jack",BirthDate = new DateTime(2015,01,22) },
                    }
                },
                new Owner()
                {
                    ownerId = 3,
                    firstName = "kostas",
                    lastName = "poul",
                    email = "kp@gmail.com",
                    Pets = new List<Pet>() {
                           new Pet() { petId = 4, name = "Orfeas",BirthDate = new DateTime(2009,11,2) }

                      }
                },
                 new Owner()
                 {
                     ownerId = 4,
                     firstName = "mitsos",
                     lastName = "kal",
                     email = "ml@gmail.com",
                     Pets = new List<Pet>() {
                       new Pet() { petId = 5, name = "apolo",BirthDate = new DateTime(2002,6,6) },
                    }
                 }
             );


            context.PetWalkers.AddOrUpdate(p => p.walkerId,
                new PetWalker()
                {
                    walkerId = 1,
                    firstName = "Tasos",
                    lastName = "Kra",
                    email = "taskra@xmail.com",
                    phone = "212323232",
                    Approvals = new List<Approval>()
                    {
                        new Approval
                        {
                            Id = 1,
                            Approved = true,
                            Owner = new Owner(){ownerId = 1},
                            Pet = new Pet(){petId = 1}
                        },
                         new Approval
                        {
                            Id = 2,
                            Approved = false,
                            Owner = new Owner(){ownerId = 1},
                            Pet = new Pet(){petId = 2}
                        },new Approval
                        {
                            Id = 3,
                            Approved = false,
                            Owner = new Owner(){ownerId = 2},
                            Pet = new Pet(){petId = 3}
                        },
                         new Approval
                        {
                            Id = 4,
                            Approved = true,
                            Owner = new Owner(){ownerId = 3},
                            Pet = new Pet(){petId = 4}
                        }
                    }
                }
            );

        }
    }
}
