using System;
using AVFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using SystemConfiguration;
using UIKit;
 
namespace Ijkplayer.iOS.UI
{
    // @interface ZFPlayer (UIScrollView)
    //[Category]
    [BaseType(typeof(UIScrollView))]
    interface UIScrollView_ZFPlayer
    {
        // @property (readonly, nonatomic) CGFloat zf_lastOffsetY;
        [Export("zf_lastOffsetY")]
        nfloat Zf_lastOffsetY { get; }

        // @property (readonly, nonatomic) CGFloat zf_lastOffsetX;
        [Export("zf_lastOffsetX")]
        nfloat Zf_lastOffsetX { get; }

        // @property (nonatomic) NSIndexPath * _Nullable zf_playingIndexPath;
        [NullAllowed, Export("zf_playingIndexPath", ArgumentSemantic.Assign)]
        NSIndexPath Zf_playingIndexPath { get; set; }

        // @property (nonatomic) NSIndexPath * _Nullable zf_shouldPlayIndexPath;
        [NullAllowed, Export("zf_shouldPlayIndexPath", ArgumentSemantic.Assign)]
        NSIndexPath Zf_shouldPlayIndexPath { get; set; }

        // @property (getter = zf_isWWANAutoPlay, nonatomic) BOOL zf_WWANAutoPlay;
        [Export("zf_WWANAutoPlay")]
        bool Zf_WWANAutoPlay { [Bind("zf_isWWANAutoPlay")] get; set; }

        // @property (nonatomic) BOOL zf_shouldAutoPlay;
        [Export("zf_shouldAutoPlay")]
        bool Zf_shouldAutoPlay { get; set; }

        // @property (nonatomic) NSInteger zf_containerViewTag;
        [Export("zf_containerViewTag")]
        nint Zf_containerViewTag { get; set; }

        // @property (nonatomic) ZFPlayerScrollViewDirection zf_scrollViewDirection;
        [Export("zf_scrollViewDirection", ArgumentSemantic.Assign)]
        ZFPlayerScrollViewDirection Zf_scrollViewDirection { get; set; }

        // @property (readonly, nonatomic) ZFPlayerScrollDirection zf_scrollDirection;
        [Export("zf_scrollDirection")]
        ZFPlayerScrollDirection Zf_scrollDirection { get; }

        // @property (nonatomic) BOOL zf_stopWhileNotVisible;
        [Export("zf_stopWhileNotVisible")]
        bool Zf_stopWhileNotVisible { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_scrollViewDidStopScrollCallback;
        [NullAllowed, Export("zf_scrollViewDidStopScrollCallback", ArgumentSemantic.Copy)]
        Action<NSIndexPath> Zf_scrollViewDidStopScrollCallback { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_shouldPlayIndexPathCallback;
        [NullAllowed, Export("zf_shouldPlayIndexPathCallback", ArgumentSemantic.Copy)]
        Action<NSIndexPath> Zf_shouldPlayIndexPathCallback { get; set; }

        // -(void)zf_filterShouldPlayCellWhileScrolled:(void (^ _Nullable)(NSIndexPath * _Nonnull))handler;
        [Export("zf_filterShouldPlayCellWhileScrolled:")]
        void Zf_filterShouldPlayCellWhileScrolled([NullAllowed] Action<NSIndexPath> handler);

        // -(void)zf_filterShouldPlayCellWhileScrolling:(void (^ _Nullable)(NSIndexPath * _Nonnull))handler;
        [Export("zf_filterShouldPlayCellWhileScrolling:")]
        void Zf_filterShouldPlayCellWhileScrolling([NullAllowed] Action<NSIndexPath> handler);

        // -(UIView * _Nonnull)zf_getCellForIndexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("zf_getCellForIndexPath:")]
        UIView Zf_getCellForIndexPath(NSIndexPath indexPath);

        // -(void)zf_scrollToRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath completionHandler:(void (^ _Nullable)(void))completionHandler;
        [Export("zf_scrollToRowAtIndexPath:completionHandler:")]
        void Zf_scrollToRowAtIndexPath(NSIndexPath indexPath, [NullAllowed] Action completionHandler);

        // -(void)zf_scrollToRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath animated:(BOOL)animated completionHandler:(void (^ _Nullable)(void))completionHandler;
        [Export("zf_scrollToRowAtIndexPath:animated:completionHandler:")]
        void Zf_scrollToRowAtIndexPath(NSIndexPath indexPath, bool animated, [NullAllowed] Action completionHandler);

        // -(void)zf_scrollToRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath animateWithDuration:(NSTimeInterval)duration completionHandler:(void (^ _Nullable)(void))completionHandler;
        [Export("zf_scrollToRowAtIndexPath:animateWithDuration:completionHandler:")]
        void Zf_scrollToRowAtIndexPath(NSIndexPath indexPath, double duration, [NullAllowed] Action completionHandler);

        // -(void)zf_scrollViewDidEndDecelerating;
        [Export("zf_scrollViewDidEndDecelerating")]
        void Zf_scrollViewDidEndDecelerating();

        // -(void)zf_scrollViewDidEndDraggingWillDecelerate:(BOOL)decelerate;
        [Export("zf_scrollViewDidEndDraggingWillDecelerate:")]
        void Zf_scrollViewDidEndDraggingWillDecelerate(bool decelerate);

        // -(void)zf_scrollViewDidScrollToTop;
        [Export("zf_scrollViewDidScrollToTop")]
        void Zf_scrollViewDidScrollToTop();

        // -(void)zf_scrollViewDidScroll;
        [Export("zf_scrollViewDidScroll")]
        void Zf_scrollViewDidScroll();

        // -(void)zf_scrollViewWillBeginDragging;
        [Export("zf_scrollViewWillBeginDragging")]
        void Zf_scrollViewWillBeginDragging();
    }

    // @interface ZFPlayerCannotCalled (UIScrollView)
    //[Category]
    [BaseType(typeof(UIScrollView))]
    interface UIScrollView_ZFPlayerCannotCalled
    {
        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull, CGFloat) zf_playerAppearingInScrollView;
        [NullAllowed, Export("zf_playerAppearingInScrollView", ArgumentSemantic.Copy)]
        Action<NSIndexPath, nfloat> Zf_playerAppearingInScrollView { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull, CGFloat) zf_playerDisappearingInScrollView;
        [NullAllowed, Export("zf_playerDisappearingInScrollView", ArgumentSemantic.Copy)]
        Action<NSIndexPath, nfloat> Zf_playerDisappearingInScrollView { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerWillAppearInScrollView;
        [NullAllowed, Export("zf_playerWillAppearInScrollView", ArgumentSemantic.Copy)]
        Action<NSIndexPath> Zf_playerWillAppearInScrollView { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerDidAppearInScrollView;
        [NullAllowed, Export("zf_playerDidAppearInScrollView", ArgumentSemantic.Copy)]
        Action<NSIndexPath> Zf_playerDidAppearInScrollView { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerWillDisappearInScrollView;
        [NullAllowed, Export("zf_playerWillDisappearInScrollView", ArgumentSemantic.Copy)]
        Action<NSIndexPath> Zf_playerWillDisappearInScrollView { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerDidDisappearInScrollView;
        [NullAllowed, Export("zf_playerDidDisappearInScrollView", ArgumentSemantic.Copy)]
        Action<NSIndexPath> Zf_playerDidDisappearInScrollView { get; set; }

        // @property (nonatomic) CGFloat zf_playerDisapperaPercent;
        [Export("zf_playerDisapperaPercent")]
        nfloat Zf_playerDisapperaPercent { get; set; }

        // @property (nonatomic) CGFloat zf_playerApperaPercent;
        [Export("zf_playerApperaPercent")]
        nfloat Zf_playerApperaPercent { get; set; }

        // @property (nonatomic) BOOL zf_viewControllerDisappear;
        [Export("zf_viewControllerDisappear")]
        bool Zf_viewControllerDisappear { get; set; }
    }

    // @interface ZFPlayerDeprecated (UIScrollView)
    //[Category]
    [BaseType(typeof(UIScrollView))]
    interface UIScrollView_ZFPlayerDeprecated
    {
        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) scrollViewDidStopScroll __attribute__((deprecated("use `zf_scrollViewDidStopScrollCallback` instead.")));
        [NullAllowed, Export("scrollViewDidStopScroll", ArgumentSemantic.Copy)]
        Action<NSIndexPath> ScrollViewDidStopScroll { get; set; }

        // @property (nonatomic, strong) NSIndexPath * _Nullable shouldPlayIndexPath __attribute__((deprecated("use `zf_shouldPlayIndexPath` instead.")));
        [NullAllowed, Export("shouldPlayIndexPath", ArgumentSemantic.Strong)]
        NSIndexPath ShouldPlayIndexPath { get; set; }
    }

    // @interface ZFFloatView : UIView
    [BaseType(typeof(UIView))]
    interface ZFFloatView
    {
        // @property (nonatomic, weak) UIView * parentView;
        [Export("parentView", ArgumentSemantic.Weak)]
        UIView ParentView { get; set; }

        // @property (assign, nonatomic) UIEdgeInsets safeInsets;
        [Export("safeInsets", ArgumentSemantic.Assign)]
        UIEdgeInsets SafeInsets { get; set; }
    }

    // @interface ZFKVOController : NSObject
    [BaseType(typeof(NSObject))]
    interface ZFKVOController
    {
        // -(instancetype)initWithTarget:(NSObject *)target;
        [Export("initWithTarget:")]
        IntPtr Constructor(NSObject target);

        // -(void)safelyAddObserver:(NSObject *)observer forKeyPath:(NSString *)keyPath options:(NSKeyValueObservingOptions)options context:(void *)context;
        [Export("safelyAddObserver:forKeyPath:options:context:")]
        unsafe void SafelyAddObserver(NSObject observer, string keyPath, NSKeyValueObservingOptions options, NSObject context);

        // -(void)safelyRemoveObserver:(NSObject *)observer forKeyPath:(NSString *)keyPath;
        [Export("safelyRemoveObserver:forKeyPath:")]
        void SafelyRemoveObserver(NSObject observer, string keyPath);

        // -(void)safelyRemoveAllObservers;
        [Export("safelyRemoveAllObservers")]
        void SafelyRemoveAllObservers();
    }

    // @interface ZFOrientationObserver : NSObject
    [BaseType(typeof(NSObject))]
    interface ZFOrientationObserver
    {
        // -(void)updateRotateView:(UIView * _Nonnull)rotateView containerView:(UIView * _Nonnull)containerView;
        [Export("updateRotateView:containerView:")]
        void UpdateRotateView(UIView rotateView, UIView containerView);

        // -(void)cellModelRotateView:(UIView * _Nonnull)rotateView rotateViewAtCell:(UIView * _Nonnull)cell playerViewTag:(NSInteger)playerViewTag;
        [Export("cellModelRotateView:rotateViewAtCell:playerViewTag:")]
        void CellModelRotateView(UIView rotateView, UIView cell, nint playerViewTag);

        // -(void)cellOtherModelRotateView:(UIView * _Nonnull)rotateView containerView:(UIView * _Nonnull)containerView;
        [Export("cellOtherModelRotateView:containerView:")]
        void CellOtherModelRotateView(UIView rotateView, UIView containerView);

        // @property (nonatomic, strong) UIView * _Nonnull fullScreenContainerView;
        [Export("fullScreenContainerView", ArgumentSemantic.Strong)]
        UIView FullScreenContainerView { get; set; }

        // @property (nonatomic, weak) UIView * _Nullable containerView;
        [NullAllowed, Export("containerView", ArgumentSemantic.Weak)]
        UIView ContainerView { get; set; }

        // @property (readonly, getter = isFullScreen, nonatomic) BOOL fullScreen;
        [Export("fullScreen")]
        bool FullScreen { [Bind("isFullScreen")] get; }

        // @property (assign, nonatomic) BOOL forceDeviceOrientation;
        [Export("forceDeviceOrientation")]
        bool ForceDeviceOrientation { get; set; }

        // @property (getter = isLockedScreen, nonatomic) BOOL lockedScreen;
        [Export("lockedScreen")]
        bool LockedScreen { [Bind("isLockedScreen")] get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFOrientationObserver * _Nonnull, BOOL) orientationWillChange;
        [NullAllowed, Export("orientationWillChange", ArgumentSemantic.Copy)]
        Action<ZFOrientationObserver, bool> OrientationWillChange { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFOrientationObserver * _Nonnull, BOOL) orientationDidChanged;
        [NullAllowed, Export("orientationDidChanged", ArgumentSemantic.Copy)]
        Action<ZFOrientationObserver, bool> OrientationDidChanged { get; set; }

        // @property (nonatomic) ZFFullScreenMode fullScreenMode;
        [Export("fullScreenMode", ArgumentSemantic.Assign)]
        ZFFullScreenMode FullScreenMode { get; set; }

        // @property (nonatomic) float duration;
        [Export("duration")]
        float Duration { get; set; }

        // @property (getter = isStatusBarHidden, nonatomic) BOOL statusBarHidden;
        [Export("statusBarHidden")]
        bool StatusBarHidden { [Bind("isStatusBarHidden")] get; set; }

        // @property (readonly, nonatomic) UIInterfaceOrientation currentOrientation;
        [Export("currentOrientation")]
        UIInterfaceOrientation CurrentOrientation { get; }

        // @property (nonatomic) BOOL allowOrentitaionRotation;
        [Export("allowOrentitaionRotation")]
        bool AllowOrentitaionRotation { get; set; }

        // @property (assign, nonatomic) ZFInterfaceOrientationMask supportInterfaceOrientation;
        [Export("supportInterfaceOrientation", ArgumentSemantic.Assign)]
        ZFInterfaceOrientationMask SupportInterfaceOrientation { get; set; }

        // -(void)addDeviceOrientationObserver;
        [Export("addDeviceOrientationObserver")]
        void AddDeviceOrientationObserver();

        // -(void)removeDeviceOrientationObserver;
        [Export("removeDeviceOrientationObserver")]
        void RemoveDeviceOrientationObserver();

        // -(void)enterLandscapeFullScreen:(UIInterfaceOrientation)orientation animated:(BOOL)animated;
        [Export("enterLandscapeFullScreen:animated:")]
        void EnterLandscapeFullScreen(UIInterfaceOrientation orientation, bool animated);

        // -(void)enterPortraitFullScreen:(BOOL)fullScreen animated:(BOOL)animated;
        [Export("enterPortraitFullScreen:animated:")]
        void EnterPortraitFullScreen(bool fullScreen, bool animated);

        // -(void)exitFullScreenWithAnimated:(BOOL)animated;
        [Export("exitFullScreenWithAnimated:")]
        void ExitFullScreenWithAnimated(bool animated);
    }

    [Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern double ZFPlayerVersionNumber;
        [Field("ZFPlayerVersionNumber", "__Internal")]
        double ZFPlayerVersionNumber { get; }

        // extern const unsigned char [] ZFPlayerVersionString;
        [Field("ZFPlayerVersionString", "__Internal")]
        NSString ZFPlayerVersionString { get; }
    }

    // @interface ZFPlayerView : UIView
    [BaseType(typeof(UIView))]
    interface ZFPlayerView
    {
    }

    // @protocol ZFPlayerMediaPlayback <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ZFPlayerMediaPlayback
    {
        // @required @property (nonatomic) ZFPlayerView * _Nonnull view;
        [Abstract]
        [Export("view", ArgumentSemantic.Assign)]
        ZFPlayerView View { get; set; }

        // @optional @property (nonatomic) float volume;
        [Export("volume")]
        float Volume { get; set; }

        // @optional @property (getter = isMuted, nonatomic) BOOL muted;
        [Export("muted")]
        bool Muted { [Bind("isMuted")] get; set; }

        // @optional @property (nonatomic) float rate;
        [Export("rate")]
        float Rate { get; set; }

        // @optional @property (readonly, nonatomic) NSTimeInterval currentTime;
        [Export("currentTime")]
        double CurrentTime { get; }

        // @optional @property (readonly, nonatomic) NSTimeInterval totalTime;
        [Export("totalTime")]
        double TotalTime { get; }

        // @optional @property (readonly, nonatomic) NSTimeInterval bufferTime;
        [Export("bufferTime")]
        double BufferTime { get; }

        // @optional @property (nonatomic) NSTimeInterval seekTime;
        [Export("seekTime")]
        double SeekTime { get; set; }

        // @optional @property (readonly, nonatomic) BOOL isPlaying;
        [Export("isPlaying")]
        bool IsPlaying { get; }

        // @optional @property (nonatomic) ZFPlayerScalingMode scalingMode;
        [Export("scalingMode", ArgumentSemantic.Assign)]
        ZFPlayerScalingMode ScalingMode { get; set; }

        // @optional @property (readonly, nonatomic) BOOL isPreparedToPlay;
        [Export("isPreparedToPlay")]
        bool IsPreparedToPlay { get; }

        // @optional @property (nonatomic) NSURL * _Nonnull assetURL;
        [Export("assetURL", ArgumentSemantic.Assign)]
        NSUrl AssetURL { get; set; }

        // @optional @property (readonly, nonatomic) CGSize presentationSize;
        [Export("presentationSize")]
        CGSize PresentationSize { get; }

        // @optional @property (readonly, nonatomic) ZFPlayerPlaybackState playState;
        [Export("playState")]
        ZFPlayerPlaybackState PlayState { get; }

        // @optional @property (readonly, nonatomic) ZFPlayerLoadState loadState;
        [Export("loadState")]
        ZFPlayerLoadState LoadState { get; }

        // @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSURL * _Nonnull) playerPrepareToPlay;
        [NullAllowed, Export("playerPrepareToPlay", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, NSUrl> PlayerPrepareToPlay { get; set; }

        // @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSURL * _Nonnull) playerReadyToPlay;
        [NullAllowed, Export("playerReadyToPlay", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, NSUrl> PlayerReadyToPlay { get; set; }

        // @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSTimeInterval, NSTimeInterval) playerPlayTimeChanged;
        [NullAllowed, Export("playerPlayTimeChanged", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, double, double> PlayerPlayTimeChanged { get; set; }

        // @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSTimeInterval) playerBufferTimeChanged;
        [NullAllowed, Export("playerBufferTimeChanged", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, double> PlayerBufferTimeChanged { get; set; }

        // @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, ZFPlayerPlaybackState) playerPlayStateChanged;
        [NullAllowed, Export("playerPlayStateChanged", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, ZFPlayerPlaybackState> PlayerPlayStateChanged { get; set; }

        // @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, ZFPlayerLoadState) playerLoadStateChanged;
        [NullAllowed, Export("playerLoadStateChanged", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, ZFPlayerLoadState> PlayerLoadStateChanged { get; set; }

        // @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, id _Nonnull) playerPlayFailed;
        [NullAllowed, Export("playerPlayFailed", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, NSObject> PlayerPlayFailed { get; set; }

        // @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull) playerDidToEnd;
        [NullAllowed, Export("playerDidToEnd", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback> PlayerDidToEnd { get; set; }

        // @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, CGSize) presentationSizeChanged;
        [NullAllowed, Export("presentationSizeChanged", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, CGSize> PresentationSizeChanged { get; set; }

        // @optional -(void)prepareToPlay;
        [Export("prepareToPlay")]
        void PrepareToPlay();

        // @optional -(void)reloadPlayer;
        [Export("reloadPlayer")]
        void ReloadPlayer();

        // @optional -(void)play;
        [Export("play")]
        void Play();

        // @optional -(void)pause;
        [Export("pause")]
        void Pause();

        // @optional -(void)replay;
        [Export("replay")]
        void Replay();

        // @optional -(void)stop;
        [Export("stop")]
        void Stop();

        // @optional -(UIImage * _Nonnull)thumbnailImageAtCurrentTime;
        [Export("thumbnailImageAtCurrentTime")]
      //  [Verify(MethodToProperty)]
        UIImage ThumbnailImageAtCurrentTime { get; }

        // @optional -(void)seekToTime:(NSTimeInterval)time completionHandler:(void (^ _Nullable)(BOOL))completionHandler;
        [Export("seekToTime:completionHandler:")]
        void SeekToTime(double time, [NullAllowed] Action<bool> completionHandler);

        // @optional -(void)replaceCurrentAssetURL:(NSURL * _Nonnull)assetURL __attribute__((deprecated("use the property `assetURL` instead.")));
        [Export("replaceCurrentAssetURL:")]
        void ReplaceCurrentAssetURL(NSUrl assetURL);
    }

    // @interface ZFPlayerGestureControl : NSObject
    [BaseType(typeof(NSObject))]
    interface ZFPlayerGestureControl
    {
        // @property (copy, nonatomic) BOOL (^ _Nullable)(ZFPlayerGestureControl * _Nonnull, ZFPlayerGestureType, UIGestureRecognizer * _Nonnull, UITouch * _Nonnull) triggerCondition;
        [NullAllowed, Export("triggerCondition", ArgumentSemantic.Copy)]
        Func<ZFPlayerGestureControl, ZFPlayerGestureType, UIGestureRecognizer, UITouch, bool> TriggerCondition { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerGestureControl * _Nonnull) singleTapped;
        [NullAllowed, Export("singleTapped", ArgumentSemantic.Copy)]
        Action<ZFPlayerGestureControl> SingleTapped { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerGestureControl * _Nonnull) doubleTapped;
        [NullAllowed, Export("doubleTapped", ArgumentSemantic.Copy)]
        Action<ZFPlayerGestureControl> DoubleTapped { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerGestureControl * _Nonnull, ZFPanDirection, ZFPanLocation) beganPan;
        [NullAllowed, Export("beganPan", ArgumentSemantic.Copy)]
        Action<ZFPlayerGestureControl, ZFPanDirection, ZFPanLocation> BeganPan { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerGestureControl * _Nonnull, ZFPanDirection, ZFPanLocation, CGPoint) changedPan;
        [NullAllowed, Export("changedPan", ArgumentSemantic.Copy)]
        Action<ZFPlayerGestureControl, ZFPanDirection, ZFPanLocation, CGPoint> ChangedPan { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerGestureControl * _Nonnull, ZFPanDirection, ZFPanLocation) endedPan;
        [NullAllowed, Export("endedPan", ArgumentSemantic.Copy)]
        Action<ZFPlayerGestureControl, ZFPanDirection, ZFPanLocation> EndedPan { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerGestureControl * _Nonnull, float) pinched;
        [NullAllowed, Export("pinched", ArgumentSemantic.Copy)]
        Action<ZFPlayerGestureControl, float> Pinched { get; set; }

        // @property (readonly, nonatomic, strong) UITapGestureRecognizer * _Nonnull singleTap;
        [Export("singleTap", ArgumentSemantic.Strong)]
        UITapGestureRecognizer SingleTap { get; }

        // @property (readonly, nonatomic, strong) UITapGestureRecognizer * _Nonnull doubleTap;
        [Export("doubleTap", ArgumentSemantic.Strong)]
        UITapGestureRecognizer DoubleTap { get; }

        // @property (readonly, nonatomic, strong) UIPanGestureRecognizer * _Nonnull panGR;
        [Export("panGR", ArgumentSemantic.Strong)]
        UIPanGestureRecognizer PanGR { get; }

        // @property (readonly, nonatomic, strong) UIPinchGestureRecognizer * _Nonnull pinchGR;
        [Export("pinchGR", ArgumentSemantic.Strong)]
        UIPinchGestureRecognizer PinchGR { get; }

        // @property (readonly, nonatomic) ZFPanDirection panDirection;
        [Export("panDirection")]
        ZFPanDirection PanDirection { get; }

        // @property (readonly, nonatomic) ZFPanLocation panLocation;
        [Export("panLocation")]
        ZFPanLocation PanLocation { get; }

        // @property (readonly, nonatomic) ZFPanMovingDirection panMovingDirection;
        [Export("panMovingDirection")]
        ZFPanMovingDirection PanMovingDirection { get; }

        // @property (nonatomic) ZFPlayerDisableGestureTypes disableTypes;
        [Export("disableTypes", ArgumentSemantic.Assign)]
        ZFPlayerDisableGestureTypes DisableTypes { get; set; }

        // @property (nonatomic) ZFPlayerDisablePanMovingDirection disablePanMovingDirection;
        [Export("disablePanMovingDirection", ArgumentSemantic.Assign)]
        ZFPlayerDisablePanMovingDirection DisablePanMovingDirection { get; set; }

        // -(void)addGestureToView:(UIView * _Nonnull)view;
        [Export("addGestureToView:")]
        void AddGestureToView(UIView view);

        // -(void)removeGestureToView:(UIView * _Nonnull)view;
        [Export("removeGestureToView:")]
        void RemoveGestureToView(UIView view);
    }

    // @interface ZFReachabilityManager : NSObject
    [BaseType(typeof(NSObject))]
    interface ZFReachabilityManager
    {
        // @property (readonly, assign, nonatomic) ZFReachabilityStatus networkReachabilityStatus;
        [Export("networkReachabilityStatus", ArgumentSemantic.Assign)]
        ZFReachabilityStatus NetworkReachabilityStatus { get; }

        // @property (readonly, getter = isReachable, assign, nonatomic) BOOL reachable;
        [Export("reachable")]
        bool Reachable { [Bind("isReachable")] get; }

        // @property (readonly, getter = isReachableViaWWAN, assign, nonatomic) BOOL reachableViaWWAN;
        [Export("reachableViaWWAN")]
        bool ReachableViaWWAN { [Bind("isReachableViaWWAN")] get; }

        // @property (readonly, getter = isReachableViaWiFi, assign, nonatomic) BOOL reachableViaWiFi;
        [Export("reachableViaWiFi")]
        bool ReachableViaWiFi { [Bind("isReachableViaWiFi")] get; }

        // +(instancetype _Nonnull)sharedManager;
        [Static]
        [Export("sharedManager")]
        ZFReachabilityManager SharedManager();

        // +(instancetype _Nonnull)manager;
        [Static]
        [Export("manager")]
        ZFReachabilityManager Manager();

        // +(instancetype _Nonnull)managerForDomain:(NSString * _Nonnull)domain;
        [Static]
        [Export("managerForDomain:")]
        ZFReachabilityManager ManagerForDomain(string domain);

        // +(instancetype _Nonnull)managerForAddress:(const void * _Nonnull)address;
        [Static]
        [Export("managerForAddress:")]
        unsafe ZFReachabilityManager ManagerForAddress(NSString address);

        // -(instancetype _Nonnull)initWithReachability:(SCNetworkReachabilityRef _Nonnull)reachability __attribute__((objc_designated_initializer));
        //[Export("initWithReachability:")]
        //[DesignatedInitializer]
        //unsafe IntPtr Constructor(NetworkReachability reachability);

        // -(void)startMonitoring;
        [Export("startMonitoring")]
        void StartMonitoring();

        // -(void)stopMonitoring;
        [Export("stopMonitoring")]
        void StopMonitoring();

        // -(NSString * _Nonnull)localizedNetworkReachabilityStatusString;
        [Export("localizedNetworkReachabilityStatusString")]
        //[Verify(MethodToProperty)]
        string LocalizedNetworkReachabilityStatusString { get; }

        // -(void)setReachabilityStatusChangeBlock:(void (^ _Nullable)(ZFReachabilityStatus))block;
        [Export("setReachabilityStatusChangeBlock:")]
        void SetReachabilityStatusChangeBlock([NullAllowed] Action<ZFReachabilityStatus> block);
    }

    //[Static]
  //  [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nonnull ZFReachabilityDidChangeNotification;
        [Field("ZFReachabilityDidChangeNotification", "__Internal")]
        NSString ZFReachabilityDidChangeNotification { get; }

        // extern NSString *const _Nonnull ZFReachabilityNotificationStatusItem;
        [Field("ZFReachabilityNotificationStatusItem", "__Internal")]
        NSString ZFReachabilityNotificationStatusItem { get; }
    }

    // @protocol ZFPlayerMediaControl <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ZFPlayerMediaControl
    {
        // @required @property (nonatomic, weak) ZFPlayerController * _Nullable player;
        [Abstract]
        [NullAllowed, Export("player", ArgumentSemantic.Weak)]
        ZFPlayerController Player { get; set; }

        // @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer prepareToPlay:(NSURL * _Nonnull)assetURL;
        [Export("videoPlayer:prepareToPlay:")]
        void VideoPlayer(ZFPlayerController videoPlayer, NSUrl assetURL);

        // @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer playStateChanged:(ZFPlayerPlaybackState)state;
        [Export("videoPlayer:playStateChanged:")]
        void VideoPlayer(ZFPlayerController videoPlayer, ZFPlayerPlaybackState state);

        // @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer loadStateChanged:(ZFPlayerLoadState)state;
        [Export("videoPlayer:loadStateChanged:")]
        void VideoPlayer(ZFPlayerController videoPlayer, ZFPlayerLoadState state);

        // @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer currentTime:(NSTimeInterval)currentTime totalTime:(NSTimeInterval)totalTime;
        [Export("videoPlayer:currentTime:totalTime:")]
        void VideoPlayer(ZFPlayerController videoPlayer, double currentTime, double totalTime);

        // @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer bufferTime:(NSTimeInterval)bufferTime;
        [Export("videoPlayer:bufferTime:")]
        void VideoPlayer(ZFPlayerController videoPlayer, double bufferTime);

        // @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer draggingTime:(NSTimeInterval)seekTime totalTime:(NSTimeInterval)totalTime;
        [Export("videoPlayer:draggingTime:totalTime:")]
        void VideoPlayerDraggingTime(ZFPlayerController videoPlayer, double seekTime, double totalTime);

        // @optional -(void)videoPlayerPlayEnd:(ZFPlayerController * _Nonnull)videoPlayer;
        [Export("videoPlayerPlayEnd:")]
        void VideoPlayerPlayEnd(ZFPlayerController videoPlayer);

        // @optional -(void)videoPlayerPlayFailed:(ZFPlayerController * _Nonnull)videoPlayer error:(id _Nonnull)error;
        [Export("videoPlayerPlayFailed:error:")]
        void VideoPlayerPlayFailed(ZFPlayerController videoPlayer, NSObject error);

        // @optional -(void)lockedVideoPlayer:(ZFPlayerController * _Nonnull)videoPlayer lockedScreen:(BOOL)locked;
        [Export("lockedVideoPlayer:lockedScreen:")]
        void LockedVideoPlayer(ZFPlayerController videoPlayer, bool locked);

        // @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer orientationWillChange:(ZFOrientationObserver * _Nonnull)observer;
        [Export("videoPlayer:orientationWillChange:")]
        void VideoPlayer(ZFPlayerController videoPlayer, ZFOrientationObserver observer);

        // @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer orientationDidChanged:(ZFOrientationObserver * _Nonnull)observer;
        [Export("videoPlayer:orientationDidChanged:")]
        void VideoPlayerOrientationDidChanged(ZFPlayerController videoPlayer, ZFOrientationObserver observer);

        // @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer reachabilityChanged:(ZFReachabilityStatus)status;
        [Export("videoPlayer:reachabilityChanged:")]
        void VideoPlayer(ZFPlayerController videoPlayer, ZFReachabilityStatus status);

        // @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer presentationSizeChanged:(CGSize)size;
        [Export("videoPlayer:presentationSizeChanged:")]
        void VideoPlayer(ZFPlayerController videoPlayer, CGSize size);

        // @optional -(BOOL)gestureTriggerCondition:(ZFPlayerGestureControl * _Nonnull)gestureControl gestureType:(ZFPlayerGestureType)gestureType gestureRecognizer:(UIGestureRecognizer * _Nonnull)gestureRecognizer touch:(UITouch * _Nonnull)touch;
        [Export("gestureTriggerCondition:gestureType:gestureRecognizer:touch:")]
        bool GestureTriggerCondition(ZFPlayerGestureControl gestureControl, ZFPlayerGestureType gestureType, UIGestureRecognizer gestureRecognizer, UITouch touch);

        // @optional -(void)gestureSingleTapped:(ZFPlayerGestureControl * _Nonnull)gestureControl;
        [Export("gestureSingleTapped:")]
        void GestureSingleTapped(ZFPlayerGestureControl gestureControl);

        // @optional -(void)gestureDoubleTapped:(ZFPlayerGestureControl * _Nonnull)gestureControl;
        [Export("gestureDoubleTapped:")]
        void GestureDoubleTapped(ZFPlayerGestureControl gestureControl);

        // @optional -(void)gestureBeganPan:(ZFPlayerGestureControl * _Nonnull)gestureControl panDirection:(ZFPanDirection)direction panLocation:(ZFPanLocation)location;
        [Export("gestureBeganPan:panDirection:panLocation:")]
        void GestureBeganPan(ZFPlayerGestureControl gestureControl, ZFPanDirection direction, ZFPanLocation location);

        // @optional -(void)gestureChangedPan:(ZFPlayerGestureControl * _Nonnull)gestureControl panDirection:(ZFPanDirection)direction panLocation:(ZFPanLocation)location withVelocity:(CGPoint)velocity;
        [Export("gestureChangedPan:panDirection:panLocation:withVelocity:")]
        void GestureChangedPan(ZFPlayerGestureControl gestureControl, ZFPanDirection direction, ZFPanLocation location, CGPoint velocity);

        // @optional -(void)gestureEndedPan:(ZFPlayerGestureControl * _Nonnull)gestureControl panDirection:(ZFPanDirection)direction panLocation:(ZFPanLocation)location;
        [Export("gestureEndedPan:panDirection:panLocation:")]
        void GestureEndedPan(ZFPlayerGestureControl gestureControl, ZFPanDirection direction, ZFPanLocation location);

        // @optional -(void)gesturePinched:(ZFPlayerGestureControl * _Nonnull)gestureControl scale:(float)scale;
        [Export("gesturePinched:scale:")]
        void GesturePinched(ZFPlayerGestureControl gestureControl, float scale);

        // @optional -(void)playerWillAppearInScrollView:(ZFPlayerController * _Nonnull)videoPlayer;
        [Export("playerWillAppearInScrollView:")]
        void PlayerWillAppearInScrollView(ZFPlayerController videoPlayer);

        // @optional -(void)playerDidAppearInScrollView:(ZFPlayerController * _Nonnull)videoPlayer;
        [Export("playerDidAppearInScrollView:")]
        void PlayerDidAppearInScrollView(ZFPlayerController videoPlayer);

        // @optional -(void)playerWillDisappearInScrollView:(ZFPlayerController * _Nonnull)videoPlayer;
        [Export("playerWillDisappearInScrollView:")]
        void PlayerWillDisappearInScrollView(ZFPlayerController videoPlayer);

        // @optional -(void)playerDidDisappearInScrollView:(ZFPlayerController * _Nonnull)videoPlayer;
        [Export("playerDidDisappearInScrollView:")]
        void PlayerDidDisappearInScrollView(ZFPlayerController videoPlayer);

        // @optional -(void)playerAppearingInScrollView:(ZFPlayerController * _Nonnull)videoPlayer playerApperaPercent:(CGFloat)playerApperaPercent;
        [Export("playerAppearingInScrollView:playerApperaPercent:")]
        void PlayerAppearingInScrollView(ZFPlayerController videoPlayer, nfloat playerApperaPercent);

        // @optional -(void)playerDisappearingInScrollView:(ZFPlayerController * _Nonnull)videoPlayer playerDisapperaPercent:(CGFloat)playerDisapperaPercent;
        [Export("playerDisappearingInScrollView:playerDisapperaPercent:")]
        void PlayerDisappearingInScrollView(ZFPlayerController videoPlayer, nfloat playerDisapperaPercent);
    }

    // @interface ZFPlayerNotification : NSObject
    [BaseType(typeof(NSObject))]
    interface ZFPlayerNotification
    {
        // @property (readonly, nonatomic) ZFPlayerBackgroundState backgroundState;
        [Export("backgroundState")]
        ZFPlayerBackgroundState BackgroundState { get; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerNotification * _Nonnull) willResignActive;
        [NullAllowed, Export("willResignActive", ArgumentSemantic.Copy)]
        Action<ZFPlayerNotification> WillResignActive { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerNotification * _Nonnull) didBecomeActive;
        [NullAllowed, Export("didBecomeActive", ArgumentSemantic.Copy)]
        Action<ZFPlayerNotification> DidBecomeActive { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerNotification * _Nonnull) newDeviceAvailable;
        [NullAllowed, Export("newDeviceAvailable", ArgumentSemantic.Copy)]
        Action<ZFPlayerNotification> NewDeviceAvailable { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerNotification * _Nonnull) oldDeviceUnavailable;
        [NullAllowed, Export("oldDeviceUnavailable", ArgumentSemantic.Copy)]
        Action<ZFPlayerNotification> OldDeviceUnavailable { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerNotification * _Nonnull) categoryChange;
        [NullAllowed, Export("categoryChange", ArgumentSemantic.Copy)]
        Action<ZFPlayerNotification> CategoryChange { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(float) volumeChanged;
        [NullAllowed, Export("volumeChanged", ArgumentSemantic.Copy)]
        Action<float> VolumeChanged { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(AVAudioSessionInterruptionType) audioInterruptionCallback;
        [NullAllowed, Export("audioInterruptionCallback", ArgumentSemantic.Copy)]
        Action<AVAudioSessionInterruptionType> AudioInterruptionCallback { get; set; }

        // -(void)addNotification;
        [Export("addNotification")]
        void AddNotification();

        // -(void)removeNotification;
        [Export("removeNotification")]
        void RemoveNotification();
    }

    // @interface ZFPlayerController : NSObject
    [BaseType(typeof(NSObject))]
    interface ZFPlayerController
    {
        // @property (nonatomic, strong) UIView * _Nonnull containerView;
        [Export("containerView", ArgumentSemantic.Strong)]
        UIView ContainerView { get; set; }

        // @property (nonatomic, strong) id<ZFPlayerMediaPlayback> _Nonnull currentPlayerManager;
        [Export("currentPlayerManager", ArgumentSemantic.Strong)]
        ZFPlayerMediaPlayback CurrentPlayerManager { get; set; }

        // @property (nonatomic, strong) UIView<ZFPlayerMediaControl> * _Nonnull controlView;
        [Export("controlView", ArgumentSemantic.Strong)]
        ZFPlayerMediaControl ControlView { get; set; }

        // @property (readonly, nonatomic, strong) ZFPlayerNotification * _Nonnull notification;
        [Export("notification", ArgumentSemantic.Strong)]
        ZFPlayerNotification Notification { get; }

        // +(instancetype _Nonnull)playerWithPlayerManager:(id<ZFPlayerMediaPlayback> _Nonnull)playerManager containerView:(UIView * _Nonnull)containerView;
        [Static]
        [Export("playerWithPlayerManager:containerView:")]
        ZFPlayerController PlayerWithPlayerManager(ZFPlayerMediaPlayback playerManager, UIView containerView);

        // -(instancetype _Nonnull)initWithPlayerManager:(id<ZFPlayerMediaPlayback> _Nonnull)playerManager containerView:(UIView * _Nonnull)containerView;
        [Export("initWithPlayerManager:containerView:")]
        IntPtr Constructor(ZFPlayerMediaPlayback playerManager, UIView containerView);

        // +(instancetype _Nonnull)playerWithScrollView:(UIScrollView * _Nonnull)scrollView playerManager:(id<ZFPlayerMediaPlayback> _Nonnull)playerManager containerViewTag:(NSInteger)containerViewTag;
        [Static]
        [Export("playerWithScrollView:playerManager:containerViewTag:")]
        ZFPlayerController PlayerWithScrollView(UIScrollView scrollView, ZFPlayerMediaPlayback playerManager, nint containerViewTag);

        // -(instancetype _Nonnull)initWithScrollView:(UIScrollView * _Nonnull)scrollView playerManager:(id<ZFPlayerMediaPlayback> _Nonnull)playerManager containerViewTag:(NSInteger)containerViewTag;
        [Export("initWithScrollView:playerManager:containerViewTag:")]
        IntPtr Constructor(UIScrollView scrollView, ZFPlayerMediaPlayback playerManager, nint containerViewTag);
    }

    // @interface ZFPlayerTimeControl (ZFPlayerController)
    //[Category]
    [BaseType(typeof(ZFPlayerController))]
    interface ZFPlayerController_ZFPlayerTimeControl
    {
        // @property (readonly, nonatomic) NSTimeInterval currentTime;
        [Export("currentTime")]
        double CurrentTime { get; }

        // @property (readonly, nonatomic) NSTimeInterval totalTime;
        [Export("totalTime")]
        double TotalTime { get; }

        // @property (readonly, nonatomic) NSTimeInterval bufferTime;
        [Export("bufferTime")]
        double BufferTime { get; }

        // @property (readonly, nonatomic) float progress;
        [Export("progress")]
        float Progress { get; }

        // @property (readonly, nonatomic) float bufferProgress;
        [Export("bufferProgress")]
        float BufferProgress { get; }

        // -(void)seekToTime:(NSTimeInterval)time completionHandler:(void (^ _Nullable)(BOOL))completionHandler;
        [Export("seekToTime:completionHandler:")]
        void SeekToTime(double time, [NullAllowed] Action<bool> completionHandler);
    }

    // @interface ZFPlayerPlaybackControl (ZFPlayerController)
    //[Category]
    [BaseType(typeof(ZFPlayerController))]
    interface ZFPlayerController_ZFPlayerPlaybackControl
    {
        // @property (nonatomic) float volume;
        [Export("volume")]
        float Volume { get; set; }

        // @property (getter = isMuted, nonatomic) BOOL muted;
        [Export("muted")]
        bool Muted { [Bind("isMuted")] get; set; }

        // @property (nonatomic) float brightness;
        [Export("brightness")]
        float Brightness { get; set; }

        // @property (nonatomic) NSURL * _Nonnull assetURL;
        [Export("assetURL", ArgumentSemantic.Assign)]
        NSUrl AssetURL { get; set; }

        // @property (copy, nonatomic) NSArray<NSURL *> * _Nullable assetURLs;
        [NullAllowed, Export("assetURLs", ArgumentSemantic.Copy)]
        NSUrl[] AssetURLs { get; set; }

        // @property (nonatomic) NSInteger currentPlayIndex;
        [Export("currentPlayIndex")]
        nint CurrentPlayIndex { get; set; }

        // @property (readonly, nonatomic) BOOL isLastAssetURL;
        [Export("isLastAssetURL")]
        bool IsLastAssetURL { get; }

        // @property (readonly, nonatomic) BOOL isFirstAssetURL;
        [Export("isFirstAssetURL")]
        bool IsFirstAssetURL { get; }

        // @property (nonatomic) BOOL pauseWhenAppResignActive;
        [Export("pauseWhenAppResignActive")]
        bool PauseWhenAppResignActive { get; set; }

        // @property (getter = isPauseByEvent, nonatomic) BOOL pauseByEvent;
        [Export("pauseByEvent")]
        bool PauseByEvent { [Bind("isPauseByEvent")] get; set; }

        // @property (getter = isViewControllerDisappear, nonatomic) BOOL viewControllerDisappear;
        [Export("viewControllerDisappear")]
        bool ViewControllerDisappear { [Bind("isViewControllerDisappear")] get; set; }

        // @property (assign, nonatomic) BOOL customAudioSession;
        [Export("customAudioSession")]
        bool CustomAudioSession { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSURL * _Nonnull) playerPrepareToPlay;
        [NullAllowed, Export("playerPrepareToPlay", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, NSUrl> PlayerPrepareToPlay { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSURL * _Nonnull) playerReadyToPlay;
        [NullAllowed, Export("playerReadyToPlay", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, NSUrl> PlayerReadyToPlay { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSTimeInterval, NSTimeInterval) playerPlayTimeChanged;
        [NullAllowed, Export("playerPlayTimeChanged", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, double, double> PlayerPlayTimeChanged { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSTimeInterval) playerBufferTimeChanged;
        [NullAllowed, Export("playerBufferTimeChanged", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, double> PlayerBufferTimeChanged { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, ZFPlayerPlaybackState) playerPlayStateChanged;
        [NullAllowed, Export("playerPlayStateChanged", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, ZFPlayerPlaybackState> PlayerPlayStateChanged { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, ZFPlayerLoadState) playerLoadStateChanged;
        [NullAllowed, Export("playerLoadStateChanged", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, ZFPlayerLoadState> PlayerLoadStateChanged { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, id _Nonnull) playerPlayFailed;
        [NullAllowed, Export("playerPlayFailed", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, NSObject> PlayerPlayFailed { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull) playerDidToEnd;
        [NullAllowed, Export("playerDidToEnd", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback> PlayerDidToEnd { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, CGSize) presentationSizeChanged;
        [NullAllowed, Export("presentationSizeChanged", ArgumentSemantic.Copy)]
        Action<ZFPlayerMediaPlayback, CGSize> PresentationSizeChanged { get; set; }

        // -(void)playTheNext;
        [Export("playTheNext")]
        void PlayTheNext();

        // -(void)playThePrevious;
        [Export("playThePrevious")]
        void PlayThePrevious();

        // -(void)playTheIndex:(NSInteger)index;
        [Export("playTheIndex:")]
        void PlayTheIndex(nint index);

        // -(void)stop;
        [Export("stop")]
        void Stop();

        // -(void)replaceCurrentPlayerManager:(id<ZFPlayerMediaPlayback> _Nonnull)manager;
        [Export("replaceCurrentPlayerManager:")]
        void ReplaceCurrentPlayerManager(ZFPlayerMediaPlayback manager);
    }

    // @interface ZFPlayerOrientationRotation (ZFPlayerController)
    //[Category]
    [BaseType(typeof(ZFPlayerController))]
    interface ZFPlayerController_ZFPlayerOrientationRotation
    {
        // @property (readonly, nonatomic) ZFOrientationObserver * _Nonnull orientationObserver;
        [Export("orientationObserver")]
        ZFOrientationObserver OrientationObserver { get; }

        // @property (readonly, nonatomic) BOOL shouldAutorotate;
        [Export("shouldAutorotate")]
        bool ShouldAutorotate { get; }

        // @property (nonatomic) BOOL allowOrentitaionRotation;
        [Export("allowOrentitaionRotation")]
        bool AllowOrentitaionRotation { get; set; }

        // @property (readonly, nonatomic) BOOL isFullScreen;
        [Export("isFullScreen")]
        bool IsFullScreen { get; }

        // @property (getter = isLockedScreen, nonatomic) BOOL lockedScreen;
        [Export("lockedScreen")]
        bool LockedScreen { [Bind("isLockedScreen")] get; set; }

        // @property (getter = isStatusBarHidden, nonatomic) BOOL statusBarHidden;
        [Export("statusBarHidden")]
        bool StatusBarHidden { [Bind("isStatusBarHidden")] get; set; }

        // @property (assign, nonatomic) BOOL forceDeviceOrientation;
        [Export("forceDeviceOrientation")]
        bool ForceDeviceOrientation { get; set; }

        // @property (readonly, nonatomic) UIInterfaceOrientation currentOrientation;
        [Export("currentOrientation")]
        UIInterfaceOrientation CurrentOrientation { get; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerController * _Nonnull, BOOL) orientationWillChange;
        [NullAllowed, Export("orientationWillChange", ArgumentSemantic.Copy)]
        Action<ZFPlayerController, bool> OrientationWillChange { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerController * _Nonnull, BOOL) orientationDidChanged;
        [NullAllowed, Export("orientationDidChanged", ArgumentSemantic.Copy)]
        Action<ZFPlayerController, bool> OrientationDidChanged { get; set; }

        // -(void)addDeviceOrientationObserver;
        [Export("addDeviceOrientationObserver")]
        void AddDeviceOrientationObserver();

        // -(void)removeDeviceOrientationObserver;
        [Export("removeDeviceOrientationObserver")]
        void RemoveDeviceOrientationObserver();

        // -(void)enterLandscapeFullScreen:(UIInterfaceOrientation)orientation animated:(BOOL)animated;
        [Export("enterLandscapeFullScreen:animated:")]
        void EnterLandscapeFullScreen(UIInterfaceOrientation orientation, bool animated);

        // -(void)enterPortraitFullScreen:(BOOL)fullScreen animated:(BOOL)animated;
        [Export("enterPortraitFullScreen:animated:")]
        void EnterPortraitFullScreen(bool fullScreen, bool animated);

        // -(void)enterFullScreen:(BOOL)fullScreen animated:(BOOL)animated;
        [Export("enterFullScreen:animated:")]
        void EnterFullScreen(bool fullScreen, bool animated);
    }

    // @interface ZFPlayerViewGesture (ZFPlayerController)
    //[Category]
    [BaseType(typeof(ZFPlayerController))]
    interface ZFPlayerController_ZFPlayerViewGesture
    {
        // @property (readonly, nonatomic) ZFPlayerGestureControl * _Nonnull gestureControl;
        [Export("gestureControl")]
        ZFPlayerGestureControl GestureControl { get; }

        // @property (assign, nonatomic) ZFPlayerDisableGestureTypes disableGestureTypes;
        [Export("disableGestureTypes", ArgumentSemantic.Assign)]
        ZFPlayerDisableGestureTypes DisableGestureTypes { get; set; }

        // @property (nonatomic) ZFPlayerDisablePanMovingDirection disablePanMovingDirection;
        [Export("disablePanMovingDirection", ArgumentSemantic.Assign)]
        ZFPlayerDisablePanMovingDirection DisablePanMovingDirection { get; set; }
    }

    // @interface ZFPlayerScrollView (ZFPlayerController)
    //[Category]
    [BaseType(typeof(ZFPlayerController))]
    interface ZFPlayerController_ZFPlayerScrollView
    {
        // @property (readonly, nonatomic) UIScrollView * _Nullable scrollView;
        [NullAllowed, Export("scrollView")]
        UIScrollView ScrollView { get; }

        // @property (nonatomic) BOOL shouldAutoPlay;
        [Export("shouldAutoPlay")]
        bool ShouldAutoPlay { get; set; }

        // @property (getter = isWWANAutoPlay, nonatomic) BOOL WWANAutoPlay;
        [Export("WWANAutoPlay")]
        bool WWANAutoPlay { [Bind("isWWANAutoPlay")] get; set; }

        // @property (readonly, nonatomic) ZFFloatView * _Nullable smallFloatView;
        [NullAllowed, Export("smallFloatView")]
        ZFFloatView SmallFloatView { get; }

        // @property (readonly, nonatomic) BOOL isSmallFloatViewShow;
        [Export("isSmallFloatViewShow")]
        bool IsSmallFloatViewShow { get; }

        // @property (readonly, nonatomic) NSIndexPath * _Nullable playingIndexPath;
        [NullAllowed, Export("playingIndexPath")]
        NSIndexPath PlayingIndexPath { get; }

        // @property (readonly, nonatomic) NSInteger containerViewTag;
        [Export("containerViewTag")]
        nint ContainerViewTag { get; }

        // @property (nonatomic) BOOL stopWhileNotVisible;
        [Export("stopWhileNotVisible")]
        bool StopWhileNotVisible { get; set; }

        // @property (nonatomic) CGFloat playerDisapperaPercent;
        [Export("playerDisapperaPercent")]
        nfloat PlayerDisapperaPercent { get; set; }

        // @property (nonatomic) CGFloat playerApperaPercent;
        [Export("playerApperaPercent")]
        nfloat PlayerApperaPercent { get; set; }

        // @property (copy, nonatomic) NSArray<NSArray<NSURL *> *> * _Nullable sectionAssetURLs;
        [NullAllowed, Export("sectionAssetURLs", ArgumentSemantic.Copy)]
        NSArray<NSUrl>[] SectionAssetURLs { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull, CGFloat) zf_playerAppearingInScrollView;
        [NullAllowed, Export("zf_playerAppearingInScrollView", ArgumentSemantic.Copy)]
        Action<NSIndexPath, nfloat> Zf_playerAppearingInScrollView { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull, CGFloat) zf_playerDisappearingInScrollView;
        [NullAllowed, Export("zf_playerDisappearingInScrollView", ArgumentSemantic.Copy)]
        Action<NSIndexPath, nfloat> Zf_playerDisappearingInScrollView { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerWillAppearInScrollView;
        [NullAllowed, Export("zf_playerWillAppearInScrollView", ArgumentSemantic.Copy)]
        Action<NSIndexPath> Zf_playerWillAppearInScrollView { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerDidAppearInScrollView;
        [NullAllowed, Export("zf_playerDidAppearInScrollView", ArgumentSemantic.Copy)]
        Action<NSIndexPath> Zf_playerDidAppearInScrollView { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerWillDisappearInScrollView;
        [NullAllowed, Export("zf_playerWillDisappearInScrollView", ArgumentSemantic.Copy)]
        Action<NSIndexPath> Zf_playerWillDisappearInScrollView { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerDidDisappearInScrollView;
        [NullAllowed, Export("zf_playerDidDisappearInScrollView", ArgumentSemantic.Copy)]
        Action<NSIndexPath> Zf_playerDidDisappearInScrollView { get; set; }

        // -(void)updateScrollViewPlayerToCell;
        [Export("updateScrollViewPlayerToCell")]
        void UpdateScrollViewPlayerToCell();

        // -(void)updateNoramlPlayerWithContainerView:(UIView * _Nonnull)containerView;
        [Export("updateNoramlPlayerWithContainerView:")]
        void UpdateNoramlPlayerWithContainerView(UIView containerView);

        // -(void)stopCurrentPlayingCell;
        [Export("stopCurrentPlayingCell")]
        void StopCurrentPlayingCell();

        // -(void)playTheIndexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("playTheIndexPath:")]
        void PlayTheIndexPath(NSIndexPath indexPath);

        // -(void)playTheIndexPath:(NSIndexPath * _Nonnull)indexPath scrollToTop:(BOOL)scrollToTop;
        [Export("playTheIndexPath:scrollToTop:")]
        void PlayTheIndexPath(NSIndexPath indexPath, bool scrollToTop);

        // -(void)playTheIndexPath:(NSIndexPath * _Nonnull)indexPath assetURL:(NSURL * _Nonnull)assetURL scrollToTop:(BOOL)scrollToTop;
        [Export("playTheIndexPath:assetURL:scrollToTop:")]
        void PlayTheIndexPath(NSIndexPath indexPath, NSUrl assetURL, bool scrollToTop);

        // -(void)playTheIndexPath:(NSIndexPath * _Nonnull)indexPath scrollToTop:(BOOL)scrollToTop completionHandler:(void (^ _Nullable)(void))completionHandler;
        [Export("playTheIndexPath:scrollToTop:completionHandler:")]
        void PlayTheIndexPath(NSIndexPath indexPath, bool scrollToTop, [NullAllowed] Action completionHandler);
    }

    // @interface ZFPlayerLogManager : NSObject
    [BaseType(typeof(NSObject))]
    interface ZFPlayerLogManager
    {
        // +(void)setLogEnable:(BOOL)enable;
        [Static]
        [Export("setLogEnable:")]
        void SetLogEnable(bool enable);

        // +(BOOL)getLogEnable;
        [Static]
        [Export("getLogEnable")]
        //[Verify(MethodToProperty)]
        bool LogEnable { get; }

        // +(NSString *)version;
        [Static]
        [Export("version")]
      //  [Verify(MethodToProperty)]
        string Version { get; }

        // +(void)logWithFunction:(const char *)function lineNumber:(int)lineNumber formatString:(NSString *)formatString;
        [Static]
        [Export("logWithFunction:lineNumber:formatString:")]
        unsafe void LogWithFunction(string function, int lineNumber, string formatString);
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    //partial interface Constants
    //{
    //    // extern double ZFPlayerVersionNumber;
    //    [Field("ZFPlayerVersionNumber", "__Internal")]
    //    double ZFPlayerVersionNumber { get; }

    //    // extern const unsigned char [] ZFPlayerVersionString;
    //    [Field("ZFPlayerVersionString", "__Internal")]
    //    byte[] ZFPlayerVersionString { get; }
    //}
}