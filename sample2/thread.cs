using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;


public delegate void deleDraw(ref int num);

namespace sample2
{
   
    public class threadClass
    {
        public Int32 gCount;
        private deleDraw drawMethod;
        public Boolean bContinue;


        public threadClass(deleDraw indraw)
        {
            this.gCount = 0;

            drawMethod = indraw;
        }
        public void wThread()
        {
            try
            {
                while (bContinue==true)
                {
                    drawMethod(ref gCount);
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                MessageBox.Show("thread stop");
            }
        }
    }
}
