using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Csharp_WinVolumeAdjust
{
    /// <summary>
    /// MenuItem, 內容寫法(EX: RaisePropertyChanged)主要目的: 讓WPF的Binding能正常更新UI
    /// </summary>
    public class MainWindow_MenuItem : INotifyPropertyChanged
    {
        public MainWindow_MenuItem(string name, string kind, string descript, object content)
        {
            _name = name;
            _kind = kind;
            _descript = descript;
            Content = content;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(); }
        }

        private string _kind;
        public string Kind
        {
            get { return _kind; }
            set { _kind = value; RaisePropertyChanged(); }
        }

        private string _descript;
        public string Descript
        {
            get { return _descript; }
            set { _descript = value; RaisePropertyChanged(); }
        }

        private object _content;
        public object Content
        {
            get { return _content; }
            set { _content = value; RaisePropertyChanged(); }
        }
    }
}
