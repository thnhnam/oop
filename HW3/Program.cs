using System;
using System.Collections.Generic;
using System.Text;

class NhanVien
{
    private string ten;
    public string Ten
    {
        get { return ten; }
        set { ten = value; }
    }
}

class SanPham
{
    private double gia;
    private double giamGia;

    public SanPham(double gia, double giamGia)
    {
        this.gia = gia;
        this.giamGia = giamGia;
    }

    public double LayGia()
    {
        return gia;
    }

    public double LayGiamGia()
    {
        return giamGia;
    }
}

class HoaDonMuaHang
{
    private NhanVien nhanVien;
    protected List<SanPham> danhSachSanPham;

    public HoaDonMuaHang(NhanVien nhanVien)
    {
        this.nhanVien = nhanVien;
        danhSachSanPham = new List<SanPham>();
    }

    public void ThemVao(SanPham sanPham)
    {
        danhSachSanPham.Add(sanPham);
    }

    public double TinhTongTien()
    {
        double tong = 0;
        foreach (SanPham sanPham in danhSachSanPham)
        {
            tong += sanPham.LayGia();
        }
        return tong;
    }

    public void InHoaDon()
    {
        Console.WriteLine("Hóa đơn:");
        foreach (SanPham sanPham in danhSachSanPham)
        {
            Console.WriteLine($"- Sản phẩm: {sanPham.LayGia()} VND");
        }
        Console.WriteLine($"Tổng cộng: {TinhTongTien()} VND");
    }
}

class HoaDonGiamGia : HoaDonMuaHang
{
    private bool khachHangUuTien;

    public HoaDonGiamGia(NhanVien nhanVien, bool khachHangUuTien) : base(nhanVien)
    {
        this.khachHangUuTien = khachHangUuTien;
    }

    public int LaySoLuongSanPhamDuocGiamGia()
    {
        int soLuong = 0;
        foreach (SanPham sanPham in danhSachSanPham)
        {
            if (sanPham.LayGiamGia() > 0)
            {
                soLuong++;
            }
        }
        return soLuong;
    }

    public double LayTongGiamGia()
    {
        double tongGiamGia = 0;
        foreach (SanPham sanPham in danhSachSanPham)
        {
            tongGiamGia += sanPham.LayGiamGia();
        }
        return tongGiamGia;
    }

    public double LayPhanTramGiamGia()
    {
        double tongGiamGia = LayTongGiamGia();
        double tongTien = TinhTongTien();
        if (tongTien > 0)
        {
            return (tongGiamGia / tongTien) * 100;
        }
        return 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding=Encoding.UTF8;
        NhanVien nhanVien = new NhanVien();
        HoaDonMuaHang hoaDonMuaHang = new HoaDonMuaHang(nhanVien);
        HoaDonGiamGia hoaDonGiamGia = new HoaDonGiamGia(nhanVien, true);

        SanPham sanPham1 = new SanPham(1.35, 0.25);
        SanPham sanPham2 = new SanPham(2.50, 0.0);

        hoaDonMuaHang.ThemVao(sanPham1);
        hoaDonMuaHang.ThemVao(sanPham2);

        hoaDonGiamGia.ThemVao(sanPham1);
        hoaDonGiamGia.ThemVao(sanPham2);

        Console.WriteLine("Hóa đơn thông thường:");
        hoaDonMuaHang.InHoaDon();

        Console.WriteLine("Hóa đơn có giảm giá:");
        hoaDonGiamGia.InHoaDon();
    }
}