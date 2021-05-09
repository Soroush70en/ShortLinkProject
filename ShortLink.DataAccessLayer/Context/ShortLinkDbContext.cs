using Microsoft.EntityFrameworkCore;
using ShortLink.DataAccessLayer.Entities;

namespace ShortLink.DataAccessLayer.Context
{
    public class ShortLinkDbContext : DbContext
    {
        /// <summary>
        /// سازنده کلاس کانتکست دیتابیس
        /// </summary>
        /// <param name="options"></param>
        public ShortLinkDbContext(DbContextOptions<ShortLinkDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// فراخوانی کلاس انتیتی برای ایجاد در دیتابیس
        /// </summary>
        public DbSet<tbShortLinks> tbShortLinks { get; set; }
    }
}
