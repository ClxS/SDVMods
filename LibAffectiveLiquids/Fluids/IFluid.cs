namespace LibAffectiveFluids.Fluids
{
    public interface IFluid
    {
        Affects Affects { get; }

        void OnImpacted(object impactee);
    }
}