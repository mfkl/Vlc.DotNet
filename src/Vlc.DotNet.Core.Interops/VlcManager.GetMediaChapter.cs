using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public int GetMediaChapter(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetMediaChapter>().Invoke(mediaPlayerInstance);
        }

        public int Record(VlcMediaPlayerInstance mediaPlayerInstance, bool enable, string path)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            using (var handle = Utf8InteropStringConverter.ToUtf8StringHandle(path))
            {
                return GetInteropDelegate<Record>().Invoke(mediaPlayerInstance, enable, handle);
            }
        }
    }
}