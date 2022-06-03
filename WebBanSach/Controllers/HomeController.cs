using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbcontext _DB;

        public HomeController(ILogger<HomeController> logger, dbcontext context)
        {
            _logger = logger;
            _DB = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TrangChu()
        {
            var lstProdust = _DB.Sachs.ToList();
            return View(lstProdust);
        }
        public IActionResult DetailBook(string id)
        {
            List<SachCT> lstSachCT = new List<SachCT>();
            lstSachCT = _DB.SachCTs.Where(c => c.MaSach == id).ToList();
            List<TacGia> lstTacGia = new List<TacGia>();
            List<TheLoai> lstTheLoai = new List<TheLoai>();
            foreach (var item in lstSachCT)
            {
                TacGia tacGia = new TacGia();
                tacGia = _DB.TacGias.First(c => c.ID_TacGia == item.MaTacGia);
                lstTacGia.Add(tacGia);
                TheLoai theLoai = new TheLoai();
                theLoai = _DB.TheLoais.First(c=>c.ID_TheLoai == item.MaTheLoai);
                lstTheLoai.Add(theLoai);
            }
            ViewBag.TacGia = lstTacGia;
            ViewBag.TheLoai = lstTheLoai;
            var DetailSP = _DB.Sachs.Where(c => c.ID_Sach == id).FirstOrDefault();
            var DetailSPCT = _DB.SachCTs.Where(c => c.MaSach == id).FirstOrDefault();  
            return View(DetailSP);
        }
        [Authorize(Policy ="AdminOnly")]
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}