namespace FarmDAL.Entity
{
    public class DeEntity : CattleEntity
    {
        public static string TiengKeu { get; } = "DeDe";
        public DeEntity(string loai, int soCon, int soSua) : base(loai, soCon, soSua)
        {
            this.Loai = loai;
            this.SoCon = soCon;
            this.SoSua = soSua;
        }
    }
}
