using BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BackEnd.DAL
{
    public class DALGenericoImpl<TEntity> : IDALGenerico<TEntity> where TEntity : class
    {

        protected readonly BD_REDBOX_DISTRIBUIDORAContext Context;

        public DALGenericoImpl(BD_REDBOX_DISTRIBUIDORAContext context)
        {
            Context = context;
        }


        public bool Add(TEntity entity)
        {
            try
            {

                Context.Set<TEntity>().Add(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Context.Set<TEntity>().AddRange(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.Set<TEntity>().Where(predicate);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public TEntity Get(int id)
        {
            try
            {
                return Context.Set<TEntity>().Find(id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return Context.Set<TEntity>().ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Attach(entity);
                Context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Context.Set<TEntity>().RemoveRange(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.Set<TEntity>().SingleOrDefault(predicate);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
