using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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

        //public List<Pedido> Get()
        //{
        //    try
        //    {
        //        IEnumerable<Pedido> pedidos;
        //        using (UnidadDeTrabajo<Pedido> unidad = new UnidadDeTrabajo<Pedido>(context))
        //        {
        //            pedidos = unidad.genericDAL.GetAll();
        //        }
        //        return pedidos.ToList();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

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

        public bool setPedidoSP(int IdProducto, int Cantidad, int IdUsuario, string NumeroPedido /*DateTime FechaPedido,*/ /*int IdEstado*/)
        {
            string resultado;
            string sql = "[dbo].[SP_Ante_Pedido_Result] @ID_PRODUCT, @CANT_PRODUCTO, @ID_USUARIO, @NUM_PEDIDO";

            //FechaPedido = DateTime.Today;

            var param = new SqlParameter[]
            {                

                new SqlParameter()
                {
                    ParameterName = "@ID_PRODUCT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = IdProducto
                },


                new SqlParameter()
                {
                    ParameterName = "@CANT_PRODUCTO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = Cantidad
                },

                new SqlParameter()
                {
                    ParameterName = "@ID_USUARIO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = IdUsuario
                },

                new SqlParameter()
                {
                    ParameterName = "@NUM_PEDIDO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Size = 100,
                    Value = NumeroPedido
                }

                //new SqlParameter()
                //{
                //    ParameterName = "@FECHA_PEDIDO",
                //    SqlDbType = System.Data.SqlDbType.DateTime,
                //    Value = FechaPedido
                //},

                //new SqlParameter()
                //{
                //    ParameterName = "@ID_ESTADO",
                //    SqlDbType = System.Data.SqlDbType.Int,
                //    Direction = System.Data.ParameterDirection.Input,
                //    Value = IdEstado
                //}

            };

            //var consulta = context.SP_Ante_Pedido_Results.FromSqlRaw(sql, param).FirstOrDefault();
            context.Database.ExecuteSqlRaw(sql, param);
            //context.SaveChanges();

            //return consulta.ToString();
            return true;




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

