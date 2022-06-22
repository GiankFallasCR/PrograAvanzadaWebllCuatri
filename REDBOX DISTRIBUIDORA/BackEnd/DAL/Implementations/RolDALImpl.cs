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
    public class RolDALImpl: IRolDAL
    {
        BD_REDBOX_DISTRIBUIDORAContext context;

        public RolDALImpl()
        {
            context = new BD_REDBOX_DISTRIBUIDORAContext();

        }

        public bool Add(Rol entity)
        {
            try
            {
                //sumar o calcular 

                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Rol> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> Find(Expression<Func<Rol, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Rol Get(int RolID)
        {
            try
            {
                Rol rol;
                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
                {
                    rol = unidad.genericDAL.Get(RolID);
                }
                return rol;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Rol> Get()
        {
            try
            {
                IEnumerable<Rol> roles;
                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
                {
                    roles = unidad.genericDAL.GetAll();
                }
                return roles.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Rol> GetAll()
        {
            try
            {
                IEnumerable<Rol> roles;
                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
                {
                    roles = unidad.genericDAL.GetAll();
                }
                return roles;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Remove(Rol entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
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

        public void RemoveRange(IEnumerable<Rol> entities)
        {
            throw new NotImplementedException();
        }

        public Rol SingleOrDefault(Expression<Func<Rol, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Rol rol)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
                {
                    unidad.genericDAL.Update(rol);
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
