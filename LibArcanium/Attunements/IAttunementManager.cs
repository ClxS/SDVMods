namespace LibArcanium.Attunements
{
    using System.Collections.Generic;

    public interface IAttunementManager
    {
        IEnumerable<IAttunementSpecification> GetAttunements();

        IAttunement AttuneEntity(IAttunementSpecification specification, object attuned);
    }
}