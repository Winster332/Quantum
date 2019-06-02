namespace Quantum.DOM
{
    public class DocumentType : Node
    {
        public string Name { get; set; }
        public string PublicId { get; set; }
        public string SystemId { get; set; }

        public DocumentType(Node parentNode)
        {
            ParentNode = parentNode;
            Name = "html";
            PublicId = "";
            SystemId = "";
        }

        public void Remove()
        {
            ParentNode.RemoveChild(this);
        }
    }
}