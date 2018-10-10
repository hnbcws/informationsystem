using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Check
    {


        public static bool LoginYan1(string username, string password)
        {
        
            SqlParameter a1 = new SqlParameter("@name", username);
            SqlParameter a2 = new SqlParameter("@pwd", password);
            return DBHelper.DBreader("select * from student where Sno=@name and password=@pwd and flag=1", a1, a2);

        }
        public static bool LoginYan2(string username, string password)
        {
            SqlParameter a1 = new SqlParameter("@name", username);
            SqlParameter a2 = new SqlParameter("@pwd", password);
            return DBHelper.DBreader("select * from teacher where Tno=@name and password=@pwd and flag=1", a1, a2);

        }
        public static bool LoginYan3(string username, string password)
        {
         
            SqlParameter a1 = new SqlParameter("@name", username);
            SqlParameter a2 = new SqlParameter("@pwd", password);
            return DBHelper.DBreader("select * from admin where username=@name and password=@pwd", a1, a2);
        }

        public static bool RegisterYan1(string username, string password)
        {
            SqlParameter a1 = new SqlParameter("@name", username);
            SqlParameter a2 = new SqlParameter("@pwd", password);
            return DBHelper.DBquery("insert into student(Sno,password) values (@name, @pwd)", a1, a2); ;
        }

        public static bool RegisterYan2(string username, string password)
        {
            SqlParameter a1 = new SqlParameter("@name", username);
            SqlParameter a2 = new SqlParameter("@pwd", password);
            return DBHelper.DBquery("insert into teacher(Tname,Tpassword) values (@name, @pwd)", a1, a2); ;
        }

        public static  void ChangePass1(string username, string password, string newpass,string confirmpass)
        {
            SqlConnection con = new SqlConnection("server=.;database=information;user=sa;pwd=123");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            SqlParameter a1 = new SqlParameter("@name", username);
            SqlParameter a2 = new SqlParameter("@pwd", password);
            SqlParameter a3 = new SqlParameter("@newpwd", newpass);
            cmd.Parameters.Add(a1);
            cmd.Parameters.Add(a2);
            cmd.Parameters.Add(a3);
            cmd.CommandText = "select * from student where Sno=@name and password=@pwd";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                if (newpass == confirmpass) { 
                cmd.CommandText = "update student set password=@newpwd where Sno=@name";
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    con.Close();
                    MessageBox.Show("密码修改成功");
                }
                else
                {
                    MessageBox.Show("密码修改失败");
                }
                }
                else
                {
                    MessageBox.Show("两次密码输入不一致");
                }
            }
            else
            {

                MessageBox.Show("用户名或密码错误");
            }
        }
        public static void ChangePass2(string username, string password, string newpass, string confirmpass)
        {
            SqlConnection con = new SqlConnection("server=.;database=information;user=sa;pwd=123");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            SqlParameter a1 = new SqlParameter("@name", username);
            SqlParameter a2 = new SqlParameter("@pwd", password);
            SqlParameter a3 = new SqlParameter("@newpwd", newpass);
            cmd.Parameters.Add(a1);
            cmd.Parameters.Add(a2);
            cmd.Parameters.Add(a3);
            cmd.CommandText = "  select* from teacher where Tno = @name and password = @pwd";
             SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                dr.Close();
                if (newpass == confirmpass)
                {
                    cmd.CommandText = "update teacher set password=@newpwd where Tno=@name";
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        con.Close();
                        MessageBox.Show("密码修改成功");
                    }
                    else
                    {
                        MessageBox.Show("密码修改失败");
                    }
                }
                else
                {
                    MessageBox.Show("两次密码输入不一致");
                }
            }
            else
            {

                MessageBox.Show("用户名或密码错误");
            }
        }


    }
}
