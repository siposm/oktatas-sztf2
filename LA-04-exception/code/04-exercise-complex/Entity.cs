namespace _04_exercise_complex
{
    abstract class Entity
    {
        public string Id { get; private set; }

        public int RegDate { get; private set; }


        public Entity(string id)
        {
            this.Id = id;
            this.RegDate = DateTime.Now.Year;
        }

    }
}