namespace Ascension
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using LibAffectiveFluids.API;
    using LibAffectiveFluids.Fluids;
    using LibAffectiveFluids.Systems.Affect;
    using LibAffectiveFluids.Systems.Affect.Inbuilt;
    using Microsoft.Xna.Framework;
    using StardewModdingAPI;
    using StardewValley;
    using StardewValley.Monsters;
    using Constants = LibAffectiveFluids.API.Constants;

    public class ModEntry : Mod
    {
        private IFluidApi AffectiveFluids { get; set; }

        public override void Entry(IModHelper helper)
        {
            this.AffectiveFluids = this.GetFluidApi(helper);
            helper.Events.GameLoop.SaveLoaded += GameLoop_SaveLoaded;
            Helper.Events.World.NpcListChanged += World_NpcListChanged;
            Helper.Events.Player.Warped += Player_Warped;

            this.AffectiveFluids.GetEffectApi().RegisterEffectSystems<BurningSystem, BurningRenderer, Burning>(Affects.AllPlayersAndMonsters);
        }

        private void Player_Warped(object sender, StardewModdingAPI.Events.WarpedEventArgs e)
        {
            Debug.WriteLine($"New Location with {e.NewLocation.characters.Count(c => c.IsMonster)} monsters");
            foreach (var monster in e.NewLocation.characters.Where(c => c.IsMonster).Cast<Monster>())
            {
                this.AffectiveFluids.GetEffectApi().ApplyEffect<Burning>(monster);
            }
        }

        private void GameLoop_SaveLoaded(object sender, StardewModdingAPI.Events.SaveLoadedEventArgs e)
        {
            Game1.enterMine(5);
        }

        private void World_NpcListChanged(object sender, StardewModdingAPI.Events.NpcListChangedEventArgs e)
        {
            //Monitor.Log($"New Npc List with {e.Added.Count(n => n.IsMonster)} monsters");
        }

        private IFluidApi GetFluidApi(IModHelper helper)
        {
            var apiObj = helper.ModRegistry.GetApi(Constants.ModId);
            if (!(apiObj is IFluidApi api))
            {
                throw new Exception(
                    $"{nameof(Ascension)} relies on {nameof(LibAffectiveFluids)} but could not access API using mod key {Constants.ModId}.");
            }

            return api;
        }
    }
}