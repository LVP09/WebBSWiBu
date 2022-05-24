using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanSach.Models
{
    [Table("NhaXuatBan")]
    public class NhaXuatBan
    {
        [Key]
        [Required]
        public string ID_NXB { get; set; }
        public string TenXuatBan { get; set; }
        public int TrangThai { get; set; }
        public virtual ICollection<SachCT> SachCTs { get; set; }
    }
}
