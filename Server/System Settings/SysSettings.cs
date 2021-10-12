using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace Server
{
    public class SysSettings
    {
        [DllImport("gdi32.dll")]
        private unsafe static extern bool SetDeviceGammaRamp(Int32 hdc, void* ramp);

        private static bool initialized = false;
        private static Int32 hdc;

        public static void ChangeVolume(int volume)
        {
            CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            defaultPlaybackDevice.Volume = volume;
        }

        private static void InitializeClass()
        {
            if (initialized)
                return;

            hdc = Graphics.FromHwnd(IntPtr.Zero).GetHdc().ToInt32();

            initialized = true;
        }

        public static unsafe bool ChangeBrightness(short brightness)
        {
            InitializeClass();

            if (brightness > 255)
                brightness = 255;

            if (brightness < 0)
                brightness = 0;

            short* gArray = stackalloc short[3 * 256];
            short* idx = gArray;

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 256; i++)
                {
                    int arrayVal = i * (brightness + 128);

                    if (arrayVal > 65535)
                        arrayVal = 65535;

                    *idx = (short)arrayVal;
                    idx++;
                }
            }

            bool retVal = SetDeviceGammaRamp(hdc, gArray);

            return retVal;
        }
    }
}
