namespace LibClxSDI.Autofac
{
    using System;
    using global::Autofac;
    using global::Autofac.Builder;

    internal class AutofacBuilder : IBuilder
    {
        public AutofacBuilder(ContainerBuilder builder)
        {
            this.Builder = builder;
        }

        internal ContainerBuilder Builder { get; }

        public IRegistrationBuilder<T> RegisterInstance<T>(T instance) where T : class
        {
            return new AutofacRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle>(
                this.Builder.RegisterInstance(instance));
        }

        public IRegistrationBuilder<TImplementer> RegisterType<TImplementer>()
        {
            return new AutofacRegistrationBuilder<TImplementer, ConcreteReflectionActivatorData, SingleRegistrationStyle
            >(this.Builder.RegisterType<TImplementer>());
        }

        public IRegistrationBuilder<object> RegisterType(Type implementationType)
        {
            return new AutofacRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>(
                this.Builder.RegisterType(implementationType));
        }

        internal IContainer Build()
        {
            return this.Builder.Build();
        }
    }
}