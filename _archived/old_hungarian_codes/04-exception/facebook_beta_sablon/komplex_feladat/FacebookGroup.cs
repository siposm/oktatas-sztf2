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
    

        // ****************

        // TODO: delegált + esemény!...
        // Használandó név: GroupMembersAreFullEventHandler

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
            // ha 'who_is_adding' admin ÉS van hely az members tömbben
            // akkor hozzáadhatjuk

            // ha betelt ezt követően a helyek száma, akkor esemény formájában jelezzünk
            //      OnMembersAreFull()

            // ha nincs már hely alapból akkor NoMoreMemberException-t dobjunk

            // ha pedig nem admin jogosultságú a személy, akkor MemberAddingException-t dobjunk
        }

        public void MakeMemberToAdmin(User whoIsMaking, User whoWillBeMade)
        {
            // ha 'who_is_making' admin akkor adhat hozzá
            // egyéb esetben dobjunk hibát Member_Adding_Exception
        }

        private bool IsAmongAdmins(User user)
        {
            // a paraméterként kapott user benne van-e az admin tömbben
        }

        public override string ToString()
        {
            // print out: Title ([year created])
        }
            

        protected virtual void OnMembersAreFull(FacebookGroup group)
        {
            // süssük el az eseményt
            // használjuk a saját esemény argumentum osztályt
        }
    }
}
