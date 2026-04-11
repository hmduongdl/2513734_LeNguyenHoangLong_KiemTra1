namespace _2513734_LNHLong_KiemTra1
{
    class Sach
    {
        private float giatien;
        private string nhaxuatban;
        private int soTrang;
        private string ten;

        // Properties
        public float GiaTien
        {
            get { return giatien; }
        }

        public string NhaXuatBan
        {
            get { return nhaxuatban; }
            set { nhaxuatban = value; }
        }

        public int SoTrang
        {
            get { return soTrang; }
            set { soTrang = value; }
        }

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }


        public Sach()
        {
            giatien = 0;
            nhaxuatban = "";
            soTrang = 0;
            ten = "";
        }

        public Sach(string t, string nxb, float gt, int st)
        {
            ten = t;
            nhaxuatban = nxb;
            giatien = gt;
            soTrang = st;
        }


        public static implicit operator Sach(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return new Sach();
            var parts = str.Split(',');
            if (parts.Length < 4) return new Sach();

            string ten = parts[0].Trim();
            string nxb = parts[1].Trim();
            float.TryParse(parts[2].Trim(), out float gia);
            int.TryParse(parts[3].Trim(), out int soTrang);

            return new Sach(ten, nxb, gia, soTrang);
        }

        public override string ToString()
        {
            return string.Format("{0,-31} {1,-27} {2,13:0.000} VND {3,10}", ten, nhaxuatban, giatien, soTrang);
        }
    }
}
