using NAudio.CoreAudioApi;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using MaterialDesignThemes.Wpf.Transitions;
using System.Windows.Media.Animation;

namespace Csharp_WinVolumeAdjust.VolumeAdjust_View
{
    /// <summary>
    /// View_Homexaml.xaml 的互動邏輯
    /// </summary>
    public partial class View_VolumeAdjust : UserControl
    {
        public View_VolumeAdjust()
        {
            InitializeComponent();

            // 創建Model
            this.volumeAdjustModel = new View_VolumeAdjustModel();
            DataContext = new
            {
                volumeAdjust = this,
                volumeAdjustModel = this.volumeAdjustModel,
            };
            // 取得預設播放裝置、將DeviceListBox選擇為預設播放裝置、取得系統音量並設置
            this.DefaultAudioDevice = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            this.DeviceListBox.SelectedIndex = this.volumeAdjustModel.GetDefaultDeviceIndex(DefaultAudioDevice);
            this.UpdateViewSliderValue();
            this.SetupSlideSubView();//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            // 開啟Timer
            this.VolumeAdjust_Timer_Start();
            // 註冊系統音量調整事件
            this.DefaultAudioDevice.AudioEndpointVolume.OnVolumeNotification += Volume_Slider_Update;
        }

        private View_VolumeAdjustModel volumeAdjustModel; // 音量調整View的Model
        public MMDevice DefaultAudioDevice;    // 預設的播放裝置
        public event EventHandler<VolumeEventArgs> VolumnChanged;   // 音量改變事件
        // 改變預設播放裝置的DLL
        [DllImport("DLL_SetDefaultAudioDevice.dll", EntryPoint = "SetAsDefault", CharSet = CharSet.Unicode)]
        private static extern void SetAsDefault(string device_ID);

        #region VolumeAdjust View

        private DispatcherTimer VolumeAdjust_Timer = new DispatcherTimer();  // 音量調整View的Timer
        // 配置並啟動Timer
        private void VolumeAdjust_Timer_Start()
        {
            VolumeAdjust_Timer.Interval = TimeSpan.FromMilliseconds(30);
            VolumeAdjust_Timer.Tick += MainVolume_Timer_Func; // 加入主聲音ProgressBar的事件
            VolumeAdjust_Timer.Start();
        }
        // Timer事件: 讓ProgressBar隨著聲音大小擺動
        private void MainVolume_Timer_Func(object sender, EventArgs e)
        {
            MainVolume_PB.Value = this.DefaultAudioDevice.AudioMeterInformation.MasterPeakValue;
        }

        private void MainVolume_Slider_DragStarted(object sender, DragStartedEventArgs e) => MainVolumeAdjust_PB.IsIndeterminate = true;

        private void MainVolume_Slider_DragCompleted(object sender, DragCompletedEventArgs e) => MainVolumeAdjust_PB.IsIndeterminate = false;

        // 預設裝置改變事件
        private void DeviceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.DeviceListBox.Text.Equals(""))    // 排除掉建立UI時產生的事件
            {
                this.DefaultAudioDevice = ((View_AudioItem)((ComboBox)sender).SelectedItem).Device;
                SetAsDefault(this.DefaultAudioDevice.ID);   // 呼叫外部DLL
                this.UpdateAllViewSliderValue();
            }
        }

        private void UpdateViewSliderValue()
        {
            this.MainVolume_Slider.Value = Math.Round(DefaultAudioDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
        }

        #endregion

        #region VolumeAdjust View & Subview

        private void Volume_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            float volume = (float)e.NewValue / 100.0f;
            if (((Slider)sender).Name == "MainVolume_Slider")
            {
                this.DefaultAudioDevice.AudioEndpointVolume.MasterVolumeLevelScalar = volume;
                this.UpdateSlideSubViewSliderValue();
            }
            else if (((Slider)sender).Name == "LeftVolume_Slider")
            {
                this.DefaultAudioDevice.AudioEndpointVolume.Channels[0].VolumeLevelScalar = volume;
            }
            else if (((Slider)sender).Name == "RightVolume_Slider")
            {
                this.DefaultAudioDevice.AudioEndpointVolume.Channels[1].VolumeLevelScalar = volume;
            }
            // 中斷事件傳遞, 移動Slider->改變系統音量, 改變系統音量->產生OnVolumeNotification事件
            this.VolumnChanged?.Invoke(sender, new VolumeEventArgs(volume));
        }

        // 監聽系統音量控制事件, 於程式外控制音量, 程式亦可更新音量
        public void Volume_Slider_Update(AudioVolumeNotificationData data)
        {
            try
            {
                this.MainVolume_Slider.Dispatcher.Invoke(new Action(delegate ()
                {
                    this.UpdateAllViewSliderValue();
                }));
            }
            catch (Exception) { }
        }

        private void UpdateAllViewSliderValue()
        {
            this.UpdateViewSliderValue();
            this.UpdateSlideSubViewSliderValue();
        }

        #endregion

        #region Slide SubView 相關

        private void SetupSlideSubView()
        {
            this.UpdateSlideSubViewSliderValue();
            this.Slide1_VolumeChannelAdjust.LeftVolume_Slider.ValueChanged += Volume_Slider_ValueChanged;
            this.Slide1_VolumeChannelAdjust.RightVolume_Slider.ValueChanged += Volume_Slider_ValueChanged;
        }

        private void UpdateSlideSubViewSliderValue()
        {
            this.Slide1_VolumeChannelAdjust.LeftVolume_Slider.Value = Math.Round(DefaultAudioDevice.AudioEndpointVolume.Channels[0].VolumeLevelScalar * 100);
            this.Slide1_VolumeChannelAdjust.RightVolume_Slider.Value = Math.Round(DefaultAudioDevice.AudioEndpointVolume.Channels[1].VolumeLevelScalar * 100);
        }

        private void Transitioner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((Transitioner)sender).SelectedIndex != 0)  // 非起始頁
            {
                double height = Window.GetWindow(this).ActualHeight;
                double from = height;
                double to = height + (Slide1_VolumeChannelAdjust.ActualHeight - Slide0_VolumeChannelAdjustComfirm.ActualHeight);
                ((MainWindow)Window.GetWindow(this)).Window_ResizeWindow(from, to, 300);
            }
        }

        #endregion
    }
}
