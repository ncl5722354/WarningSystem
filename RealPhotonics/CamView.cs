using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms.Integration;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

namespace RealPhotonics
{
    
    
    
    public partial class CamView : UserControl
    {
        private bool m_bInitSDK = false;
        private Int32 m_lUserID = -1;
        private Int32 m_lRealHandle = -1;
        private Int32 m_lPlayHandle = -1;

        public string myDVRIPAddress = "";
        public Int16 myDVRPortNumber = 0;
        public string myDVRUserName = "";
        public string myDVRPassword = "";
        public DateTime mystarttime;
        public int mytongdao;

        private uint dwAChanTotalNum = 0;
        private uint dwDChanTotalNum = 0;

        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
        public CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        public CHCNetSDK.NET_DVR_GET_STREAM_UNION m_unionGetStream;
        public CHCNetSDK.NET_DVR_IPCHANINFO m_struChanInfo;


         [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 96, ArraySubType = UnmanagedType.U4)]

        private int[] iChannelNum;
        public CamView()
        {
            InitializeComponent();
            iChannelNum = new int[96];
           
        }

        private void ShowView_Load(object sender, EventArgs e)
        {
            
        }

        private void ShowView_Resize(object sender, EventArgs e)
        {
            
        }

        public void ReSet_Size()
        { 
            pictureBox1.Left = 0;
            pictureBox1.Top = 0;
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
        }

        public void ReView(string DVRIPAddress,Int16 DVRPortNumber,string DVRUserName,string DVRPassword,DateTime starttime,int tongdsao)
        {
            try
            {
                m_bInitSDK = CHCNetSDK.NET_DVR_Init();
                if(m_bInitSDK==false)
                {
                    MessageBox.Show("NET_DVR_Init error!");
                    return;
                }
                else
                {
                    CHCNetSDK.NET_DVR_SetLogToFile(3,"C:\\SdkLog\\",true);
                }
                pictureBox1.Left = 0;
                pictureBox1.Top = 0;
                pictureBox1.Width = this.Width;
                pictureBox1.Height = this.Height;
            }
            catch { }
            myDVRIPAddress = DVRIPAddress;
            myDVRPortNumber = DVRPortNumber;
            myDVRUserName = DVRUserName;
            myDVRPassword = DVRPassword;
            mystarttime = starttime;
            mytongdao = tongdsao;
            Thread mythread = new Thread(review);
            mythread.Start();
        }

        void review()
        {
            try
            {
                this.Invoke((EventHandler)delegate
                {
                    string DVRIPAddress = myDVRIPAddress; //设备IP地址或者域名
                    Int16 DVRPortNumber = myDVRPortNumber;//设备服务端口号
                    string DVRUserName = myDVRUserName;//设备登录用户名
                    string DVRPassword = myDVRPassword;//设备登录密码
                    CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                    // 
                    if (m_lUserID >= 0)
                    {
                        // 已经有回放的
                        if (m_lPlayHandle >= 0)
                        {
                            // 要先停止预览
                            if (!CHCNetSDK.NET_DVR_StopPlayBack(m_lPlayHandle))
                            {
                                // iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                                // str = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
                                MessageBox.Show("停止预览失败");
                                return;
                            }
                            if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                            {
                                MessageBox.Show("切换摄像头失败");

                            }
                            m_lPlayHandle = -1;
                            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                            // 
                            if (m_lUserID < 0)
                            {
                                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                                string str = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //登录失败，输出错误号
                                //MessageBox.Show(str);
                                return;
                            }
                            else
                            {
                                dwAChanTotalNum = (uint)DeviceInfo.byChanNum;
                                dwDChanTotalNum = (uint)DeviceInfo.byIPChanNum + 256 * (uint)DeviceInfo.byHighDChanNum;

                                if (dwDChanTotalNum > 0)
                                {
                                    InfoIPChannel();
                                }
                                else
                                {
                                    for (int i = 0; i < dwAChanTotalNum; i++)
                                    {
                                       // ListAnalogChannel(i + 1, 1);
                                        iChannelNum[i] = i + (int)DeviceInfo.byStartChan;
                                    }
                                    // MessageBox.Show("This device has no IP channel!");
                                }
                                //登录成功
                                //MessageBox.Show("Login Success!");
                                //btnLogin.Text = "Logout";
                            }
                            Chongbo();
                            return;

                        }
                        else
                        {
                            if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                            {
                                //MessageBox.Show("回放失败");

                            }
                            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                            // 
                            if (m_lUserID < 0)
                            {
                                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                                string str = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //登录失败，输出错误号
                                //MessageBox.Show(str);
                                return;
                            }
                            else
                            {
                                //登录成功
                                //MessageBox.Show("Login Success!");
                                //btnLogin.Text = "Logout";
                                dwAChanTotalNum = (uint)DeviceInfo.byChanNum;
                                dwDChanTotalNum = (uint)DeviceInfo.byIPChanNum + 256 * (uint)DeviceInfo.byHighDChanNum;

                                if (dwDChanTotalNum > 0)
                                {
                                    InfoIPChannel();
                                }
                                else
                                {
                                    for (int i = 0; i < dwAChanTotalNum; i++)
                                    {
                                        // ListAnalogChannel(i + 1, 1);
                                        iChannelNum[i] = i + (int)DeviceInfo.byStartChan;
                                    }
                                    // MessageBox.Show("This device has no IP channel!");
                                }
                            }
                            Chongbo();
                            return;
                        }
                    }

                    m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                    // 
                    if (m_lUserID < 0)
                    {
                        uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        string str = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //登录失败，输出错误号
                       // MessageBox.Show(str);
                        return;
                    }
                    else
                    {
                        //登录成功
                        //MessageBox.Show("Login Success!");
                        //btnLogin.Text = "Logout";
                        dwAChanTotalNum = (uint)DeviceInfo.byChanNum;
                        dwDChanTotalNum = (uint)DeviceInfo.byIPChanNum + 256 * (uint)DeviceInfo.byHighDChanNum;

                        if (dwDChanTotalNum > 0)
                        {
                            InfoIPChannel();
                        }
                        else
                        {
                            for (int i = 0; i < dwAChanTotalNum; i++)
                            {
                                // ListAnalogChannel(i + 1, 1);
                                iChannelNum[i] = i + (int)DeviceInfo.byStartChan;
                            }
                            // MessageBox.Show("This device has no IP channel!");
                        }
                    }
                    Chongbo();
                });
            }
            catch { }
        }

        public void InfoIPChannel()
        {
            uint dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40);

            IntPtr ptrIpParaCfgV40 = Marshal.AllocHGlobal((Int32)dwSize);
            Marshal.StructureToPtr(m_struIpParaCfgV40, ptrIpParaCfgV40, false);

            uint dwReturn = 0;
            int iGroupNo = 0; //该Demo仅获取第一组64个通道，如果设备IP通道大于64路，需要按组号0~i多次调用NET_DVR_GET_IPPARACFG_V40获取
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_IPPARACFG_V40, iGroupNo, ptrIpParaCfgV40, dwSize, ref dwReturn))
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str1 = "NET_DVR_GET_IPPARACFG_V40 failed, error code= " + iLastErr; //获取IP资源配置信息失败，输出错误号
               // MessageBox.Show(str1);
            }
            else
            {
                // succ
                m_struIpParaCfgV40 = (CHCNetSDK.NET_DVR_IPPARACFG_V40)Marshal.PtrToStructure(ptrIpParaCfgV40, typeof(CHCNetSDK.NET_DVR_IPPARACFG_V40));

                for (int i = 0; i < dwAChanTotalNum; i++)
                {
                    //ListAnalogChannel(i + 1, m_struIpParaCfgV40.byAnalogChanEnable[i]);
                    iChannelNum[i] = i + (int)DeviceInfo.byStartChan;
                }

                byte byStreamType;
                uint iDChanNum = 64;

                if (dwDChanTotalNum < 64)
                {
                    iDChanNum = dwDChanTotalNum; //如果设备IP通道小于64路，按实际路数获取
                }

                for (int i = 0; i < iDChanNum; i++)
                {
                    iChannelNum[i + dwAChanTotalNum] = i + (int)m_struIpParaCfgV40.dwStartDChan;

                    byStreamType = m_struIpParaCfgV40.struStreamMode[i].byGetStreamType;
                    m_unionGetStream = m_struIpParaCfgV40.struStreamMode[i].uGetStream;

                    switch (byStreamType)
                    {
                        //目前NVR仅支持0- 直接从设备取流一种方式
                        case 0:
                            dwSize = (uint)Marshal.SizeOf(m_unionGetStream);
                            IntPtr ptrChanInfo = Marshal.AllocHGlobal((Int32)dwSize);
                            Marshal.StructureToPtr(m_unionGetStream, ptrChanInfo, false);
                            m_struChanInfo = (CHCNetSDK.NET_DVR_IPCHANINFO)Marshal.PtrToStructure(ptrChanInfo, typeof(CHCNetSDK.NET_DVR_IPCHANINFO));

                            //列出IP通道
                           // ListIPChannel(i + 1, m_struChanInfo.byEnable, m_struChanInfo.byIPID);
                            Marshal.FreeHGlobal(ptrChanInfo);
                            break;

                        default:
                            break;
                    }
                }
            }
            Marshal.FreeHGlobal(ptrIpParaCfgV40);
        }

        public void Chongbo()
        {
            Thread mythread = new Thread(chongbo);
            mythread.Start();
        }

        private void chongbo()
        {
            this.Invoke((EventHandler)delegate
               {
                   CHCNetSDK.NET_DVR_VOD_PARA struVodPara = new CHCNetSDK.NET_DVR_VOD_PARA();
                   //struVodPara.dwSize = (uint)Marshal.SizeOf(struVodPara);
                   if (mytongdao <= 0) return;
                   struVodPara.struIDInfo.dwChannel = (uint)iChannelNum[(int)(mytongdao-1)]; //通道号 Channel number  
                   struVodPara.hWnd = pictureBox1.Handle;//回放窗口句柄
                   DateTime nowstarttime= mystarttime.AddSeconds(-10);

                   //设置回放的开始时间 Set the starting time to search video files
                   struVodPara.struBeginTime.dwYear = (uint)nowstarttime.Year;
                   struVodPara.struBeginTime.dwMonth = (uint)nowstarttime.Month;
                   struVodPara.struBeginTime.dwDay = (uint)nowstarttime.Day;
                   struVodPara.struBeginTime.dwHour = (uint)nowstarttime.Hour;
                   struVodPara.struBeginTime.dwMinute = (uint)nowstarttime.Minute;
                   struVodPara.struBeginTime.dwSecond = (uint)nowstarttime.Second;

                   //设置回放的结束时间 Set the stopping time to search video files
                   struVodPara.struEndTime.dwYear = (uint)mystarttime.Year;
                   struVodPara.struEndTime.dwMonth = (uint)mystarttime.Month;
                   struVodPara.struEndTime.dwDay = (uint)mystarttime.Day;
                   struVodPara.struEndTime.dwHour = (uint)mystarttime.Hour;
                   struVodPara.struEndTime.dwMinute = (uint)mystarttime.Minute;
                   struVodPara.struEndTime.dwSecond = (uint)mystarttime.Second;

                   //按时间回放 Playback by time
                   m_lPlayHandle = CHCNetSDK.NET_DVR_PlayBackByTime_V40(m_lUserID, ref struVodPara);
                   if (m_lPlayHandle < 0)
                   {
                       uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                       string str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //回放控制失败，输出错误号
                       //MessageBox.Show(str);
                       //return;
                       //MessageBox.Show("回放错误！");
                       return;
                   }

                   uint iOutValue = 0;
                   if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
                   {
                       uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                       string str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //回放控制失败，输出错误号
                      // MessageBox.Show(str);
                       return;
                   }
               });       
            //timerPlayback.Interval = 1000;
            //timerPlayback.Enabled = true;
            //btnStopPlayback.Enabled = true;
        }


        public void Login_in(string DVRIPAddress,Int16 DVRPortNumber,string DVRUserName,string DVRPassword)
        {
            //string DVRIPAddress = textBoxIP.Text; //设备IP地址或者域名
            //Int16 DVRPortNumber = Int16.Parse(textBoxPort.Text);//设备服务端口号
            //string DVRUserName = textBoxUserName.Text;//设备登录用户名
            //string DVRPassword = textBoxPassword.Text;//设备登录密码

            //try
            //{
            //    this.Invoke((EventHandler)delegate
            //    {
            //        CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            //        m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
            //    });
            //}
            //catch { }
            try
            {
                m_bInitSDK = CHCNetSDK.NET_DVR_Init();
                if (m_bInitSDK == false)
                {
                    MessageBox.Show("NET_DVR_Init error!");
                    return;
                }
                else
                {
                    //保存SDK日志 To save the SDK log
                    CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
                }
                pictureBox1.Left = 0;
                pictureBox1.Top = 0;
                pictureBox1.Width = this.Width;
                pictureBox1.Height = this.Height;
            }
            catch { }
            myDVRIPAddress = DVRIPAddress;
            myDVRPortNumber = DVRPortNumber;
            myDVRUserName = DVRUserName;
            myDVRPassword = DVRPassword;
            
            Thread mythread = new Thread(login_in);
            mythread.Start();
        }




        void login_in()
        {
            try
            {
                this.Invoke((EventHandler)delegate
                {
                    string DVRIPAddress = myDVRIPAddress; //设备IP地址或者域名
                    Int16 DVRPortNumber = myDVRPortNumber;//设备服务端口号
                    string DVRUserName = myDVRUserName;//设备登录用户名
                    string DVRPassword = myDVRPassword;//设备登录密码
                    CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                    // 
                    if(m_lUserID>=0)
                    {
                         // 已经有登录的
                        if(m_lRealHandle>=0)
                        {
                            // 要先停止预览
                            if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
                            {
                               // iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                               // str = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
                                MessageBox.Show("停止预览失败");
                                return;
                            }
                            if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                            {
                                MessageBox.Show("切换摄像头失败");

                            }
                            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                            // 
                            if (m_lUserID < 0)
                            {
                                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                                string str = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //登录失败，输出错误号
                               // MessageBox.Show(str);
                                return;
                            }
                            else
                            {
                                //登录成功
                                //MessageBox.Show("Login Success!");
                                //btnLogin.Text = "Logout";
                            }
                            Prview();
                            return;

                        }
                        else
                        {
                            if(!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                            {
                                MessageBox.Show("切换摄像头失败");
                                
                            }
                            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                            // 
                            if (m_lUserID < 0)
                            {
                                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                                string str = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //登录失败，输出错误号
                               // MessageBox.Show(str);
                                return;
                            }
                            else
                            {
                                //登录成功
                                //MessageBox.Show("Login Success!");
                                //btnLogin.Text = "Logout";
                            }
                            Prview();
                            return;
                        }
                    }

                    m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                    // 
                    if (m_lUserID < 0)
                    {
                        uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        string str = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //登录失败，输出错误号
                       // MessageBox.Show(str);
                        return;
                    }
                    else
                    {
                        //登录成功
                        //MessageBox.Show("Login Success!");
                        //btnLogin.Text = "Logout";
                    }
                    Prview();
                });
            }
            catch { }
        }
        
        public void Prview()
        {
            Thread mythread = new Thread(preview);
            mythread.Start();
        }

        private void preview()
        {
            try
            {
                this.Invoke((EventHandler)delegate
                {
                    CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                    lpPreviewInfo.hPlayWnd = pictureBox1.Handle;    // 预览窗口
                    lpPreviewInfo.lChannel = 1;                     // 设置设备通道
                    lpPreviewInfo.dwStreamType = 0;                //码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                    lpPreviewInfo.dwLinkMode = 0;                  //连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                    lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                    lpPreviewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数

                    CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
                    IntPtr pUser = new IntPtr();//用户数据
                    m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                    if (m_lRealHandle < 0)
                    {
                        uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        string str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //预览失败，输出错误号
                        // MessageBox.Show(str);
                        return;
                    }
                    else
                    {
                        //预览成功
                        //btnPreview.Text = "Stop Live View";
                    }
                }
                );

            }
            catch { }
        }
        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {

        }

        
    }
}
