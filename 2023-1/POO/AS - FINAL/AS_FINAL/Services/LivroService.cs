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
    public class LivroService : BaseService, ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LivroService(ILivroRepository livroRepository, IUnitOfWork unitOfWork)
        {
            _livroRepository = livroRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Livro livro)
        {
            if (!ExecutarValidacao(new LivroValidation(), livro)) return false;

            _livroRepository.Save(livro);
            await _unitOfWork.Commit();
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var wasRemoved = _livroRepository.Delete(id);

            if (wasRemoved)
            {
                await _unitOfWork.Commit();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> Update(Livro livro)
        {
            if (!ExecutarValidacao(new LivroValidation(), livro)) return false;
            else
            {
                _livroRepository.Update(livro);
                await _unitOfWork.Commit();
                return true;
            }

        }

        
        public void Dispose()
        {
            _livroRepository?.Dispose();
        }
        

        public Task<bool> UpdateAutor(Autor autor)
        {
            throw new NotImplementedException();
        }
    }
}