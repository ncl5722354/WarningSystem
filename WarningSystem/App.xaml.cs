using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.InteropServices;

namespace WarningSystem
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        //LierdaCracker cracker = new LierdaCracker();
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    cracker.Cracker(100);//垃圾回收间隔时间
        //    base.OnStartup(e);
        //}
        [DllImport("FreeConsole")]
        public static extern bool AllocConsole();

        

    }
}
