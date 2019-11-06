namespace LibClxSDI.Autofac
{
    using System;
    using System.Collections.Generic;
    using global::Autofac;

    public class AutofacDependencyApi : IDependencyApi
    {
        public event EventHandler Composed;

        private readonly Dictionary<string, AutofacBuilder>
            containerBuilders = new Dictionary<string, AutofacBuilder>();

        private readonly Dictionary<string, IContainer> containers = new Dictionary<string, IContainer>();

        public IBuilder GetBuilder(string modManifestUniqueId)
        {
            if (!this.containerBuilders.ContainsKey(modManifestUniqueId))
            {
                this.containerBuilders[modManifestUniqueId] = new AutofacBuilder(new ContainerBuilder());
            }

            this.RegisterDefaults(this.containerBuilders[modManifestUniqueId]);

            return this.containerBuilders[modManifestUniqueId];
        }

        public T Resolve<T>(string modManifestUniqueId)
        {
            return this.containers[modManifestUniqueId].Resolve<T>();
        }

        private void RegisterDefaults(AutofacBuilder containerBuilder)
        {
            containerBuilder.Builder.RegisterGeneric(typeof(AutofacIndexed<,>)).As(typeof(IIndexed<,>));
        }

        internal void Compose()
        {
            foreach (var builder in this.containerBuilders)
            {
                this.containers[builder.Key] = builder.Value.Build();
            }

            this.OnComposed();
        }

        protected virtual void OnComposed()
        {
            this.Composed?.Invoke(this, EventArgs.Empty);
        }
    }
}