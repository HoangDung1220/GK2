using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_102190059_NgoNguyenHoangDung
{
    public class CSDL_OOP
    {
        private static CSDL_OOP _Instance ;

        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL_OOP();
                }
                return _Instance;
            }

            set
            {

            }

        }

        private CSDL_OOP()
        {

        }

        public List<DienThoai> GetAllDienThoai()
        {
            List<DienThoai> list = new List<DienThoai>();

            foreach (DataRow i in CSDL.Instance.DTDT.Rows)
            {

                list.Add(GetDienThoai(i));

            }
            return list;
        }

        public DienThoai GetDienThoai(DataRow i)
        {
            DienThoai s = new DienThoai();
            s.MaDT = Convert.ToInt32(i["MaDT"]);
            s.TenDT = i["TenDT"].ToString();
            s.MaHang = Convert.ToInt32(i["MaHang"]);
            s.Gia = Convert.ToDouble(i["Gia"].ToString());
            s.NSX = Convert.ToDateTime(i["NSX"].ToString());

            return s;
        }

        public List<HangDT> GetAllHangDT()
        {
            List<HangDT> list = new List<HangDT>();
            foreach (DataRow i in CSDL.Instance.DTHDT.Rows)
            {
                list.Add(GetHangDT(i));
            }
            return list;
        }

        public HangDT GetHangDT(DataRow i)
        {
            return new HangDT
            {
                MaHang = Convert.ToInt32(i["MaHang"].ToString()),
                TenHang = i["TenHang"].ToString()
            };
        }

        public List<DienThoai> GetListDienThoai(int MaHangDT, string Name)
        {
            if (Name == null) 
                Name = "";
            List<DienThoai> list = new List<DienThoai>();

            if (MaHangDT == 0)
            {
                foreach (DienThoai i in GetAllDienThoai())
                {
                    if (i.TenDT.Contains(Name) || i.TenDT.Contains(Name.ToLower()) || i.TenDT.Contains(Name.ToUpper()))

                    {
                        list.Add(new DienThoai
                        {
                            MaDT = i.MaDT,
                            TenDT = i.TenDT,
                            NSX = i.NSX,
                            MaHang = i.MaHang,
                            Gia = i.Gia
                        });
                    }
                }
            }
            foreach (DienThoai i in GetAllDienThoai())
            {
                if (i.MaHang==MaHangDT && (i.TenDT.Contains(Name) || i.TenDT.Contains(Name.ToLower()) || i.TenDT.Contains(Name.ToUpper())))

                {
                    list.Add(new DienThoai
                    {
                        MaDT = i.MaDT,
                        TenDT = i.TenDT,
                        NSX = i.NSX,
                        MaHang = i.MaHang,
                        Gia = i.Gia
                    });
                }
            }
            return list;

        }


        public DienThoai getDienThoai_ByMaDT(int MaDT)
        {
            DienThoai s = new DienThoai();
            foreach (DienThoai i in GetAllDienThoai())
            {
                if (i.MaDT == MaDT)
                {
                    s = i;
                }
            }
            return s;

        }

        public HangDT getHangDT_ByMa(int MaHang)
        {
            HangDT n = new HangDT();
            foreach (HangDT i in GetAllHangDT())
            {
                if (i.MaHang == MaHang) n = i;
            }
            return n;
        }

        public void ExecuteData(DienThoai i)
        {
            bool check = false;
            foreach (DienThoai r in GetAllDienThoai())
            {
                if (i.MaDT == r.MaDT)
                {
                    check = true;
                }
            }
            if (check == true)
            {
                CSDL.Instance.editDataRow(i);

            }
            else
            {
                CSDL.Instance.addDataRow(i);

            }
        }

        public void del(List<int> list)
        {
            CSDL.Instance.Del(list);
        }

        public void sorted(DienThoai[] list, string sortedBy)
        {
            if (sortedBy.Equals("MaDT"))
            {
                CSDL.Instance.sorted(list, CSDL.Instance.sortByMaDT);
            }
            if (sortedBy.Equals("TenDT"))
            {
                CSDL.Instance.sorted(list, CSDL.Instance.sortByTenDT);
            }
            if (sortedBy.Equals("HangDT"))
            {
                CSDL.Instance.sorted(list, CSDL.Instance.sortByMaHang);
            }

        }



    }
}
