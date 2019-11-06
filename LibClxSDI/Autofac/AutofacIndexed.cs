namespace LibClxSDI.Autofac
{
    using global::Autofac.Features.Indexed;

    internal class AutofacIndexed<TIndex, TValue> : IIndexed<TIndex, TValue>
    {
        private readonly IIndex<TIndex, TValue> index;

        public AutofacIndexed(IIndex<TIndex, TValue> index)
        {
            this.index = index;
        }

        public TValue this[TIndex key] => this.index[key];

        public bool TryGetValue(TIndex key, out TValue value)
        {
            return this.index.TryGetValue(key, out value);
        }
    }
}