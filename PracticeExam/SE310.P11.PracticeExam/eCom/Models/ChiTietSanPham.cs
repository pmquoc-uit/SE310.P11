using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCom.Models
{
    public class ChiTietSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaChiTietSp { get; set; } = null!;
        public string? MaSp { get; set; }
        public string? MaKichThuoc { get; set; }
        public string? MaMauSac { get; set; }
        public string? AnhDaiDien { get; set; }
        public double? DonGia { get; set; }
        public int? SoLuong { get; set; }
        public virtual SanPham? MaSpNavigation { get; set; }
        public virtual KichThuocSanPham? MaKichThuocNavigation { get; set; }
        public virtual MauSacSanPham? MaMauSacNavigation { get; set; }
        public virtual ICollection<AnhChiTietSanPham> AnhChiTietSanPhams { get; set; } = [];
    }
}