namespace _04_exercise_complex
{
    
    delegate void GroupMembersAreFullEventHandler(object source, FacebookGroupEventArgs args);

    class FacebookGroup : IFacebookGroup
    {
        public event GroupMembersAreFullEventHandler MembersAreFull;
        public string Title { get; set; }
        public int StartYear { get; set; }
        public User[] Admins { get; private set; } // members with admin privileges
        public User[] Members { get; private set; } // members
        public User Owner { get; private set; } // creator and owner of the group
        int memberIndex;
        int adminIndex;

        public FacebookGroup(User owner, string title)
        {
            this.Title = title;
            Members = new User[5];
            Admins = new User[3];

            this.Owner = owner;
            Admins[adminIndex++] = owner;

            memberIndex = 0;
        }


        public void AddMember(User whoIsAdding, User whoWillBeAdded)
        {
            if (IsAmongAdmins(whoIsAdding))
            {
                if (Members.Length > memberIndex)
                {
                    Members[memberIndex++] = whoWillBeAdded;
                    if (Members.Length == memberIndex)
                        OnMembersAreFull(this); // if last space is occupied, fire an event
                }
                else
                    throw new NoMoreMemberException("We are full! :(");
            }
            else
                throw new MemberAddingException("You have to be admin, to add a person!");

        }

        public void MakeMemberToAdmin(User whoIsMaking, User whoWillBeMade)
        {
            if (IsAmongAdmins(whoIsMaking))
                Admins[adminIndex++] = whoWillBeMade;
            else
                throw new MemberAddingException("You have to be admin, to make person to admin!");
        }

        private bool IsAmongAdmins(User user)
        {
            for (int i = 0; i < adminIndex; i++)
            {
                if (user.Id == Admins[i].Id)
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return this.Title + " (" + this.StartYear + ")";
        }

        protected virtual void OnMembersAreFull(FacebookGroup group)
        {
            if (MembersAreFull != null)
                MembersAreFull(this, new FacebookGroupEventArgs() { FBGroup = group });
        }
    }
}