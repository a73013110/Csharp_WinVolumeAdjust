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

namespace Csharp_WinVolumeAdjust.AboutAuthor_View
{
    /// <summary>
    /// View_AboutAuthor.xaml 的互動邏輯
    /// </summary>
    public partial class View_AboutAuthor : UserControl
    {
        public View_AboutAuthor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string btn = ((Button)sender).Name;
            if (btn == "github_btn")
            {
                System.Diagnostics.Process.Start("https://github.com/a73013110");
            }
            else if (btn == "facebook_btn")
            {
                System.Diagnostics.Process.Start("https://www.facebook.com/Mr.Yikia");
            }
            else if (btn == "gmail_btn")
            {
                System.Diagnostics.Process.Start("mailto:a73013110@gmail.com");
            }
        }
    }
}
