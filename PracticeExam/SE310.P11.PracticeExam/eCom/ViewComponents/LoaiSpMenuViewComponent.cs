using eCom.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eCom.ViewComponents
{
    public class LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var loaisp = loaiSpRepository.GetAllLoaiSp().OrderBy(x => x.TenLoai);
            return View(loaisp);
        }
    }
}
