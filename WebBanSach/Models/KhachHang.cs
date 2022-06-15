using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanSach.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public string ID_KhachHang { get; set; }
        public string HoVaTen { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        [MinLength(5)]
        [MaxLength(20)]
        public string MatKhau { get; set; }
        [Range(0,1)]
        public int TrangThai { get; set; }
        public virtual ICollection<HoaDon>? HoaDons { get; set; }
    }
}
