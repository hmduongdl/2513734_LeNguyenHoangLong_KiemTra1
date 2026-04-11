using System;
using System.IO;

class Program
{
    static void Main()
    {
        string p = "/media/hoangminhduong/DATA/2513734_LeNguyenHoangLong_KiemTra1/2513734_LeNguyenHoangLong_KiemTra1/Menu.cs";
        string s = File.ReadAllText(p);
        
        s = s.Replace("Console.WriteLine(\"Chuc nang chua hoan thanh.\");\n                    break;\n                case MenuCT.ThongKe:", @"Console.Write(""Nhap Nha Xuat Ban can xoa: "");
                    string nxb = Console.ReadLine();
                    // ql.XoaTatCaSachTheoNXB(nxb);
                    ql.XoaTatCaSachTheoNXB_Cach2(nxb);
                    Console.WriteLine(""Da xoa cac sach cua nxb: "" + nxb);
                    Console.WriteLine(""Danh sach Sach sau khi xoa la: "");
                    ql.XuatDS();
                    break;
                case MenuCT.ThongKe:");
                
        s = s.Replace("case MenuCT.ThongKe:\n                    Console.WriteLine(\"Chuc nang chua hoan thanh.\");", @"case MenuCT.ThongKe:
                    Console.WriteLine(""Thong ke so luong sach theo tung Nha Xuat Ban:"");
                    // ql.ThongKeSoLuongSachTheoNXB();
                    ql.ThongKeSoLuongSachTheoNXB_Cach2();");

        File.WriteAllText(p, s);
    }
}
