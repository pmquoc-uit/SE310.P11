using eCom.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCom.Controllers
{
    public class AccessController(EComContext qlbanVaLiContext) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") == null) return View();
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                var u =
                    qlbanVaLiContext.User
                    .Where(x => x.Username.Equals(user.Username)
                    && x.Password.Equals(user.Password)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("Username", u.Username);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("Username") == null) return View();
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                var exitsu =
                    qlbanVaLiContext.User
                    .Where(x => x.Username.Equals(user.Username)
                    && x.Password.Equals(user.Password)).FirstOrDefault();
                if (exitsu != null)
                {
                    HttpContext.Session.SetString("Username", exitsu.Username);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    user.LoaiUser = 0;
                    KhachHang kh = new()
                    {
                        Username = user.Username,
                        TenKhachHang = user.Username,
                        DiaChi = "KH mới!",
                        LoaiKhachHang = 0
                    };
                    user.KhachHangs.Add(kh);
                    qlbanVaLiContext.User.Add(user);
                    if (qlbanVaLiContext.SaveChanges() > 0)
                    {
                        HttpContext.Session.SetString("Username", user.Username);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login", "Access");
        }
    }
}
