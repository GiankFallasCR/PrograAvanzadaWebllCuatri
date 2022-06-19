using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class DALPedidoIMP : IDALPedido
    {
        BD_REDBOX_DISTRIBUIDORAContext context;

        public DALPedidoIMP()
        {
            context = new BD_REDBOX_DISTRIBUIDORAContext();

        }

        public bool Add(Pedido entity)
        {
            try
            {
                //sumar o calcular 

                using (UnidadDeTrabajo<Pedido> unidad = new UnidadDeTrabajo<Pedido>(context))
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

        public void AddRange(IEnumerable<Pedido> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> Find(Expression<Func<Pedido, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Pedido Get(int id)
        {
            try
            {
                Pedido pedido;
                using (UnidadDeTrabajo<Pedido> unidad = new UnidadDeTrabajo<Pedido>(context))
                {
                    pedido = unidad.genericDAL.Get(id);
                }
                return pedido;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Pedido> Get()
        {
            try
            {
                IEnumerable<Pedido> pedidos;
                using (UnidadDeTrabajo<Pedido> unidad = new UnidadDeTrabajo<Pedido>(context))
                {
                    pedidos = unidad.genericDAL.GetAll();
                }
                return pedidos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Pedido> GetAll()
        {
            try
            {
                IEnumerable<Pedido> pedidos;
                using (UnidadDeTrabajo<Pedido> unidad = new UnidadDeTrabajo<Pedido>(context))
                {
                    pedidos = unidad.genericDAL.GetAll();
                }
                return pedidos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Pedido entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Pedido> unidad = new UnidadDeTrabajo<Pedido>(context))
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

        public void RemoveRange(IEnumerable<Pedido> entities)
        {
            throw new NotImplementedException();
        }

        public Pedido SingleOrDefault(Expression<Func<Pedido, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pedido Pedido)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Pedido> unidad = new UnidadDeTrabajo<Pedido>(context))
                {
                    unidad.genericDAL.Update(Pedido);
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

