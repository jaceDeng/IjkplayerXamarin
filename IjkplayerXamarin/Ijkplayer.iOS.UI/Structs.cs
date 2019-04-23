using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;
 
namespace Ijkplayer.iOS.UI
{

    [Native]
    public enum ZFPlayerPlaybackState : nuint
    {
        Unknown,
        Playing,
        Paused,
        PlayFailed,
        PlayStopped
    }

    [Native]
    public enum ZFPlayerLoadState : nuint
    {
        Unknown = 0,
        Prepare = 1 << 0,
        Playable = 1 << 1,
        PlaythroughOK = 1 << 2,
        Stalled = 1 << 3
    }

    [Native]
    public enum ZFPlayerScalingMode : nint
    {
        None,
        AspectFit,
        AspectFill,
        Fill
    }

    [Native]
    public enum ZFFullScreenMode : nuint
    {
        Automatic,
        Landscape,
        Portrait
    }

    [Native]
    public enum ZFRotateType : nuint
    {
        Normal,
        Cell,
        CellOther
    }

    [Native]
    public enum ZFInterfaceOrientationMask : nuint
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
    public enum ZFReachabilityStatus : nint
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