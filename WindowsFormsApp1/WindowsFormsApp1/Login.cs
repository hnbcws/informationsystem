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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Register f2 = new Register();
        //    DialogResult dialogResult= f2.ShowDialog();
        //    if(dialogResult== DialogResult.OK)
        //    {
        //        //refresh main form
        //    }
        //    else
        //    {
        //        //to do nothing
        //    }
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string user = textBox1.Text;
        //    string pwd = textBox2.Text;
        //    if (Check.LoginYan(user, pwd))
        //    {
        //        MessageBox.Show("登录成功");
        //        LoginSuccess success = new LoginSuccess();
        //        success.ShowDialog();

        //    }
        //    else {
        //        MessageBox.Show("登录失败");
        //    }

        //}

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{

        //    ChangePass f3 = new ChangePass();
        //    DialogResult dialogResult = f3.ShowDialog();
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pwd = textBox2.Text;
            string name1, totalname1,name2,totalname2;
            
            SqlConnection con = new SqlConnection("server=.;database=information;user=sa;pwd=123");
            SqlCommand cmd = con.CreateCommand();


            if (radioButton1.Checked == true)
                {
                    if (Check.LoginYan1(user, pwd))
                    {
                        MessageBox.Show("登录成功");
                        this.Hide();
                       


                        cmd.CommandText= "select Sname from stuinfo where Sid='" + user + "'";
                        con.Open();
                        name1 =cmd.ExecuteScalar().ToString();
                        totalname1 = user+" "+name1+"同学";
                       
                        con.Close();
                        Student stu = new Student(totalname1);
                        stu.ShowDialog();



                    }
                    else
                    {
                        MessageBox.Show("登录失败");
                    }
                }

            if (radioButton2.Checked == true)
            {
                if (Check.LoginYan2(user, pwd))
                {
                    MessageBox.Show("登录成功");
                    this.Hide();


                    cmd.CommandText ="select Tname from teainfo where Tid='" + user + "'";
                    con.Open();
                    name2 = cmd.ExecuteScalar().ToString();
                    totalname2 = user + " " + name2 + "老师";
                    con.Close();
                    Teacher teach = new Teacher(totalname2);
                    teach.ShowDialog();



                }
                else
                {
                    MessageBox.Show("登录失败");
                }
            }


            if (radioButton3.Checked == true)
                {
                    if (Check.LoginYan3(user, pwd))
                    {
                        MessageBox.Show("登录成功");
                        this.Hide();
                        Admin success = new Admin(user);
                        success.ShowDialog();



                    }
                    else
                    {
                        MessageBox.Show("登录失败");
                    }
                }
            
           



        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Register f2 = new Register();
            DialogResult dialogResult = f2.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                //refresh main form
            }
            else
            {
                //to do nothing
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePass f3 = new ChangePass();
            DialogResult dialogResult = f3.ShowDialog();
        }
    }
}
