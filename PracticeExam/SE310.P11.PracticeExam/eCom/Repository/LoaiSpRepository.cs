using eCom.Models;

namespace eCom.Repository
{
    public class LoaiSpRepository(EComContext qlbanVaLiContext) : ILoaiSpRepository
    {
        public LoaiSanPham Add(LoaiSanPham loaiSp)
        {
            qlbanVaLiContext.LoaiSanPhams.Add(loaiSp);
            qlbanVaLiContext.SaveChanges();
            return loaiSp;
        }

        public LoaiSanPham? Delete(string maLoaiSp)
        {
            //var loaiSp = qlbanVaLiContext.TLoaiSps.FirstOrDefault(x => x.MaLoai == maLoaiSp);
            var loaiSp = qlbanVaLiContext.LoaiSanPhams.Find(maLoaiSp);
            if (loaiSp != null) qlbanVaLiContext.LoaiSanPhams.Remove(entity: loaiSp);
            return loaiSp;
        }

        public IEnumerable<LoaiSanPham> GetAllLoaiSp()
        {
            return qlbanVaLiContext.LoaiSanPhams;
        }

        public LoaiSanPham? GetLoaiSp(string maLoaiSp)
        {
            return qlbanVaLiContext.LoaiSanPhams.Find(maLoaiSp);
            //return qlbanVaLiContext.TLoaiSps.FirstOrDefault(x => x.MaLoai == maLoaiSp);
        }

        public LoaiSanPham Update(LoaiSanPham loaiSp)
        {
            qlbanVaLiContext.LoaiSanPhams.Update(loaiSp);
            qlbanVaLiContext.SaveChanges();
            return loaiSp;
        }
    }
}
