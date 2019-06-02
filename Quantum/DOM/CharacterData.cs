namespace Quantum.DOM
{
    public class CharacterData : Node
    {
        public string Data { get; set; }
        public int Length => Data.Length;

        public Element NextElementSibling => NextSibling as Element;
        public Element PreviousElementSibling => PreviousSibling as Element;

        public CharacterData()
        {
            Data = string.Empty;
        }

        public void AppendData(string text)
        {
            Data = $"{Data}{text}";
        }

        public void DeleteData(int size, int position)
        {
            Data = Data.Remove(position, size);
        }

        public void InsertData(int index, string data)
        {
            Data = Data.Insert(index, data);
        }
        
        public void ReplaceData(string oldData, string newData)
        {
            Data = Data.Replace(oldData, newData);
        }
        
        public void SubstringData(int size, int position)
        {
            Data = Data.Substring(position, size);
        }
    }
}