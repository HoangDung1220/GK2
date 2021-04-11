using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_102190059_NgoNguyenHoangDung
{
    public partial class DetailForm : Form
    {
        public delegate void mydel(int Ma, string name);
        public mydel d { get; set; }
        public int MaDT { get; set; }
        public DetailForm(int m)
        {
            InitializeComponent();
            MaDT = m;

            createCBB();
            setGui();
           
        }

       
        private void createCBB()
        {

            foreach (HangDT i in CSDL_OOP.Instance.GetAllHangDT())
            {
                comboBoxHangDT.Items.Add(new CBBItem
                {
                    Value = Convert.ToInt32(i.MaHang),
                    Text = i.TenHang
                }) ;

            }
        }

        public void refresh()
        {
            textBoxMaDT.Text = "";
            textBoxTenDT.Text = "";
            DateTime date = DateTime.Now;
            dateTimePickerNSX.Value = date.Date;
            textBoxGia.Text = "";

        }

        public void setGui()
        {
            DateTime date = new DateTime(2000, 1, 1);
            if (CSDL_OOP.Instance.getDienThoai_ByMaDT(MaDT) != null)
            {
                DienThoai s = CSDL_OOP.Instance.getDienThoai_ByMaDT(MaDT);
                textBoxMaDT.Text = s.MaDT.ToString();
                textBoxGia.Text = s.Gia.ToString();
                textBoxTenDT.Text = s.TenDT;
                comboBoxHangDT.Text = CSDL_OOP.Instance.getHangDT_ByMa(s.MaHang).TenHang;


            }


        }
        private DienThoai getData_ByGui()
        {
            DienThoai s = new DienThoai();
            s.MaDT = Convert.ToInt32(textBoxMaDT.Text);
            s.TenDT = textBoxTenDT.Text;
            DateTime si = dateTimePickerNSX.Value;
            s.NSX = si.Date;
            s.MaHang = ((CBBItem)comboBoxHangDT.SelectedItem).Value;
            s.Gia = Convert.ToDouble(textBoxGia.Text);

            return s;
        }
       

        private void button1_Click(object sender, EventArgs e)
        {

            CSDL_OOP.Instance.ExecuteData(getData_ByGui());
            
                d(0, null);
            
            
            refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

