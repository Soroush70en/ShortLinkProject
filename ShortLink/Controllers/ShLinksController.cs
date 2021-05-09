using Microsoft.AspNetCore.Mvc;
using ShortLink.Core.Interface;

namespace ShortLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShLinksController : ControllerBase
    {
        /// <summary>
        /// دستگیره سرویس لینک کوتاه
        /// </summary>
        private IShLink _shLink;
        public ShLinksController(IShLink ShLink)
        {
            _shLink = ShLink;
        }

        // در این بخش در صورت گذاشتن یک بک اسلش در ابتدای آدرس ورودی، مقدار نام کنترلر بای پس می‌شود
        [HttpGet("GotoLink/{Link}")]
        /// <summary>
        /// دریافت لینک و ارسال به پیچ مربوط به لینک کوتاه در این تابع انجام می‌شود
        /// </summary>
        /// <param name="Link">ادرس کوتاه شده لینک</param>
        /// <returns>انتقال به صفحه مربوط به لینک کوتاه وارد شده</returns>
        /// آدرس : http://localhost:7665/api/ShLinks/GotoLink/{Link}
        public RedirectResult GotoLinks(string Link)
        {
            return Redirect(_shLink.Take_Short_Link(Link));
        }

        /// <summary>
        /// تولید لینک کوتاه شده سایت
        /// </summary>
        /// <param name="_Link">لینک کامل که به صورت ورودی وارد می‌شود</param>
        /// <returns>لینک کوتاه شده ساخته شود</returns>
        /// آدرس : http://localhost:7665/api/ShLinks/GenerateLink
        [HttpPost("GenerateLink")]
        public string GenerateLinks([FromForm]string _Link)
        {
            return _shLink.Add_Short_Link(_Link);
        }
    }
}
