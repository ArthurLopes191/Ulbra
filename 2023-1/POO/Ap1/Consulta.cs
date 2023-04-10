using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ap1
{
    public class Consulta
    {
        public int Id { get; private set; }
        public DateTime DataHora { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }

        public Consulta(int id, DateTime dataHora, Medico medico, Paciente paciente)
        {
            Id = id;
            DataHora = dataHora;
            Medico = medico;
            Paciente = paciente;
        }
    }
}