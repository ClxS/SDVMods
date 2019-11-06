namespace LibClxSDI
{
    using Autofac;
    using StardewModdingAPI;

    public class ModEntry : Mod
    {
        private readonly AutofacDependencyApi api = new AutofacDependencyApi();

        public override void Entry(IModHelper helper)
        {
        }

        public override object GetApi()
        {
            return this.api;
        }
    }
}