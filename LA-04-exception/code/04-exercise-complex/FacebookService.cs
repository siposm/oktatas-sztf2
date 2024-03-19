namespace _04_exercise_complex
{
    class FacebookService
    {
        public string GenerateID()
        {
            Random r = new Random();
            return r.Next(10000, 90000).ToString();
        }

        public void OnMembersAreFull(object source, FacebookGroupEventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine("[FB-EVENT] : this group is full with members, no more can fit.");
            Console.WriteLine("\t> Group: " + args.FBGroup.Title + " (owner: " + args.FBGroup.Owner.Name + ")");
            Console.WriteLine();
        }

        public void OnNoMoreGroupsPossible(object source, EventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine("[FB-EVENT] : can't create more groups! We are limited.");
            Console.WriteLine();
        }
    }
}