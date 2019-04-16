using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Shuini
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// 
        /// </summary>
        /// 
        /// ]
        /// 
       
        [STAThread]
        [DllImport("kernel32.dll")]
         static extern bool FreeConsole();
         [DllImport("kernel32.dll")]
         public static extern bool AllocConsole();
        
        static void Main()
        {
            AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            FreeConsole();//释放控制台
        }
    }
}
