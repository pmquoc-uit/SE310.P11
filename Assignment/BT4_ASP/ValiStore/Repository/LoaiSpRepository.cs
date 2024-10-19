using Microsoft.EntityFrameworkCore;
using ValiStore.Models;

namespace ValiStore.Repository
{
    public class LoaiSpRepository(QlbanVaLiContext qlbanVaLiContext) : ILoaiSpRepository
    {
        public TLoaiSp Add(TLoaiSp loaiSp)
        {
            qlbanVaLiContext.TLoaiSps.Add(loaiSp);
            qlbanVaLiContext.SaveChanges();
            return loaiSp;
        }

        public TLoaiSp? Delete(string maLoaiSp)
        {
            //var loaiSp = qlbanVaLiContext.TLoaiSps.FirstOrDefault(x => x.MaLoai == maLoaiSp);
            var loaiSp = qlbanVaLiContext.TLoaiSps.Find(maLoaiSp);
            if (loaiSp != null) qlbanVaLiContext.TLoaiSps.Remove(entity: loaiSp);
            return loaiSp;
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return qlbanVaLiContext.TLoaiSps;
        }

        public TLoaiSp? GetLoaiSp(string maLoaiSp)
        {
            return qlbanVaLiContext.TLoaiSps.Find(maLoaiSp);
            //return qlbanVaLiContext.TLoaiSps.FirstOrDefault(x => x.MaLoai == maLoaiSp);
        }

        public TLoaiSp Update(TLoaiSp loaiSp)
        {
            qlbanVaLiContext.TLoaiSps.Update(loaiSp);
            qlbanVaLiContext.SaveChanges() ;
            return loaiSp;
        }
    }
}
