using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ThreadTest5
{
    public partial class Form1 : Form
    {
        Thread thread;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void setImageOff()
        {
            try
            {
                pictureBox1.BackColor = Color.Black;
            }
            catch (Exception ex)
            { }
            
        }

        private void setImageOn()
        {
            try
            {
                pictureBox1.BackColor = Color.Red;
                Thread.Sleep(50);

            }
            catch (Exception ex)
            { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadStart threadstart = new ThreadStart(setImageOn);
            thread = new Thread(threadstart);
            thread.Start();
        }
    }
}
