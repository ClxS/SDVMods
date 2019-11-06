namespace LibAffectiveFluids.Systems.Affect
{
    using API;
    using Fluids;

    public static class EffectApiExtensions
    {
        public static void RegisterEffect<TComponent1, TComponent2>(this IEffectApi @this, IEffectSystem system, IEffectRenderer renderer, Affects affects)
        {
            @this.RegisterEffect<TComponent1>(system, renderer, affects);
            @this.RegisterEffect<TComponent2>(affects);
        }
        public static void RegisterEffect<TComponent1, TComponent2, TComponent3>(this IEffectApi @this, IEffectSystem system, IEffectRenderer renderer, Affects affects)
        {
            @this.RegisterEffect<TComponent1>(system, renderer, affects);
            @this.RegisterEffect<TComponent2>(affects);
            @this.RegisterEffect<TComponent3>(affects);
        }
        public static void RegisterEffect<TComponent1, TComponent2, TComponent3, TComponent4>(this IEffectApi @this, IEffectSystem system, IEffectRenderer renderer, Affects affects)
        {
            @this.RegisterEffect<TComponent1>(system, renderer, affects);
            @this.RegisterEffect<TComponent2>(affects);
            @this.RegisterEffect<TComponent3>(affects);
            @this.RegisterEffect<TComponent4>(affects);
        }
        public static void RegisterEffect<TComponent1, TComponent2, TComponent3, TComponent4, TComponent5>(this IEffectApi @this, IEffectSystem system, IEffectRenderer renderer, Affects affects)
        {
            @this.RegisterEffect<TComponent1>(system, renderer, affects);
            @this.RegisterEffect<TComponent2>(affects);
            @this.RegisterEffect<TComponent3>(affects);
            @this.RegisterEffect<TComponent4>(affects);
            @this.RegisterEffect<TComponent5>(affects);
        }

        public static void RegisterEffectSystems<TSystem, TRenderer, TComponent1>(this IEffectApi @this, Affects affects)
            where TSystem : IEffectSystem, new()
            where TRenderer : IEffectRenderer, new()
        {
            var system = new TSystem();
            var renderer = new TRenderer();
            @this.RegisterEffect<TComponent1>(system, renderer, affects);
        }

        public static void RegisterEffectSystems<TSystem, TRenderer, TComponent1, TComponent2>(this IEffectApi @this, Affects affects)
            where TSystem : IEffectSystem, new()
            where TRenderer : IEffectRenderer, new()
        {
            var system = new TSystem();
            var renderer = new TRenderer();
            @this.RegisterEffect<TComponent1, TComponent2>(system, renderer, affects);
        }

        public static void RegisterEffectSystems<TSystem, TRenderer, TComponent1, TComponent2, TComponent3>(this IEffectApi @this, Affects affects)
            where TSystem : IEffectSystem, new()
            where TRenderer : IEffectRenderer, new()
        {
            var system = new TSystem();
            var renderer = new TRenderer();
            @this.RegisterEffect<TComponent1, TComponent2, TComponent3>(system, renderer, affects);
        }

        public static void RegisterEffectSystems<TSystem, TRenderer, TComponent1, TComponent2, TComponent3, TComponent4>(this IEffectApi @this, Affects affects)
            where TSystem : IEffectSystem, new()
            where TRenderer : IEffectRenderer, new()
        {
            var system = new TSystem();
            var renderer = new TRenderer();
            @this.RegisterEffect<TComponent1, TComponent2, TComponent3, TComponent4>(system, renderer, affects);
        }

        public static void RegisterEffectSystems<TSystem, TRenderer, TComponent1, TComponent2, TComponent3, TComponent4, TComponent5>(this IEffectApi @this, Affects affects)
            where TSystem : IEffectSystem, new()
            where TRenderer : IEffectRenderer, new()
        {
            var system = new TSystem();
            var renderer = new TRenderer();
            @this.RegisterEffect<TComponent1, TComponent2, TComponent3, TComponent4, TComponent5>(system, renderer, affects);
        }

        public static void RegisterEffect<TComponent1, TComponent2>(this IEffectApi @this, Affects affects)
        {
            @this.RegisterEffect<TComponent1>(affects);
            @this.RegisterEffect<TComponent2>(affects);
        }

        public static void RegisterEffect<TComponent1, TComponent2, TComponent3>(this IEffectApi @this, Affects affects)
        {
            @this.RegisterEffect<TComponent1>(affects);
            @this.RegisterEffect<TComponent2>(affects);
            @this.RegisterEffect<TComponent3>(affects);
        }

        public static void RegisterEffect<TComponent1, TComponent2, TComponent3, TComponent4>(this IEffectApi @this, Affects affects)
        {
            @this.RegisterEffect<TComponent1>(affects);
            @this.RegisterEffect<TComponent2>(affects);
            @this.RegisterEffect<TComponent3>(affects);
            @this.RegisterEffect<TComponent4>(affects);
        }

        public static void RegisterEffect<TComponent1, TComponent2, TComponent3, TComponent4, TComponent5>(this IEffectApi @this, Affects affects)
        {
            @this.RegisterEffect<TComponent1>(affects);
            @this.RegisterEffect<TComponent2>(affects);
            @this.RegisterEffect<TComponent3>(affects);
            @this.RegisterEffect<TComponent4>(affects);
            @this.RegisterEffect<TComponent5>(affects);
        }
    }
}