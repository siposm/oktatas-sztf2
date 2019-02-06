using System;

namespace mintazhresidentevilcodenamenik
{
    public interface IJatekos
    {
        string Nev { get; set; }
        int Eletero { get; set; }
        int Sebzes { get; set; }
        JatekosKarakter Karakter { get; set; }
        void Tamadas(IEllenseg ellenseg);

    }
}
