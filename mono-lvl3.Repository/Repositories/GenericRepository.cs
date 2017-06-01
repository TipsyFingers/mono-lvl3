using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using mono_lvl3.Repository.Common;
using mono_lvl3.DAL.DbContext;

namespace mono_lvl3.Repository
{
    public class GenericRepository : IGenericRepository
    {
        #region Properties

        protected IDataContext DbContext { get; private set; }
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }

        #endregion Properties

        #region Constructors

        public GenericRepository(IDataContext db, IUnitOfWorkFactory unitOfWorkFactory)
		{
			if(db == null)
			{
				throw new ArgumentNullException("DbContext");
			}
			DbContext = db;
			UnitOfWorkFactory = unitOfWorkFactory;
		}

        #endregion Constructors

        #region Methods

        public IUnitOfWork CreateUnitOfWork()
        {
            return UnitOfWorkFactory.CreateUnitOfWork();
        }

        public virtual Task<List<T>> GetAsync<T>() where T : class
        {
            return DbContext.Set<T>().ToListAsync();
        }

        public virtual Task<T> GetByIDAsync<T>(Guid id) where T : class
        {
            return DbContext.Set<T>().FindAsync();
        }

        public virtual async Task<int> AddAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbContext.Set<T>().Add(entity);
            }
            return await DbContext.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbContext.Set<T>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
            return await DbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbContext.Set<T>().Attach(entity);
                DbContext.Set<T>().Remove(entity);
            }
            return await DbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            var entity = await GetByIDAsync<T>(id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Entity with specified ID does not exist");
            }
            return await DeleteAsync<T>(entity);
        }

        public virtual IQueryable<T> GetWhere<T>() where T : class
        {
            return DbContext.Set<T>();
        }

        #endregion Methods
    }
}
