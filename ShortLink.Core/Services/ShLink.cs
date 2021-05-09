using System.Linq;
using ShortLink.Core.Classes;
using ShortLink.Core.Interface;
using ShortLink.DataAccessLayer.Entities;

namespace ShortLink.Core.Services
{
    /// <summary>
    /// کلاس سرویس پیاده سازی اینترفیس IShLink
    /// </summary>
    public class ShLink : IShLink
    {
        //private ShortLinkDbContext _context;

        private IUnitOFWork _UnW;
        private IRepository<tbShortLinks> ShLinkRepo;

        public ShLink(IUnitOFWork UnW)
        {
            _UnW = UnW;
            ShLinkRepo = _UnW.Repository<tbShortLinks>();
        }

        public string Add_Short_Link(string Link)
        {
            var Check = ShLinkRepo.Get(p => p.FullLink == Link).FirstOrDefault();

            // چک کردن تکراری بودن لینک
            if (Check != null)
            {
                return Check.ShortedLink;
            }
            // در صورتی لینک از قبل موجود نباشد
            else
            {
                tbShortLinks NewShortLink = new tbShortLinks()
                {
                    FullLink = Link,
                    ShortedLink = LinkGenerator.GeneratLink()
                };

                ShLinkRepo.Insert(NewShortLink);

                if (_UnW.SaveChange())
                {
                    return NewShortLink.ShortedLink;
                }
                else
                {
                    return "لینک ساخته نشد";
                }
            }
        }

        public string Take_Short_Link(string Link)
        {
            return ShLinkRepo.Get(p => p.ShortedLink == Link).FirstOrDefault().FullLink;
        }
    }
}
