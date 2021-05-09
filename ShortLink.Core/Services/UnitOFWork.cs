using System;
using System.Collections;
using ShortLink.Core.Interface;
using ShortLink.DataAccessLayer.Context;

namespace ShortLink.Core.Services
{
    public class UnitOFWork : IUnitOFWork , IDisposable
    {
        private readonly ShortLinkDbContext Context;
        private Hashtable _repositories;
        private bool disposedValue;

        public UnitOFWork(ShortLinkDbContext _context)
        {
            Context = _context;
        }

        /// <summary>
        /// تابع تولید ریپوزیتوری به صورت جنریک
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public virtual IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type)) return (IRepository<TEntity>)_repositories[type];

            var repositoryType = typeof(Repository<>);

            var repositoryInstance =
                Activator.CreateInstance(repositoryType
                    .MakeGenericType(typeof(TEntity)), Context);

            _repositories.Add(type, repositoryInstance);

            return (IRepository<TEntity>)_repositories[type];
        }

        /// <summary>
        /// تابع کامیت ترناکشن‌ها
        /// </summary>
        public virtual bool Commit()
        {
            using (var Trans = Context.Database.BeginTransaction())
            {
                try
                {
                    SaveChange();
                    Trans.Commit();
                    return true;
                }
                catch
                {
                    Trans.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// تابع ذخیره داده ها در دیتابیس در زمان هایی که نیازی به کامیت نیست
        /// </summary>
        public virtual bool SaveChange()
        {
            try
            {
                return Convert.ToBoolean(Context.SaveChanges());
            }
            catch
            {
                return false;
            }
        }

        #region IDisposible
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }
                Context.Dispose();
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~UnitOFWork()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
