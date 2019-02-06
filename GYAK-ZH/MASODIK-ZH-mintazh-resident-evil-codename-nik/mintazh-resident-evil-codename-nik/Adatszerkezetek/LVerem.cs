using System;
namespace mintazhresidentevilcodenamenik
{
    public class LVerem<T> : OsAdatszerkezet<T> , IAdatkezelo
    {
        public LVerem()
        {
        }

        public int AktivElemSzam
        {
            get; set;
        }

        public override void ElemBerak(T elem)
        {
            throw new NotImplementedException();
        }

        public void ElemBerakas()
        {
            throw new NotImplementedException();
        }

        public override T ElemKivesz()
        {
            throw new NotImplementedException();
        }

        public override T ElemMegtekint()
        {
            throw new NotImplementedException();
        }
    }
}
