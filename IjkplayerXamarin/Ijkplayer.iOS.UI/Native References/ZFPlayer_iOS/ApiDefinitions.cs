using System;
using AVFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using SystemConfiguration;
using UIKit;
using ZFPlayer;

namespace ZFPlayer_iOS
{
	// @interface ZFPlayerView : UIView
	[BaseType (typeof(UIView))]
	interface ZFPlayerView
	{
	}

	// @protocol ZFPlayerMediaPlayback <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ZFPlayerMediaPlayback
	{
		// @required @property (nonatomic) ZFPlayerView * _Nonnull view;
		[Abstract]
		[Export ("view", ArgumentSemantic.Assign)]
		ZFPlayerView View { get; set; }

		// @optional @property (nonatomic) float volume;
		[Export ("volume")]
		float Volume { get; set; }

		// @optional @property (getter = isMuted, nonatomic) BOOL muted;
		[Export ("muted")]
		bool Muted { [Bind ("isMuted")] get; set; }

		// @optional @property (nonatomic) float rate;
		[Export ("rate")]
		float Rate { get; set; }

		// @optional @property (readonly, nonatomic) NSTimeInterval currentTime;
		[Export ("currentTime")]
		double CurrentTime { get; }

		// @optional @property (readonly, nonatomic) NSTimeInterval totalTime;
		[Export ("totalTime")]
		double TotalTime { get; }

		// @optional @property (readonly, nonatomic) NSTimeInterval bufferTime;
		[Export ("bufferTime")]
		double BufferTime { get; }

		// @optional @property (nonatomic) NSTimeInterval seekTime;
		[Export ("seekTime")]
		double SeekTime { get; set; }

		// @optional @property (readonly, nonatomic) BOOL isPlaying;
		[Export ("isPlaying")]
		bool IsPlaying { get; }

		// @optional @property (nonatomic) ZFPlayerScalingMode scalingMode;
		[Export ("scalingMode", ArgumentSemantic.Assign)]
		ZFPlayerScalingMode ScalingMode { get; set; }

		// @optional @property (readonly, nonatomic) BOOL isPreparedToPlay;
		[Export ("isPreparedToPlay")]
		bool IsPreparedToPlay { get; }

		// @optional @property (nonatomic) NSURL * _Nonnull assetURL;
		[Export ("assetURL", ArgumentSemantic.Assign)]
		NSUrl AssetURL { get; set; }

		// @optional @property (readonly, nonatomic) CGSize presentationSize;
		[Export ("presentationSize")]
		CGSize PresentationSize { get; }

		// @optional @property (readonly, nonatomic) ZFPlayerPlaybackState playState;
		[Export ("playState")]
		ZFPlayerPlaybackState PlayState { get; }

		// @optional @property (readonly, nonatomic) ZFPlayerLoadState loadState;
		[Export ("loadState")]
		ZFPlayerLoadState LoadState { get; }

		// @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSURL * _Nonnull) playerPrepareToPlay;
		[NullAllowed, Export ("playerPrepareToPlay", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, NSURL> PlayerPrepareToPlay { get; set; }

		// @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSURL * _Nonnull) playerReadyToPlay;
		[NullAllowed, Export ("playerReadyToPlay", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, NSURL> PlayerReadyToPlay { get; set; }

		// @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSTimeInterval, NSTimeInterval) playerPlayTimeChanged;
		[NullAllowed, Export ("playerPlayTimeChanged", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, double, double> PlayerPlayTimeChanged { get; set; }

		// @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSTimeInterval) playerBufferTimeChanged;
		[NullAllowed, Export ("playerBufferTimeChanged", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, double> PlayerBufferTimeChanged { get; set; }

		// @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, ZFPlayerPlaybackState) playerPlayStateChanged;
		[NullAllowed, Export ("playerPlayStateChanged", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, ZFPlayerPlaybackState> PlayerPlayStateChanged { get; set; }

		// @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, ZFPlayerLoadState) playerLoadStateChanged;
		[NullAllowed, Export ("playerLoadStateChanged", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, ZFPlayerLoadState> PlayerLoadStateChanged { get; set; }

		// @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, id _Nonnull) playerPlayFailed;
		[NullAllowed, Export ("playerPlayFailed", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, NSObject> PlayerPlayFailed { get; set; }

		// @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull) playerDidToEnd;
		[NullAllowed, Export ("playerDidToEnd", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback> PlayerDidToEnd { get; set; }

		// @optional @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, CGSize) presentationSizeChanged;
		[NullAllowed, Export ("presentationSizeChanged", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, CGSize> PresentationSizeChanged { get; set; }

		// @optional -(void)prepareToPlay;
		[Export ("prepareToPlay")]
		void PrepareToPlay ();

		// @optional -(void)reloadPlayer;
		[Export ("reloadPlayer")]
		void ReloadPlayer ();

		// @optional -(void)play;
		[Export ("play")]
		void Play ();

		// @optional -(void)pause;
		[Export ("pause")]
		void Pause ();

		// @optional -(void)replay;
		[Export ("replay")]
		void Replay ();

		// @optional -(void)stop;
		[Export ("stop")]
		void Stop ();

		// @optional -(UIImage * _Nonnull)thumbnailImageAtCurrentTime;
		[Export ("thumbnailImageAtCurrentTime")]
		[Verify (MethodToProperty)]
		UIImage ThumbnailImageAtCurrentTime { get; }

		// @optional -(void)seekToTime:(NSTimeInterval)time completionHandler:(void (^ _Nullable)(BOOL))completionHandler;
		[Export ("seekToTime:completionHandler:")]
		void SeekToTime (double time, [NullAllowed] Action<bool> completionHandler);
	}

	// typedef void (^ZFDownLoadDataCallBack)(NSData *, NSError *);
	delegate void ZFDownLoadDataCallBack (NSData arg0, NSError arg1);

	// typedef void (^ZFDownloadProgressBlock)(unsigned long long, unsigned long long);
	delegate void ZFDownloadProgressBlock (ulong arg0, ulong arg1);

	// @interface ZFImageDownloader : NSObject <NSURLSessionDownloadDelegate>
	[BaseType (typeof(NSObject))]
	interface ZFImageDownloader : INSUrlSessionDownloadDelegate
	{
		// @property (nonatomic, strong) NSURLSession * session;
		[Export ("session", ArgumentSemantic.Strong)]
		NSUrlSession Session { get; set; }

		// @property (nonatomic, strong) NSURLSessionDownloadTask * task;
		[Export ("task", ArgumentSemantic.Strong)]
		NSUrlSessionDownloadTask Task { get; set; }

		// @property (assign, nonatomic) unsigned long long totalLength;
		[Export ("totalLength")]
		ulong TotalLength { get; set; }

		// @property (assign, nonatomic) unsigned long long currentLength;
		[Export ("currentLength")]
		ulong CurrentLength { get; set; }

		// @property (copy, nonatomic) ZFDownloadProgressBlock progressBlock;
		[Export ("progressBlock", ArgumentSemantic.Copy)]
		ZFDownloadProgressBlock ProgressBlock { get; set; }

		// @property (copy, nonatomic) ZFDownLoadDataCallBack callbackOnFinished;
		[Export ("callbackOnFinished", ArgumentSemantic.Copy)]
		ZFDownLoadDataCallBack CallbackOnFinished { get; set; }

		// -(void)startDownloadImageWithUrl:(NSString *)url progress:(ZFDownloadProgressBlock)progress finished:(ZFDownLoadDataCallBack)finished;
		[Export ("startDownloadImageWithUrl:progress:finished:")]
		void StartDownloadImageWithUrl (string url, ZFDownloadProgressBlock progress, ZFDownLoadDataCallBack finished);
	}

	// typedef void (^ZFImageBlock)(UIImage *);
	delegate void ZFImageBlock (UIImage arg0);

	// @interface ZFCache (UIImageView)
	[Category]
	[BaseType (typeof(UIImageView))]
	interface UIImageView_ZFCache
	{
		// @property (copy, nonatomic) ZFImageBlock completion;
		[Export ("completion", ArgumentSemantic.Copy)]
		ZFImageBlock Completion { get; set; }

		// @property (nonatomic, strong) ZFImageDownloader * imageDownloader;
		[Export ("imageDownloader", ArgumentSemantic.Strong)]
		ZFImageDownloader ImageDownloader { get; set; }

		// @property (assign, nonatomic) NSUInteger attemptToReloadTimesForFailedURL;
		[Export ("attemptToReloadTimesForFailedURL")]
		nuint AttemptToReloadTimesForFailedURL { get; set; }

		// @property (assign, nonatomic) BOOL shouldAutoClipImageToViewSize;
		[Export ("shouldAutoClipImageToViewSize")]
		bool ShouldAutoClipImageToViewSize { get; set; }

		// -(void)setImageWithURLString:(NSString *)url placeholderImageName:(NSString *)placeholderImageName;
		[Export ("setImageWithURLString:placeholderImageName:")]
		void SetImageWithURLString (string url, string placeholderImageName);

		// -(void)setImageWithURLString:(NSString *)url placeholder:(UIImage *)placeholderImage;
		[Export ("setImageWithURLString:placeholder:")]
		void SetImageWithURLString (string url, UIImage placeholderImage);

		// -(void)setImageWithURLString:(NSString *)url placeholder:(UIImage *)placeholderImage completion:(void (^)(UIImage *))completion;
		[Export ("setImageWithURLString:placeholder:completion:")]
		void SetImageWithURLString (string url, UIImage placeholderImage, Action<UIImage> completion);

		// -(void)setImageWithURLString:(NSString *)url placeholderImageName:(NSString *)placeholderImageName completion:(void (^)(UIImage *))completion;
		[Export ("setImageWithURLString:placeholderImageName:completion:")]
		void SetImageWithURLString (string url, string placeholderImageName, Action<UIImage> completion);
	}

	// @interface ZFPlayer (UIScrollView)
	[Category]
	[BaseType (typeof(UIScrollView))]
	interface UIScrollView_ZFPlayer
	{
		// @property (readonly, nonatomic) CGFloat zf_lastOffsetY;
		[Export ("zf_lastOffsetY")]
		nfloat Zf_lastOffsetY { get; }

		// @property (readonly, nonatomic) CGFloat zf_lastOffsetX;
		[Export ("zf_lastOffsetX")]
		nfloat Zf_lastOffsetX { get; }

		// @property (nonatomic) NSIndexPath * _Nullable zf_playingIndexPath;
		[NullAllowed, Export ("zf_playingIndexPath", ArgumentSemantic.Assign)]
		NSIndexPath Zf_playingIndexPath { get; set; }

		// @property (nonatomic) NSIndexPath * _Nullable zf_shouldPlayIndexPath;
		[NullAllowed, Export ("zf_shouldPlayIndexPath", ArgumentSemantic.Assign)]
		NSIndexPath Zf_shouldPlayIndexPath { get; set; }

		// @property (getter = zf_isWWANAutoPlay, nonatomic) BOOL zf_WWANAutoPlay;
		[Export ("zf_WWANAutoPlay")]
		bool Zf_WWANAutoPlay { [Bind ("zf_isWWANAutoPlay")] get; set; }

		// @property (nonatomic) BOOL zf_shouldAutoPlay;
		[Export ("zf_shouldAutoPlay")]
		bool Zf_shouldAutoPlay { get; set; }

		// @property (nonatomic) NSInteger zf_containerViewTag;
		[Export ("zf_containerViewTag")]
		nint Zf_containerViewTag { get; set; }

		// @property (nonatomic) ZFPlayerScrollViewDirection zf_scrollViewDirection;
		[Export ("zf_scrollViewDirection", ArgumentSemantic.Assign)]
		ZFPlayerScrollViewDirection Zf_scrollViewDirection { get; set; }

		// @property (readonly, nonatomic) ZFPlayerScrollDirection zf_scrollDirection;
		[Export ("zf_scrollDirection")]
		ZFPlayerScrollDirection Zf_scrollDirection { get; }

		// @property (assign, nonatomic) ZFPlayerContainerType zf_containerType;
		[Export ("zf_containerType", ArgumentSemantic.Assign)]
		ZFPlayerContainerType Zf_containerType { get; set; }

		// @property (nonatomic, strong) UIView * _Nonnull zf_containerView;
		[Export ("zf_containerView", ArgumentSemantic.Strong)]
		UIView Zf_containerView { get; set; }

		// @property (assign, nonatomic) BOOL zf_stopWhileNotVisible;
		[Export ("zf_stopWhileNotVisible")]
		bool Zf_stopWhileNotVisible { get; set; }

		// @property (assign, nonatomic) BOOL zf_stopPlay;
		[Export ("zf_stopPlay")]
		bool Zf_stopPlay { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_scrollViewDidStopScrollCallback;
		[NullAllowed, Export ("zf_scrollViewDidStopScrollCallback", ArgumentSemantic.Copy)]
		Action<NSIndexPath> Zf_scrollViewDidStopScrollCallback { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_shouldPlayIndexPathCallback;
		[NullAllowed, Export ("zf_shouldPlayIndexPathCallback", ArgumentSemantic.Copy)]
		Action<NSIndexPath> Zf_shouldPlayIndexPathCallback { get; set; }

		// -(void)zf_filterShouldPlayCellWhileScrolled:(void (^ _Nullable)(NSIndexPath * _Nonnull))handler;
		[Export ("zf_filterShouldPlayCellWhileScrolled:")]
		void Zf_filterShouldPlayCellWhileScrolled ([NullAllowed] Action<NSIndexPath> handler);

		// -(void)zf_filterShouldPlayCellWhileScrolling:(void (^ _Nullable)(NSIndexPath * _Nonnull))handler;
		[Export ("zf_filterShouldPlayCellWhileScrolling:")]
		void Zf_filterShouldPlayCellWhileScrolling ([NullAllowed] Action<NSIndexPath> handler);

		// -(UIView * _Nonnull)zf_getCellForIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export ("zf_getCellForIndexPath:")]
		UIView Zf_getCellForIndexPath (NSIndexPath indexPath);

		// -(void)zf_scrollToRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath completionHandler:(void (^ _Nullable)(void))completionHandler;
		[Export ("zf_scrollToRowAtIndexPath:completionHandler:")]
		void Zf_scrollToRowAtIndexPath (NSIndexPath indexPath, [NullAllowed] Action completionHandler);

		// -(void)zf_scrollToRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath animated:(BOOL)animated completionHandler:(void (^ _Nullable)(void))completionHandler;
		[Export ("zf_scrollToRowAtIndexPath:animated:completionHandler:")]
		void Zf_scrollToRowAtIndexPath (NSIndexPath indexPath, bool animated, [NullAllowed] Action completionHandler);

		// -(void)zf_scrollToRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath animateWithDuration:(NSTimeInterval)duration completionHandler:(void (^ _Nullable)(void))completionHandler;
		[Export ("zf_scrollToRowAtIndexPath:animateWithDuration:completionHandler:")]
		void Zf_scrollToRowAtIndexPath (NSIndexPath indexPath, double duration, [NullAllowed] Action completionHandler);

		// -(void)zf_scrollViewDidEndDecelerating;
		[Export ("zf_scrollViewDidEndDecelerating")]
		void Zf_scrollViewDidEndDecelerating ();

		// -(void)zf_scrollViewDidEndDraggingWillDecelerate:(BOOL)decelerate;
		[Export ("zf_scrollViewDidEndDraggingWillDecelerate:")]
		void Zf_scrollViewDidEndDraggingWillDecelerate (bool decelerate);

		// -(void)zf_scrollViewDidScrollToTop;
		[Export ("zf_scrollViewDidScrollToTop")]
		void Zf_scrollViewDidScrollToTop ();

		// -(void)zf_scrollViewDidScroll;
		[Export ("zf_scrollViewDidScroll")]
		void Zf_scrollViewDidScroll ();

		// -(void)zf_scrollViewWillBeginDragging;
		[Export ("zf_scrollViewWillBeginDragging")]
		void Zf_scrollViewWillBeginDragging ();
	}

	// @interface ZFPlayerCannotCalled (UIScrollView)
	[Category]
	[BaseType (typeof(UIScrollView))]
	interface UIScrollView_ZFPlayerCannotCalled
	{
		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull, CGFloat) zf_playerAppearingInScrollView;
		[NullAllowed, Export ("zf_playerAppearingInScrollView", ArgumentSemantic.Copy)]
		Action<NSIndexPath, nfloat> Zf_playerAppearingInScrollView { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull, CGFloat) zf_playerDisappearingInScrollView;
		[NullAllowed, Export ("zf_playerDisappearingInScrollView", ArgumentSemantic.Copy)]
		Action<NSIndexPath, nfloat> Zf_playerDisappearingInScrollView { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerWillAppearInScrollView;
		[NullAllowed, Export ("zf_playerWillAppearInScrollView", ArgumentSemantic.Copy)]
		Action<NSIndexPath> Zf_playerWillAppearInScrollView { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerDidAppearInScrollView;
		[NullAllowed, Export ("zf_playerDidAppearInScrollView", ArgumentSemantic.Copy)]
		Action<NSIndexPath> Zf_playerDidAppearInScrollView { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerWillDisappearInScrollView;
		[NullAllowed, Export ("zf_playerWillDisappearInScrollView", ArgumentSemantic.Copy)]
		Action<NSIndexPath> Zf_playerWillDisappearInScrollView { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerDidDisappearInScrollView;
		[NullAllowed, Export ("zf_playerDidDisappearInScrollView", ArgumentSemantic.Copy)]
		Action<NSIndexPath> Zf_playerDidDisappearInScrollView { get; set; }

		// @property (nonatomic) CGFloat zf_playerDisapperaPercent;
		[Export ("zf_playerDisapperaPercent")]
		nfloat Zf_playerDisapperaPercent { get; set; }

		// @property (nonatomic) CGFloat zf_playerApperaPercent;
		[Export ("zf_playerApperaPercent")]
		nfloat Zf_playerApperaPercent { get; set; }

		// @property (nonatomic) BOOL zf_viewControllerDisappear;
		[Export ("zf_viewControllerDisappear")]
		bool Zf_viewControllerDisappear { get; set; }
	}

	// @interface ZFFrame (UIView)
	[Category]
	[BaseType (typeof(UIView))]
	interface UIView_ZFFrame
	{
		// @property (nonatomic) CGFloat zf_x;
		[Export ("zf_x")]
		nfloat Zf_x { get; set; }

		// @property (nonatomic) CGFloat zf_y;
		[Export ("zf_y")]
		nfloat Zf_y { get; set; }

		// @property (nonatomic) CGFloat zf_width;
		[Export ("zf_width")]
		nfloat Zf_width { get; set; }

		// @property (nonatomic) CGFloat zf_height;
		[Export ("zf_height")]
		nfloat Zf_height { get; set; }

		// @property (nonatomic) CGFloat zf_top;
		[Export ("zf_top")]
		nfloat Zf_top { get; set; }

		// @property (nonatomic) CGFloat zf_bottom;
		[Export ("zf_bottom")]
		nfloat Zf_bottom { get; set; }

		// @property (nonatomic) CGFloat zf_left;
		[Export ("zf_left")]
		nfloat Zf_left { get; set; }

		// @property (nonatomic) CGFloat zf_right;
		[Export ("zf_right")]
		nfloat Zf_right { get; set; }

		// @property (nonatomic) CGFloat zf_centerX;
		[Export ("zf_centerX")]
		nfloat Zf_centerX { get; set; }

		// @property (nonatomic) CGFloat zf_centerY;
		[Export ("zf_centerY")]
		nfloat Zf_centerY { get; set; }

		// @property (nonatomic) CGPoint zf_origin;
		[Export ("zf_origin", ArgumentSemantic.Assign)]
		CGPoint Zf_origin { get; set; }

		// @property (nonatomic) CGSize zf_size;
		[Export ("zf_size", ArgumentSemantic.Assign)]
		CGSize Zf_size { get; set; }
	}

	// @interface ZFAVPlayerManager : NSObject <ZFPlayerMediaPlayback>
	[BaseType (typeof(NSObject))]
	interface ZFAVPlayerManager : IZFPlayerMediaPlayback
	{
		// @property (readonly, nonatomic, strong) AVURLAsset * asset;
		[Export ("asset", ArgumentSemantic.Strong)]
		AVUrlAsset Asset { get; }

		// @property (readonly, nonatomic, strong) AVPlayerItem * playerItem;
		[Export ("playerItem", ArgumentSemantic.Strong)]
		AVPlayerItem PlayerItem { get; }

		// @property (readonly, nonatomic, strong) AVPlayer * player;
		[Export ("player", ArgumentSemantic.Strong)]
		AVPlayer Player { get; }

		// @property (assign, nonatomic) NSTimeInterval timeRefreshInterval;
		[Export ("timeRefreshInterval")]
		double TimeRefreshInterval { get; set; }

		// @property (nonatomic, strong) NSDictionary * requestHeader;
		[Export ("requestHeader", ArgumentSemantic.Strong)]
		NSDictionary RequestHeader { get; set; }
	}

	// @interface ZFFloatView : UIView
	[BaseType (typeof(UIView))]
	interface ZFFloatView
	{
		// @property (nonatomic, weak) UIView * parentView;
		[Export ("parentView", ArgumentSemantic.Weak)]
		UIView ParentView { get; set; }

		// @property (assign, nonatomic) UIEdgeInsets safeInsets;
		[Export ("safeInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets SafeInsets { get; set; }
	}

	// @interface ZFKVOController : NSObject
	[BaseType (typeof(NSObject))]
	interface ZFKVOController
	{
		// -(instancetype)initWithTarget:(NSObject *)target;
		[Export ("initWithTarget:")]
		IntPtr Constructor (NSObject target);

		// -(void)safelyAddObserver:(NSObject *)observer forKeyPath:(NSString *)keyPath options:(NSKeyValueObservingOptions)options context:(void *)context;
		[Export ("safelyAddObserver:forKeyPath:options:context:")]
		unsafe void SafelyAddObserver (NSObject observer, string keyPath, NSKeyValueObservingOptions options, void* context);

		// -(void)safelyRemoveObserver:(NSObject *)observer forKeyPath:(NSString *)keyPath;
		[Export ("safelyRemoveObserver:forKeyPath:")]
		void SafelyRemoveObserver (NSObject observer, string keyPath);

		// -(void)safelyRemoveAllObservers;
		[Export ("safelyRemoveAllObservers")]
		void SafelyRemoveAllObservers ();
	}

	// @interface ZFOrientationObserver : NSObject
	[BaseType (typeof(NSObject))]
	interface ZFOrientationObserver
	{
		// -(void)updateRotateView:(UIView * _Nonnull)rotateView containerView:(UIView * _Nonnull)containerView;
		[Export ("updateRotateView:containerView:")]
		void UpdateRotateView (UIView rotateView, UIView containerView);

		// -(void)cellModelRotateView:(UIView * _Nonnull)rotateView rotateViewAtCell:(UIView * _Nonnull)cell playerViewTag:(NSInteger)playerViewTag;
		[Export ("cellModelRotateView:rotateViewAtCell:playerViewTag:")]
		void CellModelRotateView (UIView rotateView, UIView cell, nint playerViewTag);

		// -(void)cellOtherModelRotateView:(UIView * _Nonnull)rotateView containerView:(UIView * _Nonnull)containerView;
		[Export ("cellOtherModelRotateView:containerView:")]
		void CellOtherModelRotateView (UIView rotateView, UIView containerView);

		// @property (nonatomic, strong) UIView * _Nonnull fullScreenContainerView;
		[Export ("fullScreenContainerView", ArgumentSemantic.Strong)]
		UIView FullScreenContainerView { get; set; }

		// @property (nonatomic, weak) UIView * _Nullable containerView;
		[NullAllowed, Export ("containerView", ArgumentSemantic.Weak)]
		UIView ContainerView { get; set; }

		// @property (readonly, getter = isFullScreen, nonatomic) BOOL fullScreen;
		[Export ("fullScreen")]
		bool FullScreen { [Bind ("isFullScreen")] get; }

		// @property (assign, nonatomic) BOOL forceDeviceOrientation;
		[Export ("forceDeviceOrientation")]
		bool ForceDeviceOrientation { get; set; }

		// @property (getter = isLockedScreen, nonatomic) BOOL lockedScreen;
		[Export ("lockedScreen")]
		bool LockedScreen { [Bind ("isLockedScreen")] get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFOrientationObserver * _Nonnull, BOOL) orientationWillChange;
		[NullAllowed, Export ("orientationWillChange", ArgumentSemantic.Copy)]
		Action<ZFOrientationObserver, bool> OrientationWillChange { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFOrientationObserver * _Nonnull, BOOL) orientationDidChanged;
		[NullAllowed, Export ("orientationDidChanged", ArgumentSemantic.Copy)]
		Action<ZFOrientationObserver, bool> OrientationDidChanged { get; set; }

		// @property (nonatomic) ZFFullScreenMode fullScreenMode;
		[Export ("fullScreenMode", ArgumentSemantic.Assign)]
		ZFFullScreenMode FullScreenMode { get; set; }

		// @property (nonatomic) float duration;
		[Export ("duration")]
		float Duration { get; set; }

		// @property (getter = isStatusBarHidden, nonatomic) BOOL statusBarHidden;
		[Export ("statusBarHidden")]
		bool StatusBarHidden { [Bind ("isStatusBarHidden")] get; set; }

		// @property (readonly, nonatomic) UIInterfaceOrientation currentOrientation;
		[Export ("currentOrientation")]
		UIInterfaceOrientation CurrentOrientation { get; }

		// @property (nonatomic) BOOL allowOrentitaionRotation;
		[Export ("allowOrentitaionRotation")]
		bool AllowOrentitaionRotation { get; set; }

		// @property (assign, nonatomic) ZFInterfaceOrientationMask supportInterfaceOrientation;
		[Export ("supportInterfaceOrientation", ArgumentSemantic.Assign)]
		ZFInterfaceOrientationMask SupportInterfaceOrientation { get; set; }

		// -(void)addDeviceOrientationObserver;
		[Export ("addDeviceOrientationObserver")]
		void AddDeviceOrientationObserver ();

		// -(void)removeDeviceOrientationObserver;
		[Export ("removeDeviceOrientationObserver")]
		void RemoveDeviceOrientationObserver ();

		// -(void)enterLandscapeFullScreen:(UIInterfaceOrientation)orientation animated:(BOOL)animated;
		[Export ("enterLandscapeFullScreen:animated:")]
		void EnterLandscapeFullScreen (UIInterfaceOrientation orientation, bool animated);

		// -(void)enterPortraitFullScreen:(BOOL)fullScreen animated:(BOOL)animated;
		[Export ("enterPortraitFullScreen:animated:")]
		void EnterPortraitFullScreen (bool fullScreen, bool animated);

		// -(void)exitFullScreenWithAnimated:(BOOL)animated;
		[Export ("exitFullScreenWithAnimated:")]
		void ExitFullScreenWithAnimated (bool animated);
	}

	// @interface ZFPlayerGestureControl : NSObject
	[BaseType (typeof(NSObject))]
	interface ZFPlayerGestureControl
	{
		// @property (copy, nonatomic) BOOL (^ _Nullable)(ZFPlayerGestureControl * _Nonnull, ZFPlayerGestureType, UIGestureRecognizer * _Nonnull, UITouch * _Nonnull) triggerCondition;
		[NullAllowed, Export ("triggerCondition", ArgumentSemantic.Copy)]
		Func<ZFPlayerGestureControl, ZFPlayerGestureType, UIGestureRecognizer, UITouch, bool> TriggerCondition { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerGestureControl * _Nonnull) singleTapped;
		[NullAllowed, Export ("singleTapped", ArgumentSemantic.Copy)]
		Action<ZFPlayerGestureControl> SingleTapped { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerGestureControl * _Nonnull) doubleTapped;
		[NullAllowed, Export ("doubleTapped", ArgumentSemantic.Copy)]
		Action<ZFPlayerGestureControl> DoubleTapped { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerGestureControl * _Nonnull, ZFPanDirection, ZFPanLocation) beganPan;
		[NullAllowed, Export ("beganPan", ArgumentSemantic.Copy)]
		Action<ZFPlayerGestureControl, ZFPanDirection, ZFPanLocation> BeganPan { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerGestureControl * _Nonnull, ZFPanDirection, ZFPanLocation, CGPoint) changedPan;
		[NullAllowed, Export ("changedPan", ArgumentSemantic.Copy)]
		Action<ZFPlayerGestureControl, ZFPanDirection, ZFPanLocation, CGPoint> ChangedPan { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerGestureControl * _Nonnull, ZFPanDirection, ZFPanLocation) endedPan;
		[NullAllowed, Export ("endedPan", ArgumentSemantic.Copy)]
		Action<ZFPlayerGestureControl, ZFPanDirection, ZFPanLocation> EndedPan { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerGestureControl * _Nonnull, float) pinched;
		[NullAllowed, Export ("pinched", ArgumentSemantic.Copy)]
		Action<ZFPlayerGestureControl, float> Pinched { get; set; }

		// @property (readonly, nonatomic, strong) UITapGestureRecognizer * _Nonnull singleTap;
		[Export ("singleTap", ArgumentSemantic.Strong)]
		UITapGestureRecognizer SingleTap { get; }

		// @property (readonly, nonatomic, strong) UITapGestureRecognizer * _Nonnull doubleTap;
		[Export ("doubleTap", ArgumentSemantic.Strong)]
		UITapGestureRecognizer DoubleTap { get; }

		// @property (readonly, nonatomic, strong) UIPanGestureRecognizer * _Nonnull panGR;
		[Export ("panGR", ArgumentSemantic.Strong)]
		UIPanGestureRecognizer PanGR { get; }

		// @property (readonly, nonatomic, strong) UIPinchGestureRecognizer * _Nonnull pinchGR;
		[Export ("pinchGR", ArgumentSemantic.Strong)]
		UIPinchGestureRecognizer PinchGR { get; }

		// @property (readonly, nonatomic) ZFPanDirection panDirection;
		[Export ("panDirection")]
		ZFPanDirection PanDirection { get; }

		// @property (readonly, nonatomic) ZFPanLocation panLocation;
		[Export ("panLocation")]
		ZFPanLocation PanLocation { get; }

		// @property (readonly, nonatomic) ZFPanMovingDirection panMovingDirection;
		[Export ("panMovingDirection")]
		ZFPanMovingDirection PanMovingDirection { get; }

		// @property (nonatomic) ZFPlayerDisableGestureTypes disableTypes;
		[Export ("disableTypes", ArgumentSemantic.Assign)]
		ZFPlayerDisableGestureTypes DisableTypes { get; set; }

		// @property (nonatomic) ZFPlayerDisablePanMovingDirection disablePanMovingDirection;
		[Export ("disablePanMovingDirection", ArgumentSemantic.Assign)]
		ZFPlayerDisablePanMovingDirection DisablePanMovingDirection { get; set; }

		// -(void)addGestureToView:(UIView * _Nonnull)view;
		[Export ("addGestureToView:")]
		void AddGestureToView (UIView view);

		// -(void)removeGestureToView:(UIView * _Nonnull)view;
		[Export ("removeGestureToView:")]
		void RemoveGestureToView (UIView view);
	}

	// @interface ZFReachabilityManager : NSObject
	[BaseType (typeof(NSObject))]
	interface ZFReachabilityManager
	{
		// @property (readonly, assign, nonatomic) ZFReachabilityStatus networkReachabilityStatus;
		[Export ("networkReachabilityStatus", ArgumentSemantic.Assign)]
		ZFReachabilityStatus NetworkReachabilityStatus { get; }

		// @property (readonly, getter = isReachable, assign, nonatomic) BOOL reachable;
		[Export ("reachable")]
		bool Reachable { [Bind ("isReachable")] get; }

		// @property (readonly, getter = isReachableViaWWAN, assign, nonatomic) BOOL reachableViaWWAN;
		[Export ("reachableViaWWAN")]
		bool ReachableViaWWAN { [Bind ("isReachableViaWWAN")] get; }

		// @property (readonly, getter = isReachableViaWiFi, assign, nonatomic) BOOL reachableViaWiFi;
		[Export ("reachableViaWiFi")]
		bool ReachableViaWiFi { [Bind ("isReachableViaWiFi")] get; }

		// +(instancetype _Nonnull)sharedManager;
		[Static]
		[Export ("sharedManager")]
		ZFReachabilityManager SharedManager ();

		// +(instancetype _Nonnull)manager;
		[Static]
		[Export ("manager")]
		ZFReachabilityManager Manager ();

		// +(instancetype _Nonnull)managerForDomain:(NSString * _Nonnull)domain;
		[Static]
		[Export ("managerForDomain:")]
		ZFReachabilityManager ManagerForDomain (string domain);

		// +(instancetype _Nonnull)managerForAddress:(const void * _Nonnull)address;
		[Static]
		[Export ("managerForAddress:")]
		unsafe ZFReachabilityManager ManagerForAddress (void* address);

		// -(instancetype _Nonnull)initWithReachability:(SCNetworkReachabilityRef _Nonnull)reachability __attribute__((objc_designated_initializer));
		[Export ("initWithReachability:")]
		[DesignatedInitializer]
		unsafe IntPtr Constructor (SCNetworkReachabilityRef* reachability);

		// -(void)startMonitoring;
		[Export ("startMonitoring")]
		void StartMonitoring ();

		// -(void)stopMonitoring;
		[Export ("stopMonitoring")]
		void StopMonitoring ();

		// -(NSString * _Nonnull)localizedNetworkReachabilityStatusString;
		[Export ("localizedNetworkReachabilityStatusString")]
		[Verify (MethodToProperty)]
		string LocalizedNetworkReachabilityStatusString { get; }

		// -(void)setReachabilityStatusChangeBlock:(void (^ _Nullable)(ZFReachabilityStatus))block;
		[Export ("setReachabilityStatusChangeBlock:")]
		void SetReachabilityStatusChangeBlock ([NullAllowed] Action<ZFReachabilityStatus> block);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull ZFReachabilityDidChangeNotification;
		[Field ("ZFReachabilityDidChangeNotification", "__Internal")]
		NSString ZFReachabilityDidChangeNotification { get; }

		// extern NSString *const _Nonnull ZFReachabilityNotificationStatusItem;
		[Field ("ZFReachabilityNotificationStatusItem", "__Internal")]
		NSString ZFReachabilityNotificationStatusItem { get; }
	}

	// @protocol ZFPlayerMediaControl <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ZFPlayerMediaControl
	{
		// @required @property (nonatomic, weak) ZFPlayerController * _Nullable player;
		[Abstract]
		[NullAllowed, Export ("player", ArgumentSemantic.Weak)]
		ZFPlayerController Player { get; set; }

		// @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer prepareToPlay:(NSURL * _Nonnull)assetURL;
		[Export ("videoPlayer:prepareToPlay:")]
		void VideoPlayer (ZFPlayerController videoPlayer, NSUrl assetURL);

		// @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer playStateChanged:(ZFPlayerPlaybackState)state;
		[Export ("videoPlayer:playStateChanged:")]
		void VideoPlayer (ZFPlayerController videoPlayer, ZFPlayerPlaybackState state);

		// @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer loadStateChanged:(ZFPlayerLoadState)state;
		[Export ("videoPlayer:loadStateChanged:")]
		void VideoPlayer (ZFPlayerController videoPlayer, ZFPlayerLoadState state);

		// @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer currentTime:(NSTimeInterval)currentTime totalTime:(NSTimeInterval)totalTime;
		[Export ("videoPlayer:currentTime:totalTime:")]
		void VideoPlayer (ZFPlayerController videoPlayer, double currentTime, double totalTime);

		// @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer bufferTime:(NSTimeInterval)bufferTime;
		[Export ("videoPlayer:bufferTime:")]
		void VideoPlayer (ZFPlayerController videoPlayer, double bufferTime);

		// @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer draggingTime:(NSTimeInterval)seekTime totalTime:(NSTimeInterval)totalTime;
		[Export ("videoPlayer:draggingTime:totalTime:")]
		void VideoPlayer (ZFPlayerController videoPlayer, double seekTime, double totalTime);

		// @optional -(void)videoPlayerPlayEnd:(ZFPlayerController * _Nonnull)videoPlayer;
		[Export ("videoPlayerPlayEnd:")]
		void VideoPlayerPlayEnd (ZFPlayerController videoPlayer);

		// @optional -(void)videoPlayerPlayFailed:(ZFPlayerController * _Nonnull)videoPlayer error:(id _Nonnull)error;
		[Export ("videoPlayerPlayFailed:error:")]
		void VideoPlayerPlayFailed (ZFPlayerController videoPlayer, NSObject error);

		// @optional -(void)lockedVideoPlayer:(ZFPlayerController * _Nonnull)videoPlayer lockedScreen:(BOOL)locked;
		[Export ("lockedVideoPlayer:lockedScreen:")]
		void LockedVideoPlayer (ZFPlayerController videoPlayer, bool locked);

		// @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer orientationWillChange:(ZFOrientationObserver * _Nonnull)observer;
		[Export ("videoPlayer:orientationWillChange:")]
		void VideoPlayer (ZFPlayerController videoPlayer, ZFOrientationObserver observer);

		// @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer orientationDidChanged:(ZFOrientationObserver * _Nonnull)observer;
		[Export ("videoPlayer:orientationDidChanged:")]
		void VideoPlayer (ZFPlayerController videoPlayer, ZFOrientationObserver observer);

		// @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer reachabilityChanged:(ZFReachabilityStatus)status;
		[Export ("videoPlayer:reachabilityChanged:")]
		void VideoPlayer (ZFPlayerController videoPlayer, ZFReachabilityStatus status);

		// @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer presentationSizeChanged:(CGSize)size;
		[Export ("videoPlayer:presentationSizeChanged:")]
		void VideoPlayer (ZFPlayerController videoPlayer, CGSize size);

		// @optional -(BOOL)gestureTriggerCondition:(ZFPlayerGestureControl * _Nonnull)gestureControl gestureType:(ZFPlayerGestureType)gestureType gestureRecognizer:(UIGestureRecognizer * _Nonnull)gestureRecognizer touch:(UITouch * _Nonnull)touch;
		[Export ("gestureTriggerCondition:gestureType:gestureRecognizer:touch:")]
		bool GestureTriggerCondition (ZFPlayerGestureControl gestureControl, ZFPlayerGestureType gestureType, UIGestureRecognizer gestureRecognizer, UITouch touch);

		// @optional -(void)gestureSingleTapped:(ZFPlayerGestureControl * _Nonnull)gestureControl;
		[Export ("gestureSingleTapped:")]
		void GestureSingleTapped (ZFPlayerGestureControl gestureControl);

		// @optional -(void)gestureDoubleTapped:(ZFPlayerGestureControl * _Nonnull)gestureControl;
		[Export ("gestureDoubleTapped:")]
		void GestureDoubleTapped (ZFPlayerGestureControl gestureControl);

		// @optional -(void)gestureBeganPan:(ZFPlayerGestureControl * _Nonnull)gestureControl panDirection:(ZFPanDirection)direction panLocation:(ZFPanLocation)location;
		[Export ("gestureBeganPan:panDirection:panLocation:")]
		void GestureBeganPan (ZFPlayerGestureControl gestureControl, ZFPanDirection direction, ZFPanLocation location);

		// @optional -(void)gestureChangedPan:(ZFPlayerGestureControl * _Nonnull)gestureControl panDirection:(ZFPanDirection)direction panLocation:(ZFPanLocation)location withVelocity:(CGPoint)velocity;
		[Export ("gestureChangedPan:panDirection:panLocation:withVelocity:")]
		void GestureChangedPan (ZFPlayerGestureControl gestureControl, ZFPanDirection direction, ZFPanLocation location, CGPoint velocity);

		// @optional -(void)gestureEndedPan:(ZFPlayerGestureControl * _Nonnull)gestureControl panDirection:(ZFPanDirection)direction panLocation:(ZFPanLocation)location;
		[Export ("gestureEndedPan:panDirection:panLocation:")]
		void GestureEndedPan (ZFPlayerGestureControl gestureControl, ZFPanDirection direction, ZFPanLocation location);

		// @optional -(void)gesturePinched:(ZFPlayerGestureControl * _Nonnull)gestureControl scale:(float)scale;
		[Export ("gesturePinched:scale:")]
		void GesturePinched (ZFPlayerGestureControl gestureControl, float scale);

		// @optional -(void)playerWillAppearInScrollView:(ZFPlayerController * _Nonnull)videoPlayer;
		[Export ("playerWillAppearInScrollView:")]
		void PlayerWillAppearInScrollView (ZFPlayerController videoPlayer);

		// @optional -(void)playerDidAppearInScrollView:(ZFPlayerController * _Nonnull)videoPlayer;
		[Export ("playerDidAppearInScrollView:")]
		void PlayerDidAppearInScrollView (ZFPlayerController videoPlayer);

		// @optional -(void)playerWillDisappearInScrollView:(ZFPlayerController * _Nonnull)videoPlayer;
		[Export ("playerWillDisappearInScrollView:")]
		void PlayerWillDisappearInScrollView (ZFPlayerController videoPlayer);

		// @optional -(void)playerDidDisappearInScrollView:(ZFPlayerController * _Nonnull)videoPlayer;
		[Export ("playerDidDisappearInScrollView:")]
		void PlayerDidDisappearInScrollView (ZFPlayerController videoPlayer);

		// @optional -(void)playerAppearingInScrollView:(ZFPlayerController * _Nonnull)videoPlayer playerApperaPercent:(CGFloat)playerApperaPercent;
		[Export ("playerAppearingInScrollView:playerApperaPercent:")]
		void PlayerAppearingInScrollView (ZFPlayerController videoPlayer, nfloat playerApperaPercent);

		// @optional -(void)playerDisappearingInScrollView:(ZFPlayerController * _Nonnull)videoPlayer playerDisapperaPercent:(CGFloat)playerDisapperaPercent;
		[Export ("playerDisappearingInScrollView:playerDisapperaPercent:")]
		void PlayerDisappearingInScrollView (ZFPlayerController videoPlayer, nfloat playerDisapperaPercent);

		// @optional -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer floatViewShow:(BOOL)show;
		[Export ("videoPlayer:floatViewShow:")]
		void VideoPlayer (ZFPlayerController videoPlayer, bool show);
	}

	// @interface ZFPlayerNotification : NSObject
	[BaseType (typeof(NSObject))]
	interface ZFPlayerNotification
	{
		// @property (readonly, nonatomic) ZFPlayerBackgroundState backgroundState;
		[Export ("backgroundState")]
		ZFPlayerBackgroundState BackgroundState { get; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerNotification * _Nonnull) willResignActive;
		[NullAllowed, Export ("willResignActive", ArgumentSemantic.Copy)]
		Action<ZFPlayerNotification> WillResignActive { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerNotification * _Nonnull) didBecomeActive;
		[NullAllowed, Export ("didBecomeActive", ArgumentSemantic.Copy)]
		Action<ZFPlayerNotification> DidBecomeActive { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerNotification * _Nonnull) newDeviceAvailable;
		[NullAllowed, Export ("newDeviceAvailable", ArgumentSemantic.Copy)]
		Action<ZFPlayerNotification> NewDeviceAvailable { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerNotification * _Nonnull) oldDeviceUnavailable;
		[NullAllowed, Export ("oldDeviceUnavailable", ArgumentSemantic.Copy)]
		Action<ZFPlayerNotification> OldDeviceUnavailable { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerNotification * _Nonnull) categoryChange;
		[NullAllowed, Export ("categoryChange", ArgumentSemantic.Copy)]
		Action<ZFPlayerNotification> CategoryChange { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(float) volumeChanged;
		[NullAllowed, Export ("volumeChanged", ArgumentSemantic.Copy)]
		Action<float> VolumeChanged { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(AVAudioSessionInterruptionType) audioInterruptionCallback;
		[NullAllowed, Export ("audioInterruptionCallback", ArgumentSemantic.Copy)]
		Action<AVAudioSessionInterruptionType> AudioInterruptionCallback { get; set; }

		// -(void)addNotification;
		[Export ("addNotification")]
		void AddNotification ();

		// -(void)removeNotification;
		[Export ("removeNotification")]
		void RemoveNotification ();
	}

	// @interface ZFPlayerController : NSObject
	[BaseType (typeof(NSObject))]
	interface ZFPlayerController
	{
		// @property (nonatomic, strong) UIView * _Nonnull containerView;
		[Export ("containerView", ArgumentSemantic.Strong)]
		UIView ContainerView { get; set; }

		// @property (nonatomic, strong) id<ZFPlayerMediaPlayback> _Nonnull currentPlayerManager;
		[Export ("currentPlayerManager", ArgumentSemantic.Strong)]
		ZFPlayerMediaPlayback CurrentPlayerManager { get; set; }

		// @property (nonatomic, strong) UIView<ZFPlayerMediaControl> * _Nonnull controlView;
		[Export ("controlView", ArgumentSemantic.Strong)]
		ZFPlayerMediaControl ControlView { get; set; }

		// @property (readonly, nonatomic, strong) ZFPlayerNotification * _Nonnull notification;
		[Export ("notification", ArgumentSemantic.Strong)]
		ZFPlayerNotification Notification { get; }

		// @property (readonly, assign, nonatomic) ZFPlayerContainerType containerType;
		[Export ("containerType", ArgumentSemantic.Assign)]
		ZFPlayerContainerType ContainerType { get; }

		// @property (readonly, nonatomic, strong) ZFFloatView * _Nonnull smallFloatView;
		[Export ("smallFloatView", ArgumentSemantic.Strong)]
		ZFFloatView SmallFloatView { get; }

		// @property (readonly, assign, nonatomic) BOOL isSmallFloatViewShow;
		[Export ("isSmallFloatViewShow")]
		bool IsSmallFloatViewShow { get; }

		// +(instancetype _Nonnull)playerWithPlayerManager:(id<ZFPlayerMediaPlayback> _Nonnull)playerManager containerView:(UIView * _Nonnull)containerView;
		[Static]
		[Export ("playerWithPlayerManager:containerView:")]
		ZFPlayerController PlayerWithPlayerManager (ZFPlayerMediaPlayback playerManager, UIView containerView);

		// -(instancetype _Nonnull)initWithPlayerManager:(id<ZFPlayerMediaPlayback> _Nonnull)playerManager containerView:(UIView * _Nonnull)containerView;
		[Export ("initWithPlayerManager:containerView:")]
		IntPtr Constructor (ZFPlayerMediaPlayback playerManager, UIView containerView);

		// +(instancetype _Nonnull)playerWithScrollView:(UIScrollView * _Nonnull)scrollView playerManager:(id<ZFPlayerMediaPlayback> _Nonnull)playerManager containerViewTag:(NSInteger)containerViewTag;
		[Static]
		[Export ("playerWithScrollView:playerManager:containerViewTag:")]
		ZFPlayerController PlayerWithScrollView (UIScrollView scrollView, ZFPlayerMediaPlayback playerManager, nint containerViewTag);

		// -(instancetype _Nonnull)initWithScrollView:(UIScrollView * _Nonnull)scrollView playerManager:(id<ZFPlayerMediaPlayback> _Nonnull)playerManager containerViewTag:(NSInteger)containerViewTag;
		[Export ("initWithScrollView:playerManager:containerViewTag:")]
		IntPtr Constructor (UIScrollView scrollView, ZFPlayerMediaPlayback playerManager, nint containerViewTag);

		// +(instancetype _Nonnull)playerWithScrollView:(UIScrollView * _Nonnull)scrollView playerManager:(id<ZFPlayerMediaPlayback> _Nonnull)playerManager containerView:(UIView * _Nonnull)containerView;
		[Static]
		[Export ("playerWithScrollView:playerManager:containerView:")]
		ZFPlayerController PlayerWithScrollView (UIScrollView scrollView, ZFPlayerMediaPlayback playerManager, UIView containerView);

		// -(instancetype _Nonnull)initWithScrollView:(UIScrollView * _Nonnull)scrollView playerManager:(id<ZFPlayerMediaPlayback> _Nonnull)playerManager containerView:(UIView * _Nonnull)containerView;
		[Export ("initWithScrollView:playerManager:containerView:")]
		IntPtr Constructor (UIScrollView scrollView, ZFPlayerMediaPlayback playerManager, UIView containerView);
	}

	// @interface ZFPlayerTimeControl (ZFPlayerController)
	[Category]
	[BaseType (typeof(ZFPlayerController))]
	interface ZFPlayerController_ZFPlayerTimeControl
	{
		// @property (readonly, nonatomic) NSTimeInterval currentTime;
		[Export ("currentTime")]
		double CurrentTime { get; }

		// @property (readonly, nonatomic) NSTimeInterval totalTime;
		[Export ("totalTime")]
		double TotalTime { get; }

		// @property (readonly, nonatomic) NSTimeInterval bufferTime;
		[Export ("bufferTime")]
		double BufferTime { get; }

		// @property (readonly, nonatomic) float progress;
		[Export ("progress")]
		float Progress { get; }

		// @property (readonly, nonatomic) float bufferProgress;
		[Export ("bufferProgress")]
		float BufferProgress { get; }

		// -(void)seekToTime:(NSTimeInterval)time completionHandler:(void (^ _Nullable)(BOOL))completionHandler;
		[Export ("seekToTime:completionHandler:")]
		void SeekToTime (double time, [NullAllowed] Action<bool> completionHandler);
	}

	// @interface ZFPlayerPlaybackControl (ZFPlayerController)
	[Category]
	[BaseType (typeof(ZFPlayerController))]
	interface ZFPlayerController_ZFPlayerPlaybackControl
	{
		// @property (nonatomic) float volume;
		[Export ("volume")]
		float Volume { get; set; }

		// @property (getter = isMuted, nonatomic) BOOL muted;
		[Export ("muted")]
		bool Muted { [Bind ("isMuted")] get; set; }

		// @property (nonatomic) float brightness;
		[Export ("brightness")]
		float Brightness { get; set; }

		// @property (nonatomic) NSURL * _Nonnull assetURL;
		[Export ("assetURL", ArgumentSemantic.Assign)]
		NSUrl AssetURL { get; set; }

		// @property (copy, nonatomic) NSArray<NSURL *> * _Nullable assetURLs;
		[NullAllowed, Export ("assetURLs", ArgumentSemantic.Copy)]
		NSUrl[] AssetURLs { get; set; }

		// @property (nonatomic) NSInteger currentPlayIndex;
		[Export ("currentPlayIndex")]
		nint CurrentPlayIndex { get; set; }

		// @property (readonly, nonatomic) BOOL isLastAssetURL;
		[Export ("isLastAssetURL")]
		bool IsLastAssetURL { get; }

		// @property (readonly, nonatomic) BOOL isFirstAssetURL;
		[Export ("isFirstAssetURL")]
		bool IsFirstAssetURL { get; }

		// @property (nonatomic) BOOL pauseWhenAppResignActive;
		[Export ("pauseWhenAppResignActive")]
		bool PauseWhenAppResignActive { get; set; }

		// @property (getter = isPauseByEvent, nonatomic) BOOL pauseByEvent;
		[Export ("pauseByEvent")]
		bool PauseByEvent { [Bind ("isPauseByEvent")] get; set; }

		// @property (getter = isViewControllerDisappear, nonatomic) BOOL viewControllerDisappear;
		[Export ("viewControllerDisappear")]
		bool ViewControllerDisappear { [Bind ("isViewControllerDisappear")] get; set; }

		// @property (assign, nonatomic) BOOL customAudioSession;
		[Export ("customAudioSession")]
		bool CustomAudioSession { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSURL * _Nonnull) playerPrepareToPlay;
		[NullAllowed, Export ("playerPrepareToPlay", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, NSURL> PlayerPrepareToPlay { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSURL * _Nonnull) playerReadyToPlay;
		[NullAllowed, Export ("playerReadyToPlay", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, NSURL> PlayerReadyToPlay { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSTimeInterval, NSTimeInterval) playerPlayTimeChanged;
		[NullAllowed, Export ("playerPlayTimeChanged", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, double, double> PlayerPlayTimeChanged { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, NSTimeInterval) playerBufferTimeChanged;
		[NullAllowed, Export ("playerBufferTimeChanged", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, double> PlayerBufferTimeChanged { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, ZFPlayerPlaybackState) playerPlayStateChanged;
		[NullAllowed, Export ("playerPlayStateChanged", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, ZFPlayerPlaybackState> PlayerPlayStateChanged { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, ZFPlayerLoadState) playerLoadStateChanged;
		[NullAllowed, Export ("playerLoadStateChanged", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, ZFPlayerLoadState> PlayerLoadStateChanged { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, id _Nonnull) playerPlayFailed;
		[NullAllowed, Export ("playerPlayFailed", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, NSObject> PlayerPlayFailed { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull) playerDidToEnd;
		[NullAllowed, Export ("playerDidToEnd", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback> PlayerDidToEnd { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(id<ZFPlayerMediaPlayback> _Nonnull, CGSize) presentationSizeChanged;
		[NullAllowed, Export ("presentationSizeChanged", ArgumentSemantic.Copy)]
		Action<ZFPlayerMediaPlayback, CGSize> PresentationSizeChanged { get; set; }

		// -(void)playTheNext;
		[Export ("playTheNext")]
		void PlayTheNext ();

		// -(void)playThePrevious;
		[Export ("playThePrevious")]
		void PlayThePrevious ();

		// -(void)playTheIndex:(NSInteger)index;
		[Export ("playTheIndex:")]
		void PlayTheIndex (nint index);

		// -(void)stop;
		[Export ("stop")]
		void Stop ();

		// -(void)replaceCurrentPlayerManager:(id<ZFPlayerMediaPlayback> _Nonnull)manager;
		[Export ("replaceCurrentPlayerManager:")]
		void ReplaceCurrentPlayerManager (ZFPlayerMediaPlayback manager);

		// -(void)addPlayerViewToCell;
		[Export ("addPlayerViewToCell")]
		void AddPlayerViewToCell ();

		// -(void)addPlayerViewToContainerView:(UIView * _Nonnull)containerView;
		[Export ("addPlayerViewToContainerView:")]
		void AddPlayerViewToContainerView (UIView containerView);

		// -(void)addPlayerViewToKeyWindow;
		[Export ("addPlayerViewToKeyWindow")]
		void AddPlayerViewToKeyWindow ();

		// -(void)stopCurrentPlayingView;
		[Export ("stopCurrentPlayingView")]
		void StopCurrentPlayingView ();

		// -(void)stopCurrentPlayingCell;
		[Export ("stopCurrentPlayingCell")]
		void StopCurrentPlayingCell ();
	}

	// @interface ZFPlayerOrientationRotation (ZFPlayerController)
	[Category]
	[BaseType (typeof(ZFPlayerController))]
	interface ZFPlayerController_ZFPlayerOrientationRotation
	{
		// @property (readonly, nonatomic) ZFOrientationObserver * _Nonnull orientationObserver;
		[Export ("orientationObserver")]
		ZFOrientationObserver OrientationObserver { get; }

		// @property (readonly, nonatomic) BOOL shouldAutorotate;
		[Export ("shouldAutorotate")]
		bool ShouldAutorotate { get; }

		// @property (nonatomic) BOOL allowOrentitaionRotation;
		[Export ("allowOrentitaionRotation")]
		bool AllowOrentitaionRotation { get; set; }

		// @property (readonly, nonatomic) BOOL isFullScreen;
		[Export ("isFullScreen")]
		bool IsFullScreen { get; }

		// @property (getter = isLockedScreen, nonatomic) BOOL lockedScreen;
		[Export ("lockedScreen")]
		bool LockedScreen { [Bind ("isLockedScreen")] get; set; }

		// @property (getter = isStatusBarHidden, nonatomic) BOOL statusBarHidden;
		[Export ("statusBarHidden")]
		bool StatusBarHidden { [Bind ("isStatusBarHidden")] get; set; }

		// @property (assign, nonatomic) BOOL forceDeviceOrientation;
		[Export ("forceDeviceOrientation")]
		bool ForceDeviceOrientation { get; set; }

		// @property (readonly, nonatomic) UIInterfaceOrientation currentOrientation;
		[Export ("currentOrientation")]
		UIInterfaceOrientation CurrentOrientation { get; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerController * _Nonnull, BOOL) orientationWillChange;
		[NullAllowed, Export ("orientationWillChange", ArgumentSemantic.Copy)]
		Action<ZFPlayerController, bool> OrientationWillChange { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(ZFPlayerController * _Nonnull, BOOL) orientationDidChanged;
		[NullAllowed, Export ("orientationDidChanged", ArgumentSemantic.Copy)]
		Action<ZFPlayerController, bool> OrientationDidChanged { get; set; }

		// -(void)addDeviceOrientationObserver;
		[Export ("addDeviceOrientationObserver")]
		void AddDeviceOrientationObserver ();

		// -(void)removeDeviceOrientationObserver;
		[Export ("removeDeviceOrientationObserver")]
		void RemoveDeviceOrientationObserver ();

		// -(void)enterLandscapeFullScreen:(UIInterfaceOrientation)orientation animated:(BOOL)animated;
		[Export ("enterLandscapeFullScreen:animated:")]
		void EnterLandscapeFullScreen (UIInterfaceOrientation orientation, bool animated);

		// -(void)enterPortraitFullScreen:(BOOL)fullScreen animated:(BOOL)animated;
		[Export ("enterPortraitFullScreen:animated:")]
		void EnterPortraitFullScreen (bool fullScreen, bool animated);

		// -(void)enterFullScreen:(BOOL)fullScreen animated:(BOOL)animated;
		[Export ("enterFullScreen:animated:")]
		void EnterFullScreen (bool fullScreen, bool animated);
	}

	// @interface ZFPlayerViewGesture (ZFPlayerController)
	[Category]
	[BaseType (typeof(ZFPlayerController))]
	interface ZFPlayerController_ZFPlayerViewGesture
	{
		// @property (readonly, nonatomic) ZFPlayerGestureControl * _Nonnull gestureControl;
		[Export ("gestureControl")]
		ZFPlayerGestureControl GestureControl { get; }

		// @property (assign, nonatomic) ZFPlayerDisableGestureTypes disableGestureTypes;
		[Export ("disableGestureTypes", ArgumentSemantic.Assign)]
		ZFPlayerDisableGestureTypes DisableGestureTypes { get; set; }

		// @property (nonatomic) ZFPlayerDisablePanMovingDirection disablePanMovingDirection;
		[Export ("disablePanMovingDirection", ArgumentSemantic.Assign)]
		ZFPlayerDisablePanMovingDirection DisablePanMovingDirection { get; set; }
	}

	// @interface ZFPlayerScrollView (ZFPlayerController)
	[Category]
	[BaseType (typeof(ZFPlayerController))]
	interface ZFPlayerController_ZFPlayerScrollView
	{
		// @property (readonly, nonatomic) UIScrollView * _Nullable scrollView;
		[NullAllowed, Export ("scrollView")]
		UIScrollView ScrollView { get; }

		// @property (nonatomic) BOOL shouldAutoPlay;
		[Export ("shouldAutoPlay")]
		bool ShouldAutoPlay { get; set; }

		// @property (getter = isWWANAutoPlay, nonatomic) BOOL WWANAutoPlay;
		[Export ("WWANAutoPlay")]
		bool WWANAutoPlay { [Bind ("isWWANAutoPlay")] get; set; }

		// @property (readonly, nonatomic) NSIndexPath * _Nullable playingIndexPath;
		[NullAllowed, Export ("playingIndexPath")]
		NSIndexPath PlayingIndexPath { get; }

		// @property (readonly, nonatomic) NSInteger containerViewTag;
		[Export ("containerViewTag")]
		nint ContainerViewTag { get; }

		// @property (nonatomic) BOOL stopWhileNotVisible;
		[Export ("stopWhileNotVisible")]
		bool StopWhileNotVisible { get; set; }

		// @property (nonatomic) CGFloat playerDisapperaPercent;
		[Export ("playerDisapperaPercent")]
		nfloat PlayerDisapperaPercent { get; set; }

		// @property (nonatomic) CGFloat playerApperaPercent;
		[Export ("playerApperaPercent")]
		nfloat PlayerApperaPercent { get; set; }

		// @property (copy, nonatomic) NSArray<NSArray<NSURL *> *> * _Nullable sectionAssetURLs;
		[NullAllowed, Export ("sectionAssetURLs", ArgumentSemantic.Copy)]
		NSArray<NSURL>[] SectionAssetURLs { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull, CGFloat) zf_playerAppearingInScrollView;
		[NullAllowed, Export ("zf_playerAppearingInScrollView", ArgumentSemantic.Copy)]
		Action<NSIndexPath, nfloat> Zf_playerAppearingInScrollView { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull, CGFloat) zf_playerDisappearingInScrollView;
		[NullAllowed, Export ("zf_playerDisappearingInScrollView", ArgumentSemantic.Copy)]
		Action<NSIndexPath, nfloat> Zf_playerDisappearingInScrollView { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerWillAppearInScrollView;
		[NullAllowed, Export ("zf_playerWillAppearInScrollView", ArgumentSemantic.Copy)]
		Action<NSIndexPath> Zf_playerWillAppearInScrollView { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerDidAppearInScrollView;
		[NullAllowed, Export ("zf_playerDidAppearInScrollView", ArgumentSemantic.Copy)]
		Action<NSIndexPath> Zf_playerDidAppearInScrollView { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerWillDisappearInScrollView;
		[NullAllowed, Export ("zf_playerWillDisappearInScrollView", ArgumentSemantic.Copy)]
		Action<NSIndexPath> Zf_playerWillDisappearInScrollView { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSIndexPath * _Nonnull) zf_playerDidDisappearInScrollView;
		[NullAllowed, Export ("zf_playerDidDisappearInScrollView", ArgumentSemantic.Copy)]
		Action<NSIndexPath> Zf_playerDidDisappearInScrollView { get; set; }

		// -(void)playTheIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export ("playTheIndexPath:")]
		void PlayTheIndexPath (NSIndexPath indexPath);

		// -(void)playTheIndexPath:(NSIndexPath * _Nonnull)indexPath scrollToTop:(BOOL)scrollToTop;
		[Export ("playTheIndexPath:scrollToTop:")]
		void PlayTheIndexPath (NSIndexPath indexPath, bool scrollToTop);

		// -(void)playTheIndexPath:(NSIndexPath * _Nonnull)indexPath assetURL:(NSURL * _Nonnull)assetURL scrollToTop:(BOOL)scrollToTop;
		[Export ("playTheIndexPath:assetURL:scrollToTop:")]
		void PlayTheIndexPath (NSIndexPath indexPath, NSUrl assetURL, bool scrollToTop);

		// -(void)playTheIndexPath:(NSIndexPath * _Nonnull)indexPath scrollToTop:(BOOL)scrollToTop completionHandler:(void (^ _Nullable)(void))completionHandler;
		[Export ("playTheIndexPath:scrollToTop:completionHandler:")]
		void PlayTheIndexPath (NSIndexPath indexPath, bool scrollToTop, [NullAllowed] Action completionHandler);
	}

	// @interface ZFPlayerDeprecated (ZFPlayerController)
	[Category]
	[BaseType (typeof(ZFPlayerController))]
	interface ZFPlayerController_ZFPlayerDeprecated
	{
		// -(void)updateScrollViewPlayerToCell __attribute__((deprecated("use `addPlayerViewToCell:` instead.")));
		[Export ("updateScrollViewPlayerToCell")]
		void UpdateScrollViewPlayerToCell ();

		// -(void)updateNoramlPlayerWithContainerView:(UIView * _Nonnull)containerView __attribute__((deprecated("use `addPlayerViewToContainerView:` instead.")));
		[Export ("updateNoramlPlayerWithContainerView:")]
		void UpdateNoramlPlayerWithContainerView (UIView containerView);
	}

	// @protocol ZFSliderViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ZFSliderViewDelegate
	{
		// @optional -(void)sliderTouchBegan:(float)value;
		[Export ("sliderTouchBegan:")]
		void SliderTouchBegan (float value);

		// @optional -(void)sliderValueChanged:(float)value;
		[Export ("sliderValueChanged:")]
		void SliderValueChanged (float value);

		// @optional -(void)sliderTouchEnded:(float)value;
		[Export ("sliderTouchEnded:")]
		void SliderTouchEnded (float value);

		// @optional -(void)sliderTapped:(float)value;
		[Export ("sliderTapped:")]
		void SliderTapped (float value);
	}

	// @interface ZFSliderButton : UIButton
	[BaseType (typeof(UIButton))]
	interface ZFSliderButton
	{
	}

	// @interface ZFSliderView : UIView
	[BaseType (typeof(UIView))]
	interface ZFSliderView
	{
		[Wrap ("WeakDelegate")]
		ZFSliderViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ZFSliderViewDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ZFSliderButton * sliderBtn;
		[Export ("sliderBtn", ArgumentSemantic.Strong)]
		ZFSliderButton SliderBtn { get; }

		// @property (nonatomic, strong) UIColor * maximumTrackTintColor;
		[Export ("maximumTrackTintColor", ArgumentSemantic.Strong)]
		UIColor MaximumTrackTintColor { get; set; }

		// @property (nonatomic, strong) UIColor * minimumTrackTintColor;
		[Export ("minimumTrackTintColor", ArgumentSemantic.Strong)]
		UIColor MinimumTrackTintColor { get; set; }

		// @property (nonatomic, strong) UIColor * bufferTrackTintColor;
		[Export ("bufferTrackTintColor", ArgumentSemantic.Strong)]
		UIColor BufferTrackTintColor { get; set; }

		// @property (nonatomic, strong) UIColor * loadingTintColor;
		[Export ("loadingTintColor", ArgumentSemantic.Strong)]
		UIColor LoadingTintColor { get; set; }

		// @property (nonatomic, strong) UIImage * maximumTrackImage;
		[Export ("maximumTrackImage", ArgumentSemantic.Strong)]
		UIImage MaximumTrackImage { get; set; }

		// @property (nonatomic, strong) UIImage * minimumTrackImage;
		[Export ("minimumTrackImage", ArgumentSemantic.Strong)]
		UIImage MinimumTrackImage { get; set; }

		// @property (nonatomic, strong) UIImage * bufferTrackImage;
		[Export ("bufferTrackImage", ArgumentSemantic.Strong)]
		UIImage BufferTrackImage { get; set; }

		// @property (assign, nonatomic) float value;
		[Export ("value")]
		float Value { get; set; }

		// @property (assign, nonatomic) float bufferValue;
		[Export ("bufferValue")]
		float BufferValue { get; set; }

		// @property (assign, nonatomic) BOOL allowTapped;
		[Export ("allowTapped")]
		bool AllowTapped { get; set; }

		// @property (assign, nonatomic) BOOL animate;
		[Export ("animate")]
		bool Animate { get; set; }

		// @property (assign, nonatomic) CGFloat sliderHeight;
		[Export ("sliderHeight")]
		nfloat SliderHeight { get; set; }

		// @property (assign, nonatomic) BOOL isHideSliderBlock;
		[Export ("isHideSliderBlock")]
		bool IsHideSliderBlock { get; set; }

		// @property (assign, nonatomic) BOOL isdragging;
		[Export ("isdragging")]
		bool Isdragging { get; set; }

		// @property (assign, nonatomic) BOOL isForward;
		[Export ("isForward")]
		bool IsForward { get; set; }

		// @property (assign, nonatomic) CGSize thumbSize;
		[Export ("thumbSize", ArgumentSemantic.Assign)]
		CGSize ThumbSize { get; set; }

		// -(void)startAnimating;
		[Export ("startAnimating")]
		void StartAnimating ();

		// -(void)stopAnimating;
		[Export ("stopAnimating")]
		void StopAnimating ();

		// -(void)setBackgroundImage:(UIImage *)image forState:(UIControlState)state;
		[Export ("setBackgroundImage:forState:")]
		void SetBackgroundImage (UIImage image, UIControlState state);

		// -(void)setThumbImage:(UIImage *)image forState:(UIControlState)state;
		[Export ("setThumbImage:forState:")]
		void SetThumbImage (UIImage image, UIControlState state);
	}

	// @interface ZFLandScapeControlView : UIView
	[BaseType (typeof(UIView))]
	interface ZFLandScapeControlView
	{
		// @property (readonly, nonatomic, strong) UIView * _Nonnull topToolView;
		[Export ("topToolView", ArgumentSemantic.Strong)]
		UIView TopToolView { get; }

		// @property (readonly, nonatomic, strong) UIButton * _Nonnull backBtn;
		[Export ("backBtn", ArgumentSemantic.Strong)]
		UIButton BackBtn { get; }

		// @property (readonly, nonatomic, strong) UILabel * _Nonnull titleLabel;
		[Export ("titleLabel", ArgumentSemantic.Strong)]
		UILabel TitleLabel { get; }

		// @property (readonly, nonatomic, strong) UIView * _Nonnull bottomToolView;
		[Export ("bottomToolView", ArgumentSemantic.Strong)]
		UIView BottomToolView { get; }

		// @property (readonly, nonatomic, strong) UIButton * _Nonnull playOrPauseBtn;
		[Export ("playOrPauseBtn", ArgumentSemantic.Strong)]
		UIButton PlayOrPauseBtn { get; }

		// @property (readonly, nonatomic, strong) UILabel * _Nonnull currentTimeLabel;
		[Export ("currentTimeLabel", ArgumentSemantic.Strong)]
		UILabel CurrentTimeLabel { get; }

		// @property (readonly, nonatomic, strong) ZFSliderView * _Nonnull slider;
		[Export ("slider", ArgumentSemantic.Strong)]
		ZFSliderView Slider { get; }

		// @property (readonly, nonatomic, strong) UILabel * _Nonnull totalTimeLabel;
		[Export ("totalTimeLabel", ArgumentSemantic.Strong)]
		UILabel TotalTimeLabel { get; }

		// @property (readonly, nonatomic, strong) UIButton * _Nonnull lockBtn;
		[Export ("lockBtn", ArgumentSemantic.Strong)]
		UIButton LockBtn { get; }

		// @property (nonatomic, weak) ZFPlayerController * _Nullable player;
		[NullAllowed, Export ("player", ArgumentSemantic.Weak)]
		ZFPlayerController Player { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(CGFloat, BOOL) sliderValueChanging;
		[NullAllowed, Export ("sliderValueChanging", ArgumentSemantic.Copy)]
		Action<nfloat, bool> SliderValueChanging { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(CGFloat) sliderValueChanged;
		[NullAllowed, Export ("sliderValueChanged", ArgumentSemantic.Copy)]
		Action<nfloat> SliderValueChanged { get; set; }

		// @property (copy, nonatomic) void (^ _Nonnull)(void) backBtnClickCallback;
		[Export ("backBtnClickCallback", ArgumentSemantic.Copy)]
		Action BackBtnClickCallback { get; set; }

		// @property (assign, nonatomic) BOOL seekToPlay;
		[Export ("seekToPlay")]
		bool SeekToPlay { get; set; }

		// -(void)resetControlView;
		[Export ("resetControlView")]
		void ResetControlView ();

		// -(void)showControlView;
		[Export ("showControlView")]
		void ShowControlView ();

		// -(void)hideControlView;
		[Export ("hideControlView")]
		void HideControlView ();

		// -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer currentTime:(NSTimeInterval)currentTime totalTime:(NSTimeInterval)totalTime;
		[Export ("videoPlayer:currentTime:totalTime:")]
		void VideoPlayer (ZFPlayerController videoPlayer, double currentTime, double totalTime);

		// -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer bufferTime:(NSTimeInterval)bufferTime;
		[Export ("videoPlayer:bufferTime:")]
		void VideoPlayer (ZFPlayerController videoPlayer, double bufferTime);

		// -(BOOL)shouldResponseGestureWithPoint:(CGPoint)point withGestureType:(ZFPlayerGestureType)type touch:(UITouch * _Nonnull)touch;
		[Export ("shouldResponseGestureWithPoint:withGestureType:touch:")]
		bool ShouldResponseGestureWithPoint (CGPoint point, ZFPlayerGestureType type, UITouch touch);

		// -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer presentationSizeChanged:(CGSize)size;
		[Export ("videoPlayer:presentationSizeChanged:")]
		void VideoPlayer (ZFPlayerController videoPlayer, CGSize size);

		// -(void)showTitle:(NSString * _Nullable)title fullScreenMode:(ZFFullScreenMode)fullScreenMode;
		[Export ("showTitle:fullScreenMode:")]
		void ShowTitle ([NullAllowed] string title, ZFFullScreenMode fullScreenMode);

		// -(void)playOrPause;
		[Export ("playOrPause")]
		void PlayOrPause ();

		// -(void)playBtnSelectedState:(BOOL)selected;
		[Export ("playBtnSelectedState:")]
		void PlayBtnSelectedState (bool selected);

		// -(void)sliderValueChanged:(CGFloat)value currentTimeString:(NSString * _Nonnull)timeString;
		[Export ("sliderValueChanged:currentTimeString:")]
		void SliderValueChanged (nfloat value, string timeString);

		// -(void)sliderChangeEnded;
		[Export ("sliderChangeEnded")]
		void SliderChangeEnded ();
	}

	// @interface ZFLoadingView : UIView
	[BaseType (typeof(UIView))]
	interface ZFLoadingView
	{
		// @property (assign, nonatomic) ZFLoadingType animType;
		[Export ("animType", ArgumentSemantic.Assign)]
		ZFLoadingType AnimType { get; set; }

		// @property (nonatomic, strong) UIColor * _Null_unspecified lineColor;
		[Export ("lineColor", ArgumentSemantic.Strong)]
		UIColor LineColor { get; set; }

		// @property (nonatomic) CGFloat lineWidth;
		[Export ("lineWidth")]
		nfloat LineWidth { get; set; }

		// @property (nonatomic) BOOL hidesWhenStopped;
		[Export ("hidesWhenStopped")]
		bool HidesWhenStopped { get; set; }

		// @property (readwrite, nonatomic) NSTimeInterval duration;
		[Export ("duration")]
		double Duration { get; set; }

		// @property (readonly, getter = isAnimating, assign, nonatomic) BOOL animating;
		[Export ("animating")]
		bool Animating { [Bind ("isAnimating")] get; }

		// -(void)startAnimating;
		[Export ("startAnimating")]
		void StartAnimating ();

		// -(void)stopAnimating;
		[Export ("stopAnimating")]
		void StopAnimating ();
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const ZFDownloadNetworkSpeedNotificationKey;
		[Field ("ZFDownloadNetworkSpeedNotificationKey", "__Internal")]
		NSString ZFDownloadNetworkSpeedNotificationKey { get; }

		// extern NSString *const ZFUploadNetworkSpeedNotificationKey;
		[Field ("ZFUploadNetworkSpeedNotificationKey", "__Internal")]
		NSString ZFUploadNetworkSpeedNotificationKey { get; }

		// extern NSString *const ZFNetworkSpeedNotificationKey;
		[Field ("ZFNetworkSpeedNotificationKey", "__Internal")]
		NSString ZFNetworkSpeedNotificationKey { get; }
	}

	// @interface ZFNetworkSpeedMonitor : NSObject
	[BaseType (typeof(NSObject))]
	interface ZFNetworkSpeedMonitor
	{
		// @property (readonly, copy, nonatomic) NSString * downloadNetworkSpeed;
		[Export ("downloadNetworkSpeed")]
		string DownloadNetworkSpeed { get; }

		// @property (readonly, copy, nonatomic) NSString * uploadNetworkSpeed;
		[Export ("uploadNetworkSpeed")]
		string UploadNetworkSpeed { get; }

		// -(void)startNetworkSpeedMonitor;
		[Export ("startNetworkSpeedMonitor")]
		void StartNetworkSpeedMonitor ();

		// -(void)stopNetworkSpeedMonitor;
		[Export ("stopNetworkSpeedMonitor")]
		void StopNetworkSpeedMonitor ();
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double ZFPlayerVersionNumber;
		[Field ("ZFPlayerVersionNumber", "__Internal")]
		double ZFPlayerVersionNumber { get; }

		// extern const unsigned char [] ZFPlayerVersionString;
		[Field ("ZFPlayerVersionString", "__Internal")]
		byte[] ZFPlayerVersionString { get; }
	}

	// @interface ZFPortraitControlView : UIView
	[BaseType (typeof(UIView))]
	interface ZFPortraitControlView
	{
		// @property (readonly, nonatomic, strong) UIView * _Nonnull bottomToolView;
		[Export ("bottomToolView", ArgumentSemantic.Strong)]
		UIView BottomToolView { get; }

		// @property (readonly, nonatomic, strong) UIView * _Nonnull topToolView;
		[Export ("topToolView", ArgumentSemantic.Strong)]
		UIView TopToolView { get; }

		// @property (readonly, nonatomic, strong) UILabel * _Nonnull titleLabel;
		[Export ("titleLabel", ArgumentSemantic.Strong)]
		UILabel TitleLabel { get; }

		// @property (readonly, nonatomic, strong) UIButton * _Nonnull playOrPauseBtn;
		[Export ("playOrPauseBtn", ArgumentSemantic.Strong)]
		UIButton PlayOrPauseBtn { get; }

		// @property (readonly, nonatomic, strong) UILabel * _Nonnull currentTimeLabel;
		[Export ("currentTimeLabel", ArgumentSemantic.Strong)]
		UILabel CurrentTimeLabel { get; }

		// @property (readonly, nonatomic, strong) ZFSliderView * _Nonnull slider;
		[Export ("slider", ArgumentSemantic.Strong)]
		ZFSliderView Slider { get; }

		// @property (readonly, nonatomic, strong) UILabel * _Nonnull totalTimeLabel;
		[Export ("totalTimeLabel", ArgumentSemantic.Strong)]
		UILabel TotalTimeLabel { get; }

		// @property (readonly, nonatomic, strong) UIButton * _Nonnull fullScreenBtn;
		[Export ("fullScreenBtn", ArgumentSemantic.Strong)]
		UIButton FullScreenBtn { get; }

		// @property (nonatomic, weak) ZFPlayerController * _Nullable player;
		[NullAllowed, Export ("player", ArgumentSemantic.Weak)]
		ZFPlayerController Player { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(CGFloat, BOOL) sliderValueChanging;
		[NullAllowed, Export ("sliderValueChanging", ArgumentSemantic.Copy)]
		Action<nfloat, bool> SliderValueChanging { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(CGFloat) sliderValueChanged;
		[NullAllowed, Export ("sliderValueChanged", ArgumentSemantic.Copy)]
		Action<nfloat> SliderValueChanged { get; set; }

		// @property (assign, nonatomic) BOOL seekToPlay;
		[Export ("seekToPlay")]
		bool SeekToPlay { get; set; }

		// -(void)resetControlView;
		[Export ("resetControlView")]
		void ResetControlView ();

		// -(void)showControlView;
		[Export ("showControlView")]
		void ShowControlView ();

		// -(void)hideControlView;
		[Export ("hideControlView")]
		void HideControlView ();

		// -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer currentTime:(NSTimeInterval)currentTime totalTime:(NSTimeInterval)totalTime;
		[Export ("videoPlayer:currentTime:totalTime:")]
		void VideoPlayer (ZFPlayerController videoPlayer, double currentTime, double totalTime);

		// -(void)videoPlayer:(ZFPlayerController * _Nonnull)videoPlayer bufferTime:(NSTimeInterval)bufferTime;
		[Export ("videoPlayer:bufferTime:")]
		void VideoPlayer (ZFPlayerController videoPlayer, double bufferTime);

		// -(BOOL)shouldResponseGestureWithPoint:(CGPoint)point withGestureType:(ZFPlayerGestureType)type touch:(UITouch * _Nonnull)touch;
		[Export ("shouldResponseGestureWithPoint:withGestureType:touch:")]
		bool ShouldResponseGestureWithPoint (CGPoint point, ZFPlayerGestureType type, UITouch touch);

		// -(void)showTitle:(NSString * _Nullable)title fullScreenMode:(ZFFullScreenMode)fullScreenMode;
		[Export ("showTitle:fullScreenMode:")]
		void ShowTitle ([NullAllowed] string title, ZFFullScreenMode fullScreenMode);

		// -(void)playOrPause;
		[Export ("playOrPause")]
		void PlayOrPause ();

		// -(void)playBtnSelectedState:(BOOL)selected;
		[Export ("playBtnSelectedState:")]
		void PlayBtnSelectedState (bool selected);

		// -(void)sliderValueChanged:(CGFloat)value currentTimeString:(NSString * _Nonnull)timeString;
		[Export ("sliderValueChanged:currentTimeString:")]
		void SliderValueChanged (nfloat value, string timeString);

		// -(void)sliderChangeEnded;
		[Export ("sliderChangeEnded")]
		void SliderChangeEnded ();
	}

	// @interface ZFSpeedLoadingView : UIView
	[BaseType (typeof(UIView))]
	interface ZFSpeedLoadingView
	{
		// @property (nonatomic, strong) ZFLoadingView * loadingView;
		[Export ("loadingView", ArgumentSemantic.Strong)]
		ZFLoadingView LoadingView { get; set; }

		// @property (nonatomic, strong) UILabel * speedTextLabel;
		[Export ("speedTextLabel", ArgumentSemantic.Strong)]
		UILabel SpeedTextLabel { get; set; }

		// -(void)startAnimating;
		[Export ("startAnimating")]
		void StartAnimating ();

		// -(void)stopAnimating;
		[Export ("stopAnimating")]
		void StopAnimating ();
	}

	// @interface ZFPlayerControlView : UIView <ZFPlayerMediaControl>
	[BaseType (typeof(UIView))]
	interface ZFPlayerControlView : IZFPlayerMediaControl
	{
		// @property (readonly, nonatomic, strong) ZFPortraitControlView * portraitControlView;
		[Export ("portraitControlView", ArgumentSemantic.Strong)]
		ZFPortraitControlView PortraitControlView { get; }

		// @property (readonly, nonatomic, strong) ZFLandScapeControlView * landScapeControlView;
		[Export ("landScapeControlView", ArgumentSemantic.Strong)]
		ZFLandScapeControlView LandScapeControlView { get; }

		// @property (readonly, nonatomic, strong) ZFSpeedLoadingView * activity;
		[Export ("activity", ArgumentSemantic.Strong)]
		ZFSpeedLoadingView Activity { get; }

		// @property (readonly, nonatomic, strong) UIView * fastView;
		[Export ("fastView", ArgumentSemantic.Strong)]
		UIView FastView { get; }

		// @property (readonly, nonatomic, strong) ZFSliderView * fastProgressView;
		[Export ("fastProgressView", ArgumentSemantic.Strong)]
		ZFSliderView FastProgressView { get; }

		// @property (readonly, nonatomic, strong) UILabel * fastTimeLabel;
		[Export ("fastTimeLabel", ArgumentSemantic.Strong)]
		UILabel FastTimeLabel { get; }

		// @property (readonly, nonatomic, strong) UIImageView * fastImageView;
		[Export ("fastImageView", ArgumentSemantic.Strong)]
		UIImageView FastImageView { get; }

		// @property (readonly, nonatomic, strong) UIButton * failBtn;
		[Export ("failBtn", ArgumentSemantic.Strong)]
		UIButton FailBtn { get; }

		// @property (readonly, nonatomic, strong) ZFSliderView * bottomPgrogress;
		[Export ("bottomPgrogress", ArgumentSemantic.Strong)]
		ZFSliderView BottomPgrogress { get; }

		// @property (readonly, nonatomic, strong) UIImageView * coverImageView;
		[Export ("coverImageView", ArgumentSemantic.Strong)]
		UIImageView CoverImageView { get; }

		// @property (readonly, nonatomic, strong) UIImageView * bgImgView;
		[Export ("bgImgView", ArgumentSemantic.Strong)]
		UIImageView BgImgView { get; }

		// @property (readonly, nonatomic, strong) UIView * effectView;
		[Export ("effectView", ArgumentSemantic.Strong)]
		UIView EffectView { get; }

		// @property (assign, nonatomic) BOOL fastViewAnimated;
		[Export ("fastViewAnimated")]
		bool FastViewAnimated { get; set; }

		// @property (assign, nonatomic) BOOL effectViewShow;
		[Export ("effectViewShow")]
		bool EffectViewShow { get; set; }

		// @property (assign, nonatomic) BOOL fullScreenOnly;
		[Export ("fullScreenOnly")]
		bool FullScreenOnly { get; set; }

		// @property (assign, nonatomic) BOOL seekToPlay;
		[Export ("seekToPlay")]
		bool SeekToPlay { get; set; }

		// @property (copy, nonatomic) void (^backBtnClickCallback)();
		[Export ("backBtnClickCallback", ArgumentSemantic.Copy)]
		Action BackBtnClickCallback { get; set; }

		// @property (readonly, nonatomic) BOOL controlViewAppeared;
		[Export ("controlViewAppeared")]
		bool ControlViewAppeared { get; }

		// @property (copy, nonatomic) void (^controlViewAppearedCallback)(BOOL);
		[Export ("controlViewAppearedCallback", ArgumentSemantic.Copy)]
		Action<bool> ControlViewAppearedCallback { get; set; }

		// @property (assign, nonatomic) NSTimeInterval autoHiddenTimeInterval;
		[Export ("autoHiddenTimeInterval")]
		double AutoHiddenTimeInterval { get; set; }

		// @property (assign, nonatomic) NSTimeInterval autoFadeTimeInterval;
		[Export ("autoFadeTimeInterval")]
		double AutoFadeTimeInterval { get; set; }

		// @property (assign, nonatomic) BOOL horizontalPanShowControlView;
		[Export ("horizontalPanShowControlView")]
		bool HorizontalPanShowControlView { get; set; }

		// @property (assign, nonatomic) BOOL prepareShowLoading;
		[Export ("prepareShowLoading")]
		bool PrepareShowLoading { get; set; }

		// @property (assign, nonatomic) BOOL customDisablePanMovingDirection;
		[Export ("customDisablePanMovingDirection")]
		bool CustomDisablePanMovingDirection { get; set; }

		// -(void)showTitle:(NSString *)title coverURLString:(NSString *)coverUrl fullScreenMode:(ZFFullScreenMode)fullScreenMode;
		[Export ("showTitle:coverURLString:fullScreenMode:")]
		void ShowTitle (string title, string coverUrl, ZFFullScreenMode fullScreenMode);

		// -(void)showTitle:(NSString *)title coverURLString:(NSString *)coverUrl placeholderImage:(UIImage *)placeholder fullScreenMode:(ZFFullScreenMode)fullScreenMode;
		[Export ("showTitle:coverURLString:placeholderImage:fullScreenMode:")]
		void ShowTitle (string title, string coverUrl, UIImage placeholder, ZFFullScreenMode fullScreenMode);

		// -(void)showTitle:(NSString *)title coverImage:(UIImage *)image fullScreenMode:(ZFFullScreenMode)fullScreenMode;
		[Export ("showTitle:coverImage:fullScreenMode:")]
		void ShowTitle (string title, UIImage image, ZFFullScreenMode fullScreenMode);

		// -(void)resetControlView;
		[Export ("resetControlView")]
		void ResetControlView ();
	}

	// @interface ZFPlayerLogManager : NSObject
	[BaseType (typeof(NSObject))]
	interface ZFPlayerLogManager
	{
		// +(void)setLogEnable:(BOOL)enable;
		[Static]
		[Export ("setLogEnable:")]
		void SetLogEnable (bool enable);

		// +(BOOL)getLogEnable;
		[Static]
		[Export ("getLogEnable")]
		[Verify (MethodToProperty)]
		bool LogEnable { get; }

		// +(NSString *)version;
		[Static]
		[Export ("version")]
		[Verify (MethodToProperty)]
		string Version { get; }

		// +(void)logWithFunction:(const char *)function lineNumber:(int)lineNumber formatString:(NSString *)formatString;
		[Static]
		[Export ("logWithFunction:lineNumber:formatString:")]
		unsafe void LogWithFunction (sbyte* function, int lineNumber, string formatString);
	}

	// @interface ZFSmallFloatControlView : UIView
	[BaseType (typeof(UIView))]
	interface ZFSmallFloatControlView
	{
		// @property (copy, nonatomic) void (^ _Nullable)(void) closeClickCallback;
		[NullAllowed, Export ("closeClickCallback", ArgumentSemantic.Copy)]
		Action CloseClickCallback { get; set; }
	}

	// @interface ZFUtilities : NSObject
	[BaseType (typeof(NSObject))]
	interface ZFUtilities
	{
		// +(NSString *)convertTimeSecond:(NSInteger)timeSecond;
		[Static]
		[Export ("convertTimeSecond:")]
		string ConvertTimeSecond (nint timeSecond);

		// +(UIImage *)imageWithColor:(UIColor *)color size:(CGSize)size;
		[Static]
		[Export ("imageWithColor:size:")]
		UIImage ImageWithColor (UIColor color, CGSize size);
	}

	// @interface ZFVolumeBrightnessView : UIView
	[BaseType (typeof(UIView))]
	interface ZFVolumeBrightnessView
	{
		// @property (readonly, assign, nonatomic) ZFVolumeBrightnessType volumeBrightnessType;
		[Export ("volumeBrightnessType", ArgumentSemantic.Assign)]
		ZFVolumeBrightnessType VolumeBrightnessType { get; }

		// @property (readonly, nonatomic, strong) UIProgressView * progressView;
		[Export ("progressView", ArgumentSemantic.Strong)]
		UIProgressView ProgressView { get; }

		// @property (readonly, nonatomic, strong) UIImageView * iconImageView;
		[Export ("iconImageView", ArgumentSemantic.Strong)]
		UIImageView IconImageView { get; }

		// -(void)updateProgress:(CGFloat)progress withVolumeBrightnessType:(ZFVolumeBrightnessType)volumeBrightnessType;
		[Export ("updateProgress:withVolumeBrightnessType:")]
		void UpdateProgress (nfloat progress, ZFVolumeBrightnessType volumeBrightnessType);

		// -(void)addSystemVolumeView;
		[Export ("addSystemVolumeView")]
		void AddSystemVolumeView ();

		// -(void)removeSystemVolumeView;
		[Export ("removeSystemVolumeView")]
		void RemoveSystemVolumeView ();
	}
}
