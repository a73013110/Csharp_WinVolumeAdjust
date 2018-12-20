using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using MaterialDesignThemes.Wpf;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Media.Animation;

namespace Csharp_WinVolumeAdjust
{
    /// <summary>
    /// MainWindow 的視窗事件
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
            }).ContinueWith(t =>
            {
                MainSnackbar.MessageQueue.Enqueue("歡迎使用 Windows Volume 調整系統");
            }, TaskScheduler.FromCurrentSynchronizationContext());

            DataContext = new MainWindow_ViewModel(MainSnackbar.MessageQueue);

            Snackbar = this.MainSnackbar;
        }

        // 由於Window Style=None, 此方法用於解決最大化視窗的問題
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MaxWidth = SystemParameters.WorkArea.Width + 7;
            this.MaxHeight = SystemParameters.WorkArea.Height + 7;
        }

        // 視窗關閉、最大化、最小化事件
        private void ControlWindow_OnClick(object sender, RoutedEventArgs e)
        {
            object tag = null;
            // 根據Sender型別進行轉換並取得Tag
            if (sender.GetType().Equals(typeof(MaterialDesignThemes.Wpf.PopupBox)))
            {
                tag = ((PopupBox)sender).Tag;
            }
            else if (sender.GetType().Equals(typeof(System.Windows.Controls.Button)))
            {
                tag = ((ButtonBase)sender).Tag;
            }
            // 根據Tag執行動作
            switch (tag.ToString())
            {
                case "CloseWindow":
                    this.Close();
                    break;
                case "MinimizeWindow":
                    this.WindowState = WindowState.Minimized;
                    break;
                case "MaximizeWindow":
                    this.WindowState = this.WindowState.Equals(WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
                    break;
                default:
                    Console.Write("ControlWindow_OnClick出現Bug了");
                    break;
            }
        }

        // 只要按下滑鼠就記錄位置
        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.mouse_pos = PointToScreen(e.GetPosition(this));
        }

        // 透過SubView的條件以動畫來改變視窗大小
        public void Window_ResizeWindow(double from, double to, double duration)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = from;
                myDoubleAnimation.To = to;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(duration));
                this.BeginAnimation(Window.HeightProperty, myDoubleAnimation);
            }), null);
        }
    }
}
