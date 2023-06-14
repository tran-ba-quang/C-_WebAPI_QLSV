namespace WebQuanLySinhVien.API
{
    public class SinhVien
    {
        private string? _id;
        private string? _ten;
        private string? _gioitinh;
        private int? _tuoi;
        private double? _diemtoan;
        private double? _diemvan;
        private double? _diemanh;
        private double? _diemtrungbinh;
        private string? _hocluc;

        public string? Id { get => _id; set => _id = value; }
        public string? Ten { get => _ten; set => _ten = value; }
        public string? Gioitinh { get => _gioitinh; set => _gioitinh = value; }
        public int? Tuoi { get => _tuoi; set => _tuoi = value; }
        public double? Diemtoan { get => _diemtoan; set => _diemtoan = value; }
        public double? Diemvan { get => _diemvan; set => _diemvan = value; }
        public double? Diemanh { get => _diemanh; set => _diemanh = value; }
        public double? Diemtrungbinh { get => _diemtrungbinh; set => _diemtrungbinh = value; }
        public string? Hocluc { get => _hocluc; set => _hocluc = value; }
    }
}
