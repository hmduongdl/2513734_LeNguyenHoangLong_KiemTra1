using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2513734_LNHLong_KiemTra1
{
    class QuanLySach
    {
        List<Sach> dsSach;

        public QuanLySach()
        {
            dsSach = new List<Sach>();
        }

        public int Count
        {
            get { return dsSach.Count; }
        }

        public Sach this[int index]
        {
            get { return this.dsSach[index]; }
            set { this.dsSach[index] = value; }
        }
        public void Nhap1CuonSach()
        {
            string ten;
            string nxb;
            int soTrang;
            float giatien;
            Console.WriteLine("Nhap thong tin cuon sach");
            Console.Write("Ten: ");
            ten = Console.ReadLine();
            Console.Write("NXB: ");
            nxb = Console.ReadLine();
            Console.Write("So Trang: ");
            while (!float.TryParse(Console.ReadLine(), out giatien))
            {
                Console.Write("Nhap lai Gia tien: ");
            }
            while (!int.TryParse(Console.ReadLine(), out soTrang))
            {
                Console.Write("Nhap lai So Trang: ");
            }
            Console.Write("Gia tien: ");


            Them(new Sach(ten, nxb, giatien, soTrang));

        }
        public void Them(Sach sach)
        {
            if (sach == null) return;
            dsSach.Add(sach);
        }

        public void NhapCD()
        {
            Them(new Sach("Lap trình C# co ban", "NXB Cong Nghe", 199f, 320));
            Them(new Sach("Cau truc du lieu va giai thuat", "NXB Dai Hoc", 250f, 480));
            Them(new Sach("Lap trinh huong doi tuong", "NXB Cong Nghe", 179f, 260));
            Them(new Sach("Tam Ly Hoc ve Tien", "Morgan Housle", 210f, 400));
            Them(new Sach("Tham tu lung danh Conan", "NXB Kim Dong", 299f, 560));
        }

        void XuatTieuDe()
        {
            Console.WriteLine("{0,-31} {1,-27} {2,17} {3,10}",
                      "TEN SACH", "NHA XUAT BAN", "GIA TIEN", "SO TRANG");
        }
        public override string ToString()
        {
            string str = string.Format("{0,-31} {1,-27} {2,17} {3,10}\n", "TEN SACH", "NHA XUAT BAN", "GIA TIEN", "SO TRANG");
            foreach(var sach in dsSach)
            {
                str += sach.ToString() + "\n";
            }
            return str;
        }

        public void XuatDS()
        {
            if (dsSach.Count == 0)
            {
                Console.WriteLine("Danh sach rong.");
                return;
            }
            XuatTieuDe();
            for (int i = 0; i < dsSach.Count; i++)
            {
                Console.WriteLine("{0}", dsSach[i].ToString());
            }
        }


        public void DocFile(string duongdan)
        {
            this.dsSach.Clear();
            if (File.Exists(duongdan))
            {
                string[] lines = File.ReadAllLines(duongdan);
                foreach (string line in lines)
                {
                    Them((Sach)line.Trim());
                }
                Console.WriteLine("Doc file thanh cong!");
            }
            else
            {
                Console.WriteLine("File khong ton tai");
            }
        }
        public void TimSachCoGiaMax()
        {
            List<Sach> kq = new List<Sach>();
            float max = 0;

            for (int i = 0; i < this.dsSach.Count; i++)
            {
                if (this.dsSach[i].GiaTien > max)
                {
                    max = this.dsSach[i].GiaTien;
                }
            }
            for (int i = 0; i < this.dsSach.Count; i++)
            {
                if (this.dsSach[i].GiaTien == max)
                {
                    kq.Add(this.dsSach[i]);
                }
            }

            Console.WriteLine("Danh sach sach co gia tien Max = {0}", max);
            XuatTieuDe();
            for (int i = 0; i < kq.Count; i++)
            {
                Console.WriteLine(kq[i]);
            }
        }

        
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
            
            Console.WriteLine("{0,-27} {1,10}", "Nha Xuat Ban", "So Luong");
            for (int i = 0; i < nxbList.Count; i++)
            {
                Console.WriteLine("{0,-27} {1,10}", nxbList[i], countList[i]);
            }
        }

        public void ThongKeSoLuongSachTheoNXB_Cach2()
        {
            var thongKe = dsSach.GroupBy(s => s.NhaXuatBan)
                                .Select(g => new { NXB = g.Key, Count = g.Count() });
            
            Console.WriteLine("{0,-27} {1,10}", "Nha Xuat Ban", "So Luong");
            foreach (var item in thongKe)
            {
                Console.WriteLine("{0,-27} {1,10}", item.NXB, item.Count);
            }
        }

        public void TimSachCoGiaMax_Cach2()
        {
            if (dsSach.Count == 0) return;
            float maxGia = dsSach.Max(s => s.GiaTien);
            var result = dsSach.Where(s => s.GiaTien == maxGia);

            Console.WriteLine("Danh sach sach co gia tien Max = {0}", maxGia);
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

        public void SapTangTheoTen()
        {
            for (int i = 0; i < dsSach.Count - 1; i++)
            {
                for (int j = 0; j < dsSach.Count - 1 - i; j++)
                {

                    if (dsSach[j].Ten.ToLower().CompareTo(dsSach[j + 1].Ten.ToLower()) > 0)
                    {
                        Sach temp = dsSach[j];
                        dsSach[j] = dsSach[j + 1];
                        dsSach[j + 1] = temp;
                    }
                }
            }
        }
    }
}
