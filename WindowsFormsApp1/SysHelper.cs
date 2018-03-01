using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class SysHelper
    {
        //要呼叫別的執行緒就必須透過委派!!
        delegate void PrintHandler(DataGridView dgv, BindingSource source);
        public static void Print(DataGridView dgv, BindingSource source)
        {
            //判斷這個TextBox的物件是否在同一個執行緒上
            if (dgv.InvokeRequired)
            {
                //當InvokeRequired為true時，表示在不同的執行緒上，所以進行委派的動作!!
                PrintHandler ph = new PrintHandler(Print);
                dgv.Invoke(ph, dgv, source);
            }
            else
            {
                //表示在同一個執行緒上了，所以可以正常的呼叫到這個TextBox物件
                dgv.DataSource = source;
            }
        }
    }
}
