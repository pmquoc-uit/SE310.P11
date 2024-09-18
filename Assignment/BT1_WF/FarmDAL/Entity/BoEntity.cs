namespace FarmDAL.Entity
{
    public class BoEntity : CattleEntity
    {
        public static string TiengKeu { get; } = "BoBo";
        public BoEntity(string loai, int soCon, int soSua) : base(loai, soCon, soSua)
        {
            this.Loai = loai;
            this.SoCon = soCon;
            this.SoSua = soSua;
        }
    }
}
