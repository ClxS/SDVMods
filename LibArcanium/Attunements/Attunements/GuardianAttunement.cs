namespace LibArcanium.Attunements.Attunements
{
    internal class GuardianAttunement : IAttunement
    {
        public GuardianAttunement(IAttunementSpecification specification)
        {
            this.Specification = specification;
        }

        public IAttunementSpecification Specification { get; }
    }
}