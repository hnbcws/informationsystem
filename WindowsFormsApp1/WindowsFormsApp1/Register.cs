using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
         
            string user = textBox1.Text;
            string pwd = textBox2.Text;
            string confirmpass = textBox3.Text;


            if (pwd == confirmpass)
            {
                if (radioButton1.Checked == true)
                {
                    if (Check.RegisterYan1(user, pwd))
                    {
                        MessageBox.Show("注册成功");
                    }
                    else
                    {
                        MessageBox.Show("注册失败");
                    }
                }
                if (radioButton2.Checked == true) {
                    if (Check.RegisterYan2(user, pwd))
                    {
                        MessageBox.Show("注册成功");
                    }
                    else
                    {
                        MessageBox.Show("注册失败");
                    }
                }
            }
            else {
                MessageBox.Show("两次密码输入不一致");
            }
            this.DialogResult = DialogResult.OK;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
