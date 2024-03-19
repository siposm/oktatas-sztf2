namespace _02_interface_inheritance
{
    interface ISellable
    {
        int Price { get; set; }
    }
    interface IDiscount
    {
        int DiscountAmount { get; set; }
    }
    interface IExtraDiscount : IDiscount
    {
        int ExtraDiscountAmount { get; set; }
    }
    
    // One class can implement multiple interfaces. Similar to multi-inheritance, which is not possible in C#.
    class Product : ISellable, IDiscount
    {
        public int Price { get; set; } // ISellable
        public int DiscountAmount { get; set; } // IDiscount
    }
    
    // Both ExtraDiscountAmount and DiscountAmount are added, because
    // IExtraDiscount inherits from IDiscount
    class XYTermek : IExtraDiscount
    {
        public int ExtraDiscountAmount { get; set; }
        public int DiscountAmount { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}