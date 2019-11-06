namespace LibAffectiveFluids.Behaviours.Spread
{
    using Fluids;

    public interface ISpreadBehaviour
    {
        void Tick(IFluid fluid);
    }
}