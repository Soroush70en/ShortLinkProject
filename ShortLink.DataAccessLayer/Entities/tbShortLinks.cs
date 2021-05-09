using System.ComponentModel.DataAnnotations;

namespace ShortLink.DataAccessLayer.Entities
{
    /// <summary>
    /// کلاس نگهداری لینک های کوتاه شده
    /// </summary>
    public class tbShortLinks
    {
        /// <summary>
        /// آیدی جدول دیتابیس که از جنس انحصاری تعریف شده است
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// لینک کامل سایت
        /// </summary>
        [Display(Name = "لینک اصلی")]
        [Required(ErrorMessage = "ورود این مقدار ضروری می‌باشد")]
        public string FullLink { get; set; }

        /// <summary>
        /// لینک کوتاه شده سایت
        /// </summary>
        [Display(Name = "لینک کوتاه شده")]
        [Required(ErrorMessage = "ورود این مقدار ضروری می‌باشد")]
        public string ShortedLink { get; set; }
    }
}
