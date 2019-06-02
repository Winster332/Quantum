using System.Collections.Generic;

namespace Quantum.DOM
{
    public class Selection
    {
        private List<Range> _ranges;
        public Node AnchorNode { get; set; }
        public int AnchorOffset { get; set; }
        public Node FocusNode { get; set; }
        public int FocusOffset { get; set; }
        public bool IsCollapsed { get; set; }
        public int RangeCount => _ranges.Count;
        public SelectionType Type { get; set; }

        public Selection()
        {
            AnchorNode = null;
            Type = SelectionType.None;
            _ranges = new List<Range>();
        }

        public void AddRange(Range range)
        {
            _ranges.Add(range);
        }

        public void Collapse()
        {
            // TODO: Impl
        }

        public void CollapseToEnd()
        {
            // TODO: Impl
        }
        
        public void CollapseToStart()
        {
            // TODO: Impl
        }

        public bool Contains()
        {
            // TODO: Impl
            return false;
        }

        public void DeleteFromDocument()
        {
            // TODO: Impl
        }

        public void Empty()
        {
            // TODO: Impl
        }

        public void Extend()
        {
            // TODO: Impl
        }

        public void GetRangeAt()
        {
            // TODO: Impl
        }

        public void RemoveRange()
        {
            // TODO: Impl
        }

        public void RemoveAllRanges()
        {
            // TODO: Impl
        }

        public void SelectAllChildren()
        {
            // TODO: Impl
        }

        public void SetBaseAndExtent()
        {
            // TODO: Impl
        }

        public void SetPosition()
        {
            // TODO: Impl
        }

        public override string ToString()
        {
            // TODO: Impl
            return base.ToString();
        }
    }
}