using MaterialDesignThemes.Wpf;
using System;
using Csharp_WinVolumeAdjust.VolumeAdjust_View;
using Csharp_WinVolumeAdjust.AboutAuthor_View;

namespace Csharp_WinVolumeAdjust
{
    /// <summary>
    /// MainWindow.xaml 的Menu項目及其顯示於MainWindow的Information
    /// </summary>
    public class MainWindow_ViewModel
    {
        public MainWindow_ViewModel(ISnackbarMessageQueue snackbarMessageQueue)
        {
            // 錯誤偵測, 若snackbarMessageQueue為null
            if (snackbarMessageQueue == null) throw new ArgumentNullException(nameof(snackbarMessageQueue));
            // 定義Menu項目及其資訊
            MainWindow_MenuItems = new[]
            {
                new MainWindow_MenuItem("程式功能", "Audio", "系統音量調整", new View_VolumeAdjust()),
                new MainWindow_MenuItem("關於作者", "UserCardDetails", "作者的相關資訊", new View_AboutAuthor()),
            };
        }

        public MainWindow_MenuItem[] MainWindow_MenuItems { get; }
    }
}
