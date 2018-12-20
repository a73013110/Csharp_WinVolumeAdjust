using NAudio.CoreAudioApi;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Csharp_WinVolumeAdjust.VolumeAdjust_View
{
    public class View_AudioItem : INotifyPropertyChanged
    {
        public View_AudioItem(MMDevice device)
        {
            _device = device;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private MMDevice _device;        
        public MMDevice Device
        {
            get { return _device; }
            set { _device = value; RaisePropertyChanged(); }
        }

        public string Name
        {
            get { return _device.ToString(); }
        }
    }
}
