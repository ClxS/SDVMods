namespace ModLavaDemonstration
{
    using LibArcanium.API;
    using StardewModdingAPI;
    using Constants = LibArcanium.API.Constants;

    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            var arcanium = helper.ModRegistry.GetApi<IArcaniumApi>(Constants.ModId);
            arcanium.RegisterDefaults();
        }
    }
}