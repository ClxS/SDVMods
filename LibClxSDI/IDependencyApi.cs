namespace LibClxSDI
{
    using System;

    public interface IDependencyApi
    {
        IBuilder GetBuilder(string modManifestUniqueId);

        T Resolve<T>(string modManifestUniqueId);

        event EventHandler Composed;
    }
}