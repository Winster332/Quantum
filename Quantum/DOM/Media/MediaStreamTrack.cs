using System;
using Quantum.DOM.Media.Common;

namespace Quantum.DOM.Media
{
    public class MediaStreamTrack : ICloneable
    {
        public string ContentHint { get; set; }
        public bool Enabled { get; set; }
        public string Id { get; set; }
        public bool Isolated { get; set; }
        public string Kind { get; set; }
        public string Label { get; set; }
        public bool Muted { get; set; }
        public bool Readonly { get; set; }
        public MediaStreamTrackState ReadyState { get; set; }

        public void ApplyConstraints()
        {
        }

        public object Clone()
        {
            return null;
        }

        public void GetCapabilities()
        {
        }

        public MediaTrackConstraints GetConstraints()
        {
            return null;
        }

        public MediaTrackSettings GetSettings()
        {
            return null;
        }

        public void Stop()
        {
        }
        
        // TODO: Need add events
    }
}