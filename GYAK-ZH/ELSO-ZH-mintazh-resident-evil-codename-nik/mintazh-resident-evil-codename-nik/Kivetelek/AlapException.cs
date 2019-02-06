using System;
namespace mintazhresidentevilcodenamenik
{
    public class AlapException : Exception, IKivetelek
    {
        public string HibaUzenet { get; set; }
    }
}
