using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerAudioDeviceInternalEventCallback;
        public event EventHandler<VlcMediaPlayerAudioDeviceEventArgs> AudioDevice;

        private void OnMediaPlayerAudioDeviceInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerAudioDevice(Utf8InteropStringConverter.Utf8InteropToString(args.eventArgsUnion.MediaPlayerAudioDevice.pszDevice));
        }

        public void OnMediaPlayerAudioDevice(string audioDevice)
        {
            AudioDevice?.Invoke(this, new VlcMediaPlayerAudioDeviceEventArgs(audioDevice));
        }
    }


    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerRecordChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerRecordEventArgs> OnRecord;

        private void OnMediaPlayerRecordChangedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            var filename = Utf8InteropStringConverter.Utf8InteropToString(args.eventArgsUnion.MediaPlayerRecordChanged.FileName);
            var recording = args.eventArgsUnion.MediaPlayerRecordChanged.Recording;

            OnMediaPlayerRecord(filename, recording);
        }

        public void OnMediaPlayerRecord(string filename, bool record)
        {
            OnRecord?.Invoke(this, new VlcMediaPlayerRecordEventArgs(filename, record));
        }

        /// <summary>
        /// Call this *after* calling play
        /// Call stop or enable = false to generate the recorded file
        /// </summary>
        /// <param name="enable">true to enable, false to stop</param>
        /// <param name="directoryLocation">full path of the Directory where the file will be created</param>
        /// <returns>true on success, false otherwise</returns>
        public bool Record(bool enable, string directoryPath) => Manager.Record(myMediaPlayerInstance, enable, directoryPath) == 0;
    }
}