using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ValiStore.Models;
using ValiStore.Models.Authentication;
using ValiStore.ViewModels;
using X.PagedList;

namespace ValiStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QlbanVaLiContext _qlbanVaLiContext;
        public HomeController(ILogger<HomeController> logger, QlbanVaLiContext qlbanVaLiContext)
        {
            _logger = logger;
            _qlbanVaLiContext = qlbanVaLiContext;
        }

        //[Authentication]
        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = _qlbanVaLiContext.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }

        public IActionResult SanPhamTheoLoai(String maloai, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham =
                _qlbanVaLiContext.TDanhMucSps
                .AsNoTracking()
                .Where(x => x.MaLoai == maloai)
                .OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstSanPham, pageNumber, pageSize);
            ViewBag.maloai = maloai;
            return View(lst);
        }

        public IActionResult ChiTietSanPham(String maSp)
        {
            var sanPham = _qlbanVaLiContext.TDanhMucSps
                .SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham = _qlbanVaLiContext.TAnhSps
                .Where(x => x.MaSp == maSp).ToList();
            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);
        }

        public IActionResult ProductDetail(String maSp)
        {
            var sanPham = _qlbanVaLiContext.TDanhMucSps
                .SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham = _qlbanVaLiContext.TAnhSps
                .Where(x => x.MaSp == maSp).ToList();
            var homeProductDetailViewModel = new HomeProductDetailViewModel(sanPham, anhSanPham);
            return View(sanPham);
        }

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
