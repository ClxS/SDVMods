namespace LibAffectiveFluids.Fluids
{
    using System;

    public interface IImpartedEffect
    {
        TimeSpan TimeRemaining { get; set; }
    }
}