using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using NAudio.CoreAudioApi;

namespace Csharp_WinVolumeAdjust.VolumeAdjust_View
{
    /// <summary>
    /// Slide1_AudioChannelAdjust.xaml 的互動邏輯
    /// </summary>
    public partial class Slide1_VolumeChannelAdjust : UserControl
    {
        public Slide1_VolumeChannelAdjust()
        {
            InitializeComponent();
        }

        private void LeftVolume_Slider_DragStarted(object sender, DragStartedEventArgs e) => LeftVolumeAdjust_PB.IsIndeterminate = true;

        private void LeftVolume_Slider_DragCompleted(object sender, DragCompletedEventArgs e) => LeftVolumeAdjust_PB.IsIndeterminate = false;

        private void RightVolume_Slider_DragStarted(object sender, DragStartedEventArgs e) => RightVolumeAdjust_PB.IsIndeterminate = true;

        private void RightVolume_Slider_DragCompleted(object sender, DragCompletedEventArgs e) => RightVolumeAdjust_PB.IsIndeterminate = false;

    }
}
