using System;
using System.IO;

class Program
{
    static void Main()
    {
        string p = "/media/hoangminhduong/DATA/2513734_LeNguyenHoangLong_KiemTra1/2513734_LeNguyenHoangLong_KiemTra1/QuanLySach.cs";
        string s = File.ReadAllText(p);
        
        // 1. ToString in QuanLySach
        if(!s.Contains("public override string ToString()"))
        {
            s = s.Replace("public void XuatDS()", @"public override string ToString()
        {
            string str = string.Format(""{0,-31} {1,-27} {2,17} {3,10}\n"", ""TEN SACH"", ""NHA XUAT BAN"", ""GIA TIEN"", ""SO TRANG"");
            foreach(var sach in dsSach)
            {
                str += sach.ToString() + ""\n"";
            }
            return str;
        }

        public void XuatDS()");

        }

        // 2 & 3. Thong Ke, Xoa, Max, Sort Cach 2
        
        string newMethods = @"
        public void XoaTatCaSachTheoNXB(string nxb)
        {
            for (int i = dsSach.Count - 1; i >= 0; i--)
            {
                if (dsSach[i].NhaXuatBan.Equals(nxb, StringComparison.OrdinalIgnoreCase))
                {
                    dsSach.RemoveAt(i);
                }
            }
        }

        public void XoaTatCaSachTheoNXB_Cach2(string nxb)
        {
            dsSach.RemoveAll(s => s.NhaXuatBan.Equals(nxb, StringComparison.OrdinalIgnoreCase));
        }

        public void ThongKeSoLuongSachTheoNXB()
        {
            List<string> nxbList = new List<string>();
            List<int> countList = new List<int>();

            foreach (var sach in dsSach)
            {
                int index = nxbList.FindIndex(x => x.Equals(sach.NhaXuatBan, StringComparison.OrdinalIgnoreCase));
                if (index == -1)
                {
                    nxbList.Add(sach.NhaXuatBan);
                    countList.Add(1);
                }
                else
                {
                    countList[index]++;
                }
            }
            
            Console.WriteLine(""{0,-27} {1,10}"", ""Nha Xuat Ban"", ""So Luong"");
            for (int i = 0; i < nxbList.Count; i++)
            {
                Console.WriteLine(""{0,-27} {1,10}"", nxbList[i], countList[i]);
            }
        }

        public void ThongKeSoLuongSachTheoNXB_Cach2()
        {
            var thongKe = dsSach.GroupBy(s => s.NhaXuatBan)
                                .Select(g => new { NXB = g.Key, Count = g.Count() });
            
            Console.WriteLine(""{0,-27} {1,10}"", ""Nha Xuat Ban"", ""So Luong"");
            foreach (var item in thongKe)
            {
                Console.WriteLine(""{0,-27} {1,10}"", item.NXB, item.Count);
            }
        }

        public void TimSachCoGiaMax_Cach2()
        {
            if (dsSach.Count == 0) return;
            float maxGia = dsSach.Max(s => s.GiaTien);
            var result = dsSach.Where(s => s.GiaTien == maxGia);

            Console.WriteLine(""Danh sach sach co gia tien Max = {0}"", maxGia);
            XuatTieuDe();
            foreach (var s in result)
            {
                Console.WriteLine(s.ToString());
            }
        }

        public void SapTangTheoTen_Cach2()
        {
            dsSach = dsSach.OrderBy(s => s.Ten).ToList();
        }
";
        s = s.Replace("public void SapTangTheoTen()", newMethods + "\n        public void SapTangTheoTen()");
        
        if(!s.Contains("using System.Linq;"))
        {
            s = s.Replace("using System.IO;", "using System.IO;\nusing System.Linq;");
        }
        
        File.WriteAllText(p, s);
    }
}
