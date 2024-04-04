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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace FinalProject
{
    public partial class frmLogin : Form
    {
        WorkClass clsWork = new WorkClass();
        UsersClass clsUser = new UsersClass();
        public static string User_Name;
        public static string id_Type;
        public static string User_Geral;
        public static string Data_User;

        frmPrincipal formp = new frmPrincipal();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Throw()
        {
            txtPass.Text = "";
            txtUser.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            clsWork.user = txtUser.Text;
            clsWork.pass = txtPass.Text;

            dt = clsWork.N_Login(clsWork);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bem Vindo!" + dt.Rows[0][0].ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                User_Name = dt.Rows[0][0].ToString();
                id_Type = dt.Rows[0][1].ToString();
                User_Geral = dt.Rows[0][2].ToString();
                Data_User = dt.Rows[0][3].ToString();
                this.Hide();
                formp.ShowDialog();
                Throw();
            }
            else
            {
                MessageBox.Show("Incorrect User or Password, try again! ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Throw();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

    }
}
