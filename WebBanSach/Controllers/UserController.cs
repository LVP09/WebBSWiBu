using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using WebBanSach.Dao;
using WebBanSach.Data;
using WebBanSach.Models;
using WebBanSach.Models.Extend;


namespace WebBanSach.Controllers
{
    public class UserController : Controller
    {
        private dbcontext db;
      

        public UserController(dbcontext db)
        {
            this.db = db;
        }

        //GET: NGƯỜI DÙNG
        public ActionResult Index()
        {
            return View();
        }

        //Get: Người dùng
        
        public ActionResult Dangky()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dangky(IFormCollection collection,KhachHang kh)
        {
          
            var Khs = db.KhachHangs.ToList();
           
            var hoten = collection["HotenKH"];
           
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai = collection["Matkhaunhaplai"];
            var email = collection["Email"];
            var diachi = collection["Diachi"];
            var dienthoai = collection["Dienthoai"];
            var trangthai = collection["Trangthai"];
            var ngaysinh = String.Format("{0:mm/dd/yyyy}", collection["Ngaysinh"]);
            foreach (var item in Khs)
            {
                if (item.Email == email)
                {
                    ViewData["Loi5"] = "Email Đã tồn tại";
                    return RedirectToAction("Dangky", "User");
                }
            }
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên không được để trống";
            }
           
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Mật khẩu không được để trống";
            }
            if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi4"] = "Mật khẩu nhập lại không được để trống";
            }
            if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Email không được để trống";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi6"] = "SDT không được để trống";
            }
            if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi7"] = "Địa chỉ không được để trống";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi8"] = "Trạng thái không được để trống";
            }
            
            else
            {
                //Gán vào data
                kh.ID_KhachHang = Guid.NewGuid().ToString();
                kh.HoVaTen = hoten;
                kh.Email = email;
                kh.MatKhau = matkhau;
                kh.DiaChi = diachi;
                kh.SDT = dienthoai;
                kh.NgaySinh = DateTime.Parse(ngaysinh);
                kh.TrangThai = 1;
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Login", "Login");
            }
            return Dangky();
        }



        //Quên mật khẩu
        [HttpGet("forgot-password")]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Code here
                ModelState.Clear();
                model.EmailSent = true;
            }
            return View(model);
        }
    }
}

