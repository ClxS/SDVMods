namespace LibAffectiveFluids.Systems.Affect
{
    using ECS;
    using StardewValley.Menus;

    public interface IEffectSystem
    {
        void Tick();
    }

    public interface IEffectRenderer
    {
        void Draw();
    }

    public interface IEffectSystem<TComponent> : IEffectSystem
    {
    }

    public interface IEffectRenderer<TComponent> : IEffectRenderer
    {
    }

    public static class EffectSystemExtensions
    {
        public static EntityComponentSet[] GetComponents<T>(this IEffectSystem<T> @this)
        {
            return EcsManager.Get().GetEntitiesWithComponents<T>();
        }

        public static EntityComponentSet[] GetComponents<T>(this IEffectRenderer<T> @this)
        {
            return EcsManager.Get().GetEntitiesWithComponents<T>();
        }
    }
}