using BackEnd.DAL.Interfaces;
using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL.Implementations
{
    public class EstadoDALImpl : IEstadoDAL
    {

        BD_REDBOX_DISTRIBUIDORAContext context;

        public EstadoDALImpl()
        {
            context = new BD_REDBOX_DISTRIBUIDORAContext();
        }



        public bool Add(Estado entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Estado> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estado> Find(Expression<Func<Estado, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Estado Get(int id)
        {
            try
            {
                Estado estado;
                using (UnidadDeTrabajo<Estado> unidad = new UnidadDeTrabajo<Estado>(context))
                {
                    estado = unidad.genericDAL.Get(id);

                }
                return estado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Estado> GetAll()
        {
            try
            {
                IEnumerable<Estado> estados;
                using (UnidadDeTrabajo<Estado> unidad = new UnidadDeTrabajo<Estado>(context))
                {
                    estados = unidad.genericDAL.GetAll();
                }
                return estados;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Estado entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Estado> entities)
        {
            throw new NotImplementedException();
        }

        public Estado SingleOrDefault(Expression<Func<Estado, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Estado entity)
        {
            throw new NotImplementedException();
        }
    }
}
