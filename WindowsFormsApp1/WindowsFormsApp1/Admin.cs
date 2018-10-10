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
    public partial class Admin : Form
    {
        private string str;
        public Admin(string  s)
        { 
            InitializeComponent();
            this.str = s;
            dataGridView1.Visible = false;
            
          
           
            button4.Visible = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            showdatagrid("select Tno as 用户名, password as 密码, Tname as 姓名, sex as 性别, age as 年龄 from teacher, teainfo where flag = 1 and Tno = Tid");
            showdatagrid("select Sno as 用户名 ,password as 密码,Sname as 姓名,sex as 性别, age as 年龄,major as 专业 from student,stuinfo where flag=1 and Sno=Sid");
        }

        private void LoginSuccess_Load(object sender, EventArgs e)
        {
            this.label1.Text = "你好," + str+"管理员";

        }

        private void stu_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
           
            button4.Visible = true;
            showdatagrid("select Sno as 用户名 ,password as 密码,Sname as 姓名,sex as 性别, age as 年龄,major as 专业 from student,stuinfo where flag=1 and Sno=Sid");
        }

        private void tea_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            button4.Visible = true;
            showdatagrid("select Tno as 用户名, password as 密码, Tname as 姓名, sex as 性别, age as 年龄 from teacher, teainfo where flag = 1 and Tno = Tid");
        }

        private void 管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void showdatagrid(string sql) {


            String connsql = "server=.;database=information;user=sa;pwd=123";
            SqlConnection conn_select = new SqlConnection();
            conn_select.ConnectionString = connsql;
            conn_select.Open(); // 打开数据库连接
           
            SqlDataAdapter myda = new SqlDataAdapter(sql, conn_select); // 实例化适配器
            DataTable dt = new DataTable(); // 实例化数据表
            myda.Fill(dt); // 保存数据 
            dataGridView1.DataSource = dt; // 设置到DataGridView中
            conn_select.Close();    // 关闭数据库连接
        }

        private void 学生用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent add = new AddStudent();
            DialogResult dialogResult = add.ShowDialog();
        }

        private void 教师用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTeacher tea = new AddTeacher();
            DialogResult dialogResult = tea.ShowDialog();
        }

        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteUser delete = new DeleteUser();
            DialogResult dialogResult = delete.ShowDialog();

        }

        private void 恢复用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecoverUser rec = new RecoverUser();
            DialogResult dialogResult = rec.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
