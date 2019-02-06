using System;
namespace mintazhresidentevilcodenamenik
{
    public class TSor <T> : OsAdatszerkezet<T>, IAdatkezelo
    {
        public TSor(int meret)
        {
            Elemek = new T[meret];
            AktivElemSzam = 0;
            IndexBe = 0;
            IndexKi = 0;
            Meret = meret;
        }


        public int AktivElemSzam { get; set; }
        public int Meret { get; private set; }
        public T[] Elemek { get; private set; }

        private int IndexBe { get; set; }
        private int IndexKi { get; set; }


        public override void ElemBerak(T elem)
        {
            if (AktivElemSzam == Elemek.Length)
                throw new NincsHelyException()
                {
                    HibaUzenet = "ERR: Nincs szabad hely az adatszerkezetben (TSOR)."
                };
            else
            {
                Elemek[IndexBe++] = elem;
                AktivElemSzam++;
            }
        }

        public override T ElemKivesz()
        {
            if( AktivElemSzam == 0 )
                throw new NincsElemException()
                {
                    HibaUzenet = "ERR: Nincs elem az adatszerkezetben (TSOR)."
                };
            else
            {
                T visszaAdando = Elemek[0];

                // mozgatás
                for (int i = 0; i < AktivElemSzam-1; i++)
                {
                    Elemek[i] = Elemek[i+1];
                }

                AktivElemSzam--;
                IndexBe--;
                return visszaAdando;
            }
        }

        public override T ElemMegtekint()
        {
            if (AktivElemSzam == 0)
                throw new NincsElemException()
                {
                    HibaUzenet = "ERR: Nincs elem az adatszerkezetben (TSOR)."
                };
            else
                return Elemek[0];
        }
    }
}
