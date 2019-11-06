namespace LibClxSDI
{
    using System;

    public interface IBuilder
    {
        IRegistrationBuilder<T> RegisterInstance<T>(T instance) where T : class;

        IRegistrationBuilder<TImplementer> RegisterType<TImplementer>();

        IRegistrationBuilder<object> RegisterType(Type implementationType);
    }
}