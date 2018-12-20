using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharp_WinVolumeAdjust.VolumeAdjust_View
{
    /// <summary>
    /// MainWindow.xaml 的Menu項目及其顯示於MainWindow的Information
    /// </summary>
    public class View_VolumeAdjustModel
    {
        public View_VolumeAdjustModel()
        {
            // 取得系統播放裝置
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);  // Render: 播放裝置(非麥克風), Active: 已啟用的裝置
            // 定義播放裝置Item 
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                //Console.WriteLine("{0}: {1}", devices[i].ID, devices[i].FriendlyName);
                View_AudioItems.Add(new View_AudioItem(devices[i]));
            }
        }

        public List<View_AudioItem> View_AudioItems { get; } = new List<View_AudioItem>();
        public int GetDefaultDeviceIndex(MMDevice defaultDevice)
        {
            return Array.IndexOf(View_AudioItems.Select(x => x.Name).ToArray(), defaultDevice.ToString());
        }
    }
}
