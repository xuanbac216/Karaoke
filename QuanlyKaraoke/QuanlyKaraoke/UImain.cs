using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanlyKaraoke
{
    public partial class UImain : Form
    {
        public UImain()
        {
            InitializeComponent();

        }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void UImain_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void UImain_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void UImain_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //panel4.Visible = true;
            //panel4.Controls.Clear();
            //panel4.Controls.Add(new test1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //panel4.Visible = true;
            //panel4.Controls.Clear();
            //panel4.Controls.Add(new test2());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //panel4.Visible = false;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_hoadonhd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UImain_Load(object sender, EventArgs e)
        {

        }

        private void dgv_hoadonhd_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Karaoke_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dgv_hoadondichvu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
