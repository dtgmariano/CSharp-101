//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Thread_102.Core
//{
//    class Mediator
//    {
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
//using Edith.Properties;
//using Edith.UIComponents;
using System.IO;
using System.Windows;
using System.Collections.Concurrent;

namespace Thread_102.Core
{
    /// <summary>
    /// This Class is used to managed all communications beetween Modules and the core
    /// it also provide the tick frequency
    /// </summary>
    public class Mediator
    {
        public event EventHandler Tick;
        public event EventHandler Click;

        public DispatcherTimer tickTimer = new DispatcherTimer(DispatcherPriority.Send);

        public TimeSpan Tc, ts;


        private Queue<int> adjustQueue;
        private Queue<bool> tickQueue;

        public DateTime tickTime;
        private DateTime MouseDownTime;
        private double menuAreaWidth;

        public bool isPaused = false;

        private static Mediator instance = null;

        public static Mediator INSTANCE
        {
            get
            {
                if (instance == null)
                {
                    instance = new Mediator();
                }
                return instance;
            }
        }

        public Mediator()
        {
            /*
             * Timer used to provided the tick frequency
             * on each Tick, the Tick event is fired.
             */
            tickTimer.Tick += new EventHandler(tickTimer_Tick);
            tickTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            tickTimer.Start();
        }


        void tickTimer_Tick(object sender, EventArgs e)
        {
            //if (this.CurrentModule.ModuleType == ModuleType.ContentModule)
            //{
            //    this.CurrentModule.Element.
            //    Console.WriteLine("");
            //    //this.CurrentModule.Element.
            //}
            //tickTime = DateTime.Now;
            if (isPaused)
                return;
            if (Tick != null)
            {
                //SetCursorPos(0, 10000);
                //SetCursorPos(20, 800);
                Tick(this, new EventArgs());
            }
        }

        public void Resume()
        {
            Tc = DateTime.Now - MouseDownTime;
            //Core.Log.Debug("TimeClick:" + "\t" + Tc.ToString());
            isPaused = false;
        }

        /// <summary>
        /// Call by system to fired the Click event
        /// </summary>
        public void DoClick()
        {
            isPaused = true;
            ts = DateTime.Now - tickTime;
            //Core.Log.ActionTime(ts.ToString());

            if (this.Click != null)
                Click(this, new EventArgs());
        }


        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int X, int Y);
    }
}
