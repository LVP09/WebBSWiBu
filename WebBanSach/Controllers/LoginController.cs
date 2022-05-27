using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;
using WebBanSach.Models.Extend;

namespace WebBanSach.Controllers
{
    public class LoginController : Controller
    {
        private dbcontext _db;
        public LoginController(dbcontext dbcontext)
        {
            _db = dbcontext;
        }
        public IActionResult KhachHangLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KhachHangLogin(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                if (_db.KhachHangs.ToList().Exists(c => c.Email == userLogin.User && c.MatKhau == userLogin.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("","Sai");
                }
            }
            return View(userLogin);
        }
        public IActionResult NhanVien(string user, string pw)
        {
            return View();
        }
    }
}
