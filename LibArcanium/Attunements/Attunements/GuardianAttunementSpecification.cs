namespace LibArcanium.Attunements.Attunements
{
    using Magic;

    internal class GuardianAttunementSpecification : IAttunementSpecification
    {
        public static string StaticUniqueId => "Attunement.Guardian";

        public string Name => "Guardian";

        public string UniqueId => StaticUniqueId;

        public ManaType PrimaryManaType => ManaType.Air;

        public ManaType SecondaryManaType => ManaType.Air;
    }
}