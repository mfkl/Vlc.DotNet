using System;

namespace Vlc.DotNet.Core
{
    /// <summary>
    /// The event that is emited on a libvlc <c>AudioDevice</c> event
    /// </summary>
    public class VlcMediaPlayerAudioDeviceEventArgs : EventArgs
    {
        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="audioDevice">The audio device</param>
        public VlcMediaPlayerAudioDeviceEventArgs(string audioDevice)
        {
            this.Device = audioDevice;
        }

        /// <summary>
        /// The device
        /// </summary>
        public string Device { get; }
    }

    
    public class VlcMediaPlayerRecordEventArgs : EventArgs
    {
        public VlcMediaPlayerRecordEventArgs(string filename, bool record)
        {
            FileName = filename;
            Record = record;
        }

        public string FileName { get; }
        public bool Record { get; }
    }
}