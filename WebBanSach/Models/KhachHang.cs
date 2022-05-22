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
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MatKhau { get; set; }
        public int TrangThai { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
