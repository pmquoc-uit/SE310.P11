using eCom.Models;

namespace eCom.Repository
{
    public interface ILoaiSpRepository
    {
        LoaiSanPham Add(LoaiSanPham loaiSp);
        LoaiSanPham Update(LoaiSanPham loaiSp);
        LoaiSanPham? Delete(String maLoaiSp);
        LoaiSanPham? GetLoaiSp(String maLoaiSp);
        IEnumerable<LoaiSanPham> GetAllLoaiSp();
    }
}
