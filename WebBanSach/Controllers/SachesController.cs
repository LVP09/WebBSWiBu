using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Views
{
    public class SachesController : Controller
    {
        private readonly dbcontext _context;
        private DateTime aDateTime;
        public SachesController(dbcontext context)
        {
            _context = context;
        }

        // GET: Saches
        public async Task<IActionResult> Index()
        {
            var dbcontext = _context.Sachs.Include(s => s.NhaXuatBan);
            return View(await dbcontext.ToListAsync());
        }

        // GET: Saches/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Sachs == null)
            {
                return NotFound();
            }

            var sach = await _context.Sachs
                .Include(s => s.NhaXuatBan)
                .FirstOrDefaultAsync(m => m.ID_Sach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }
        private List<Sach> GetSach()
        {
            List<Sach> saches = new List<Sach>();
            saches = _context.Sachs.ToList();
            return saches;
        }

        public List<SachCT> GetSachCT()
        {
            List<SachCT> sachCT = new List<SachCT>();
            sachCT = _context.SachCTs.ToList();
            return sachCT;
        }
        public List<TacGia> GetTG()
        {
            List<TacGia> tacGias = new List<TacGia>();
            tacGias = _context.TacGias.ToList();
            return tacGias;
        }
        public List<TheLoai> GetTL()
        {
            List<TheLoai> theLoais = new List<TheLoai>();
            theLoais = _context.TheLoais.ToList();
            return theLoais;
        }

        //GET: Saches/Create
        public class MultiDropDownListViewModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public List<SelectListItem> ItemList { get; set; }
        }
        public IActionResult Create()
        {
 
            

            
            MultiDropDownListViewModel model = new();
            ViewBag.IDTL =  model.ItemList = GetTL().Select(x => new SelectListItem { Text = x.TenTL, Value = x.ID_TheLoai.ToString() }).ToList();
        

            ViewBag.IDNXB = new SelectList(_context.NhaXuatBans, "ID_NXB", "TenXuatBan");
         
            ViewBag.IDTG = model.ItemList = GetTG().Select(x => new SelectListItem { Text = x.HoVaTen, Value = x.ID_TacGia.ToString() }).ToList();
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenSach,MaNXB,HinhAnh,SoTrang,TaiBan,NgayNhap,SoLuong,Gia")] Sach sach, string[] SelectedIdsTL, string[] SelectedIdsTG,double idGia)
        {
           
            if (sach != null)
            {
                sach.ID_Sach = Guid.NewGuid().ToString();
                sach.TrangThai = 1;
                sach.NgayNhap = aDateTime = DateTime.Now;
                sach.Gia = idGia;
                _context.Add(sach);
                foreach (var tgx in SelectedIdsTG)
                {
                    foreach (var tlx in SelectedIdsTL)
                    {
                        SachCT sachCT = new SachCT();
                        sachCT.ID_SachCT = Guid.NewGuid().ToString();
                        sachCT.MaTacGia = tgx;
                        sachCT.MaTheLoai = tlx;
                        sachCT.TrangThai = 1;
                        sachCT.MaSach = sach.ID_Sach;
                        _context.Add(sachCT);
                    }
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); 
            }

            ViewBag.IDNXB = new SelectList(_context.NhaXuatBans, "ID_NXB", "TenXuatBan", sach.MaNXB);
           

            return RedirectToAction("Index");
        }

        // GET: Saches/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Sachs == null)
            {
                return NotFound();
            }

            var sach = await _context.Sachs.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            ViewData["MaNXB"] = new SelectList(_context.NhaXuatBans, "ID_NXB", "ID_NXB", sach.MaNXB);
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID_Sach,MaNXB,TenSach,HinhAnh,SoTrang,TaiBan,NgayNhap,SoLuong,TrangThai")] Sach sach)
        {
            if (id != sach.ID_Sach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachExists(sach.ID_Sach))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNXB"] = new SelectList(_context.NhaXuatBans, "ID_NXB", "ID_NXB", sach.MaNXB);
            return View(sach);
        }

        // GET: Saches/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Sachs == null)
            {
                return NotFound();
            }

            var sach = await _context.Sachs
                .Include(s => s.NhaXuatBan)
                .FirstOrDefaultAsync(m => m.ID_Sach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Sachs == null)
            {
                return Problem("Entity set 'dbcontext.Sachs'  is null.");
            }
            var sach = await _context.Sachs.FindAsync(id);
            if (sach != null)
            {
                _context.Sachs.Remove(sach);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SachExists(string id)
        {
          return (_context.Sachs?.Any(e => e.ID_Sach == id)).GetValueOrDefault();
        }
    }
}
