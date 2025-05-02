using DA.Colegio.Interfaz;
using DA.Colegio;
using DT.Colegio.Constantes;
using DT.Colegio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Colegio.Interfaces;
using System.Runtime.Intrinsics.Arm;
using DT.Colegio.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using DA.Colegio.Repositorios;

namespace BM.Colegio.Servicios
{
    public class MateriaPorGradoServicio : GenericService<MateriaPorGrado>, IMateriaPorGradoServicio
    {
        //Dependency Inversion Principle(DIP)
        private readonly IMateriaPorGradoRepositorio _materiaPorGradoRepositorio;
        private readonly IGradoRepositorio _gradoRepositorio;
        private readonly IMateriaRepositorio _materiaRepositorio;
        private readonly IDocenteRepositorio _docenteRepositorio;
        private readonly ITransactionCoordinatorUnitOfWork _transactionCoordinatorUnitOfWork;

        public MateriaPorGradoServicio(
            IMateriaPorGradoRepositorio materiaPorGradoRepositorio,
            IGradoRepositorio gradoRepositorio,
            IMateriaRepositorio materiaRepositorio,
            IDocenteRepositorio docenteRepositorio,
            ITransactionCoordinatorUnitOfWork transactionCoordinatorUnitOfWork) :base(materiaPorGradoRepositorio)
        {
            _materiaPorGradoRepositorio = materiaPorGradoRepositorio;
             _gradoRepositorio = gradoRepositorio;
            _materiaRepositorio = materiaRepositorio;
            _docenteRepositorio = docenteRepositorio;
            _transactionCoordinatorUnitOfWork = transactionCoordinatorUnitOfWork;
        }

        // Sobrescribimos Insertar que recibe la entidad, si se llamara así
        public override async Task Insertar(MateriaPorGrado entity)
        {
            // validations or logic
            await base.Insertar(entity);
        }

        /*
         *  Utilizando Unit of work
         * 
         */
        public async Task Insertar(MateriaPorGradoDTO nuevaRelacion)
        {
            // Todo bajo control de EF (sin TransactionScope)
            var grado = await _transactionCoordinatorUnitOfWork.GradoRepositorio.ObtenerPorId(nuevaRelacion.grado.id);
            if (grado == null)
            {
                grado = new Grado { Nombre = nuevaRelacion.grado.nombre };
                await _transactionCoordinatorUnitOfWork.GradoRepositorio.Insertar(grado);
            }

            var materia = await _transactionCoordinatorUnitOfWork.MateriaRepositorio.ObtenerPorId(nuevaRelacion.materia.id);
            if (materia == null)
            {
                materia = new Materia { Nombre = nuevaRelacion.materia.nombre };
                await _transactionCoordinatorUnitOfWork.MateriaRepositorio.Insertar(materia);
            }

            var docente = await _transactionCoordinatorUnitOfWork.DocenteRepositorio.ObtenerPorId(nuevaRelacion.docente.id);
            if (docente == null)
                throw new Exception("El docente no existe.");

            var yaExiste = await _transactionCoordinatorUnitOfWork.MateriaPorGradoRepositorio
                .ExisteRelacion(grado.Id, materia.Id);
            if (yaExiste)
                throw new Exception("Ya existe una relación entre ese grado y materia.");

            var materiagrado = new MateriaPorGrado
            {
                MateriaId = materia.Id,
                GradoId = grado.Id,
                DocenteId = docente.Id
            };

            await _transactionCoordinatorUnitOfWork.MateriaPorGradoRepositorio.Insertar(materiagrado);

            // Esta línea guarda todos los cambios en una sola transacción
            await _transactionCoordinatorUnitOfWork.SaveChangesAsync();
        }

        /*
         * TransactionScope
         * 
         * 
        // Override para personalizar la inserción de MateriaPorGrado
        public async Task Insertar(MateriaPorGradoDTO nuevaRelacion)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {

                try
                {

                    // Validar existencia de grado
                    Grado grado = new Grado();
                    grado = await _gradoRepositorio.ObtenerPorId(nuevaRelacion.grado.id);
                    if (grado == null)
                    {
                        grado = new Grado()
                        {
                            Nombre = nuevaRelacion.grado.nombre
                        };
                        await _gradoRepositorio.Insertar(grado);
                    }


                    // Validar existencia de materia
                    Materia materia = new Materia();
                    materia = await _materiaRepositorio.ObtenerPorId(nuevaRelacion.materia.id);
                    if (materia == null)
                    {
                        materia = new Materia()
                        {
                            Nombre = nuevaRelacion.materia.nombre
                        };
                        await _materiaRepositorio.Insertar(materia);

                    }

                    // Validar existencia de docente
                    var docente = await _docenteRepositorio.ObtenerPorId(nuevaRelacion.docente.id);
                    if (docente == null)
                        throw new Exception("El docente no existe.");

                    // Validar que no exista ya una relación similar
                    var yaExiste = await _materiaPorGradoRepositorio.ExisteRelacion(nuevaRelacion.grado.id, nuevaRelacion.materia.id);
                    if (yaExiste)
                        throw new Exception("Ya existe una relación entre ese grado y materia.");

                    MateriaPorGrado materiagrado = new MateriaPorGrado()
                    {
                        MateriaId = materia.Id,
                        GradoId = grado.Id,
                        DocenteId = docente.Id
                    };
            
                    // Si todo está bien, insertar
                    await base.Insertar(materiagrado);
                    scope.Complete();
                }
                catch (Exception)
                {
                    scope.Dispose();
                    throw;
                }
            }

        }*/


        public Task<List<MateriaPorGrado>> ObtenerMateriaPorGrado()
        {
            throw new NotImplementedException();
        }
    }
}
