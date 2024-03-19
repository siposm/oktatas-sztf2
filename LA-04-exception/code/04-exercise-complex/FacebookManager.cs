namespace _04_exercise_complex
{
    delegate void NoSpaceForMoreGroupsEventHandler(object source, EventArgs args);

    class FacebookManager
    {
        public event NoSpaceForMoreGroupsEventHandler NoMoreGroupsPossible;
        int groupIndex;
        public FacebookGroup[] Groups { get; private set; }

        public FacebookManager(int groupNumber)
        {
            Groups = new FacebookGroup[groupNumber];
            groupIndex = 0;
        }

        public void CreateGroup(User user, string title)
        {
            FacebookGroup group = new FacebookGroup(user, title);
            group.StartYear = DateTime.Now.Year;
            if (Groups.Length > groupIndex)
                Groups[groupIndex++] = group;

            // fire event if there is no more space for new groups
            if (groupIndex == Groups.Length)
                OnNoMoreGroupsPossible();
        }

        protected virtual void OnNoMoreGroupsPossible()
        {
            if (NoMoreGroupsPossible != null)
                NoMoreGroupsPossible(this, EventArgs.Empty);
        }

        public void ListGroups()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("====================================");
            Console.WriteLine("| FACEBOOK GROUPS");
            Console.WriteLine("====================================");

            for (int i = 0; i < groupIndex; i++)
            {
                Console.WriteLine("| " + Groups[i]);
            }

            Console.WriteLine("====================================");
            
            // sidenote: not really good if console.writelines are hardcoded here!
        }
    }
}