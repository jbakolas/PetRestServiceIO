using PetRestServiceIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetRestServiceIO.Repositories
{
    public class UnitOfWork : IDisposable
    {

        private PetRestServiceIOContext context = new PetRestServiceIOContext();
        private GenericRepository<PetWalker> petWalkerRepositoryRepository;
        private ApprovalRepository _approvalRepository;

        public GenericRepository<PetWalker> PetWalkerRepository
        {
            get
            {

                if (this.petWalkerRepositoryRepository == null)
                {
                    this.petWalkerRepositoryRepository = new GenericRepository<PetWalker>(context);
                }
                return petWalkerRepositoryRepository;
            }
        }

        public ApprovalRepository ApprovalRepository
        {
            get
            {

                if (this._approvalRepository == null)
                {
                    this._approvalRepository = new ApprovalRepository(context);
                }
                return _approvalRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
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

            