﻿using KutuphaneProgramı.Data.Repositories;
using System;

namespace KutuphaneProgramı.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;


        public UnitOfWork()
        {
            _context = new Context();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context); 
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception) { throw; }
            }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    _context.Dispose();
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
