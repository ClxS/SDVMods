namespace LibClxSDI.Autofac
{
    using System;
    using System.Collections.Generic;
    using global::Autofac.Builder;

    internal class AutofacRegistrationBuilder<TInst, TActivatorData, TRegistrationStyle> : IRegistrationBuilder<TInst>
    {
        private readonly IRegistrationBuilder<TInst, TActivatorData, TRegistrationStyle> registerInstance;

        public AutofacRegistrationBuilder(
            IRegistrationBuilder<TInst, TActivatorData, TRegistrationStyle> registerInstance)
        {
            this.registerInstance = registerInstance;
        }

        public IRegistrationBuilder<TInst> As(params Type[] services)
        {
            this.registerInstance.As(services);
            return this;
        }

        public IRegistrationBuilder<TInst> As<TService1, TService2, TService3>()
        {
            this.registerInstance.As<TService1, TService2, TService3>();
            return this;
        }

        public IRegistrationBuilder<TInst> As<TService1, TService2>()
        {
            this.registerInstance.As<TService1, TService2>();
            return this;
        }

        public IRegistrationBuilder<TInst> As<TService>()
        {
            this.registerInstance.As<TService>();
            return this;
        }

        public IRegistrationBuilder<TInst> ExternallyOwned()
        {
            this.registerInstance.ExternallyOwned();
            return this;
        }

        public IRegistrationBuilder<TInst> InstancePerLifetimeScope()
        {
            this.registerInstance.InstancePerLifetimeScope();
            return this;
        }

        public IRegistrationBuilder<TInst> Keyed(object serviceKey, Type serviceType)
        {
            this.registerInstance.Keyed(serviceKey, serviceType);
            return this;
        }

        public IRegistrationBuilder<TInst> Keyed<TService>(object serviceKey)
        {
            this.registerInstance.Keyed<TService>(serviceKey);
            return this;
        }

        public IRegistrationBuilder<TInst> Named(string serviceName, Type serviceType)
        {
            this.registerInstance.Named(serviceName, serviceType);
            return this;
        }

        public IRegistrationBuilder<TInst> Named<TService>(string serviceName)
        {
            this.registerInstance.Named<TService>(serviceName);
            return this;
        }

        public IRegistrationBuilder<TInst> SingleInstance()
        {
            this.registerInstance.SingleInstance();
            return this;
        }

        public IRegistrationBuilder<TInst> WithMetadata(string key, object value)
        {
            this.registerInstance.WithMetadata(key, value);
            return this;
        }

        public IRegistrationBuilder<TInst> WithMetadata(IEnumerable<KeyValuePair<string, object>> properties)
        {
            this.registerInstance.WithMetadata(properties);
            return this;
        }

        public IRegistrationBuilder<TInst> WithMetadata<TMetadata>(
            Action<MetadataConfiguration<TMetadata>> configurationAction)
        {
            this.registerInstance.WithMetadata(configurationAction);
            return this;
        }
    }
}