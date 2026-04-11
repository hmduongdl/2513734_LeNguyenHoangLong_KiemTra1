# 📚 Hệ Thống Quản Lý Sách - 2513734_LeNguyenHoangLong_KiemTra1

Dự án C# console application quản lý danh sách sách với các chức năng cơ bản và nâng cao. Đặc biệt: **Mỗi chức năng đều được triển khai theo 2 cách khác nhau** để so sánh hiệu suất và cách tiếp cận lập trình.

## 🎯 Tính Năng Chính

- ✅ Nhập/xuất thông tin sách
- ✅ Đọc dữ liệu từ file txt
- ✅ Tìm sách có giá lớn nhất (2 cách)
- ✅ Sắp xếp danh sách theo tên (2 cách)
- ✅ Xóa sách theo nhà xuất bản (2 cách)
- ✅ Thống kê số lượng sách theo NXB (2 cách)
- ✅ Định dạng giá tiền với 3 chữ số thập phân + "VND"

## 🔧 Cấu Trúc Dự Án

```
📁 2513734_LeNguyenHoangLong_KiemTra1/
├── Sach.cs           # Class định nghĩa đối tượng Sách
├── QuanLySach.cs     # Class chính chứa logic quản lý
├── Menu.cs           # Class điều khiển giao diện menu
├── Program.cs       # Entry point của ứng dụng
├── dsSach.txt       # File dữ liệu mẫu
└── KiemTra.sln      # Solution file
```

## 📊 So Sánh Thuật Toán: Cách 1 vs Cách 2

### 1. 🔍 **Tìm Sách Có Giá Lớn Nhất**

#### **Cách 1: Vòng lặp truyền thống**
```csharp
public void TimSachCoGiaMax()
{
    List<Sach> kq = new List<Sach>();
    float max = 0;
    
    // Tìm giá trị max
    for (int i = 0; i < this.dsSach.Count; i++)
    {
        if (this.dsSach[i].GiaTien > max)
        {
            max = this.dsSach[i].GiaTien;
        }
    }
    
    // Thu thập tất cả sách có giá = max
    for (int i = 0; i < this.dsSach.Count; i++)
    {
        if (this.dsSach[i].GiaTien == max)
        {
            kq.Add(this.dsSach[i]);
        }
    }
    
    // Xuất kết quả...
}
```

#### **Cách 2: LINQ**
```csharp
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
```

**📈 Phân tích:**
- **Cách 1:** Tường minh, dễ hiểu, 2 vòng lặp riêng biệt → O(2n) = O(n)
- **Cách 2:** Ngắn gọn, dễ đọc, sử dụng built-in methods → O(n) nhưng tối ưu hơn

---

### 2. 📝 **Sắp Xếp Danh Sách Tăng Theo Tên**

#### **Cách 1: Bubble Sort**
```csharp
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
```

#### **Cách 2: LINQ OrderBy**
```csharp
public void SapTangTheoTen_Cach2()
{
    dsSach = dsSach.OrderBy(s => s.Ten).ToList();
}
```

**📈 Phân tích:**
- **Cách 1:** Bubble Sort thuần túy → O(n²)
- **Cách 2:** Sử dụng TimSort (hybrid) → O(n log n) - hiệu suất cao hơn với dữ liệu lớn

---

### 3. 🗑️ **Xóa Tất Cả Sách Theo Nhà Xuất Bản**

#### **Cách 1: Duyệt ngược**
```csharp
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
```

#### **Cách 2: RemoveAll + Lambda**
```csharp
public void XoaTatCaSachTheoNXB_Cach2(string nxb)
{
    dsSach.RemoveAll(s => s.NhaXuatBan.Equals(nxb, StringComparison.OrdinalIgnoreCase));
}
```

**📈 Phân tích:**
- **Cách 1:** Duyệt ngược để tránh lỗi index khi xóa → O(n)
- **Cách 2:** Method có sẵn, tự động xử lý index → O(n) nhưng code gọn hơn

---

### 4. 📈 **Thống Kê Số Lượng Sách Theo NXB**

#### **Cách 1: Manual counting**
```csharp
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
```

#### **Cách 2: LINQ GroupBy**
```csharp
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
```

**📈 Phân tích:**
- **Cách 1:** Quản lý 2 danh sách song song → O(n×m) với m là số NXB khác nhau
- **Cách 2:** GroupBy tự động tạo hash table → O(n) hiệu suất tốt hơn

## 🎮 Cách Sử Dụng Menu

### Menu Structure
```
0 - Thoat
1 - Nhap1Sach
2 - NhapCD
3 - DocFile
4 - XuatDS
5 - TimSachCoGiaMax_Cach1      ← Vòng lặp truyền thống
6 - TimSachCoGiaMax_Cach2      ← LINQ
7 - SapTangTheoTen_Cach1       ← Bubble Sort
8 - SapTangTheoTen_Cach2       ← OrderBy
9 - XoaTatCaSachTheoNSB_Cach1  ← Duyệt ngược
10 - XoaTatCaSachTheoNSB_Cach2 ← RemoveAll
11 - ThongKeSoLuongSachTheoNXB_Cach1 ← Manual counting
12 - ThongKeSoLuongSachTheoNXB_Cach2 ← GroupBy
```

### Ví dụ Menu Implementation
```csharp
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
```

## 💰 Định Dạng Giá Tiền

### ToString() Enhancement
```csharp
// Trong class Sach
public override string ToString()
{
    return string.Format("{0,-31} {1,-27} {2,13:0.000} VND {3,10}", 
                         ten, nhaxuatban, giatien, soTrang);
}
```

**Kết quả:**
- `179f` → `179.000 VND`
- `250.5f` → `250.500 VND`

## 🚀 Cách Chạy Dự Án

```bash
# Clone repository
git clone https://github.com/hmduongdl/2513734_LeNguyenHoangLong_KiemTra1.git

# Di chuyển vào thư mục dự án
cd 2513734_LeNguyenHoangLong_KiemTra1

# Build và chạy
dotnet build
dotnet run

# Hoặc chạy trực tiếp
cd 2513734_LeNguyenHoangLong_KiemTra1
dotnet run
```

## 📁 File dsSach.txt Format

```
Lap trình C# co ban,NXB Cong Nghe,199,320
Cau truc du lieu va giai thuat,NXB Dai Hoc,250,480
Lap trinh huong doi tuong,NXB Cong Nghe,179,260
Tam Ly Hoc ve Tien,Morgan Housle,210,400
Tham tu lung danh Conan,NXB Kim Dong,299,560
```

## 🎯 Kết Luận Về Hiệu Suất

| Chức Năng | Cách 1 (Traditional) | Cách 2 (LINQ) | Khuyến Nghị |
|-----------|---------------------|----------------|------------|
| **Tìm Max** | O(2n), 2 vòng lặp | O(n), tối ưu | Cách 2 |
| **Sắp Xếp** | O(n²), Bubble Sort | O(n log n), TimSort | Cách 2 |
| **Xóa** | O(n), manual | O(n), built-in | Cách 2 |
| **Thống Kê** | O(n×m), 2 lists | O(n), HashMap | Cách 2 |

**Tuy nhiên**, Cách 1 rất hữu ích để:
- 🎓 Hiểu sâu thuật toán
- 🔧 Tùy chỉnh logic phức tạp
- 🐛 Debug dễ dàng hơn

---

**👨‍💻 Tác giả:** 2513734_LeNguyenHoangLong  
**🔗 Repository:** https://github.com/hmduongdl/2513734_LeNguyenHoangLong_KiemTra1.git