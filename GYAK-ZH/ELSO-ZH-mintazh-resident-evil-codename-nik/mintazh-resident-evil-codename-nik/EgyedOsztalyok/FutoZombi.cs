using System;
namespace mintazhresidentevilcodenamenik
{
    public sealed class FutoZombi : Zombi
    {
        public FutoZombi(int eletero) : base(eletero)
        {

        }

        public FutoZombi(int eletero, int stamina) : base(eletero)
        {
            this.Stamina = stamina;
        }

        public int Stamina { get; set; }

        public override string ToString()
        {
            return string.Format("FUTOZOMBI - ({0}) ({1}) ({2})" , base.Eletero, base.Sebzes, Stamina);
        }

        public override bool Tamadas(IJatekos jatekos)
        {
            jatekos.Eletero -= 15;
            return true;
        }

        public override void EleteroVisszatoltes()
        {
            this.Eletero += 10;
        }

        public override void LogZombi()
        {
            Console.WriteLine("[LOG]: FUTO: " + this.GetType());
        }
    }
}
