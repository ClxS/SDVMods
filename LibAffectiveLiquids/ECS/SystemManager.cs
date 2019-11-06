namespace LibAffectiveFluids.ECS
{
    using System.Collections.Generic;

    internal class SystemManager
    {
        private readonly List<ISystem> systems;

        public SystemManager()
        {
            this.systems = new List<ISystem>();
        }

        public void Tick()
        {
            foreach (var system in this.systems)
            {
                system.Tick();
            }
        }

        public void AddSystem(ISystem system)
        {
            this.systems.Add(system);
        }
    }
}