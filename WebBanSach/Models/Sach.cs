using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanSach.Models
{
    [Table("Sach")]
    public class Sach
    {
        [Key]
        [Required]
        public string ID_Sach { get; set; }
        [ForeignKey("NhaXuatBan")]
        public string MaNXB { get; set; }
        public string TenSach { get; set; }
        public string HinhAnh { get; set; }
        public int SoTrang { get; set; }
        public int TaiBan { get; set; }
        public DateTime NgayNhap { get; set; }
        public int SoLuong { get; set; }
        public int TrangThai { get; set; }
        public virtual NhaXuatBan NhaXuatBan { get; set; }
        public virtual ICollection<SachCT> SachCTs { get; set; }
    }
}
