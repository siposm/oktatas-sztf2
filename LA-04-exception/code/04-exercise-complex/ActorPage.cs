namespace _04_exercise_complex
{
    class ActorPage : Page
    {
        public string Name{get; private set;}
        public ActorPage(string id, string name) : base(id)
        {
            this.Name = name;
        }
    }
}