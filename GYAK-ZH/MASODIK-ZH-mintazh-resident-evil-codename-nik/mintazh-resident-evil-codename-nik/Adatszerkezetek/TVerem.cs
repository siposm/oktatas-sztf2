using System;
namespace mintazhresidentevilcodenamenik
{
    public class TVerem <T> : OsAdatszerkezet<T> , IAdatkezelo
    {
        public TVerem(int meret)
        {
            Elemek = new T[meret];
            AktivElemSzam = 0;
        }


        public int AktivElemSzam { get; set; }
        public int Meret { get; private set; }
        public T[] Elemek { get; private set; }


        public override void ElemBerak(T elem)
        {
            if (AktivElemSzam == Meret)
                throw new NincsHelyException()
                {
                    HibaUzenet = "ERR: Nincs szabad hely az adatszerkezetben (TVEREM)."
                };
            else
                Elemek[AktivElemSzam++] = elem;
        }

        public override T ElemKivesz()
        {
            if (AktivElemSzam == 0)
                throw new NincsElemException()
                {
                    HibaUzenet = "ERR: Nincs elem az adatszerkezetben (TVEREM)."
                };
            else
                return Elemek[--AktivElemSzam];
        }

        public override T ElemMegtekint()
        {
            if (AktivElemSzam == 0)
                throw new NincsElemException()
                {
                    HibaUzenet = "ERR: Nincs elem az adatszerkezetben (TVEREM)."
                };
            else
                return Elemek[AktivElemSzam - 1];
        }

    }
}
