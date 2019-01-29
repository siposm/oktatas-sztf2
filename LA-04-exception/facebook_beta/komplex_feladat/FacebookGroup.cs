using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komplex_feladat
{
    class FacebookGroup : IFacebookGroup
    {
        // FIELDS AND PROPERTIES

        User[] members; // ők a tagok
        User[] admins; // ők is tagok de admin joggal
        User owner; // ő pedig a csoport létrehozója/tulaja
        public string Title     { get; set; }
        public int StartYear    { get; set; }
        int memberIndex;
        int adminIndex;
        public delegate void GroupMembersAreFullEventHandler(object source, FacebookGroupEventArgs args);
        public event GroupMembersAreFullEventHandler MembersAreFull;

        public User[] Admins
        {
            get { return admins; }
        }
        public User[] Members
        {
            get { return members; }
        }
        public User Owner
        {
            get { return this.owner; }
        }


        // CONSTRUCTOR

        public FacebookGroup(User owner, string title)
        {
            this.Title = title;
            members = new User[5];
            admins = new User[3];
            
            this.owner = owner;
            admins[adminIndex++] = owner;
            
            memberIndex = 0;
        }

        
        // METHODS

        public void AddMember(User whoIsAdding, User whoWillBeAdded)
        {
            // ha admin (tömbben van) akkor adhat hozzá
            // default esetben, aki létrehozza a csoportot az alapból admin lesz
            // lsd. konstruktor

            if ( IsAmongAdmins(whoIsAdding) )
            {
                // mehet, mert admin jogkörrel hozzá lehet adni
                if (members.Length > memberIndex)
                {
                    members[memberIndex++] = whoWillBeAdded;
                    if (members.Length == memberIndex)
                        OnMembersAreFull(this); // utolsó hely betöltésekor jelezzünk esemény formájában
                }
                else
                    throw new NoMoreMemberException("We are full! :(");
            }
            else
                throw new MemberAddingException("You have to be admin, to add a person!");
           
        }

        public void MakeMemberToAdmin(User whoIsMaking, User whoWillBeMade)
        {
            if ( IsAmongAdmins(whoIsMaking) )
                admins[adminIndex++] = whoWillBeMade;
            else
                throw new MemberAddingException("You have to be admin, to make person to admin!");
        }

        private bool IsAmongAdmins(User user)
        {
            for (int i = 0; i < adminIndex; i++)
            {
                if (user.Id == admins[i].Id)
                    return true; // igen, benne van mert az ID-k egyeznek
            }
            return false;
        }

        public override string ToString()
        {
            // formátum: GroupName (2015)
            return this.Title + " (" + this.StartYear + ")";
        }

        protected virtual void OnMembersAreFull(FacebookGroup group)
        {
            if (MembersAreFull != null)
                MembersAreFull(this, new FacebookGroupEventArgs() { FBGroup = group });
        }
    }
}
