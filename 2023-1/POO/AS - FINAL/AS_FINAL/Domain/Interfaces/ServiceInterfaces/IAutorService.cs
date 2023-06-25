using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_FINAL.Domain.Entities;

namespace AS_FINAL.Domain.Interfaces.ServiceInterfaces
{
     public interface IAutorService : IDisposable
    {
        Task<bool> Add(Autor autor);
        Task<bool> Update(Autor autor);
        Task<bool> Remove(int id);
    }
}