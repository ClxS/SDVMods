namespace LibAffectiveFluids.Systems.Affect.Inbuilt
{
    using System;
    using System.Threading.Tasks;
    using Fluids;
    using Utility;

    public class Burning : IImpartedEffect
    {
        public Burning(int damagePerTick, double tickDuration, TimeSpan duration)
        {
            this.Damage = damagePerTick;
            this.TickDuration = tickDuration;
            this.TimeUntilTick = tickDuration;
            this.TimeRemaining = duration;
        }

        public TimeSpan TimeRemaining { get; set; }

        public readonly int Damage;

        public double TimeUntilTick;

        public readonly double TickDuration;
    }

    public class BurningSystem : IEffectSystem<Burning>
    {
        public void Tick()
        {
            Parallel.ForEach(this.GetComponents(),
                entitySet =>
                {
                    foreach (var component in entitySet.ComponentsOfType<Burning>())
                    {
                        component.TimeUntilTick -= component.TickDuration;
                        if (component.TimeUntilTick < 0.0)
                        {
                            TargetHelpers.HurtEntity(entitySet.Entity.Target, component.Damage);
                            component.TimeUntilTick = component.TickDuration;
                        }
                    }
                });
        }
    }

    public class BurningRenderer : IEffectRenderer<Burning>
    {
        public void Draw()
        {
        }
    }
}