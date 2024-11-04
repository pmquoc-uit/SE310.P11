using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ValiStore.Models;
using X.PagedList;

namespace ValiStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/HomeAdmin")]
    public class HomeAdminController(QlbanVaLiContext qlbanVaLiContext) : Controller
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
            var lstSanPham = qlbanVaLiContext.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaChatLieu =
                new SelectList(qlbanVaLiContext.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx =
                new SelectList(qlbanVaLiContext.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx =
                new SelectList(qlbanVaLiContext.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai =
                new SelectList(qlbanVaLiContext.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt =
                new SelectList(qlbanVaLiContext.TLoaiDts.ToList(), "MaDt", "TenLoai");
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                qlbanVaLiContext.TDanhMucSps.Add(sanPham);
                if (qlbanVaLiContext.SaveChanges() > 0)
                    return RedirectToAction("DanhMucSanPham");
            }
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(String maSanPham)
        {
            ViewBag.MaChatLieu =
                new SelectList(qlbanVaLiContext.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx =
                new SelectList(qlbanVaLiContext.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx =
                new SelectList(qlbanVaLiContext.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai =
                new SelectList(qlbanVaLiContext.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt =
                new SelectList(qlbanVaLiContext.TLoaiDts.ToList(), "MaDt", "TenLoai");
            var sanPham = qlbanVaLiContext.TDanhMucSps.Find(maSanPham);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                qlbanVaLiContext.Attach(sanPham);
                qlbanVaLiContext.Entry(sanPham).State = EntityState.Modified;
                if (qlbanVaLiContext.SaveChanges() > 0)
                    return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(String maSanPham)
        {
            TempData["Message"] = "";
            var sanPham = qlbanVaLiContext.TDanhMucSps.Find(maSanPham);
            if (sanPham != null)
            {
                var chiTietSanPham =
                    qlbanVaLiContext.TChiTietSanPhams.Where(x => x.MaSp == maSanPham).ToList();
                if (chiTietSanPham.Count() > 0)
                {
                    TempData["Message"] = "Khong xoa duoc san pham nay";
                    return RedirectToAction("DanhMucSanPham", "HomeAdmin");
                }
                var anhSanPham = qlbanVaLiContext.TAnhSps.Where(x => x.MaSp == maSanPham).ToList();
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
