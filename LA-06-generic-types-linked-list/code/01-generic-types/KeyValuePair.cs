namespace _01_generic_types
{
    public class KeyValuePair<KKey, TValue>
    {
        public KKey? Key { get; set; }
        public TValue? Value { get; set; }
        public override string ToString()
        {
            return $"{Key} => {Value}";
        }
    }
}