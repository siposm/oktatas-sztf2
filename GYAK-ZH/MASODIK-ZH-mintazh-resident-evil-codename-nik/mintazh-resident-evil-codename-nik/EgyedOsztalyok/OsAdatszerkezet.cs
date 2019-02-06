using System;
namespace mintazhresidentevilcodenamenik
{
    public abstract class OsAdatszerkezet <T>
    {
        public abstract void ElemBerak(T elem);
        public abstract T ElemKivesz();
        public abstract T ElemMegtekint();
    }
}
