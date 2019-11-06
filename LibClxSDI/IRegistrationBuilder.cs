namespace LibClxSDI
{
    using System;
    using System.Collections.Generic;
    using global::Autofac.Builder;

    public interface IRegistrationBuilder<TInst>
    {
        IRegistrationBuilder<TInst> As(params Type[] services);

        IRegistrationBuilder<TInst> As<TService1, TService2, TService3>();

        IRegistrationBuilder<TInst> As<TService1, TService2>();

        IRegistrationBuilder<TInst> As<TService>();

        IRegistrationBuilder<TInst> ExternallyOwned();

        IRegistrationBuilder<TInst> InstancePerLifetimeScope();

        IRegistrationBuilder<TInst> Keyed(object serviceKey, Type serviceType);

        IRegistrationBuilder<TInst> Keyed<TService>(object serviceKey);

        IRegistrationBuilder<TInst> Named(string serviceName, Type serviceType);

        IRegistrationBuilder<TInst> Named<TService>(string serviceName);

        IRegistrationBuilder<TInst> SingleInstance();

        IRegistrationBuilder<TInst> WithMetadata(string key, object value);

        IRegistrationBuilder<TInst> WithMetadata(IEnumerable<KeyValuePair<string, object>> properties);

        IRegistrationBuilder<TInst> WithMetadata<TMetadata>(
            Action<MetadataConfiguration<TMetadata>> configurationAction);
    }
}