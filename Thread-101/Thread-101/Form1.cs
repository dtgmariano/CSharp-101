using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Thread_101
{
    public partial class Form1 : Form
    {
        List<int> dt = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunTimer();
        }

        private class StateObjClass
        {
            // Used to hold parameters for calls to TimerTask. 
            public int SomeValue;
            public System.Threading.Timer TimerReference;
            public bool TimerCanceled;
        }

        public void RunTimer()
        {
            StateObjClass StateObj = new StateObjClass();
            StateObj.TimerCanceled = false;
            StateObj.SomeValue = 1;
            System.Threading.TimerCallback TimerDelegate =
                new System.Threading.TimerCallback(TimerTask);

            // Create a timer that calls a procedure every 2 seconds. 
            // Note: There is no Start method; the timer starts running as soon as  
            // the instance is created.
            System.Threading.Timer TimerItem =
                new System.Threading.Timer(TimerDelegate, StateObj, 50, 50);

            // Save a reference for Dispose.
            StateObj.TimerReference = TimerItem;

            // Run for ten loops. 
            while (StateObj.SomeValue < 10)
            {
                // Wait one second.
                System.Threading.Thread.Sleep(1000);
            }

            // Request Dispose of the timer object.
            StateObj.TimerCanceled = true;
        }

        private void TimerTask(object StateObj)
        {
            StateObjClass State = (StateObjClass)StateObj;
            // Use the interlocked class to increment the counter variable.
            System.Threading.Interlocked.Increment(ref State.SomeValue);
            richTextBox1.AppendText(DateTime.Now.Millisecond.ToString() + "\n");
            System.Diagnostics.Debug.WriteLine("Launched new thread  " + DateTime.Now.ToString() + " " + DateTime.Now.Millisecond.ToString());
            if (State.TimerCanceled)
            // Dispose Requested.
            {
                State.TimerReference.Dispose();
                System.Diagnostics.Debug.WriteLine("Done  " + DateTime.Now.ToString());
            }
        }

    }
}
