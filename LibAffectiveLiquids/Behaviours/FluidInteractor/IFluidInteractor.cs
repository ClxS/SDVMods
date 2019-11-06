namespace LibAffectiveFluids.Behaviours.FluidInteractor
{
    using Fluids;

    public interface IFluidInteractor
    {
        void PerformInteraction(IFluid a, IFluid b);
    }
}