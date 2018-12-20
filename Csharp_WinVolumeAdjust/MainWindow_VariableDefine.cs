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
    /// MainWindow.xaml 的變數定義
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Snackbar Snackbar;
        private Point mouse_pos;    // 紀錄滑鼠位置
    }
}
