using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCom.Models
{
    public class NhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaNhanVien { get; set; } = null!;
        public string? Username { get; set; }
        public string? TenNhanVien { get; set; }
        public string? DiaChi { get; set; }
        public string? ChucVu { get; set; }
        public virtual User? UsernameNavigation { get; set; }
    }
}