using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        static bool s = true;

        public Form1()
        {
            InitializeComponent();

            this.TransparencyKey = Color.Wheat;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;


            CheckForIllegalCrossThreadCalls = false;

            Thread th = new Thread(showhide);
            th.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void showhide()
        {
            while (true)
            {
                if(GetAsyncKeyState(Keys.Insert) < 0 && s == true)
                {
                    this.Hide();
                    s = false;
                    Thread.Sleep(80);

                }
                else if(GetAsyncKeyState(Keys.Insert) < 0 && s == false)
                {
                    this.Show();

                    s = true;
                    Thread.Sleep(80);
                }
                Thread.Sleep(20);
            }
        }
    }
}
