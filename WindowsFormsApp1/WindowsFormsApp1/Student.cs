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
    public partial class Student : Form
    {   private string str;
        public Student(string s)
        {
            InitializeComponent();
            this.str = s;
        }

        

        private void Student_Load(object sender, EventArgs e)
        {
            this.label2.Text = "欢迎你:"+str;
            String connsql = "server=.;database=information;user=sa;pwd=123";
            SqlConnection conn_select = new SqlConnection();
            conn_select.ConnectionString = connsql;
            conn_select.Open(); // 打开数据库连接
            String sql = "select Cno as 课程代码 ,cname as 课程名,croom as 上课地点,ctime as 上课时间, cdepart as 课程所属类  from course"; 
            SqlDataAdapter myda = new SqlDataAdapter(sql, conn_select); // 实例化适配器
            DataTable dt = new DataTable(); // 实例化数据表
            myda.Fill(dt); // 保存数据 
            DataGridViewCheckBoxColumn columncb = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(columncb);
            dataGridView1.DataSource = dt;// 设置到DataGridView中
           
            conn_select.Close();    // 关闭数据库连接
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePass f3 = new ChangePass();
            DialogResult dialogResult = f3.ShowDialog();
        }
    }
}
