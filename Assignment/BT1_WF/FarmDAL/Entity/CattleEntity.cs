namespace FarmDAL.Entity
{
    public abstract class CattleEntity(string loai, int soCon, int soSua)
    {
        public string Loai { get; set; } = loai;
        public int SoCon { get; set; } = soCon;
        public int SoSua { get; set; } = soSua;
    }
}
