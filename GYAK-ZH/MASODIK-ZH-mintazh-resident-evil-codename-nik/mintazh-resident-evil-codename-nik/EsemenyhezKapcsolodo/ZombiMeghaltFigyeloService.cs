using System;
namespace mintazhresidentevilcodenamenik
{
    public class ZombiMeghaltFigyeloService
    {
        public void OnMeghalt(object source, ZombiMeghaltEventArgs args)
        {
            Console.WriteLine(

                "\nLOG [{0}]:"
                +
                "\n\tA(z) {1} ellenség meghalt."

                ,

                args.Idobelyeg, 
                args.Ellenseg

                );
        }
    }
}
