using ValiStore.Models;

namespace ValiStore.ViewModels
{
    public class HomeProductDetailViewModel(TDanhMucSp danhMucSp, List<TAnhSp> anhSps)
    {
        public TDanhMucSp DanhMucSp { get; set; } = danhMucSp;
        public List<TAnhSp> AnhSps { get; set; } = anhSps;
    }
}
