using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ranji2019
{
    class RealTime_data
    {
        public static int[,] DT=new int[100,1024];                           // DT值
        public static int[,] R = new int[100,1024];
        public static int[,] R_jicun = new int[100, 65535];                  // R值
        public RealTime_data()
        {
        }
        public static double[] liulang = new double[61];
    }
}
