using System;
namespace mintazhresidentevilcodenamenik
{
    public class JatekTalalatFigyeloService
    {
        public void OnTalalat(object source, TalalatEventArgs args)
        {
            Console.WriteLine(

                "\nLOG [{2}]:"
                +
                "\n\tA {0} játékos eltalálta a(z) {1} ellenfelet."
                +
                "\n\tEllenfél új életereje: {3}"

                ,

                args.Jatekos,
                args.Ellenseg,
                args.Idobelyeg,
                args.Ellenseg.Eletero

                );
        }
    }
}
