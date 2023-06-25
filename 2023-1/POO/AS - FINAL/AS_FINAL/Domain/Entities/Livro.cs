using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AS_FINAL.Domain.Entities
{
    public class Livro : Entity
    {

        public String Titulo { get; set; }

        public String Isbn { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public List<Autor> Autores { get; set; }
    }
}