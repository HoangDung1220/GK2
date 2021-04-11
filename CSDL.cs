using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_102190059_NgoNguyenHoangDung
{
    public class CSDL
    {
        public delegate bool sort(object s1, object s2);
        public DataTable DTDT { get; set; }
        public DataTable DTHDT { get; set; }
        public static CSDL _Instance;

        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL();
                }

                return _Instance;

            }
            private set
            {

            }


        }

        public DataTable selectDTDT()
        {

            CSDL.Instance.DTDT = new DataTable();
            CSDL.Instance.DTDT.Columns.Add("MaDT", typeof(int));
            CSDL.Instance.DTDT.Columns.Add("TenDT", typeof(string));
            CSDL.Instance.DTDT.Columns.Add("MaHang", typeof(int));
            CSDL.Instance.DTDT.Columns.Add("NSX", typeof(DateTime));
            CSDL.Instance.DTDT.Columns.Add("Gia", typeof(double));
            DateTime date = new DateTime(2001, 2, 2);
            DataRow dr = CSDL.Instance.DTDT.NewRow();
            dr["MaDT"] = 1;
            dr["TenDT"] = "OppoA37";
            dr["MaHang"] = 1;
            dr["NSX"] = date;
            dr["Gia"] = 3200000;

            DTDT.Rows.Add(dr);

            DateTime date1 = new DateTime(1991, 1, 10);
            DataRow dr1 = CSDL.Instance.DTDT.NewRow();
            dr1["MaDT"] = 2;
            dr1["TenDT"] = "SamSungX";
            dr1["MaHang"] = 2;
            dr1["NSX"] = date1;
            dr1["Gia"] = 4000000;

            DTDT.Rows.Add(dr1);


            DateTime date2 = new DateTime(1980, 5, 3);
            DataRow dr2 = CSDL.Instance.DTDT.NewRow();
            dr2["MaDT"] = 3;
            dr2["TenDT"] = "Oppo11";
            dr2["MaHang"] = 1;
            dr2["NSX"] = date2;
            dr2["Gia"] = 7000000;

            DTDT.Rows.Add(dr2);


            return DTDT;


        }

        public void selectDTHDT()
        {

            CSDL.Instance.DTHDT = new DataTable();
            CSDL.Instance.DTHDT.Columns.Add("MaHang", typeof(int));
            CSDL.Instance.DTHDT.Columns.Add("TenHang", typeof(string));

            DataRow dr = CSDL.Instance.DTHDT.NewRow();
            dr["MaHang"] = 1;
            dr["TenHang"] = "Oppo";


            DTHDT.Rows.Add(dr);

            DataRow dr1 = CSDL.Instance.DTHDT.NewRow();
            dr1["MaHang"] = 2;
            dr1["TenHang"] = "SamSung";


            DTHDT.Rows.Add(dr1);


            DataRow dr2 = CSDL.Instance.DTHDT.NewRow();
            dr2["MaHang"] = 3;
            dr2["TenHang"] = "Iphone";


            DTHDT.Rows.Add(dr2);


            


        }

        public void editDataRow(DienThoai s)
        {

            foreach (DataRow i in DTDT.Rows)
            {
                if ((Convert.ToInt32(i["MaDT"])) == s.MaDT)
                {
                    i["TenDT"] = s.TenDT;
                    i["NSX"] = s.NSX;
                    i["MaHang"] = s.MaHang;
                    i["Gia"] = s.Gia;

                }

            }

        }
        public void addDataRow(DienThoai s)
        {
            DTDT.Rows.Add(new object[]
            {
                s.MaDT,s.TenDT,s.MaHang,s.NSX,s.Gia
            });

        }

        public void Del(List<int> list)
        {



            {
                foreach (int ir in list)
                {
                    for (int i = 0; i < DTDT.Rows.Count; i++)
                        if ((Convert.ToInt32(DTDT.Rows[i]["MaDT"].ToString())) == ir)
                        {
                            DTDT.Rows.RemoveAt(i);
                        }


                }

            }



        }

        public bool sortByMaDT(object s1, object s2)
        {
            if (((DienThoai)s1).MaDT>(((DienThoai)s2).MaDT))
                return true;
            return false;
        }

        public bool sortByTenDT(object s1, object s2)
        {
            if (((DienThoai)s1).TenDT.CompareTo(((DienThoai)s2).TenDT) > 0)
                return true;
            return false;
        }

        public bool sortByMaHang(object s1, object s2)
        {
            if (((DienThoai)s1).MaHang > ((DienThoai)s2).MaHang)
                return true;
            return false;
        }


        public void sorted(DienThoai[] list, sort cmp)
        {
            for (int i = 0; i < list.Length - 1; i++)
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (cmp(list[i], list[j]))
                    {
                        DienThoai t = list[i];
                        list[i] = list[j];
                        list[j] = t;

                    }
                }

        }

    }
}
