using System;
namespace mintazhresidentevilcodenamenik
{
    public sealed class Tyrant : IFoEllenseg
    {
        public int Legyozhetoseg { get; set; }
        public int Eletero { get; set; }
        public int Sebzes { get; set; }

        public bool Tamadas(IJatekos jatekos)
        {
            jatekos.Eletero -= this.Sebzes;
            return true;
        }
    }
}
