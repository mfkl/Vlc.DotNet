using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get media chapter (if applicable).
    /// </summary>
    [LibVlcFunction("libvlc_media_player_get_chapter")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int GetMediaChapter(IntPtr mediaPlayerInstance);

    [LibVlcFunction("libvlc_media_player_record")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int Record(IntPtr mediaPlayerInstance, bool enable, Utf8StringHandle path);
}
