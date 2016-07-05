using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetRestServiceIOB.Models
{
    public class PetRestServiceIOBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PetRestServiceIOBContext() : base("name=PetRestServiceIOBContext")
        {
        }

        public System.Data.Entity.DbSet<PetRestServiceIOB.Models.Pet> Pets { get; set; }

        public System.Data.Entity.DbSet<PetRestServiceIOB.Models.PetWalker> PetWalkers { get; set; }

        public System.Data.Entity.DbSet<PetRestServiceIOB.Models.Owner> Owners { get; set; }

        public System.Data.Entity.DbSet<PetRestServiceIOB.Models.Approval> Approvals { get; set; }

        public System.Data.Entity.DbSet<PetRestServiceIOB.Models.Token> Tokens { get; set; }

        public System.Data.Entity.DbSet<PetRestServiceIOB.Models.User> Users { get; set; }
    }
}
