using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;
 
namespace Ijkplayer.iOS.UI
{
    [Native]
    public enum ZFPlayerScrollDirection : nuint
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    [Native]
    public enum ZFPlayerScrollViewDirection : nint
    {
        Vertical,
        Horizontal
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
    public enum ZFPlayerGestureType : nuint
    {
        Unknown,
        SingleTap,
        DoubleTap,
        Pan,
        Pinch
    }

    [Native]
    public enum ZFPanDirection : nuint
    {
        Unknown,
        V,
        H
    }

    [Native]
    public enum ZFPanLocation : nuint
    {
        Unknown,
        Left,
        Right
    }

    [Native]
    public enum ZFPanMovingDirection : nuint
    {
        Unkown,
        Top,
        Left,
        Bottom,
        Right
    }

    [Native]
    public enum ZFPlayerDisableGestureTypes : nuint
    {
        None = 0,
        SingleTap = 1 << 0,
        DoubleTap = 1 << 1,
        Pan = 1 << 2,
        Pinch = 1 << 3,
        All = (SingleTap | DoubleTap | Pan | Pinch)
    }

    [Native]
    public enum ZFPlayerDisablePanMovingDirection : nuint
    {
        None = 0,
        Vertical = 1 << 0,
        Horizontal = 1 << 1,
        All = (Vertical | Horizontal)
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

    [Native]
    public enum ZFPlayerBackgroundState : nuint
    {
        Foreground,
        Background
    }
}