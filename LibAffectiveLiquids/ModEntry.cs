namespace LibAffectiveFluids
{
    using Systems;
    using Systems.Affect;
    using Systems.Affect.Inbuilt;
    using API;
    using ECS;
    using Fluids;
    using StardewModdingAPI;

    public class ModEntry : Mod
    {
        private FluidApi api;
        private EffectApi effectApi;
        private SystemManager systemManager = new SystemManager();

        public override void Entry(IModHelper helper)
        {
            EcsManager.Ensure(helper);
            this.systemManager = new SystemManager();

            this.CreateEffectSystem(helper);
            this.api = new FluidApi(this.effectApi);

            this.RegisterDefaults();
            this.Helper.Events.GameLoop.UpdateTicking += GameLoop_UpdateTicking;
        }

        private void GameLoop_UpdateTicking(object sender, StardewModdingAPI.Events.UpdateTickingEventArgs e)
        {
            this.systemManager.Tick();
        }

        private void RegisterDefaults()
        {
        }

        private void CreateEffectSystem(IModHelper helper)
        {
            var affectSystem = new AffectSystem();
            var renderSystem = new AffectRenderSystem(helper, affectSystem);
            this.effectApi = new EffectApi(affectSystem, renderSystem);
            this.systemManager.AddSystem(affectSystem);
            this.systemManager.AddSystem(renderSystem);
        }

        public override object GetApi()
        {
            return this.api;
        }
    }
}