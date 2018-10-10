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
    public partial class DeleteUser : Form
    {
        bool flag;
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            SqlParameter a1 = new SqlParameter("@username", username);
            if (radioButton1.Checked == true) {
                flag = DBHelper.DBquery("update student set flag=0 where Sno=@username", a1);
            }
            else if (radioButton2.Checked==true) {
                flag = DBHelper.DBquery("update teacher set flag=0 where Tno=@username", a1);
            }
             
            if (flag)
            {

                MessageBox.Show("删除用户成功");
            }
            else {
                MessageBox.Show("删除用户失败");
            }
        }
    }
}
