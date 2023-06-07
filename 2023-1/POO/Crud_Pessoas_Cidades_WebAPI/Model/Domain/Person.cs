using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Pessoas_Cidades_WebAPI
{
    public class Person
    {
        public string Nome { get; set; }  
        public int Id { get; private set; }
        public string Telefone { get; set; }

        public City City { get; set; }



    }
}