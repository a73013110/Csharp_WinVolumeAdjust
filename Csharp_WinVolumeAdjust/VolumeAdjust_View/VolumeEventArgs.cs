using System;

namespace Csharp_WinVolumeAdjust.VolumeAdjust_View
{
    public class VolumeEventArgs : EventArgs
    {
        public VolumeEventArgs(float volume) => this.Volume = volume;
        public float Volume { get; private set; }
    }
}
