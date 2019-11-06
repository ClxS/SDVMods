namespace LibAffectiveFluids.API
{
    public class FluidApi : IFluidApi
    {
        private readonly IEffectApi effectApi;

        public FluidApi(IEffectApi effectApi)
        {
            this.effectApi = effectApi;
        }

        public IEffectApi GetEffectApi()
        {
            return this.effectApi;
        }
    }
}