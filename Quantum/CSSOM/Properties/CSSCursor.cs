using System;
using System.Linq;

namespace Quantum.CSSOM.Properties
{
    public enum CSSCursorType
    {
        Alias,
        AllScroll,
        Auto,
        Cell,
        ContextMenu,
        ColResize,
        Copy,
        Crosshair,
        Default,
        EResize,
        EwResize,
        Grab,
        Grabbing,
        Help,
        Move,
        NResize,
        NeResize,
        NeswResize,
        NsResize,
        NwResize,
        NwseResize,
        NoDrop,
        None,
        NotAllowed,
        Pointer,
        Progress,
        RowResize,
        SResize,
        SeResize,
        SwResize,
        Text,
        URL,
        VerticalText,
        WResize,
        Wait,
        ZoomIn,
        ZoomOut,
        Initial,
        Inherit
    }

    public class CSSCursor : ICloneable
    {
        public CSSCursorType Value { get; set; }

        public CSSCursor()
        {
            Value = CSSCursorType.Auto;
        }

        public static CSSCursor Parse(string text)
        {
            var cursor = new CSSCursor();
            var items = text.Split('-').ToList();
            var item = string.Empty;

            if (items.Count == 1)
            {
                item = text;
            }
            else
            {
                item = string.Join("", items);
            }

            CSSCursorType.TryParse<CSSCursorType>(item, true, out var result);
            cursor.Value = result;
            
            return cursor;
        }

        public object Clone()
        {
          return new CSSCursor
          {
            Value = Value
          };
        }
    }
}