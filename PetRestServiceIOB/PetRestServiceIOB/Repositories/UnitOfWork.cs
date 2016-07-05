using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using PetRestServiceIOB.Models;
using PetRestServiceIOB.Repositories;

namespace PetRestServiceIO.Repositories
{
    public class UnitOfWork : IDisposable
    {

        private PetRestServiceIOBContext context = new PetRestServiceIOBContext();
        private GenericRepository<PetWalker> petWalkerRepositoryRepository;
        // private ApprovalRepository _approvalRepository;
        private GenericRepository<User> _userRepository;
        private GenericRepository<Token> _tokenRepository;


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

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<User>(context);
                return _userRepository;
            }
        }

        public GenericRepository<Token> TokenRepository
        {
            get
            {
                if (this._tokenRepository == null)
                    this._tokenRepository = new GenericRepository<Token>(context);
                return _tokenRepository;
            }
        }

        /*public ApprovalRepository ApprovalRepository
        {
            get
            {

                if (this._approvalRepository == null)
                {
                    this._approvalRepository = new ApprovalRepository(context);
                }
                return _approvalRepository;
            }
        }*/

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }
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

            