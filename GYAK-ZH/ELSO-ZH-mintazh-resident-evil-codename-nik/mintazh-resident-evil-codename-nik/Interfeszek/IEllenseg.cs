using System;
namespace mintazhresidentevilcodenamenik
{
    public interface IEllenseg
    {
        int Eletero { get; set; }
        int Sebzes { get; set; }
        bool Tamadas(IJatekos jatekos);
    }
}
