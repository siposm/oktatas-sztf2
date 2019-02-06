using System;
namespace mintazhresidentevilcodenamenik
{
    public class LSor<T> : OsAdatszerkezet<T> , IAdatkezelo 
    {
        public LSor()
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
