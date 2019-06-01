namespace Quantum.DOM.CSS
{
    public class StyleSheet
    {
        public bool Disabled { get; set; }
        public string Href { get; set; }
        
        /// TODO MediList
        
        public Node OwnerNode { get; set; }
        public StyleSheet ParentStyleSheet { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public StyleSheet()
        {
            Disabled = false;
            Href = string.Empty;
            OwnerNode = null;
            ParentStyleSheet = null;
            Title = string.Empty;
            Type = "text/css";
        }
    }
}