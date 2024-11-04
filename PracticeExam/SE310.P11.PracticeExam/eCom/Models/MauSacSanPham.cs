using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCom.Models
{
    public class MauSacSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaMauSac { get; set; } = null!;
        public string? TenMauSac { get; set; }
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = [];
    }
}