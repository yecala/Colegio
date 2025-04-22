using BM.Colegio.Interfaces;
using DA.Colegio.Interfaz;
using DT.Colegio.InterfacesDeDominio;
using DT.Colegio.Modelos;

namespace BM.Colegio.Servicios
{
    public class DocenteServicio : GenericService<Docente>, IDocenteServicio, IEnsenanza
    {
        public DocenteServicio(IDocenteRepositorio repo) : base(repo) { }

        public void Enseñar(int docenteId)
        {
            Console.WriteLine($"Docente {docenteId} Esta ensenando");
        }

    }
}
