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
    public partial class AddTeacher : Form
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string name = textBox2.Text;
            string sex = comboBox1.Text;
            int age;
            int.TryParse(comboBox2.Text, out age);

            SqlParameter a1 = new SqlParameter("@username", username);
            SqlParameter a2 = new SqlParameter("@name", name);
            SqlParameter a3 = new SqlParameter("@sex", sex);
            SqlParameter a4 = new SqlParameter("@age", age);

            bool flag1 = DBHelper.DBquery("insert into teacher(Tno,password) values(@username,'123')", a1);
            bool flag2 = DBHelper.DBquery("insert into teainfo(Tid,Tname,sex,age) values(@username,@name,@sex,@age)", a1, a2, a3, a4);
            if (flag1 && flag2)
            {

                MessageBox.Show("添加教师成功");
            }
            else
            {
                MessageBox.Show("添加教师失败");
            }
        }
    }
}
