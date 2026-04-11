using System.ComponentModel.Design;

namespace _2513734_LNHLong_KiemTra1
{
    class Menu
    {
        enum MenuCT
        {
            Thoat,
            Nhap1Sach,
            NhapCD,
            DocFile,
            XuatDS,
            TimSachCoGiaMax_Cach1,
            TimSachCoGiaMax_Cach2,
            SapTangTheoTen_Cach1,
            SapTangTheoTen_Cach2,
            XoaTatCaSachTheoNSB_Cach1,
            XoaTatCaSachTheoNSB_Cach2,
            ThongKeSoLuongSachTheoNXB_Cach1,
            ThongKeSoLuongSachTheoNXB_Cach2,
        }
        static void XuatMenu()
        {
            for (int i = 0; i <= (int)MenuCT.ThongKeSoLuongSachTheoNXB_Cach2; i++)
            {
                Console.WriteLine("Nhap {0} de thuc hien chuc nang {1}", i, (MenuCT)i);
            }
        }
        static MenuCT ChonMenu()
        {
            int chon;
            do
            {
                Console.WriteLine("Nhap {0} ... {1}: ", (int)MenuCT.Thoat, (int)MenuCT.ThongKeSoLuongSachTheoNXB_Cach2);
                int.TryParse(Console.ReadLine(), out chon);
                if ((int)MenuCT.Thoat <= chon && chon <= (int)MenuCT.ThongKeSoLuongSachTheoNXB_Cach2)
                    break;
            } while (true);
            return (MenuCT)chon;
        }
        static void XuLyMenu(MenuCT chon, QuanLySach ql)
        {
            string tenfile = "dsSach.txt";
            switch (chon)
            {
                case MenuCT.Thoat:
                    break;
                case MenuCT.Nhap1Sach:
                    ql.Nhap1CuonSach();
                    Console.WriteLine("Danh sach Sach hien tai la: ");
                    ql.XuatDS();
                    break;
                case MenuCT.NhapCD:
                    ql.NhapCD();
                    Console.WriteLine("Da nhap co dinh 5 quyen sach!");
                    Console.WriteLine("\nDanh sach Sach hien tai la: ");
                    ql.XuatDS();
                    break;
                case MenuCT.XuatDS:
                    Console.WriteLine("Danh sach Sach hien tai la: ");
                    ql.XuatDS();
                    break;
                case MenuCT.DocFile:
                    ql.DocFile(tenfile);
                    Console.WriteLine("\nDanh sach Sach hien tai la: ");
                    ql.XuatDS();
                    break;

                case MenuCT.TimSachCoGiaMax_Cach1:
                    Console.WriteLine("Danh sach Sach hien tai la (Cach 1): ");
                    ql.XuatDS();
                    ql.TimSachCoGiaMax();
                    break;
                case MenuCT.TimSachCoGiaMax_Cach2:
                    Console.WriteLine("Danh sach Sach hien tai la (Cach 2): ");
                    ql.XuatDS();
                    ql.TimSachCoGiaMax_Cach2();
                    break;
                case MenuCT.SapTangTheoTen_Cach1:
                    Console.WriteLine("\nDanh sach Sach truoc khi sap xep la: ");
                    ql.XuatDS();
                    ql.SapTangTheoTen();
                    Console.WriteLine("\nDa sap xep danh sach tang theo ten! (Cach 1)");
                    Console.WriteLine("\nDanh sach Sach sau khi sap xep la: ");
                    ql.XuatDS();
                    break;
                case MenuCT.SapTangTheoTen_Cach2:
                    Console.WriteLine("\nDanh sach Sach truoc khi sap xep la: ");
                    ql.XuatDS();
                    ql.SapTangTheoTen_Cach2();
                    Console.WriteLine("\nDa sap xep danh sach tang theo ten! (Cach 2)");
                    Console.WriteLine("\nDanh sach Sach sau khi sap xep la: ");
                    ql.XuatDS();
                    break;
                case MenuCT.XoaTatCaSachTheoNSB_Cach1:
                    Console.Write("Nhap Nha Xuat Ban can xoa (Cach 1): ");
                    string nxb1 = Console.ReadLine();
                    ql.XoaTatCaSachTheoNXB(nxb1);
                    Console.WriteLine("Da xoa cac sach cua nxb: " + nxb1);
                    Console.WriteLine("Danh sach Sach sau khi xoa la: ");
                    ql.XuatDS();
                    break;
                case MenuCT.XoaTatCaSachTheoNSB_Cach2:
                    Console.Write("Nhap Nha Xuat Ban can xoa (Cach 2): ");
                    string nxb2 = Console.ReadLine();
                    ql.XoaTatCaSachTheoNXB_Cach2(nxb2);
                    Console.WriteLine("Da xoa cac sach cua nxb: " + nxb2);
                    Console.WriteLine("Danh sach Sach sau khi xoa la: ");
                    ql.XuatDS();
                    break;
                case MenuCT.ThongKeSoLuongSachTheoNXB_Cach1:
                    Console.WriteLine("Thong ke so luong sach theo tung Nha Xuat Ban (Cach 1):");
                    ql.ThongKeSoLuongSachTheoNXB();
                    break;
                case MenuCT.ThongKeSoLuongSachTheoNXB_Cach2:
                    Console.WriteLine("Thong ke so luong sach theo tung Nha Xuat Ban (Cach 2):");
                    ql.ThongKeSoLuongSachTheoNXB_Cach2();
                    break;
                default:
                    break;
            }
        }
        public static void ChayChuongTrinh()
        {
            QuanLySach ql = new QuanLySach();
            MenuCT chon = MenuCT.Thoat;
            do
            {
                Console.Clear();
                XuatMenu();
                chon = ChonMenu();
                if (chon == MenuCT.Thoat)
                    break;
                XuLyMenu(chon, ql);
                Console.ReadKey();
            } while (true);
        }
    }
}
