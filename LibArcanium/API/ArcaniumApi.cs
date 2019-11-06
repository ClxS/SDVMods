namespace LibArcanium.API
{
    using System;
    using System.Collections.Generic;
    using Attunements;
    using Attunements.Attunements;
    using LibClxSDI;
    using StardewModdingAPI;

    public interface IArcaniumApi
    {
        void RegisterDefaults();

        void RegisterAttunement<TSpecification, TAttunementInstance>(string uniqueId)
            where TSpecification : IAttunementSpecification where TAttunementInstance : IAttunement;

        IAttunementManager GetAttunementManager();
    }

    public class ArcaniumApi : IArcaniumApi
    {
        private readonly IBuilder builder;
        private readonly IDependencyApi dependencyApi;
        private readonly IManifest manifest;

        private IAttunementManager attunementManager;

        public ArcaniumApi(IDependencyApi dependencyApi, IManifest manifest)
        {
            this.dependencyApi = dependencyApi;
            this.manifest = manifest;
            this.dependencyApi.Composed += this.DependencyApi_Composed;
            this.builder = this.dependencyApi.GetBuilder(manifest.UniqueID);
        }

        public void RegisterDefaults()
        {
            this.RegisterAttunement<DivinerAttunementSpecification, DivinerAttunement>(DivinerAttunementSpecification
                .StaticUniqueId);
            this.RegisterAttunement<GuardianAttunementSpecification, GuardianAttunement>(GuardianAttunementSpecification
                .StaticUniqueId);
        }

        public void RegisterAttunement<TSpecification, TAttunementInstance>(string uniqueId)
            where TSpecification : IAttunementSpecification where TAttunementInstance : IAttunement
        {
            this.builder.RegisterType<TSpecification>()
                .As<IAttunementSpecification>()
                .Keyed<IAttunementSpecification>(uniqueId);
            this.builder.RegisterType<TAttunementInstance>()
                .As<IAttunement>()
                .Keyed<IAttunementSpecification>(typeof(TSpecification));
        }

        private void DependencyApi_Composed(object sender, EventArgs e)
        {
            this.attunementManager = this.dependencyApi.Resolve<IAttunementManager>(this.manifest.UniqueID);
        }

        public IAttunementManager GetAttunementManager()
        {
            return this.attunementManager;
        }
    }
}