using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCom.Models
{
    public class AnhChiTietSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaChiTietSp { get; set; } = null!;
        public string TenFileAnh { get; set; } = null!;
        public virtual ChiTietSanPham MaChiTietSpNavigation { get; set; } = null!;
    }
}