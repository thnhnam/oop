using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp1
{
    // lớp tài khoản
    public class taikhoan
    {
        private string sotaikhoan;
        private string soCMND;
        private string tenchutk;
        private double sotien;
        private double laixuat;
        public List<GiaoDich> DanhSachGiaoDich;
        public string Sotaikhoan
        {
            get { return sotaikhoan; }
            set { sotaikhoan = value; }
        }
        public string SoCMND
        {
            get { return soCMND; }
            set { soCMND = value; }
        }
        public string Tenchutk
        {
            get { return tenchutk; }
            set { tenchutk = value; }
        }
        public double Sotien
        {
            get { return sotien; }
            set { sotien = value; }
        }
        public double Laixuat
        {
            get { return laixuat; }
            set { laixuat = value; }
        }
        public taikhoan(string sotaikhoan, string soCMND, string tenchutk, double sotien, double laixuat)
        {
            Sotaikhoan = sotaikhoan;
            SoCMND = soCMND;
            Tenchutk = tenchutk;
            Laixuat = laixuat;
            DanhSachGiaoDich = new List<GiaoDich>();
        }
    }
    // Lớp giao dịch
    public class GiaoDich
    {
        public DateTime ngaygiaodich;
        public string loaigiaodich;
        public double sotien;
        public DateTime Ngaygiaodich
        {
            get {return ngaygiaodich;}
            set {ngaygiaodich = value;}
        }
        public string Loaigiaodich
        {
            get { return loaigiaodich; }
            set { loaigiaodich = value;}
        }
        public double Sotien
        {
            get { return sotien; }
            set { sotien = value; }
        }
    }
    public class nganhang
    {
        public List<taikhoan> DanhSachTaiKhoan;
        public nganhang()
        {
            DanhSachTaiKhoan = new List<taikhoan>();
        }
        public static taikhoan timtaikhoan(List<taikhoan> danhSachTaiKhoan, string soTaiKhoan)
        {
            foreach (taikhoan taiKhoan in danhSachTaiKhoan)
            {
                if (taiKhoan.Sotaikhoan == soTaiKhoan)
                {
                    return taiKhoan;
                }
            }

            return null; // Trả về null nếu không tìm thấy tài khoản
        }
        public void motaikhoan(string sotaikhoan, string soCMND, string tenchutk, double sotien, double laixuat)
        {
            taikhoan taikhoan = new taikhoan(sotaikhoan,soCMND,tenchutk,sotien,laixuat);
            DanhSachTaiKhoan.Add(taikhoan);
        }
        public void NhapTien(string soTaiKhoan, double soTien,DateTime ngaygiaodich)
        {
            taikhoan taiKhoan = timtaikhoan(DanhSachTaiKhoan, soTaiKhoan);
            if (taiKhoan != null)
            {
                taiKhoan.Sotien += soTien;
                GiaoDich giaoDich = new GiaoDich
                {
                    Ngaygiaodich = ngaygiaodich,
                    Loaigiaodich = "Nhập tiền",
                    Sotien = soTien
                };
                taiKhoan.DanhSachGiaoDich.Add(giaoDich);
                Console.WriteLine("Đã nạp thành công {0} vào tài khoản {1}", soTien, soTaiKhoan);
            }
            else
            {
                Console.WriteLine("Tài khoản không tồn tại.");
            }
        }
        public void ruttien(string soTaiKhoan, double soTien,DateTime ngaygiaodich)
        {
            taikhoan taiKhoan = timtaikhoan(DanhSachTaiKhoan, soTaiKhoan);
            if (taiKhoan != null)
            {
                if (taiKhoan.Sotien >= soTien)
                {
                    taiKhoan.Sotien -= soTien;
                    GiaoDich giaoDich = new GiaoDich
                    {
                        Ngaygiaodich = ngaygiaodich,
                        Loaigiaodich = "Rút tiền",
                        Sotien = soTien
                    };
                    taiKhoan.DanhSachGiaoDich.Add(giaoDich);
                    Console.WriteLine("Đã rút thành công {0} từ tài khoản {1}", soTien, soTaiKhoan);
                }
                else
                {
                    Console.WriteLine("Số dư không đủ để rút tiền.");
                }
            }
            else
            {
                Console.WriteLine("Tài khoản không tồn tại.");
            }
        }
        public void xemsotien(string soTaiKhoan)
        {
            taikhoan taiKhoan = timtaikhoan(DanhSachTaiKhoan, soTaiKhoan);
            if (taiKhoan != null)
            {
                Console.WriteLine("Số dư trong tài khoản {0}: {1}", soTaiKhoan, taiKhoan.Sotien);
            }
            else
            {
                Console.WriteLine("Tài khoản không tồn tại.");
            }
        }
        public void capnhatls()
        {
            foreach (taikhoan taiKhoan in DanhSachTaiKhoan)
            {
                double laiSuat = taiKhoan.Sotien * taiKhoan.Laixuat;
                taiKhoan.Sotien += laiSuat;
                GiaoDich giaoDich = new GiaoDich
                {   
                    Loaigiaodich = "Cập nhật lãi suất",
                    Sotien = laiSuat
                };
                taiKhoan.DanhSachGiaoDich.Add(giaoDich);
            }
            Console.WriteLine("Đã cập nhật lãi suất cho tất cả các tài khoản.");
        }
        public void InBaoCao()
        {
            Console.Clear();
            foreach (taikhoan taiKhoan in DanhSachTaiKhoan)
            {
                Console.WriteLine("Số hiệu tài khoản: {0}", taiKhoan.Sotaikhoan);
                Console.WriteLine("Số tiền hiện có: {0}", taiKhoan.Sotien);

                Console.WriteLine("Các giao dịch:");
                foreach (GiaoDich giaoDich in taiKhoan.DanhSachGiaoDich)
                {
                    Console.WriteLine("Ngày giao dịch: {0}", giaoDich.Ngaygiaodich);
                    Console.WriteLine("Loại giao dịch: {0}", giaoDich.Loaigiaodich);
                    Console.WriteLine("Số tiền: {0}", giaoDich.Sotien);
                    Console.WriteLine("------------------");
                }

                Console.WriteLine("==================");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            nganhang nganHang = new nganhang();

            // Mở tài khoản cho Alice
            nganHang.motaikhoan("001", "901", "Alice", 100, 0.05);

            // Mở tài khoản cho Bob
            nganHang.motaikhoan("002", "902", "Bob", 50, 0.05);

            // Mở tài khoản mới cho Alice với lãi suất khác
            nganHang.motaikhoan("003", "901", "Alice", 200, 0.1);

            // Mở tài khoản mới cho Eve
            nganHang.motaikhoan("004", "903", "Eve", 200, 0.1);

            // Nạp tiền vào tài khoản 001
            DateTime ngayNhapTien1 = new DateTime(2005, 7, 15);
            nganHang.NhapTien("001", 100, ngayNhapTien1);

            // Nạp tiền vào tài khoản 001
            DateTime ngayNhapTien2 = new DateTime(2005, 7, 31);
            nganHang.NhapTien("001", 100, ngayNhapTien2);

            // Nạp tiền vào tài khoản 002
            DateTime ngayNhapTien3 = new DateTime(2005, 7, 1);
            nganHang.NhapTien("002", 150, ngayNhapTien3);

            // Nạp tiền vào tài khoản 002
            DateTime ngayNhapTien4 = new DateTime(2005, 7, 15);
            nganHang.NhapTien("002", 150, ngayNhapTien4);

            // Nạp tiền vào tài khoản 003
            DateTime ngayNhapTien5 = new DateTime(2005, 7, 5);
            nganHang.NhapTien("003", 200, ngayNhapTien5);

            // Nạp tiền vào tài khoản 004
            DateTime ngayNhapTien6 = new DateTime(2005, 7, 31);
            nganHang.NhapTien("004", 250, ngayNhapTien6);

            // Rút tiền từ tài khoản 001
            DateTime ngayRutTien1 = new DateTime(2005, 7, 10);
            nganHang.ruttien("001", 10, ngayRutTien1);

            // Rút tiền từ tài khoản 002
            DateTime ngayRutTien2 = new DateTime(2005, 7, 15);
            nganHang.ruttien("002", 20, ngayRutTien2);

            // Rút tiền từ tài khoản 003
            DateTime ngayRutTien3 = new DateTime(2005, 7, 31);
            nganHang.ruttien("003", 30, ngayRutTien3);

            // Rút tiền từ tài khoản 004
            DateTime ngayRutTien4 = new DateTime(2005, 7, 31);
            nganHang.ruttien("004", 40, ngayRutTien4);

            nganHang.InBaoCao();
            Console.ReadLine();
        }

    }
 }
