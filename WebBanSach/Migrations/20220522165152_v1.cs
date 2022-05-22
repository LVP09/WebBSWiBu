using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanSach.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    ID_KhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.ID_KhachHang);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    ID_NhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quyen = table.Column<bool>(type: "bit", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.ID_NhanVien);
                });

            migrationBuilder.CreateTable(
                name: "NhaXuatBan",
                columns: table => new
                {
                    ID_NXB = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenXuatBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaXuatBan", x => x.ID_NXB);
                });

            migrationBuilder.CreateTable(
                name: "TacGia",
                columns: table => new
                {
                    ID_TacGia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QueQuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacGia", x => x.ID_TacGia);
                });

            migrationBuilder.CreateTable(
                name: "TheLoai",
                columns: table => new
                {
                    ID_TheLoai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoai", x => x.ID_TheLoai);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    ID_HoaDon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayMua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.ID_HoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "ID_KhachHang",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sach",
                columns: table => new
                {
                    ID_Sach = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaNXB = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenSach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoTrang = table.Column<int>(type: "int", nullable: false),
                    TaiBan = table.Column<int>(type: "int", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach", x => x.ID_Sach);
                    table.ForeignKey(
                        name: "FK_Sach_NhaXuatBan_MaNXB",
                        column: x => x.MaNXB,
                        principalTable: "NhaXuatBan",
                        principalColumn: "ID_NXB",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SachCT",
                columns: table => new
                {
                    ID_SachCT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSach = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaTheLoai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaTacGia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SachCT", x => x.ID_SachCT);
                    table.ForeignKey(
                        name: "FK_SachCT_Sach_MaSach",
                        column: x => x.MaSach,
                        principalTable: "Sach",
                        principalColumn: "ID_Sach",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SachCT_TacGia_MaTacGia",
                        column: x => x.MaTacGia,
                        principalTable: "TacGia",
                        principalColumn: "ID_TacGia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SachCT_TheLoai_MaTheLoai",
                        column: x => x.MaTheLoai,
                        principalTable: "TheLoai",
                        principalColumn: "ID_TheLoai",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonCT",
                columns: table => new
                {
                    ID_HDCT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSachCT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaHoaDon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonCT", x => x.ID_HDCT);
                    table.ForeignKey(
                        name: "FK_HoaDonCT_HoaDon_MaHoaDon",
                        column: x => x.MaHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "ID_HoaDon",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDonCT_SachCT_MaSachCT",
                        column: x => x.MaSachCT,
                        principalTable: "SachCT",
                        principalColumn: "ID_SachCT",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaKH",
                table: "HoaDon",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCT_MaHoaDon",
                table: "HoaDonCT",
                column: "MaHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCT_MaSachCT",
                table: "HoaDonCT",
                column: "MaSachCT");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_MaNXB",
                table: "Sach",
                column: "MaNXB");

            migrationBuilder.CreateIndex(
                name: "IX_SachCT_MaSach",
                table: "SachCT",
                column: "MaSach");

            migrationBuilder.CreateIndex(
                name: "IX_SachCT_MaTacGia",
                table: "SachCT",
                column: "MaTacGia");

            migrationBuilder.CreateIndex(
                name: "IX_SachCT_MaTheLoai",
                table: "SachCT",
                column: "MaTheLoai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoaDonCT");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SachCT");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "Sach");

            migrationBuilder.DropTable(
                name: "TacGia");

            migrationBuilder.DropTable(
                name: "TheLoai");

            migrationBuilder.DropTable(
                name: "NhaXuatBan");
        }
    }
}
