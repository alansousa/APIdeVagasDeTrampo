using System;
using System.Collections.Generic;

namespace APIVagasDeTrampo.Domain.Entidades
{
    public class Vaga
    {
        public int VagaId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPostagem { get; set; }

        public virtual ICollection<VagaTecnologia> VagaTecnologias { get; set; }
        public virtual ICollection<Candidato> Candidatos { get; set; }

        public Vaga()
        {
            Candidatos = new List<Candidato>();
            VagaTecnologias = new List<VagaTecnologia>();
        }
    }
}
