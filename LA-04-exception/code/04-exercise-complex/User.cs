namespace _04_exercise_complex
{
    sealed class User : Entity
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public string Role { get; private set; }

        public override string ToString()
        {
            return $"{Name} - ({BirthYear}) {Role}";
        }

        public override bool Equals(object obj)
        {
            if ((obj as User).Id == this.Id)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public User(string name, string id, int byear, string role)
            : base(id)
        {
            this.Name = name;
            this.BirthYear = byear;
            this.Role = role;
        }
    }
}