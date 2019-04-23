using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;
 
namespace Ijkplayer.iOS.UI
{

    [Native]
    public enum ZFPlayerPlaybackState : ulong
    {
        Unknown,
        Playing,
        Paused,
        PlayFailed,
        PlayStopped
    }

    [Native]
    public enum ZFPlayerLoadState : ulong
    {
        Unknown = 0,
        Prepare = 1 << 0,
        Playable = 1 << 1,
        PlaythroughOK = 1 << 2,
        Stalled = 1 << 3
    }

    [Native]
    public enum ZFPlayerScalingMode :long
    {
        None,
        AspectFit,
        AspectFill,
        Fill
    }

    [Native]
    public enum ZFFullScreenMode :ulong
    {
        Automatic,
        Landscape,
        Portrait
    }

    [Native]
    public enum ZFRotateType :ulong
    {
        Normal,
        Cell,
        CellOther
    }

    [Native]
    public enum ZFInterfaceOrientationMask :ulong
    {
        Portrait = (1 << 0),
        LandscapeLeft = (1 << 1),
        LandscapeRight = (1 << 2),
        PortraitUpsideDown = (1 << 3),
        Landscape = (LandscapeLeft | LandscapeRight),
        All = (Portrait | LandscapeLeft | LandscapeRight | PortraitUpsideDown),
        AllButUpsideDown = (Portrait | LandscapeLeft | LandscapeRight)
    }

    [Native]
    public enum ZFReachabilityStatus :long
    {
        Unknown = -1,
        NotReachable = 0,
        ReachableViaWiFi = 1,
        ReachableVia2G = 2,
        ReachableVia3G = 3,
        ReachableVia4G = 4
    }

    static class CFunctions
    {
        // extern NSString * _Nonnull ZFStringFromNetworkReachabilityStatus (ZFReachabilityStatus status);
        [DllImport("__Internal")]
        [Verify(PlatformInvoke)]
        static extern NSString ZFStringFromNetworkReachabilityStatus(ZFReachabilityStatus status);
    }
}