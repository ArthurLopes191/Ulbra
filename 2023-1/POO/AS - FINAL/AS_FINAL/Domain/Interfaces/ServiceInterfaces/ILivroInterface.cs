using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_FINAL.Domain.Entities;

namespace AS_FINAL.Domain.Interfaces.ServiceInterfaces
{
     public interface ILivroService : IDisposable
    {
        Task<bool> Add(Livro livro);
        Task<bool> Update(Livro livro);
        Task<bool> Remove(int id);

        Task<bool> UpdateAutor(Autor autor);
    }
}