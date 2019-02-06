using System;
namespace mintazhresidentevilcodenamenik
{
    public class Jatek
    {
        public Jatek(int ellenfelekSzama)
        {
            Ellenfelek = new IEllenseg[ellenfelekSzama];
            EllenfelSzam = 0;
        }

        public Jatekos Jatekos { get; set; }
        public IEllenseg[] Ellenfelek { get; set; }
        public int EllenfelSzam { get; set; }
        JatekTalalatFigyeloService TalalatFigyeloService { get; set; }
        ZombiMeghaltFigyeloService MeghaltFigyeloService { get; set; }

        public void EllenfelHozzaadas(IEllenseg ellenseg)
        {
            if (EllenfelSzam < Ellenfelek.Length)
                Ellenfelek[EllenfelSzam++] = ellenseg;
            else
                throw new EllenfelekTeleException()
                {
                    HibaUzenet = "ERR: Nincs hely több ellenfélnek a játékban."
                };
        }

        public void EllenfelekListazasa()
        {
            for (int i = 0; i < Ellenfelek.Length; i++)
            {
                Console.WriteLine(">" + Ellenfelek[i]);
            }
        }

        public void Tamadas(IEllenseg ellenseg)
        {
            Jatekos.Tamadas(ellenseg);
        }

        public void EsemenyFeliratkoztatas()
        {
            TalalatFigyeloService = new JatekTalalatFigyeloService();
            Jatekos.Talalat += TalalatFigyeloService.OnTalalat;

            MeghaltFigyeloService = new ZombiMeghaltFigyeloService();
            for (int i = 0; i < Ellenfelek.Length; i++)
            {
                (Ellenfelek[i] as Zombi).Meghalt += MeghaltFigyeloService.OnMeghalt;
            }
        }


    }
}
