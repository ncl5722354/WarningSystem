using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace voice
{
    public partial class voiceControls : UserControl
    {
        SoundPlayer player;
        public bool playering = false;
        public string myfilename = "";
        public voiceControls(string filename)
        {
            myfilename = filename;
            InitializeComponent();
            player = new SoundPlayer(System.Environment.CurrentDirectory+"\\"+filename);
        }

        public void voiceplay_loop()
        {
            if (playering == false)
            {
                
                playering = true;
                try
                {
                    player.PlayLooping();
                }
                catch { }
            }
        }

        public void play_stop()
        {
            player.Stop();
            playering = false;
        }
    }
}
