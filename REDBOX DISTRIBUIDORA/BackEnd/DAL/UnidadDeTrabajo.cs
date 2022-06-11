using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class UnidadDeTrabajo<T> : IDisposable where T : class
    {
        private readonly BD_REDBOX_DISTRIBUIDORAContext context;
        
        public IDALGenerico<T> genericDAL;


        public UnidadDeTrabajo(BD_REDBOX_DISTRIBUIDORAContext _context)
        {
            context = _context;
            genericDAL = new DALGenericoImpl<T>(context);

        }

        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }

        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
