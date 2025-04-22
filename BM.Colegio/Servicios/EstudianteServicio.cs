using BM.Colegio.Interfaces;
using DA.Colegio;
using DA.Colegio.Interfaz;
using DA.Colegio.Repositorios;
using DT.Colegio.Constantes;
using DT.Colegio.Modelos;
using System.Collections;

namespace BM.Colegio.Servicios
{
    public class EstudianteServicio : GenericService<Estudiante>, IEstudianteServicio
    {
        public EstudianteServicio(IEstudianteRepositorio repo) : base(repo) { }
    }
}
