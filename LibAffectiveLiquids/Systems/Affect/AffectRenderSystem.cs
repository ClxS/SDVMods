namespace LibAffectiveFluids.Systems.Affect
{
    using System.Collections.Generic;
    using ECS;
    using StardewModdingAPI;
    using StardewModdingAPI.Events;

    internal class AffectRenderSystem : ISystem
    {
        private readonly List<IEffectRenderer> renderers;

        public AffectRenderSystem(IModHelper helper, AffectSystem affectSystem)
        {
            this.renderers = new List<IEffectRenderer>();
            helper.Events.Display.Rendered += this.Display_Rendered;
        }

        public void Tick()
        {
            // Do nothing
        }

        private void Display_Rendered(object sender, RenderedEventArgs e)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.Draw();
            }
        }

        public void RegisterRenderer(IEffectRenderer renderer)
        {
            this.renderers.Add(renderer);
        }
    }
}