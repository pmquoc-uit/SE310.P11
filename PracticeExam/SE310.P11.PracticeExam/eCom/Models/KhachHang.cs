using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCom.Models
{
    public class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaKhanhHang { get; set; } = null!;
        public string? Username { get; set; }
        public string? TenKhachHang { get; set; }
        public string? DiaChi { get; set; }
        public byte? LoaiKhachHang { get; set; }
        public virtual User? UsernameNavigation { get; set; }
    }
}