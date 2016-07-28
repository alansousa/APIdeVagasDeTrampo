
namespace APIVagasDeTrampo.Domain.Entidades
{
    public class VagaTecnologia
    {
        public int TecnologiaId { get; set; }
        public int VagaId { get; set; }
        public int PesoTecnologia { get; set; }

        public virtual Vaga Vaga { get; set; }
        public virtual Tecnologia Tecnologia { get; set; }

        public VagaTecnologia() { }

        public VagaTecnologia(int peso, int tecnologia, int vaga)
        {
            TecnologiaId = tecnologia;
            VagaId = vaga;
            PesoTecnologia = peso;
        }
    }
}
