using FarmDAL;
using FarmDAL.Entity;
using System.Data;

namespace FarmBLL
{
    public class CattleService
    {
        private CattleDAO cattleDAO;
        public CattleService()
        {
            this.cattleDAO = new CattleDAO();
        }
        public DataTable GetCattles()
        {
            return this.cattleDAO.GetCattles();
        }
        public List<CattleEntity> AddCattles(int soBo, int soCuu, int soDe)
        {
            List<CattleEntity> cattleList = new List<CattleEntity>();
            Random randomWithDynamicSeed = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            for (int i = 0; i < soBo; i++)
            {
                CattleEntity bo = new BoEntity(
                    "Bo",
                    randomWithDynamicSeed.Next(0, 11),
                    randomWithDynamicSeed.Next(0, 21));
                this.cattleDAO.AddCattle(bo);
            }
            for (int i = 0; i < soCuu; i++)
            {
                CattleEntity cuu = new CuuEntity(
                    "Cuu",
                    randomWithDynamicSeed.Next(0, 11),
                    randomWithDynamicSeed.Next(0, 6));
                this.cattleDAO.AddCattle(cuu);
            }
            for (int i = 0; i < soDe; i++)
            {
                CattleEntity de = new DeEntity(
                    "De",
                    randomWithDynamicSeed.Next(0, 11),
                    randomWithDynamicSeed.Next(0, 11));
                this.cattleDAO.AddCattle(de);
            }
            return cattleList;
        }
        public string Keu(string loai)
        {
            if (this.cattleDAO.GetCattles().Rows.Count == 0)
                return "Data not found!";
            return loai switch
            {
                "Bo" => BoEntity.TiengKeu,
                "Cuu" => CuuEntity.TiengKeu,
                "De" => DeEntity.TiengKeu,
                _ => "",
            };
        }
    }
}
