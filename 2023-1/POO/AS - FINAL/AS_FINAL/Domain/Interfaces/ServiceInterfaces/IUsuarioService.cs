using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_FINAL.Domain.Entities;

namespace AS_FINAL.Domain.Interfaces.ServiceInterfaces
{
    public interface IUsuarioService : IDisposable
    {
        Task<bool> Add(Usuario usuario);
        Task<bool> Update(Usuario usuario);
        Task<bool> Remove(int id);

        Task<bool> UpdateLivro(Livro livro);
    }
}