using System;
namespace mintazhresidentevilcodenamenik
{
    public sealed class BioZombi : Zombi
    {
        public BioZombi(int eletero) : base(eletero)
        {

        }

        public BioZombi(int eletero, int sugarzas) : base(eletero)
        {
            this.Sugarzas = sugarzas;
        }

        public int Sugarzas { get; set; }

        public override string ToString()
        {
            return string.Format("BIOZOMBI - ({0}) ({1}) ({2})", base.Eletero, base.Sebzes, Sugarzas);
        }

        public override bool Tamadas(IJatekos jatekos)
        {
            jatekos.Eletero -= 10;
            return true;
        }

        public override void EleteroVisszatoltes()
        {
            this.Eletero += 10;
        }

        public override void LogZombi()
        {
            Console.WriteLine("[LOG]: BIO: " + this.GetType());
        }

        public void ModellGeneralas()
        {
            Random r = new Random();
            if (r.Next(1) == 0)
                throw new ZombiModellBetoltesException()
                {
                    HibaUzenet = "ERR: modell betöltése sikertelen.",
                    Zombi = this
                };
            else
            {
                // modell létrehozása ...
            }
        }
    }
}
