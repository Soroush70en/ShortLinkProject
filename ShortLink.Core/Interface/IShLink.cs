namespace ShortLink.Core.Interface
{
    /// <summary>
    /// اینترفیس برای ایجاد اکشن‌های مربوط به کار با لینک‌ها
    /// </summary>
    public interface IShLink
    {
        /// <summary>
        /// تابع دریافت لینک از دیتابیس و ارسال کاربر به صفحه مربوطه
        /// </summary>
        /// <param name="Link">لینک کامل</param>
        string Take_Short_Link(string Link);

        /// <summary>
        /// تابع اضافه کردن لینک کوتاه در دیتابیس
        /// </summary>
        /// <param name="Link"></param>
        string Add_Short_Link(string Link);
    }
}
