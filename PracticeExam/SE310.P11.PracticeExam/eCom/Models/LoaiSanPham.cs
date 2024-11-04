using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCom.Models
{
    public class LoaiSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaLoai { get; set; } = null!;
        public string? TenLoai { get; set; }
        public ICollection<SanPham> SanPhams { get; set; } = [];
    }
}