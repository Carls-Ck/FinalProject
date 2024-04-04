using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersCover;
using WorkCover;

namespace FinalProject
{
    public partial class frmPrincipal : Form
    {
        UsersClass objE = new UsersClass();
        WorkClass objN = new WorkClass();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = frmLogin.User_Name;
            if (frmLogin.id_Type == "T0001")
            {
                pictureBox1.Enabled = true;
                pictureBox2.Enabled = true;
                pictureBox3.Enabled = true;
                pictureBox4.Enabled = true;
                pictureBox5.Enabled = true;
                pictureBox6.Enabled = true;
                pictureBox7.Enabled = true;
                pictureBox8.Enabled = true;
          
            }
            else if (frmLogin.id_Type == "T0002")
            {
                pictureBox6.Enabled = false;
                label10.Enabled = false;
            }
            else if (frmLogin.id_Type == "T0003")
            {
                pictureBox6.Enabled = false;
                pictureBox1.Enabled = false;
                pictureBox7.Enabled = false;
                pictureBox8.Enabled = false;
                label9.Enabled = false;
                label8.Enabled = false;
                label7.Enabled = false;
                label10.Enabled = false;
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("H:m");
            lblDate.Text = DateTime.Now.ToString("D:M:yyy");
        }
    }
}
