using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_FINAL.Domain.Entities;
using AS_FINAL.Domain.Entities.Validations;
using AS_FINAL.Domain.Interfaces;
using AS_FINAL.Domain.Interfaces.ServiceInterfaces;

namespace AS_FINAL.Services
{
     public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;

            _usuarioRepository.Save(usuario);
            await _unitOfWork.Commit();
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var wasRemoved = _usuarioRepository.Delete(id);

            if (wasRemoved)
            {
                await _unitOfWork.Commit();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> Update(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;
            else
            {
                _usuarioRepository.Update(usuario);
                await _unitOfWork.Commit();
                return true;
            }

        }

        
        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
        

        public Task<bool> UpdateLivro(Livro livro)
        {
            throw new NotImplementedException();
        }
    }
}