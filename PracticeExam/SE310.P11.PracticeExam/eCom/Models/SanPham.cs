using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCom.Models
{
    public class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? MaSp { get; set; }
        [Required]
        public string? TenSp { get; set; }
        public string? MaLoai { get; set; }
        public string? AnhSp { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GiaSp { get; set; }
        public LoaiSanPham? LoaiSanPham { get; set; }
        public virtual ICollection<AnhSanPham> AnhSanPhams { get; set; } = [];
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = [];
    }
}