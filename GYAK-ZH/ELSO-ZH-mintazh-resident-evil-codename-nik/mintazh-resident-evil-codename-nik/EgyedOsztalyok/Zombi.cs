using System;
namespace mintazhresidentevilcodenamenik
{
    public abstract class Zombi : IEllenseg
    {
        public Zombi(int eletero)
        {
            this.Eletero = eletero;
        }

        public delegate void MeghaltEventHandler(object source, ZombiMeghaltEventArgs args);
        public event MeghaltEventHandler Meghalt;

        public int Eletero
        {
            get { return this.eletero; }
            set
            {
                this.eletero = value;
                if (eletero <= 0)
                    OnMeghalt();
            }
        }

        private int eletero;

        public int Sebzes { get; set; }

        public virtual bool Tamadas(IJatekos jatekos)
        {
            return false; // zombi sosem lesz használva így
            // az IEllenseg előírta, hogy legyen ilyen metódus...

            // másik megoldás, ha interface-ban nem írjuk elő, és csak itt hozzuk
            // létre a metódust mint abs. metódus, ez esetben viszont elveszítjük az
            // interface előnyét... >> ezért választottuk inkább ezt az utat.
        }

        public abstract override string ToString();

        public abstract void EleteroVisszatoltes();

        protected virtual void OnMeghalt()
        {
            if (Meghalt != null)
                Meghalt(this, new ZombiMeghaltEventArgs()
                {
                    Ellenseg = this,
                    Idobelyeg = DateTime.Now
                });
        }

        public virtual void LogZombi()
        {
            Console.WriteLine("[LOG]: " + this.GetType());
        }
    }
}
