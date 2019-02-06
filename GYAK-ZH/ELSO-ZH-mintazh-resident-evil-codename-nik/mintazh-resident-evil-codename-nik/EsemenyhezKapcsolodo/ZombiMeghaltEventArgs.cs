using System;
namespace mintazhresidentevilcodenamenik
{
    public class ZombiMeghaltEventArgs : EventArgs
    {
        public IEllenseg Ellenseg { get; set; }
        public DateTime Idobelyeg { get; set; }
    }
}
