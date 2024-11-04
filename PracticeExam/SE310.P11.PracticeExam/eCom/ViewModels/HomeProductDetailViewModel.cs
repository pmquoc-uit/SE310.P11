using eCom.Models;

namespace eCom.ViewModels
{
    public class HomeProductDetailViewModel(SanPham danhMucSp, List<AnhSanPham> anhSps)
    {
        public SanPham DanhMucSp { get; set; } = danhMucSp;
        public List<AnhSanPham> AnhSps { get; set; } = anhSps;
    }
}
