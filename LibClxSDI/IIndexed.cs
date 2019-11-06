namespace LibClxSDI
{
    public interface IIndexed<in TIndex, TValue>
    {
        TValue this[TIndex key] { get; }

        bool TryGetValue(TIndex key, out TValue value);
    }
}