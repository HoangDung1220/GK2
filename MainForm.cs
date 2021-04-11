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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            createDBHDT();
            createCBB();
            create2();

            dataGridViewListDT.DataSource = CSDL.Instance.selectDTDT();
        }

     

            private void createCBB()
            {
                comboBoxHangDT.Items.Add(new CBBItem { Value = 0, Text = "All" });
                foreach (HangDT i in CSDL_OOP.Instance.GetAllHangDT())
                {
                    comboBoxHangDT.Items.Add(new CBBItem
                    {
                        Value = Convert.ToInt32(i.MaHang),
                        Text = i.TenHang.ToString()
                    });

                }
            }

        public void createDBHDT()
        {
            CSDL.Instance.DTHDT = new DataTable();
            CSDL.Instance.DTHDT.Columns.Add("MaHang", typeof(int));
            CSDL.Instance.DTHDT.Columns.Add("TenHang", typeof(string));

            DataRow dr = CSDL.Instance.DTHDT.NewRow();
            dr["MaHang"] = 1;
            dr["TenHang"] = "Oppo";


            CSDL.Instance.DTHDT.Rows.Add(dr);

            DataRow dr1 = CSDL.Instance.DTHDT.NewRow();
            dr1["MaHang"] = 2;
            dr1["TenHang"] = "SamSung";


            CSDL.Instance.DTHDT.Rows.Add(dr1);


            DataRow dr2 = CSDL.Instance.DTHDT.NewRow();
            dr2["MaHang"] = 3;
            dr2["TenHang"] = "Iphone";


            CSDL.Instance.DTHDT.Rows.Add(dr2);






        }

        private void create2()
        {
            List<string> list = new List<string>()
            {
                "MaDT","TenDT"
            };
            comboBoxSort.DataSource = list;
        }


        public void show(int MaHang, string name)
        {

            dataGridViewListDT.DataSource = CSDL_OOP.Instance.GetListDienThoai(MaHang, name);
        }

       

        private void buttonShow_Click_1(object sender, EventArgs e)
        {
            show(((CBBItem)comboBoxHangDT.SelectedItem).Value, null);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int maDT = -1;
            DetailForm f = new DetailForm(maDT);
            f.Show();
            f.d += new DetailForm.mydel(show);
            f.refresh();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
           
                if (dataGridViewListDT.SelectedRows.Count == 1)
                {
                    int ms = Convert.ToInt32(dataGridViewListDT.SelectedRows[0].Cells["MaDT"].Value.ToString());
                    DetailForm f = new DetailForm(ms);
                    f.Show();
                    f.d = new DetailForm.mydel(show);
                }
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            List<int> listSt = new List<int>();

            DataGridViewSelectedRowCollection list =  dataGridViewListDT.SelectedRows;
            foreach (DataGridViewRow i in list)
            {
                listSt.Add(Convert.ToInt32(i.Cells["MaDT"].Value.ToString()));
            }

            CSDL_OOP.Instance.del(listSt);
            show(0, null);

        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
           
                string text = comboBoxSort.Text;

                DienThoai[] list = CSDL_OOP.Instance.GetAllDienThoai().ToArray();
                CSDL_OOP.Instance.sorted(list, text);
                dataGridViewListDT.DataSource = list;

            }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBoxSearch.Text;
            show(0, name);
        }
    }
    }

