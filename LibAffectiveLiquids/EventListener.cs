namespace LibAffectiveFluids
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using StardewModdingAPI;
    using StardewModdingAPI.Events;

    public static class EventListener
    {
        public static void Listen(IModHelper helper, IMonitor monitor)
        {
            helper.Events.World.NpcListChanged += WorldOnNpcListChanged;
            monitor.Log("Listening", LogLevel.Error);
            Debug.WriteLine("Listening");
            Console.WriteLine("Listening");
        }

        private static void WorldOnNpcListChanged(object sender, NpcListChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}