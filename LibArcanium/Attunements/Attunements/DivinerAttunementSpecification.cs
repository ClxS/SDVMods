namespace LibArcanium.Attunements.Attunements
{
    using Magic;

    internal class DivinerAttunementSpecification : IAttunementSpecification
    {
        public string Name => "Diviner";

        public static string StaticUniqueId => "Attunement.Diviner";

        public string UniqueId => StaticUniqueId;

        public ManaType PrimaryManaType => ManaType.Air;

        public ManaType SecondaryManaType => ManaType.Air;
    }
}