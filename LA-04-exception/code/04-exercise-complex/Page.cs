namespace _04_exercise_complex
{
    abstract class Page : Entity
    {
        public string Topic { get; set; }

        public Page(string id) : base(id)
        {

        }

        public Page(string id, string topic) : base(id)
        {
            this.Topic = topic;
        }
    }
}