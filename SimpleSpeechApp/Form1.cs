using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Speech.Synthesis;
using MySql.Data.MySqlClient;

namespace SimpleSpeechApp
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private static void Speech(string LabelName)
        {
            // Initialize a new instance of the SpeechSynthesizer.  
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the audio output.   
            synth.SetOutputToDefaultAudioDevice();

            // Speak a string.  
            synth.Speak(LabelName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //buttonをさがす。子コントロールは検索しない。

            Control c1 = this.Controls["button1"];
            Control c2 = this.Controls["button2"];
            Control c3 = this.Controls["button3"];

            string Input_Text = textBox1.Text;

            //button1が見つかれば、Textを変更する
            if (c1 != null)
            {
                button1.Name = Input_Text;
                button1.Text = Input_Text;
            }
            //button2が見つかれば、Textを変更する
            else if (c2 != null)
            {
                button2.Name = Input_Text;
                button2.Text = Input_Text;
            }
            //button3が見つかれば、Textを変更する
            else if (c3 != null)
            {
                button3.Name = Input_Text;
                button3.Text = Input_Text;

            }
        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            string LabelName = ((Button)sender).Text;

            // MessageBox.Show(LabelName);


            Speech(LabelName);
        }


        private void button2_Click(object sender, EventArgs e)
            {
            string LabelName = ((Button)sender).Text;

            Speech(LabelName);



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string LabelName = ((Button)sender).Text;

            Speech(LabelName);

        }




        private void button4_Click_1(object sender, EventArgs e)
        {
            List<string> Btnlist = new List<string> { };

            for (int i = 1; i <= 3; i++)
            {

            }


            button1.Text = "button1";
            button1.Name = "button1";
            button2.Text = "button2";
            button2.Name = "button2"; 
            button3.Text = "button3";
            button3.Name = "button3";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sLogin = "server=localhost; database = simpledata; userid=root; password=root; ";

            try
            {
                MySqlConnection connection = new MySqlConnection(sLogin);
                connection.Open();
                MessageBox.Show("接続しました");
                connection.Close();
            }
            catch (MySqlException me)
            {
                MessageBox.Show("ERROR: " + me.Message);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string sLogin = "server=localhost; database = simpledata; userid=root; password=root; ";

            try
            {
                MySqlConnection connection = new MySqlConnection(sLogin);
                connection.Open();


                DataTable dt = new DataTable();

                MySqlDataAdapter da = new MySqlDataAdapter("select * from words", connection);

                da.Fill(dt);
                dataGridView1.DataSource = dt;

                connection.Close();
            }
            catch (MySqlException me)
            {
                MessageBox.Show("ERROR: " + me.Message);
            }
        }
    }
    
}



