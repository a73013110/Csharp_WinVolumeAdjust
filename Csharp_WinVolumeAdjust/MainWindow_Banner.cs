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

namespace Csharp_WinVolumeAdjust
{
    /// <summary>
    /// MainWindow.xaml 的Banner事件
    /// </summary>
    public partial class MainWindow : Window
    {
        // 視窗移動
        private void ColorZone_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        // 視窗最大化的情況下視窗移動
        private void ColorZone_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                this.Left = this.mouse_pos.X - this.Width / 2;
                this.Top = this.mouse_pos.Y - 20;
                DragMove();
            }
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        //private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var _MessageDialog = new MessageDialog { 
        //        Message = { Text = ((ButtonBase)sender).Content.ToString() }
        //    };

        //    await DialogHost.Show(_MessageDialog, "MainWindow");
        //}
    }
}
