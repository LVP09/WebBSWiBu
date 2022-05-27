using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;

namespace WebBanSach.Models.Extend
{
    public class Nav_data: ViewComponent
    {
        private readonly dbcontext _db;
        public Nav_data(dbcontext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //ViewBag.User = HttpContext.Session.GetString("user");
            //ViewBag.NhanVien = HttpContext.Session.GetString("nv");
            return View("NavData");
        }
    }
}
