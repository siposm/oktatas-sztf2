namespace _02_linkedlist
{
    public class KeyValuePair<KKey, TValue> where TValue : class
    {
        public KKey? Key { get; set; }
        public TValue? Value { get; set; }
        public override string ToString()
        {
            return $"{Key} => {Value}";
        }
    }
}