using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace QuanlyKaraoke
{
    public partial class frm_hddv : Form 
    {
        public string sohd;
        public frm_hddv()
        {
            InitializeComponent();
        }

        private void lb_sohoadon_Click(object sender, EventArgs e)
        {

        }
        public new void LoadDichvu()
        {
            DataSet ds = new DataSet();
            string connetionString = "server=localhost;database=karaoke;uid=root;pwd=;";
            MySqlConnection conn = new MySqlConnection(connetionString);
            MySqlDataAdapter daKaraoke;

            #region Đổ dữ liệu bảng dịch vụ
            string sSelectHoaDonDichVu = "select * from dichvu";
            daKaraoke = new MySqlDataAdapter(sSelectHoaDonDichVu, conn);
            daKaraoke.Fill(ds, "tbl_ChonHoaDonDichVu");
            foreach (DataRow r in ds.Tables["tbl_ChonHoadonDichVu"].Rows)
            {

                dgv_hddv.Rows.Add(r[0], r[1], r[4]);
            }
            ds.Tables["tbl_ChonHoaDonDichVu"].Clear();
            #endregion
        }
        
        
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadDichvu();
            txt_hddvsohd.Text = sohd;
        }
        //public void KetNoi()
        //{
        //    try
        //    {
        //        string connetionString = "server=localhost;database=karaoke;uid=root;pwd=;";
        //        MySqlConnection conn = new MySqlConnection(connetionString);
        //        MySqlDataAdapter daKaraoke;
        //        string sThemDichVu = "insert into hoadon_dichvu(sohd,madv,soluong) value(@sohd,@madv,@soluong";
        //        MySqlCommand cmd = new MySqlCommand(sThemDichVu, conn);
        //        cmd.Parameters.AddWithValue("@maphong", );
               
        //        cmd.Parameters.AddWithValue("@giovao", giovao.ToString());
        //        cmd.Parameters.AddWithValue("@trangthai", 0);
        //        cmd.ExecuteNonQuery();
               

        //        MessageBox.Show("Thêm hóa đơn thành công!");
        //        cmd.Parameters.Clear();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
