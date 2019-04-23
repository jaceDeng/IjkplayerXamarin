using System;
using CoreGraphics;
using Foundation;
using MediaPlayer;
using ObjCRuntime;
using UIKit;

namespace Ijkplayer.iOS
{
    // @protocol IJKMediaPlayback <NSObject>
    partial interface IIJKMediaPlayback { }

    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IJKMediaPlayback
    {
        // @required -(void)prepareToPlay;
        [Abstract]
        [Export("prepareToPlay")]
        void PrepareToPlay();

        // @required -(void)play;
        [Abstract]
        [Export("play")]
        void Play();

        // @required -(void)pause;
        [Abstract]
        [Export("pause")]
        void Pause();

        // @required -(void)stop;
        [Abstract]
        [Export("stop")]
        void Stop();

        // @required -(BOOL)isPlaying;
        [Abstract]
        [Export("isPlaying")]
        bool IsPlaying { get; }

        // @required -(void)shutdown;
        [Abstract]
        [Export("shutdown")]
        void Shutdown();

        // @required -(void)setPauseInBackground:(BOOL)pause;
        [Abstract]
        [Export("setPauseInBackground:")]
        void SetPauseInBackground(bool pause);

        // @required @property (readonly, nonatomic) UIView * view;
        [Abstract]
        [Export("view")]
        UIView View { get; }

        // @required @property (nonatomic) NSTimeInterval currentPlaybackTime;
        [Abstract]
        [Export("currentPlaybackTime")]
        double CurrentPlaybackTime { get; set; }

        // @required @property (readonly, nonatomic) NSTimeInterval duration;
        [Abstract]
        [Export("duration")]
        double Duration { get; }

        // @required @property (readonly, nonatomic) NSTimeInterval playableDuration;
        [Abstract]
        [Export("playableDuration")]
        double PlayableDuration { get; }

        // @required @property (readonly, nonatomic) NSInteger bufferingProgress;
        [Abstract]
        [Export("bufferingProgress")]
        nint BufferingProgress { get; }

        // @required @property (readonly, nonatomic) BOOL isPreparedToPlay;
        [Abstract]
        [Export("isPreparedToPlay")]
        bool IsPreparedToPlay { get; }

        // @required @property (readonly, nonatomic) IJKMPMoviePlaybackState playbackState;
        [Abstract]
        [Export("playbackState")]
        IJKMPMoviePlaybackState PlaybackState { get; }

        // @required @property (readonly, nonatomic) IJKMPMovieLoadState loadState;
        [Abstract]
        [Export("loadState")]
        IJKMPMovieLoadState LoadState { get; }

        // @required @property (readonly, nonatomic) int isSeekBuffering;
        [Abstract]
        [Export("isSeekBuffering")]
        int IsSeekBuffering { get; }

        // @required @property (readonly, nonatomic) int isAudioSync;
        [Abstract]
        [Export("isAudioSync")]
        int IsAudioSync { get; }

        // @required @property (readonly, nonatomic) int isVideoSync;
        [Abstract]
        [Export("isVideoSync")]
        int IsVideoSync { get; }

        // @required @property (readonly, nonatomic) int64_t numberOfBytesTransferred;
        [Abstract]
        [Export("numberOfBytesTransferred")]
        long NumberOfBytesTransferred { get; }

        // @required @property (readonly, nonatomic) CGSize naturalSize;
        [Abstract]
        [Export("naturalSize")]
        CGSize NaturalSize { get; }

        // @required @property (nonatomic) IJKMPMovieScalingMode scalingMode;
        [Abstract]
        [Export("scalingMode", ArgumentSemantic.Assign)]
        IJKMPMovieScalingMode ScalingMode { get; set; }

        // @required @property (nonatomic) BOOL shouldAutoplay;
        [Abstract]
        [Export("shouldAutoplay")]
        bool ShouldAutoplay { get; set; }

        // @required @property (nonatomic) BOOL allowsMediaAirPlay;
        [Abstract]
        [Export("allowsMediaAirPlay")]
        bool AllowsMediaAirPlay { get; set; }

        // @required @property (nonatomic) BOOL isDanmakuMediaAirPlay;
        [Abstract]
        [Export("isDanmakuMediaAirPlay")]
        bool IsDanmakuMediaAirPlay { get; set; }

        // @required @property (readonly, nonatomic) BOOL airPlayMediaActive;
        [Abstract]
        [Export("airPlayMediaActive")]
        bool AirPlayMediaActive { get; }

        // @required @property (nonatomic) float playbackRate;
        [Abstract]
        [Export("playbackRate")]
        float PlaybackRate { get; set; }

        // @required @property (nonatomic) float playbackVolume;
        [Abstract]
        [Export("playbackVolume")]
        float PlaybackVolume { get; set; }

        // @required -(UIImage *)thumbnailImageAtCurrentTime;
        [Abstract]
        [Export("thumbnailImageAtCurrentTime")]
        UIImage ThumbnailImageAtCurrentTime { get; }
    }

    [Static]
    partial interface IJKMPMoviePlayer
    {
        // extern NSString *const IJKMPMediaPlaybackIsPreparedToPlayDidChangeNotification __attribute__((visibility("default")));
        [Field("IJKMPMediaPlaybackIsPreparedToPlayDidChangeNotification", "__Internal")]
        NSString PlaybackIsPreparedToPlayDidChangeNotification { get; }

        //todo 
        // extern NSString *const IJKMPMoviePlayerScalingModeDidChangeNotification __attribute__((visibility("default")));
        //[Field("IJKMPMoviePlayerScalingModeDidChangeNotification", "__Internal")]
        //NSString ScalingModeDidChangeNotification { get; }

        // extern NSString *const IJKMPMoviePlayerPlaybackDidFinishNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerPlaybackDidFinishNotification", "__Internal")]
        NSString PlaybackDidFinishNotification { get; }

        // extern NSString *const IJKMPMoviePlayerPlaybackDidFinishReasonUserInfoKey __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerPlaybackDidFinishReasonUserInfoKey", "__Internal")]
        NSString PlaybackDidFinishReasonUserInfoKey { get; }

        // extern NSString *const IJKMPMoviePlayerPlaybackStateDidChangeNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerPlaybackStateDidChangeNotification", "__Internal")]
        NSString PlaybackStateDidChangeNotification { get; }

        // extern NSString *const IJKMPMoviePlayerLoadStateDidChangeNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerLoadStateDidChangeNotification", "__Internal")]
        NSString LoadStateDidChangeNotification { get; }

        // extern NSString *const IJKMPMoviePlayerIsAirPlayVideoActiveDidChangeNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerIsAirPlayVideoActiveDidChangeNotification", "__Internal")]
        NSString IsAirPlayVideoActiveDidChangeNotification { get; }

        // extern NSString *const IJKMPMovieNaturalSizeAvailableNotification __attribute__((visibility("default")));
        [Field("IJKMPMovieNaturalSizeAvailableNotification", "__Internal")]
        NSString NaturalSizeAvailableNotification { get; }

        // extern NSString *const IJKMPMoviePlayerVideoDecoderOpenNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerVideoDecoderOpenNotification", "__Internal")]
        NSString VideoDecoderOpenNotification { get; }

        // extern NSString *const IJKMPMoviePlayerFirstVideoFrameRenderedNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerFirstVideoFrameRenderedNotification", "__Internal")]
        NSString FirstVideoFrameRenderedNotification { get; }

        // extern NSString *const IJKMPMoviePlayerFirstAudioFrameRenderedNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerFirstAudioFrameRenderedNotification", "__Internal")]
        NSString FirstAudioFrameRenderedNotification { get; }

        // extern NSString *const IJKMPMoviePlayerFirstAudioFrameDecodedNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerFirstAudioFrameDecodedNotification", "__Internal")]
        NSString FirstAudioFrameDecodedNotification { get; }

        // extern NSString *const IJKMPMoviePlayerFirstVideoFrameDecodedNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerFirstVideoFrameDecodedNotification", "__Internal")]
        NSString FirstVideoFrameDecodedNotification { get; }

        // extern NSString *const IJKMPMoviePlayerOpenInputNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerOpenInputNotification", "__Internal")]
        NSString OpenInputNotification { get; }

        // extern NSString *const IJKMPMoviePlayerFindStreamInfoNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerFindStreamInfoNotification", "__Internal")]
        NSString FindStreamInfoNotification { get; }

        // extern NSString *const IJKMPMoviePlayerComponentOpenNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerComponentOpenNotification", "__Internal")]
        NSString ComponentOpenNotification { get; }

        // extern NSString *const IJKMPMoviePlayerDidSeekCompleteNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerDidSeekCompleteNotification", "__Internal")]
        NSString DidSeekCompleteNotification { get; }

        // extern NSString *const IJKMPMoviePlayerDidSeekCompleteTargetKey __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerDidSeekCompleteTargetKey", "__Internal")]
        NSString DidSeekCompleteTargetKey { get; }

        // extern NSString *const IJKMPMoviePlayerDidSeekCompleteErrorKey __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerDidSeekCompleteErrorKey", "__Internal")]
        NSString DidSeekCompleteErrorKey { get; }

        // extern NSString *const IJKMPMoviePlayerDidAccurateSeekCompleteCurPos __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerDidAccurateSeekCompleteCurPos", "__Internal")]
        NSString DidAccurateSeekCompleteCurPos { get; }

        // extern NSString *const IJKMPMoviePlayerAccurateSeekCompleteNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerAccurateSeekCompleteNotification", "__Internal")]
        NSString AccurateSeekCompleteNotification { get; }

        // extern NSString *const IJKMPMoviePlayerSeekAudioStartNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerSeekAudioStartNotification", "__Internal")]
        NSString SeekAudioStartNotification { get; }

        // extern NSString *const IJKMPMoviePlayerSeekVideoStartNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerSeekVideoStartNotification", "__Internal")]
        NSString SeekVideoStartNotification { get; }
    }

    // @interface IJKMediaUrlOpenData : NSObject
    [BaseType(typeof(NSObject))]
    interface IJKMediaUrlOpenData
    {
        // -(id)initWithUrl:(NSString *)url event:(IJKMediaEvent)event segmentIndex:(int)segmentIndex retryCounter:(int)retryCounter;
        [Export("initWithUrl:event:segmentIndex:retryCounter:")]
        IntPtr Constructor(string url, IJKMediaEvent @event, int segmentIndex, int retryCounter);

        // @property (readonly, nonatomic) IJKMediaEvent event;
        [Export("event")]
        IJKMediaEvent Event { get; }

        // @property (readonly, nonatomic) int segmentIndex;
        [Export("segmentIndex")]
        int SegmentIndex { get; }

        // @property (readonly, nonatomic) int retryCounter;
        [Export("retryCounter")]
        int RetryCounter { get; }

        // @property (retain, nonatomic) NSString * url;
        [Export("url", ArgumentSemantic.Retain)]
        string Url { get; set; }

        // @property (assign, nonatomic) int fd;
        [Export("fd")]
        int Fd { get; set; }

        // @property (nonatomic, strong) NSString * msg;
        [Export("msg", ArgumentSemantic.Strong)]
        string Msg { get; set; }

        // @property (nonatomic) int error;
        [Export("error")]
        int Error { get; set; }

        // @property (getter = isHandled, nonatomic) BOOL handled;
        [Export("handled")]
        bool Handled { [Bind("isHandled")] get; set; }

        // @property (getter = isUrlChanged, nonatomic) BOOL urlChanged;
        [Export("urlChanged")]
        bool UrlChanged { [Bind("isUrlChanged")] get; set; }
    }

    // @protocol IJKMediaUrlOpenDelegate <NSObject>
    partial interface IIJKMediaUrlOpenDelegate { }

    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IJKMediaUrlOpenDelegate
    {
        // @required -(void)willOpenUrl:(IJKMediaUrlOpenData *)urlOpenData;
        [Abstract]
        [Export("willOpenUrl:")]
        void WillOpenUrl(IJKMediaUrlOpenData urlOpenData);
    }

    // @protocol IJKMediaNativeInvokeDelegate <NSObject>
    partial interface IIJKMediaNativeInvokeDelegate { }

    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IJKMediaNativeInvokeDelegate
    {
        // @required -(int)invoke:(IJKMediaEvent)event attributes:(NSDictionary *)attributes;
        [Abstract]
        [Export("invoke:attributes:")]
        int Attributes(IJKMediaEvent @event, NSDictionary attributes);
    }

    // @interface IJKMPMoviePlayerController : MPMoviePlayerController <IJKMediaPlayback>
    [BaseType(typeof(MPMoviePlayerController))]
    interface IJKMPMoviePlayerController : IIJKMediaPlayback
    {
        // -(id)initWithContentURL:(NSURL *)aUrl;
        [Export("initWithContentURL:")]
        IntPtr Constructor(NSUrl aUrl);

        // -(id)initWithContentURLString:(NSString *)aUrl;
        [Export("initWithContentURLString:")]
        IntPtr Constructor(string aUrl);
    }

    // @interface IJKFFOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface IJKFFOptions
    {
        // +(IJKFFOptions *)optionsByDefault;
        [Static]
        [Export("optionsByDefault")]
        IJKFFOptions OptionsByDefault { get; }

        // -(void)applyTo:(struct IjkMediaPlayer *)mediaPlayer;
        //todo
        [Export("applyTo:")]
        unsafe void ApplyTo(NSObject mediaPlayer);

        // -(void)setOptionValue:(NSString *)value forKey:(NSString *)key ofCategory:(IJKFFOptionCategory)category;
        [Export("setOptionValue:forKey:ofCategory:")]
        void SetOptionValue(string value, string key, IJKFFOptionCategory category);

        // -(void)setOptionIntValue:(int64_t)value forKey:(NSString *)key ofCategory:(IJKFFOptionCategory)category;
        [Export("setOptionIntValue:forKey:ofCategory:")]
        void SetOptionIntValue(long value, string key, IJKFFOptionCategory category);

        // -(void)setFormatOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setFormatOptionValue:forKey:")]
        void SetFormatOptionValue(string value, string key);

        // -(void)setCodecOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setCodecOptionValue:forKey:")]
        void SetCodecOptionValue(string value, string key);

        // -(void)setSwsOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setSwsOptionValue:forKey:")]
        void SetSwsOptionValue(string value, string key);

        // -(void)setPlayerOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setPlayerOptionValue:forKey:")]
        void SetPlayerOptionValue(string value, string key);

        // -(void)setFormatOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setFormatOptionIntValue:forKey:")]
        void SetFormatOptionIntValue(long value, string key);

        // -(void)setCodecOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setCodecOptionIntValue:forKey:")]
        void SetCodecOptionIntValue(long value, string key);

        // -(void)setSwsOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setSwsOptionIntValue:forKey:")]
        void SetSwsOptionIntValue(long value, string key);

        // -(void)setPlayerOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setPlayerOptionIntValue:forKey:")]
        void SetPlayerOptionIntValue(long value, string key);

        // @property (nonatomic) BOOL showHudView;
        [Export("showHudView")]
        bool ShowHudView { get; set; }
    }

    // @interface IJKFFMonitor : NSObject
    [BaseType(typeof(NSObject))]
    interface IJKFFMonitor
    {
        // @property (nonatomic) NSDictionary * mediaMeta;
        [Export("mediaMeta", ArgumentSemantic.Assign)]
        NSDictionary MediaMeta { get; set; }

        // @property (nonatomic) NSDictionary * videoMeta;
        [Export("videoMeta", ArgumentSemantic.Assign)]
        NSDictionary VideoMeta { get; set; }

        // @property (nonatomic) NSDictionary * audioMeta;
        [Export("audioMeta", ArgumentSemantic.Assign)]
        NSDictionary AudioMeta { get; set; }

        // @property (readonly, nonatomic) int64_t duration;
        [Export("duration")]
        long Duration { get; }

        // @property (readonly, nonatomic) int64_t bitrate;
        [Export("bitrate")]
        long Bitrate { get; }

        // @property (readonly, nonatomic) float fps;
        [Export("fps")]
        float Fps { get; }

        // @property (readonly, nonatomic) int width;
        [Export("width")]
        int Width { get; }

        // @property (readonly, nonatomic) int height;
        [Export("height")]
        int Height { get; }

        // @property (readonly, nonatomic) NSString * vcodec;
        [Export("vcodec")]
        string Vcodec { get; }

        // @property (readonly, nonatomic) NSString * acodec;
        [Export("acodec")]
        string Acodec { get; }

        // @property (readonly, nonatomic) int sampleRate;
        [Export("sampleRate")]
        int SampleRate { get; }

        // @property (readonly, nonatomic) int64_t channelLayout;
        [Export("channelLayout")]
        long ChannelLayout { get; }

        // @property (nonatomic) NSString * vdecoder;
        [Export("vdecoder")]
        string Vdecoder { get; set; }

        // @property (nonatomic) int tcpError;
        [Export("tcpError")]
        int TcpError { get; set; }

        // @property (nonatomic) NSString * remoteIp;
        [Export("remoteIp")]
        string RemoteIp { get; set; }

        // @property (nonatomic) int httpError;
        [Export("httpError")]
        int HttpError { get; set; }

        // @property (nonatomic) NSString * httpUrl;
        [Export("httpUrl")]
        string HttpUrl { get; set; }

        // @property (nonatomic) NSString * httpHost;
        [Export("httpHost")]
        string HttpHost { get; set; }

        // @property (nonatomic) int httpCode;
        [Export("httpCode")]
        int HttpCode { get; set; }

        // @property (nonatomic) int64_t httpOpenTick;
        [Export("httpOpenTick")]
        long HttpOpenTick { get; set; }

        // @property (nonatomic) int64_t httpSeekTick;
        [Export("httpSeekTick")]
        long HttpSeekTick { get; set; }

        // @property (nonatomic) int httpOpenCount;
        [Export("httpOpenCount")]
        int HttpOpenCount { get; set; }

        // @property (nonatomic) int httpSeekCount;
        [Export("httpSeekCount")]
        int HttpSeekCount { get; set; }

        // @property (nonatomic) int64_t lastHttpOpenDuration;
        [Export("lastHttpOpenDuration")]
        long LastHttpOpenDuration { get; set; }

        // @property (nonatomic) int64_t lastHttpSeekDuration;
        [Export("lastHttpSeekDuration")]
        long LastHttpSeekDuration { get; set; }

        // @property (nonatomic) int64_t filesize;
        [Export("filesize")]
        long Filesize { get; set; }

        // @property (nonatomic) int64_t prepareStartTick;
        [Export("prepareStartTick")]
        long PrepareStartTick { get; set; }

        // @property (nonatomic) int64_t prepareDuration;
        [Export("prepareDuration")]
        long PrepareDuration { get; set; }

        // @property (nonatomic) int64_t firstVideoFrameLatency;
        [Export("firstVideoFrameLatency")]
        long FirstVideoFrameLatency { get; set; }

        // @property (nonatomic) int64_t lastPrerollStartTick;
        [Export("lastPrerollStartTick")]
        long LastPrerollStartTick { get; set; }

        // @property (nonatomic) int64_t lastPrerollDuration;
        [Export("lastPrerollDuration")]
        long LastPrerollDuration { get; set; }
    }

    // @protocol IJKSDLGLViewProtocol <NSObject>
    partial interface IIJKSDLGLViewProtocol { }

    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IJKSDLGLViewProtocol
    {
        // @required -(UIImage *)snapshot;
        [Abstract]
        [Export("snapshot")]
        UIImage Snapshot { get; }

        // @required @property (readonly, nonatomic) CGFloat fps;
        [Abstract]
        [Export("fps")]
        nfloat Fps { get; }

        // @required @property (nonatomic) CGFloat scaleFactor;
        [Abstract]
        [Export("scaleFactor")]
        nfloat ScaleFactor { get; set; }

        // @required @property (nonatomic) BOOL isThirdGLView;
        [Abstract]
        [Export("isThirdGLView")]
        bool IsThirdGLView { get; set; }

        // @required -(void)display_pixels:(IJKOverlay *)overlay;
        [Abstract]
        [Export("display_pixels:")]
        unsafe void Display_pixels(IJKOverlay overlay);
    }

    // @interface IJKFFMoviePlayerController : NSObject <IJKMediaPlayback>
    [BaseType(typeof(NSObject))]
    interface IJKFFMoviePlayerController : IJKMediaPlayback
    {
        // -(id)initWithContentURL:(NSURL *)aUrl withOptions:(IJKFFOptions *)options;
        [Export("initWithContentURL:withOptions:")]
        IntPtr Constructor(NSUrl aUrl, IJKFFOptions options);

        // -(id)initWithContentURLString:(NSString *)aUrlString withOptions:(IJKFFOptions *)options;
        [Export("initWithContentURLString:withOptions:")]
        IntPtr Constructor(string aUrlString, IJKFFOptions options);

        // -(id)initWithMoreContent:(NSURL *)aUrl withOptions:(IJKFFOptions *)options withGLView:(UIView<IJKSDLGLViewProtocol> *)glView;
        [Export("initWithMoreContent:withOptions:withGLView:")]
        IntPtr Constructor(NSUrl aUrl, IJKFFOptions options, IJKSDLGLViewProtocol glView);

        // -(id)initWithMoreContentString:(NSString *)aUrlString withOptions:(IJKFFOptions *)options withGLView:(UIView<IJKSDLGLViewProtocol> *)glView;
        [Export("initWithMoreContentString:withOptions:withGLView:")]
        IntPtr Constructor(string aUrlString, IJKFFOptions options, IJKSDLGLViewProtocol glView);

        // -(void)prepareToPlay;
        [Export("prepareToPlay")]
        new void PrepareToPlay();

        // -(void)play;
        [Export("play")]
        new void Play();

        // -(void)pause;
        [Export("pause")]
        new void Pause();

        // -(void)stop;
        [Export("stop")]
        new void Stop();

        // -(BOOL)isPlaying;
        [Export("isPlaying")]
        new bool IsPlaying { get; }

        // -(void)shutdown;
        [Export("shutdown")]
        new void Shutdown();

        // -(void)setPauseInBackground:(BOOL)pause;
        [Export("setPauseInBackground:")]
        new void SetPauseInBackground(bool pause);

        // @property (readonly, nonatomic) UIView * view;
        [Export("view")]
        new UIView View { get; }

        // @required @property (nonatomic) NSTimeInterval currentPlaybackTime;
        [Export("currentPlaybackTime")]
        new double CurrentPlaybackTime { get; set; }

        // @required @property (readonly, nonatomic) NSTimeInterval duration;
        [Export("duration")]
        new double Duration { get; }

        // @required @property (readonly, nonatomic) NSTimeInterval playableDuration;
        [Export("playableDuration")]
        new double PlayableDuration { get; }

        // @required @property (readonly, nonatomic) NSInteger bufferingProgress;
        [Export("bufferingProgress")]
        new nint BufferingProgress { get; }

        // @required @property (readonly, nonatomic) BOOL isPreparedToPlay;
        [Export("isPreparedToPlay")]
        new bool IsPreparedToPlay { get; }

        // @required @property (readonly, nonatomic) IJKMPMoviePlaybackState playbackState;
        [Export("playbackState")]
        new IJKMPMoviePlaybackState PlaybackState { get; }

        // @required @property (readonly, nonatomic) IJKMPMovieLoadState loadState;
        [Export("loadState")]
        new IJKMPMovieLoadState LoadState { get; }

        // @required @property (readonly, nonatomic) int isSeekBuffering;
        [Export("isSeekBuffering")]
        new int IsSeekBuffering { get; }

        // @required @property (readonly, nonatomic) int isAudioSync;
        [Export("isAudioSync")]
        new int IsAudioSync { get; }

        // @required @property (readonly, nonatomic) int isVideoSync;
        [Export("isVideoSync")]
        new int IsVideoSync { get; }

        // @required @property (readonly, nonatomic) int64_t numberOfBytesTransferred;
        [Export("numberOfBytesTransferred")]
        new long NumberOfBytesTransferred { get; }

        // @required @property (readonly, nonatomic) CGSize naturalSize;
        [Export("naturalSize")]
        new CGSize NaturalSize { get; }

        // @required @property (nonatomic) IJKMPMovieScalingMode scalingMode;
        [Export("scalingMode", ArgumentSemantic.Assign)]
        new IJKMPMovieScalingMode ScalingMode { get; set; }

        // @required @property (nonatomic) BOOL shouldAutoplay;
        [Export("shouldAutoplay")]
        new bool ShouldAutoplay { get; set; }

        // @required @property (nonatomic) BOOL allowsMediaAirPlay;
        [Export("allowsMediaAirPlay")]
        new bool AllowsMediaAirPlay { get; set; }

        // @required @property (nonatomic) BOOL isDanmakuMediaAirPlay;
        [Export("isDanmakuMediaAirPlay")]
        new bool IsDanmakuMediaAirPlay { get; set; }

        // @required @property (readonly, nonatomic) BOOL airPlayMediaActive;
        [Export("airPlayMediaActive")]
        new bool AirPlayMediaActive { get; }

        // @required @property (nonatomic) float playbackRate;
        [Export("playbackRate")]
        new float PlaybackRate { get; set; }

        // @required @property (nonatomic) float playbackVolume;
        [Export("playbackVolume")]
        new float PlaybackVolume { get; set; }

        // @required -(UIImage *)thumbnailImageAtCurrentTime;
        [Export("thumbnailImageAtCurrentTime")]
        new UIImage ThumbnailImageAtCurrentTime { get; }

        // -(int64_t)trafficStatistic;
        [Export("trafficStatistic")]
        long TrafficStatistic { get; }

        // -(float)dropFrameRate;
        [Export("dropFrameRate")]
        float DropFrameRate { get; }

        // -(BOOL)isVideoToolboxOpen;
        [Export("isVideoToolboxOpen")]
        bool IsVideoToolboxOpen { get; }

        // -(void)setHudValue:(NSString *)value forKey:(NSString *)key;
        [Export("setHudValue:forKey:")]
        void SetHudValue(string value, string key);

        // +(void)setLogReport:(BOOL)preferLogReport;
        [Static]
        [Export("setLogReport:")]
        void SetLogReport(bool preferLogReport);

        // +(void)setLogLevel:(IJKLogLevel)logLevel;
        [Static]
        [Export("setLogLevel:")]
        void SetLogLevel(IJKLogLevel logLevel);

        // +(BOOL)checkIfFFmpegVersionMatch:(BOOL)showAlert;
        [Static]
        [Export("checkIfFFmpegVersionMatch:")]
        bool CheckIfFFmpegVersionMatch(bool showAlert);

        // +(BOOL)checkIfPlayerVersionMatch:(BOOL)showAlert version:(NSString *)version;
        [Static]
        [Export("checkIfPlayerVersionMatch:version:")]
        bool CheckIfPlayerVersionMatch(bool showAlert, string version);

        // @property (readonly, nonatomic) CGFloat fpsInMeta;
        [Export("fpsInMeta")]
        nfloat FpsInMeta { get; }

        // @property (readonly, nonatomic) CGFloat fpsAtOutput;
        [Export("fpsAtOutput")]
        nfloat FpsAtOutput { get; }

        // @property (nonatomic) BOOL shouldShowHudView;
        [Export("shouldShowHudView")]
        bool ShouldShowHudView { get; set; }

        // -(void)setOptionValue:(NSString *)value forKey:(NSString *)key ofCategory:(IJKFFOptionCategory)category;
        [Export("setOptionValue:forKey:ofCategory:")]
        void SetOptionValue(string value, string key, IJKFFOptionCategory category);

        // -(void)setOptionIntValue:(int64_t)value forKey:(NSString *)key ofCategory:(IJKFFOptionCategory)category;
        [Export("setOptionIntValue:forKey:ofCategory:")]
        void SetOptionIntValue(long value, string key, IJKFFOptionCategory category);

        // -(void)setFormatOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setFormatOptionValue:forKey:")]
        void SetFormatOptionValue(string value, string key);

        // -(void)setCodecOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setCodecOptionValue:forKey:")]
        void SetCodecOptionValue(string value, string key);

        // -(void)setSwsOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setSwsOptionValue:forKey:")]
        void SetSwsOptionValue(string value, string key);

        // -(void)setPlayerOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setPlayerOptionValue:forKey:")]
        void SetPlayerOptionValue(string value, string key);

        // -(void)setFormatOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setFormatOptionIntValue:forKey:")]
        void SetFormatOptionIntValue(long value, string key);

        // -(void)setCodecOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setCodecOptionIntValue:forKey:")]
        void SetCodecOptionIntValue(long value, string key);

        // -(void)setSwsOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setSwsOptionIntValue:forKey:")]
        void SetSwsOptionIntValue(long value, string key);

        // -(void)setPlayerOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setPlayerOptionIntValue:forKey:")]
        void SetPlayerOptionIntValue(long value, string key);

        [Wrap("WeakSegmentOpenDelegate")]
        IIJKMediaUrlOpenDelegate SegmentOpenDelegate { get; set; }

        // @property (retain, nonatomic) id<IJKMediaUrlOpenDelegate> segmentOpenDelegate;
        [NullAllowed, Export("segmentOpenDelegate", ArgumentSemantic.Retain)]
        NSObject WeakSegmentOpenDelegate { get; set; }

        [Wrap("WeakTcpOpenDelegate")]
        IJKMediaUrlOpenDelegate TcpOpenDelegate { get; set; }

        // @property (retain, nonatomic) id<IJKMediaUrlOpenDelegate> tcpOpenDelegate;
        [NullAllowed, Export("tcpOpenDelegate", ArgumentSemantic.Retain)]
        NSObject WeakTcpOpenDelegate { get; set; }

        [Wrap("WeakHttpOpenDelegate")]
        IIJKMediaUrlOpenDelegate HttpOpenDelegate { get; set; }

        // @property (retain, nonatomic) id<IJKMediaUrlOpenDelegate> httpOpenDelegate;
        [NullAllowed, Export("httpOpenDelegate", ArgumentSemantic.Retain)]
        NSObject WeakHttpOpenDelegate { get; set; }

        [Wrap("WeakLiveOpenDelegate")]
        IIJKMediaUrlOpenDelegate LiveOpenDelegate { get; set; }

        // @property (retain, nonatomic) id<IJKMediaUrlOpenDelegate> liveOpenDelegate;
        [NullAllowed, Export("liveOpenDelegate", ArgumentSemantic.Retain)]
        NSObject WeakLiveOpenDelegate { get; set; }

        [Wrap("WeakNativeInvokeDelegate")]
        IIJKMediaNativeInvokeDelegate NativeInvokeDelegate { get; set; }

        // @property (retain, nonatomic) id<IJKMediaNativeInvokeDelegate> nativeInvokeDelegate;
        [NullAllowed, Export("nativeInvokeDelegate", ArgumentSemantic.Retain)]
        NSObject WeakNativeInvokeDelegate { get; set; }

        // -(void)didShutdown;
        [Export("didShutdown")]
        void DidShutdown();

        // @property (readonly, nonatomic) IJKFFMonitor * monitor;
        [Export("monitor")]
        IJKFFMonitor Monitor { get; }
    }

    // @interface IJKAVMoviePlayerController : NSObject <IJKMediaPlayback>
    [BaseType(typeof(NSObject))]
    interface IJKAVMoviePlayerController : IJKMediaPlayback
    {
        // -(id)initWithContentURL:(NSURL *)aUrl;
        [Export("initWithContentURL:")]
        IntPtr Constructor(NSUrl aUrl);

        // -(id)initWithContentURLString:(NSString *)aUrl;
        [Export("initWithContentURLString:")]
        IntPtr Constructor(string aUrl);

        // -(void)prepareToPlay;
        [Export("prepareToPlay")]
        new void PrepareToPlay();

        // -(void)play;
        [Export("play")]
        new void Play();

        // -(void)pause;
        [Export("pause")]
        new void Pause();

        // -(void)stop;
        [Export("stop")]
        new void Stop();

        // -(BOOL)isPlaying;
        [Export("isPlaying")]
        new bool IsPlaying { get; }

        // -(void)shutdown;
        [Export("shutdown")]
        new void Shutdown();

        // -(void)setPauseInBackground:(BOOL)pause;
        [Export("setPauseInBackground:")]
        new void SetPauseInBackground(bool pause);

        // @property (readonly, nonatomic) UIView * view;
        [Export("view")]
        new UIView View { get; }

        // @required @property (nonatomic) NSTimeInterval currentPlaybackTime;
        [Export("currentPlaybackTime")]
        new double CurrentPlaybackTime { get; set; }

        // @required @property (readonly, nonatomic) NSTimeInterval duration;
        [Export("duration")]
        new double Duration { get; }

        // @required @property (readonly, nonatomic) NSTimeInterval playableDuration;
        [Export("playableDuration")]
        new double PlayableDuration { get; }

        // @required @property (readonly, nonatomic) NSInteger bufferingProgress;
        [Export("bufferingProgress")]
        new nint BufferingProgress { get; }

        // @required @property (readonly, nonatomic) BOOL isPreparedToPlay;
        [Export("isPreparedToPlay")]
        new bool IsPreparedToPlay { get; }

        // @required @property (readonly, nonatomic) IJKMPMoviePlaybackState playbackState;
        [Export("playbackState")]
        new IJKMPMoviePlaybackState PlaybackState { get; }

        // @required @property (readonly, nonatomic) IJKMPMovieLoadState loadState;
        [Export("loadState")]
        new IJKMPMovieLoadState LoadState { get; }

        // @required @property (readonly, nonatomic) int isSeekBuffering;
        [Export("isSeekBuffering")]
        new int IsSeekBuffering { get; }

        // @required @property (readonly, nonatomic) int isAudioSync;
        [Export("isAudioSync")]
        new int IsAudioSync { get; }

        // @required @property (readonly, nonatomic) int isVideoSync;
        [Export("isVideoSync")]
        new int IsVideoSync { get; }

        // @required @property (readonly, nonatomic) int64_t numberOfBytesTransferred;
        [Export("numberOfBytesTransferred")]
        new long NumberOfBytesTransferred { get; }

        // @required @property (readonly, nonatomic) CGSize naturalSize;
        [Export("naturalSize")]
        new CGSize NaturalSize { get; }

        // @required @property (nonatomic) IJKMPMovieScalingMode scalingMode;
        [Export("scalingMode", ArgumentSemantic.Assign)]
        new IJKMPMovieScalingMode ScalingMode { get; set; }

        // @required @property (nonatomic) BOOL shouldAutoplay;
        [Export("shouldAutoplay")]
        new bool ShouldAutoplay { get; set; }

        // @required @property (nonatomic) BOOL allowsMediaAirPlay;
        [Export("allowsMediaAirPlay")]
        new bool AllowsMediaAirPlay { get; set; }

        // @required @property (nonatomic) BOOL isDanmakuMediaAirPlay;
        [Export("isDanmakuMediaAirPlay")]
        new bool IsDanmakuMediaAirPlay { get; set; }

        // @required @property (readonly, nonatomic) BOOL airPlayMediaActive;
        [Export("airPlayMediaActive")]
        new bool AirPlayMediaActive { get; }

        // @required @property (nonatomic) float playbackRate;
        [Export("playbackRate")]
        new float PlaybackRate { get; set; }

        // @required @property (nonatomic) float playbackVolume;
        [Export("playbackVolume")]
        new float PlaybackVolume { get; set; }

        // @required -(UIImage *)thumbnailImageAtCurrentTime;
        [Export("thumbnailImageAtCurrentTime")]
        new UIImage ThumbnailImageAtCurrentTime { get; }

        // +(id)getInstance:(NSString *)aUrl;
        [Static]
        [Export("getInstance:")]
        NSObject GetInstance(string aUrl);
    }

    // @interface IJKMediaModule : NSObject
    [BaseType(typeof(NSObject))]
    interface IJKMediaModule
    {
        // +(IJKMediaModule *)sharedModule;
        [Static]
        [Export("sharedModule")]
        IJKMediaModule SharedModule { get; }

        // @property (getter = isAppIdleTimerDisabled, atomic) BOOL appIdleTimerDisabled;
        [Export("appIdleTimerDisabled")]
        bool AppIdleTimerDisabled { [Bind("isAppIdleTimerDisabled")] get; set; }

        // @property (getter = isMediaModuleIdleTimerDisabled, atomic) BOOL mediaModuleIdleTimerDisabled;
        [Export("mediaModuleIdleTimerDisabled")]
        bool MediaModuleIdleTimerDisabled { [Bind("isMediaModuleIdleTimerDisabled")] get; set; }
    }

}

