namespace LibAffectiveFluids.API
{
    using Systems.Affect;
    using Fluids;
    using Renderers;
    using StardewValley;
    using StardewValley.Monsters;

    public interface IEffectApi
    {
        IImpartedEffect ApplyEffect<TEffect>(Farmer farmer) where TEffect : IImpartedEffect, new();

        IImpartedEffect ApplyEffect<TEffect>(Monster farmer) where TEffect : IImpartedEffect, new();

        void RegisterEffect<TAssociatedComponent>(IEffectSystem system, IEffectRenderer renderer, Affects affects);

        void RegisterEffect<TAssociatedComponent>(Affects affects);
    }
}