namespace LibAffectiveFluids.Fluids.Liquids
{
    using System;

    internal class ToxicSlime : IFluid
    {
        public Affects Affects => Affects.AllPlayersAndMonsters;

        public void OnImpacted(object impactee)
        {
            throw new NotImplementedException();
        }
    }
}