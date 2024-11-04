using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCom.Models
{
    public class AnhSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaSp { get; set; } = null!;
        public string TenFileAnh { get; set; } = null!;
        public virtual SanPham MaSpNavigation { get; set; } = null!;
    }
}