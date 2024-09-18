namespace FarmDAL.Entity
{
    public class CuuEntity : CattleEntity
    {
        public static string TiengKeu { get; } = "CuuCuu";
        public CuuEntity(string loai, int soCon, int soSua) : base(loai, soCon, soSua)
        {
            this.Loai = loai;
            this.SoCon = soCon;
            this.SoSua = soSua;
        }
    }
}
