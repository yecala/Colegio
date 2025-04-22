using DT.Colegio.DTOs;
using DT.Colegio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Colegio.Interfaces
{
    public interface IMateriaPorGradoServicio : IGenericService<MateriaPorGrado>
    {
        Task<List<MateriaPorGrado>> ObtenerMateriaPorGrado();
        // Método específico que recibe un DTO
        Task Insertar(MateriaPorGradoDTO dto);
    }
}
