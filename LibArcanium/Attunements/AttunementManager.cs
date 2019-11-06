namespace LibArcanium.Attunements
{
    using System;
    using System.Collections.Generic;
    using LibClxSDI;

    public class AttunementManager : IAttunementManager
    {
        private readonly IIndexed<Type, IAttunement> attunements;
        private readonly IEnumerable<IAttunementSpecification> specifications;

        public AttunementManager(IEnumerable<IAttunementSpecification> specifications,
                                 IIndexed<Type, IAttunement> attunementFactories)
        {
            this.specifications = specifications;
            this.attunements = attunementFactories;
        }

        public IEnumerable<IAttunementSpecification> GetAttunements()
        {
            return this.specifications;
        }

        public IAttunement AttuneEntity(IAttunementSpecification specification, object attuned)
        {
            return this.attunements[specification.GetType()];
        }
    }
}