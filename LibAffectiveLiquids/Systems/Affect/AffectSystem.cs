namespace LibAffectiveFluids.Systems.Affect
{
    using System;
    using System.Collections.Generic;
    using ECS;
    using Fluids;

    internal class AffectSystem : ISystem
    {
        private readonly List<IEffectSystem> effectSystems = new List<IEffectSystem>();

        public void Tick()
        {
            DecreaseRemainingTime();
            foreach (var system in this.effectSystems)
            {
                system.Tick();
            }
        }

        private static void DecreaseRemainingTime()
        {
            var entitySets = EcsManager.Get().GetEntitiesWithComponents<IImpartedEffect>();
            foreach (var entitySet in entitySets)
            {
                foreach (var component in entitySet.ComponentsOfType<IImpartedEffect>())
                {
                    component.TimeRemaining -= TimeSpan.FromSeconds(1 / 60.0);
                    if (component.TimeRemaining.TotalMilliseconds <= 0)
                    {
                        entitySet.Entity.RemoveComponent(component);
                    }
                }
            }
        }

        public void RegisterSystem(IEffectSystem system)
        {
            this.effectSystems.Add(system);
        }
    }
}