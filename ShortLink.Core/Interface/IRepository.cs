using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace ShortLink.Core.Interface
{
    /// <summary>
    /// این کلاس سرویس ریپوزیتوری را به صورت جنریک پیاده‌سازی می‌کند.
    /// در مواقعی که تعداد مدل‌های دیتابیس زیاد است
    /// توابع عمومی عملیات دیتابیس در این اینترفیس به صورت جنریک پیاده‌سازی می‌شود
    /// </summary>
    /// <typeparam name="TEntity">مدل دیتابیس که به صورت جنریک به این اینترفیس پاس داده می‌شود</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(int Id);
        void Delete(int Id);
        void Update(int Id);

        void Insert(TEntity Entry);
        void Update(TEntity Entry);
        void Delete(TEntity Entry);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> Filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy = null, string Properties = "");
    }
}
