namespace _02_exercise
{
    class GraphEventArgs<T> : EventArgs
    {
        public T NodeA { get; set; }
        public T NodeB { get; set; }
    }
}