using eCom.Models;
using eCom.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace eCom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EComContext _qlbanVaLiContext;
        public HomeController(ILogger<HomeController> logger, EComContext qlbanVaLiContext)
        {
            _logger = logger;
            _qlbanVaLiContext = qlbanVaLiContext;
        }

        //[Authentication]
        public IActionResult Index(int? page)
        {
            const int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham =
                _qlbanVaLiContext.SanPhams.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<SanPham> lst = new(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }

        public IActionResult SanPhamTheoLoai(String maloai, int? page)
        {
            Console.WriteLine(maloai);
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham =
                _qlbanVaLiContext.SanPhams
                .AsNoTracking()
                .Where(x => x.MaLoai == maloai)
                .OrderBy(x => x.TenSp);
            PagedList<SanPham> lst = new PagedList<SanPham>(lstSanPham, pageNumber, pageSize);
            ViewBag.maloai = maloai;
            return View(lst);
        }

        public IActionResult ChiTietSanPham(String maSp)
        {
            var sanPham = _qlbanVaLiContext.SanPhams
                .SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham = _qlbanVaLiContext.AnhSanPhams
                .Where(x => x.MaSp == maSp).ToList();
            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);
        }

        public IActionResult ProductDetail(String maSp)
        {
            var sanPham = _qlbanVaLiContext.SanPhams
                .SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham = _qlbanVaLiContext.AnhSanPhams
                .Where(x => x.MaSp == maSp).ToList();
            var homeProductDetailViewModel =
                new HomeProductDetailViewModel(sanPham!, anhSanPham);
            return View(homeProductDetailViewModel);
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
