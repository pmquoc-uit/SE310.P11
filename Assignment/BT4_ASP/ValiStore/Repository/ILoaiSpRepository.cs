using ValiStore.Models;

namespace ValiStore.Repository
{
    public interface ILoaiSpRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp? Delete(String maLoaiSp);
        TLoaiSp? GetLoaiSp(String maLoaiSp);
        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
