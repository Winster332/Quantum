using System;

namespace Quantum.DOM
{
    public class File : Blob
    {
        public int LastModified => LastModifiedDate.Millisecond;
        public DateTime LastModifiedDate { get; set; }
        public string Name { get; set; }
    }
}