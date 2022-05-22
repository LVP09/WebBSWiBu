﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanSach.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public string ID_NhanVien { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MatKhau { get; set; }
        public bool Quyen { get; set; }
        public int TrangThai { get; set; }
    }
}
