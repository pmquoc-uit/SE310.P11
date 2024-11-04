using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCom.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte? LoaiUser { get; set; }
        public virtual ICollection<KhachHang> KhachHangs { get; set; } = [];
        public virtual ICollection<NhanVien> NhanViens { get; set; } = [];
    }
}