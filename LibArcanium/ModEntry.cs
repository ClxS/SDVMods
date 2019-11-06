namespace LibArcanium
{
    using System;
    using API;
    using Attunements;
    using LibClxSDI;
    using StardewModdingAPI;
    using Constants = LibClxSDI.Constants;

    public class ModEntry : Mod
    {
        private IArcaniumApi api;

        public override void Entry(IModHelper helper)
        {
            var diApiObj = helper.ModRegistry.GetApi(Constants.ModId);
            if (!(diApiObj is IDependencyApi diApi))
            {
                throw new Exception(
                    $"{nameof(LibArcanium)} relies on {nameof(LibClxSDI)} but could not access API using mod key {Constants.ModId}.");
            }

            var builder = diApi.GetBuilder(this.ModManifest.UniqueID);
            builder.RegisterType<AttunementManager>().As<IAttunementManager>().SingleInstance();

            this.api = new ArcaniumApi(diApi, this.ModManifest);
        }

        public override object GetApi()
        {
            return this.api;
        }
    }
}