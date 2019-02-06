using System;
namespace mintazhresidentevilcodenamenik
{
    public class TalalatEventArgs : EventArgs
    {
        public IEllenseg Ellenseg { get; set; }
        public Jatekos Jatekos { get; set; }
        public DateTime Idobelyeg { get; set; }
    }
}
