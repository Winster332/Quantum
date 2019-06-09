using Quantum.DOM.Media.Common;

namespace Quantum.DOM.Media
{
    public class MediaTrackConstraints
    {
        #region Properties of all media tracks
        
        public Constrain<string> DeviceId { get; set; }
        public Constrain<string> GroupId { get; set; }
        
        #endregion

        #region Properties of audio tracks

        public Constrain<bool> AutoGainControl { get; set; }
        public Constrain<long> ChannelCount { get; set; }
        public Constrain<bool> EchoCancellation { get; set; }
        public Constrain<double> Latency { get; set; }
        public Constrain<bool> NoiseSuppression { get; set; }
        public Constrain<long> SampleRate { get; set; }
        public Constrain<long> SampleSize { get; set; }
        public Constrain<double> Volume { get; set; }

        #endregion
        
        #region Properties of image tracks
        
        public MediaTrackConstraintsImageMode WhiteBalanceMode { get; set; }
        public MediaTrackConstraintsImageMode ExposureMode { get; set; }
        public MediaTrackConstraintsImageMode FocusMode { get; set; }
        public string PointsOfInterest { get; set; }
        public Constrain<double> ExposureCompensation { get; set; }
        public Constrain<double> ColorTemperature { get; set; }
        public Constrain<double> Iso { get; set; }
        public Constrain<double> Brightness { get; set; }
        public Constrain<double> Contrast { get; set; }
        public Constrain<double> Saturation { get; set; }
        public Constrain<double> Sharpness { get; set; }
        public Constrain<double> FocusDistance { get; set; }
        public Constrain<double> Zoom { get; set; }
        public Constrain<double> Torch { get; set; }
        
        #endregion
        
        #region Properties of video tracks
        
        public Constrain<double> AspectRatio { get; set; }
        public Constrain<string> FacingMode { get; set; }
        public Constrain<double> FrameRate { get; set; }
        public Constrain<long> Height { get; set; }
        public Constrain<long> Width { get; set; }
        public MediaTrackConstraintsVideoResizeMode ResizeMode { get; set; }
        
        #endregion
        
        #region Properties of shared screen tracks
        
        public MediaTrackConstraintsSharedScreenCursor Cursor { get; set; }
        public MediaTrackConstraintsSharedScreenDisplaySurface DisplaySurface { get; set; }
        public Constrain<bool> LogicalSurface { get; set; }
        
        #endregion
    }
}