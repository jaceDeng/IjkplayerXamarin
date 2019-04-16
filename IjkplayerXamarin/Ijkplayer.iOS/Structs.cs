using System;
using System.Runtime.InteropServices;
using CoreVideo;
using ObjCRuntime;

namespace IJKPlayer
{
    [Native]
    public enum IJKMPMovieScalingMode : long
    {
        None,
        AspectFit,
        AspectFill,
        Fill
    }

    [Native]
    public enum IJKMPMoviePlaybackState : long
    {
        Stopped,
        Playing,
        Paused,
        Interrupted,
        SeekingForward,
        SeekingBackward
    }

    [Native]
    public enum IJKMPMovieLoadState : ulong
    {
        Unknown = 0,
        Playable = 1 << 0,
        PlaythroughOK = 1 << 1,
        Stalled = 1 << 2
    }

    [Native]
    public enum IJKMPMovieFinishReason : long
    {
        PlaybackEnded,
        PlaybackError,
        UserExited
    }

    [Native]
    public enum IJKMPMovieTimeOption : long
    {
        NearestKeyFrame,
        Exact
    }

    [Native]
    public enum IJKMediaEvent : long
    {
        Event_WillHttpOpen = 1,
        Event_DidHttpOpen = 2,
        Event_WillHttpSeek = 3,
        Event_DidHttpSeek = 4,
        Ctrl_WillTcpOpen = 131073,
        Ctrl_DidTcpOpen = 131074,
        Ctrl_WillHttpOpen = 131075,
        Ctrl_WillLiveOpen = 131077,
        Ctrl_WillConcatSegmentOpen = 131079
    }

    public enum IJKFFOptionCategory : long
    {
        Format = 1,
        Codec = 2,
        Sws = 3,
        Player = 4,
        Swr = 5
    }

    public enum IJKAVDiscard
    {
        None = -16,
        Default = 0,
        Nonref = 8,
        Bidir = 16,
        Nonkey = 32,
        All = 48
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IJKOverlay
    {
        public int w;

        public int h;

        public uint format;

        public int planes;

        public unsafe ushort pitches;

        public unsafe byte pixels;

        public int sar_num;

        public int sar_den;

        public unsafe CVPixelBuffer pixel_buffer;
    }

    public enum IJKLogLevel : long
    {
        Unknown = 0,
        Default = 1,
        Verbose = 2,
        Debug = 3,
        Info = 4,
        Warn = 5,
        Error = 6,
        Fatal = 7,
        Silent = 8
    }

    //static class CFunctions
    //{
    //    // extern void IJKFFIOStatDebugCallback (const char *url, int type, int bytes);
    //    [DllImport("__Internal")]
    //    static extern unsafe void IJKFFIOStatDebugCallback(sbyte url, int type, int bytes);

    //    // extern void IJKFFIOStatRegister (void (* cb)(const char *, int, int));
    //    [DllImport("__Internal")]
    //    static extern unsafe void IJKFFIOStatRegister(Action<sbyte, int, int> cb);

    //    // extern void IJKFFIOStatCompleteDebugCallback (const char *url, int64_t read_bytes, int64_t total_size, int64_t elpased_time, int64_t total_duration);
    //    [DllImport("__Internal")]
    //    static extern unsafe void IJKFFIOStatCompleteDebugCallback(sbyte* url, long read_bytes, long total_size, long elpased_time, long total_duration);

    //    // extern void IJKFFIOStatCompleteRegister (void (* cb)(const char *, int64_t, int64_t, int64_t, int64_t));
    //    [DllImport("__Internal")]
    //    static extern unsafe void IJKFFIOStatCompleteRegister(Action<sbyte, long, long, long, long> cb);
    //}
}

