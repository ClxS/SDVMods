namespace LibArcanium.Attunements.Attunements
{
    internal class DivinerAttunement : IAttunement
    {
        public DivinerAttunement(IAttunementSpecification specification)
        {
            this.Specification = specification;
        }

        public IAttunementSpecification Specification { get; }
    }
}