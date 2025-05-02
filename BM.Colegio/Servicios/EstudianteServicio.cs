using BM.Colegio.Interfaces;
using DA.Colegio;
using DA.Colegio.Interfaz;
using DA.Colegio.Repositorios;
using DT.Colegio.Constantes;
using DT.Colegio.Modelos;
using System.Collections;
using DT.Colegio.DTOs;

namespace BM.Colegio.Servicios
{
    public class EstudianteServicio : GenericService<Estudiante>, IEstudianteServicio
    {
        private readonly IEstudianteRepositorio _estudianteRepositorio;
        public EstudianteServicio(IEstudianteRepositorio estudianteRepositorio) : base(estudianteRepositorio)
        {
            _estudianteRepositorio = estudianteRepositorio;
        }

        public async Task<List<Estudiante>> ObtenerEstudiantesFiltrados(EstudianteDTO filtro)
        {
            return await _estudianteRepositorio.ObtenerConFiltros(filtro);
        }
    }
}
