using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data.SQLite;

namespace PsychologeGame
{
   public class DBConnect
    {
        private string[] id = new string[10];
        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {

            //server = "localhost";
            //database = "mindgamedb";
            //uid = "root";
            ////password = "Abcd1234";
            //password = "123456";
            //string connectionString;
            //connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            //connection = new MySqlConnection(connectionString);
            ////MessageBox.Show("初始化数据库成功！");
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"/test.db")==false)
            {
                SQLiteConnection conn = null;

                string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
                conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
                conn.Open();//打开数据库，若文件不存在会自动创建  

                //string sql = "CREATE TABLE IF NOT EXISTS student(id integer, name varchar(20), sex varchar(2));";//建表语句 
                string sql = "CREATE TABLE IF NOT EXISTS student(id varchar(20));";//建表语句 
                SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
                cmdCreateTable.ExecuteNonQuery();//如果表不存在，创建数据表  

                SQLiteCommand cmdInsert = new SQLiteCommand(conn);
                cmdInsert.CommandText = "INSERT INTO student VALUES( 'jack')";//插入几条数据  
                cmdInsert.ExecuteNonQuery();
                cmdInsert.CommandText = "INSERT INTO student VALUES('manager')";
                cmdInsert.ExecuteNonQuery();
                cmdInsert.CommandText = "INSERT INTO student VALUES('abc123')";
                cmdInsert.ExecuteNonQuery();

                conn.Close();
            }
        }

        public bool read(string name)
        {
            int i = 0;
            bool result=false;
            SQLiteConnection conn = null;

            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  

            string sql = "select * from student";
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);

            SQLiteDataReader reader = cmdQ.ExecuteReader();

            while (reader.Read())
            {
                //Console.WriteLine(reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2));
                //MessageBox.Show(reader.GetString(0));
                i++;
                id[i] = reader.GetString(0);

            }

            conn.Close();

            foreach (var n in id)
            {
                if (name == n)
                {
                    result = true;
                }
               
            }
            return result;

            //Console.ReadKey();
        }  
        //open connection to database
       

       
       

     

       
       
     

        
    
    }
}
