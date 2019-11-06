namespace LibArcanium.Attunements
{
    using Magic;

    public interface IAttunementSpecification
    {
        string Name { get; }

        string UniqueId { get; }

        ManaType PrimaryManaType { get; }

        ManaType SecondaryManaType { get; }
    }
}