using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCom.Models
{
    public class KichThuocSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaKichThuoc { get; set; } = null!;
        public string? TenKichThuoc { get; set; }
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = [];
    }
}