using eCom.Models;
using eCom.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace eCom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/HomeAdmin")]
    [Authentication]
    public class HomeAdminController(EComContext qlbanVaLiContext) : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("DanhMucSanPham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = qlbanVaLiContext.SanPhams.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<SanPham> lst = new(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaLoai =
                new SelectList(qlbanVaLiContext.LoaiSanPhams.ToList(), "MaLoai", "TenLoai");
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                qlbanVaLiContext.SanPhams.Add(sanPham);
                if (qlbanVaLiContext.SaveChanges() > 0)
                    return RedirectToAction("DanhMucSanPham");
            }
            TempData[key: "Message"] = "Có lỗi khi thêm Sp";
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(String maSanPham)
        {
            ViewBag.MaLoai =
                new SelectList(qlbanVaLiContext.LoaiSanPhams.ToList(), "MaLoai", "TenLoai");
            var sanPham = qlbanVaLiContext.SanPhams.Find(maSanPham);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                qlbanVaLiContext.Attach(sanPham);
                qlbanVaLiContext.Entry(sanPham).State = EntityState.Modified;
                //qlbanVaLiContext.SanPhams.Update(sanPham);
                if (qlbanVaLiContext.SaveChanges() > 0)
                    return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            TempData[key: "Message"] = "Có lỗi khi sửa Sp";
            return View(sanPham);
        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(String maSanPham)
        {
            TempData["Message"] = "";
            var sanPham = qlbanVaLiContext.SanPhams.Find(maSanPham);
            if (sanPham != null)
            {
                var chiTietSanPham =
                    qlbanVaLiContext.ChiTietSanPhams.Where(x => x.MaSp == maSanPham).ToList();
                if (chiTietSanPham.Count() > 0)
                {
                    TempData["Message"] = "Khong xoa duoc san pham nay";
                    return RedirectToAction("DanhMucSanPham", "HomeAdmin");
                }
                var anhSanPham = qlbanVaLiContext.AnhSanPhams.Where(x => x.MaSp == maSanPham).ToList();
                if (anhSanPham.Any()) qlbanVaLiContext.RemoveRange(anhSanPham);
                qlbanVaLiContext.Remove(sanPham);
                if (qlbanVaLiContext.SaveChanges() > 0)
                {
                    TempData["Message"] = "San Pham Da Duoc Xoa";
                    return RedirectToAction("DanhMucSanPham", "HomeAdmin");
                }
                else
                {
                    TempData["Message"] = "Co loi khi xoa";
                    return RedirectToAction("DanhMucSanPham", "HomeAdmin");
                }
            }
            TempData["Message"] = "Khong tim thay san pham";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }
    }
}
