using Microsoft.AspNetCore.Mvc;
using ValiStore.Repository;
namespace ValiStore.ViewComponents
{
    public class LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var loaisp = loaiSpRepository.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaisp);
        }
    }
}
