namespace LibAffectiveFluids.Systems.Affect
{
    using System;
    using System.Collections.Generic;
    using Systems;
    using API;
    using ECS;
    using Fluids;
    using StardewValley;
    using StardewValley.Monsters;

    internal class EffectApi : IEffectApi
    {
        private readonly AffectSystem affectSystem;
        private readonly AffectRenderSystem affectRenderSystem;

        public EffectApi(AffectSystem affectSystem, AffectRenderSystem affectRenderSystem)
        {
            this.affectSystem = affectSystem;
            this.affectRenderSystem = affectRenderSystem;
            this.componentAffectsMap = new Dictionary<Type, Affects>();
        }

        public IImpartedEffect ApplyEffect<TEffect>(Farmer farmer) where TEffect : IImpartedEffect, new()
        {
            return this.ApplyAffect<TEffect>(farmer);
        }

        public IImpartedEffect ApplyEffect<TEffect>(Monster farmer) where TEffect : IImpartedEffect, new()
        {
            return this.ApplyAffect<TEffect>(farmer);
        }

        private IImpartedEffect ApplyAffect<TEffect>(object target) where TEffect : IImpartedEffect, new()
        {
            var affects = this.componentAffectsMap[typeof(TEffect)];
            var effect = new TEffect();
            switch (target)
            {
                case Farmer _ when (affects & Affects.AllPlayers) == 0:
                    throw new Exception($"Effect of type {typeof(TEffect).Name} cannot be applied to {nameof(Farmer)}.");
                case Monster _ when (affects & Affects.Monsters) == 0:
                    throw new Exception($"Effect of type {typeof(TEffect).Name} cannot be applied to {nameof(Farmer)}.");
            }

            EcsManager.Get().AddComponent<TEffect, IImpartedEffect>(target, effect);
            return effect;
        }

        private readonly Dictionary<Type, Affects> componentAffectsMap;

        public void RegisterEffect<TAssociatedComponent>(IEffectSystem system, IEffectRenderer renderer, Affects affects)
        {
            this.componentAffectsMap[typeof(TAssociatedComponent)] = affects;
            this.affectSystem.RegisterSystem(system);
            this.affectRenderSystem.RegisterRenderer(renderer);
        }

        public void RegisterEffect<TAssociatedComponent>(Affects affects)
        {
            this.componentAffectsMap[typeof(TAssociatedComponent)] = affects;
        }
    }
}