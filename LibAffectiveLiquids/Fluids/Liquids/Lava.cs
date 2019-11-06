namespace LibAffectiveFluids.Fluids.Liquids
{
    using System;

    internal class Lava : IFluid
    {
        public Affects Affects => Affects.Everything;

        public void OnImpacted(object impactee)
        {
            throw new NotImplementedException();
        }
    }
}