using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IjkplayerXamarin
{
    /// <summary>
    /// 视频播放器
    /// </summary>
    public class MediaPlayer : View
    {
        public string VideoURI { get; set; }


        public Action PlayAction { get; set; }

        public void Play()
        {
            PlayAction?.Invoke(); 
        }
    }
}
