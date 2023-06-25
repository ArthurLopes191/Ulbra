using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AS_FINAL.Data.Context;
using AS_FINAL.Domain.Entities;
using AS_FINAL.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AS_FINAL.Data.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DataContext _context;

        public LivroRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            var p = GetById(entityId);
            _context.DbSetLivro.Remove(p);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IList<Livro> GetAll()
        {
            return _context.DbSetLivro.ToList();
        }

        public Task<object> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Livro GetById(int entityId)
        {
            return _context.DbSetLivro.SingleOrDefault(x=>x.Id == entityId);
        }

        public Task<object> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Livro entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public Task<IList<Livro>> SearchAll(Expression<Func<Livro, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Livro entity)
        {
            _context.DbSetLivro.Update(entity);
            _context.SaveChanges();
        }

        bool IBaseRepository<Livro>.Delete(int entityId)
        {
            throw new NotImplementedException();
        }



        Task<IList<Livro>> IBaseRepository<Livro>.GetAllAsync()
        {
            throw new NotImplementedException();
        }



        Task<Livro> IBaseRepository<Livro>.GetByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }


    }
}