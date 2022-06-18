using System;
using System.Linq.Expressions;
using BackEnd.DAL.Interfaces;
using BackEnd.Entities;

namespace BackEnd.DAL.Implementations
{
    public class ProveedorDALImpl : IProveedorDAL
    {
        BD_REDBOX_DISTRIBUIDORAContext context;
        public ProveedorDALImpl()
        {
            context = new BD_REDBOX_DISTRIBUIDORAContext();
        }
        public bool Add(Proveedor entity)
        {
            try
            {
                using (UnidadDeTrabajo<Proveedor> unidad = new UnidadDeTrabajo<Proveedor>(context))
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

        public void AddRange(IEnumerable<Proveedor> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proveedor> Find(Expression<Func<Proveedor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Proveedor Get(int id)
        {
            try
            {
                Proveedor proveedor;
                using (UnidadDeTrabajo<Proveedor> unidad = new UnidadDeTrabajo<Proveedor>(context))
                {
                    proveedor = unidad.genericDAL.Get(id);
                }
                return proveedor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Proveedor> GetAll()
        {
            try
            {
                IEnumerable<Proveedor> proveedor;
                using (UnidadDeTrabajo<Proveedor> unidad = new UnidadDeTrabajo<Proveedor>(context))
                {
                    proveedor = unidad.genericDAL.GetAll();
                }
                return proveedor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Proveedor entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Proveedor> unidad = new UnidadDeTrabajo<Proveedor>(context))
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

        public void RemoveRange(IEnumerable<Proveedor> entities)
        {
            throw new NotImplementedException();
        }

        public Proveedor SingleOrDefault(Expression<Func<Proveedor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Proveedor entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Proveedor> unidad = new UnidadDeTrabajo<Proveedor>(context))
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

