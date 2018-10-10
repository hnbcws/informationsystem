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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string name = textBox2.Text;
            string sex = comboBox2.Text;
            int age;
            int.TryParse(comboBox1.Text,out age);
            string major = comboBox3.Text;
            
            SqlParameter a1 = new SqlParameter("@username", username);
            SqlParameter a2 = new SqlParameter("@name", name);
            SqlParameter a3 = new SqlParameter("@sex", sex);
            SqlParameter a4 = new SqlParameter("@age", age);
            SqlParameter a5= new SqlParameter("@major", major);


            bool flag1 = DBHelper.DBquery("insert into student(Sno,password) values(@username,'123')", a1);
            bool flag2= DBHelper.DBquery("insert into stuinfo(Sid,Sname,sex,age,major) values(@username,@name,@sex,@age,@major)",a1,a2,a3,a4,a5);
            if (flag1&&flag2)
            {

                MessageBox.Show("添加学生成功");
            }
            else
            {
                MessageBox.Show("添加学生失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
