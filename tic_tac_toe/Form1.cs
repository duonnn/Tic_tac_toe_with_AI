using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        char who = 'o';
        short move = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rl = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(rl == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Enabled = false;
            btn.BackColor = Color.Lavender;
            if(who == 'o')
            {
                btn.Text = "O";
                if ((btn_1.Text == btn_2.Text && btn_2.Text == btn_3.Text && btn_2.Text != "") ||
                   (btn_4.Text == btn_5.Text && btn_5.Text == btn_6.Text && btn_5.Text != "") ||
                   (btn_7.Text == btn_8.Text && btn_8.Text == btn_9.Text && btn_8.Text != "") ||
                   (btn_1.Text == btn_4.Text && btn_4.Text == btn_7.Text && btn_4.Text != "") ||
                   (btn_2.Text == btn_5.Text && btn_5.Text == btn_8.Text && btn_5.Text != "") ||
                   (btn_3.Text == btn_6.Text && btn_6.Text == btn_9.Text && btn_6.Text != "") ||
                   (btn_1.Text == btn_5.Text && btn_5.Text == btn_9.Text && btn_5.Text != "") ||
                   (btn_3.Text == btn_5.Text && btn_5.Text == btn_7.Text && btn_5.Text != "")
                 )
                {
                    MessageBox.Show("The winner is " + who.ToString().ToUpper() + "!");
                    tableLayoutPanel1.Enabled = false;
                }
                else if(move == 8)
                {
                    MessageBox.Show("Draw!");
                }
                who = 'x';
            }
            else if (who == 'x')
            {
                btn.Text = "X";
                if ((btn_1.Text == btn_2.Text && btn_2.Text == btn_3.Text && btn_2.Text != "") ||
                   (btn_4.Text == btn_5.Text && btn_5.Text == btn_6.Text && btn_5.Text != "") ||
                   (btn_7.Text == btn_8.Text && btn_8.Text == btn_9.Text && btn_8.Text != "") ||
                   (btn_1.Text == btn_4.Text && btn_4.Text == btn_7.Text && btn_4.Text != "") ||
                   (btn_2.Text == btn_5.Text && btn_5.Text == btn_8.Text && btn_5.Text != "") ||
                   (btn_3.Text == btn_6.Text && btn_6.Text == btn_9.Text && btn_6.Text != "") ||
                   (btn_1.Text == btn_5.Text && btn_5.Text == btn_9.Text && btn_5.Text != "") ||
                   (btn_3.Text == btn_5.Text && btn_5.Text == btn_7.Text && btn_5.Text != "")
                 )
                {
                    MessageBox.Show("The winner is " + who.ToString().ToUpper() + "!");
                    tableLayoutPanel1.Enabled = false;
                }
                else if (move == 8)
                {
                    MessageBox.Show("Draw!");
                }
                who = 'o';
            }
            move++;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            who = 'o';
            move = 0;
            btn_1.Enabled = true; btn_1.Text = ""; btn_1.BackColor = Color.White;
            btn_2.Enabled = true; btn_2.Text = ""; btn_2.BackColor = Color.White;
            btn_3.Enabled = true; btn_3.Text = ""; btn_3.BackColor = Color.White;
            btn_4.Enabled = true; btn_4.Text = ""; btn_4.BackColor = Color.White;
            btn_5.Enabled = true; btn_5.Text = ""; btn_5.BackColor = Color.White;
            btn_6.Enabled = true; btn_6.Text = ""; btn_6.BackColor = Color.White;
            btn_7.Enabled = true; btn_7.Text = ""; btn_7.BackColor = Color.White;
            btn_8.Enabled = true; btn_8.Text = ""; btn_8.BackColor = Color.White;
            btn_9.Enabled = true; btn_9.Text = ""; btn_9.BackColor = Color.White;
            tableLayoutPanel1.Enabled = true;
            //tạo mới thì xóa luôn dữ liệu đã lưu trước đó
            cmd =sqlConn.CreateCommand();
            cmd.CommandText = "delete from nut";
            cmd.ExecuteNonQuery();
            LoadData();
        }


        //Khai báo chuỗi kết nối
        string strConnect = @"Data Source=DUONNN\SQLEXPRESS;Initial Catalog=Tic_tac_toe;User ID=sa;Password=123";
        //Khai báo đối tượng kết nối
        SqlConnection sqlConn = null;
        SqlCommand cmd;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataTable dt = new DataTable();

        private void LoadData()
        {
            cmd = sqlConn.CreateCommand();
            cmd.CommandText = "select * from nut";
            adt.SelectCommand = cmd;
            dt.Clear();
            adt.Fill(dt);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmd = sqlConn.CreateCommand();

            //nut 1
            if(btn_1.Text == "X")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_1', 1)";
            }
            else if(btn_1.Text == "O")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_1', 2)";
            }
            else
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_1', 3)";
            }
            cmd.ExecuteNonQuery();

            //nut 2
            if (btn_2.Text == "X")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_2', 1)";
            }
            else if (btn_2.Text == "O")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_2', 2)";
            }
            else
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_2', 3)";
            }
            cmd.ExecuteNonQuery();

            //nut 3
            if (btn_3.Text == "X")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_3', 1)";
            }
            else if (btn_3.Text == "O")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_3', 2)";
            }
            else
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_3', 3)";
            }
            cmd.ExecuteNonQuery();

            //nut 4
            if (btn_4.Text == "X")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_4', 1)";
            }
            else if (btn_4.Text == "O")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_4', 2)";
            }
            else
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_4', 3)";
            }
            cmd.ExecuteNonQuery();


            //nut 5
            if (btn_5.Text == "X")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_5', 1)";
            }
            else if (btn_5.Text == "O")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_5', 2)";
            }
            else
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_5', 3)";
            }
            cmd.ExecuteNonQuery();

            //nut 6
            if (btn_6.Text == "X")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_6', 1)";
            }
            else if (btn_6.Text == "O")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_6', 2)";
            }
            else
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_6', 3)";
            }
            cmd.ExecuteNonQuery();


            //nut 7
            if (btn_7.Text == "X")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_7', 1)";
            }
            else if (btn_7.Text == "O")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_7', 2)";
            }
            else
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_7', 3)";
            }
            cmd.ExecuteNonQuery();

            //nut 8
            if (btn_8.Text == "X")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_8', 1)";
            }
            else if (btn_8.Text == "O")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_8', 2)";
            }
            else
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_8', 3)";
            }
            cmd.ExecuteNonQuery();

            //nut 9
            if (btn_9.Text == "X")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_9', 1)";
            }
            else if (btn_9.Text == "O")
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_9', 2)";
            }
            else
            {
                cmd.CommandText = "insert into nut(manut, matrangthai) values ('btn_9', 3)";
            }
            cmd.ExecuteNonQuery();

            LoadData();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConn = new SqlConnection(strConnect);
            sqlConn.Open();
            LoadData();
        }

        private void continueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string gtri_dang_giu;
            tableLayoutPanel1.Enabled = true;
            //nut 1
            cmd.CommandText = "select tentrangthai from trangthai inner join nut on trangthai.matrangthai = nut.matrangthai where manut = 'btn_1' ";
            gtri_dang_giu = (string)cmd.ExecuteScalar();
            btn_1.Text = gtri_dang_giu;
            btn_1.Enabled = false;
            if(gtri_dang_giu == "")
            {
                btn_1.BackColor = Color.White;
                btn_1.Enabled = true;
            }
            else
                btn_1.BackColor = Color.Lavender;

            //nut 2
            cmd.CommandText = "select tentrangthai from trangthai inner join nut on trangthai.matrangthai = nut.matrangthai where manut = 'btn_2' ";
            gtri_dang_giu = (string)cmd.ExecuteScalar();
            btn_2.Text = gtri_dang_giu;
            btn_2.Enabled = false;
            if (gtri_dang_giu == "")
            {
                btn_2.BackColor = Color.White;
                btn_2.Enabled = true;
            }
            else
                btn_2.BackColor = Color.Lavender;

            //nut 3
            cmd.CommandText = "select tentrangthai from trangthai inner join nut on trangthai.matrangthai = nut.matrangthai where manut = 'btn_3' ";
            gtri_dang_giu = (string)cmd.ExecuteScalar();
            btn_3.Text = gtri_dang_giu;
            btn_3.Enabled = false;
            if (gtri_dang_giu == "")
            {
                btn_3.BackColor = Color.White;
                btn_3.Enabled = true;
            }
            else
                btn_3.BackColor = Color.Lavender;

            //nut 4
            cmd.CommandText = "select tentrangthai from trangthai inner join nut on trangthai.matrangthai = nut.matrangthai where manut = 'btn_4' ";
            gtri_dang_giu = (string)cmd.ExecuteScalar();
            btn_4.Text = gtri_dang_giu;
            btn_4.Enabled = false;
            if (gtri_dang_giu == "")
            {
                btn_4.BackColor = Color.White;
                btn_4.Enabled = true;
            }
            else
                btn_4.BackColor = Color.Lavender;

            //nut 5
            cmd.CommandText = "select tentrangthai from trangthai inner join nut on trangthai.matrangthai = nut.matrangthai where manut = 'btn_5' ";
            gtri_dang_giu = (string)cmd.ExecuteScalar();
            btn_5.Text = gtri_dang_giu;
            btn_5.Enabled = false;
            if (gtri_dang_giu == "")
            {
                btn_5.BackColor = Color.White;
                btn_5.Enabled = true;
            }
            else
                btn_5.BackColor = Color.Lavender;

            //nut 6
            cmd.CommandText = "select tentrangthai from trangthai inner join nut on trangthai.matrangthai = nut.matrangthai where manut = 'btn_6' ";
            gtri_dang_giu = (string)cmd.ExecuteScalar();
            btn_6.Text = gtri_dang_giu;
            btn_6.Enabled = false;
            if (gtri_dang_giu == "")
            {
                btn_6.BackColor = Color.White;
                btn_6.Enabled = true;
            }
            else
                btn_6.BackColor = Color.Lavender;

            //nut 7
            cmd.CommandText = "select tentrangthai from trangthai inner join nut on trangthai.matrangthai = nut.matrangthai where manut = 'btn_7' ";
            gtri_dang_giu = (string)cmd.ExecuteScalar();
            btn_7.Text = gtri_dang_giu;
            btn_7.Enabled = false;
            if (gtri_dang_giu == "")
            {
                btn_7.BackColor = Color.White;
                btn_7.Enabled = true;
            }
            else
                btn_7.BackColor = Color.Lavender;

            //nut 8
            cmd.CommandText = "select tentrangthai from trangthai inner join nut on trangthai.matrangthai = nut.matrangthai where manut = 'btn_8' ";
            gtri_dang_giu = (string)cmd.ExecuteScalar();
            btn_8.Text = gtri_dang_giu;
            btn_8.Enabled = false;
            if (gtri_dang_giu == "")
            {
                btn_8.BackColor = Color.White;
                btn_8.Enabled = true;
            }
            else
                btn_8.BackColor = Color.Lavender;

            //nut 9
            cmd.CommandText = "select tentrangthai from trangthai inner join nut on trangthai.matrangthai = nut.matrangthai where manut = 'btn_9' ";
            gtri_dang_giu = (string)cmd.ExecuteScalar();
            btn_9.Text = gtri_dang_giu;
            btn_9.Enabled = false;
            if (gtri_dang_giu == "")
            {
                btn_9.BackColor = Color.White;
                btn_9.Enabled = true;
            }
            else
                btn_9.BackColor = Color.Lavender;
        }
    }
}