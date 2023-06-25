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
     public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            var p = GetById(entityId);
            _context.DbSetUsuario.Remove(p);
            _context.SaveChanges();
        }

        public IList<Usuario> GetAll()
        {
            return _context.DbSetUsuario.ToList();
        }

        public Task<object> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int entityId)
        {
            return _context.DbSetUsuario.SingleOrDefault(x=>x.Id == entityId);
        }

        public void Save(Usuario entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public Task<IList<Usuario>> SearchAll(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario entity)
        {
            _context.DbSetUsuario.Update(entity);
            _context.SaveChanges();
        }

        bool IBaseRepository<Usuario>.Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        Task<IList<Usuario>> IBaseRepository<Usuario>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetByIdAsync(int entityId)
        {
            return await _context.DbSetUsuario
                .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}