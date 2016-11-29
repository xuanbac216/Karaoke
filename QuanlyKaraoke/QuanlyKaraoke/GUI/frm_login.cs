using QuanlyKaraoke.BLL;
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
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void btn_login_ok_Click(object sender, EventArgs e)
        {
            var user = txt_username.Text;
            var pass = txt_pass.Text;
            if(XuLyUser.checkUser(user, pass))
            {
                
                frm_main frm = new frm_main();
                frm.Show();
               
            }
            else
            {
                MessageBox.Show("Error: Username or password is wrong!!! ");
            }
            
        }

        private void btn_login_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
