namespace LibAffectiveFluids.Fluids.Gases
{
    using System;

    internal class ToxicGas : IFluid
    {
        public Affects Affects => Affects.AllPlayersAndMonsters;

        public void OnImpacted(object impactee)
        {
            throw new NotImplementedException();
        }
    }
}