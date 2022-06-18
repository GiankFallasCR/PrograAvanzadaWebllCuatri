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
    public class CategoriaDALImpl : ICategoriaDAL

    {
        BD_REDBOX_DISTRIBUIDORAContext context;
        public CategoriaDALImpl()
        {
            context = new BD_REDBOX_DISTRIBUIDORAContext();
        }
        public bool Add(Categorium entity)
        {
            try
            {
                using (UnidadDeTrabajo<Categorium> unidad = new UnidadDeTrabajo<Categorium>(context))
                {
                    //Así estamos guardando en base de datos.
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception ex)
            {
                return false;
            };
        }

        public void AddRange(IEnumerable<Categorium> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categorium> Find(Expression<Func<Categorium, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Categorium Get(int id)
        {
            try
            {
                Categorium categorium;
                using (UnidadDeTrabajo<Categorium> unidad = new UnidadDeTrabajo<Categorium>(context))
                {
                    categorium = unidad.genericDAL.Get(id);
                }
                return categorium;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Categorium> GetAll()
        {
            try
            {
                IEnumerable<Categorium> categorium;
                using (UnidadDeTrabajo<Categorium> unidad = new UnidadDeTrabajo<Categorium>(context))
                {
                    categorium = unidad.genericDAL.GetAll();
                }
                return categorium;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Categorium entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Categorium> unidad = new UnidadDeTrabajo<Categorium>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Categorium> entities)
        {
            throw new NotImplementedException();
        }

        public Categorium SingleOrDefault(Expression<Func<Categorium, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Categorium entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Categorium> unidad = new UnidadDeTrabajo<Categorium>(context))
                {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }
    }
}
