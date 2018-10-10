using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Teacher : Form
    {
        private string str;
        public Teacher(string s)
        {
            InitializeComponent();
            this.str = s;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void teacher_Load(object sender, EventArgs e)
        {
            this.label1.Text = "欢迎你:"+str;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePass ch = new ChangePass();
            ch.ShowDialog();
        }
    }
}
