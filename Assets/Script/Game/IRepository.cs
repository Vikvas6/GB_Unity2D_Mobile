using System.Collections.Generic;


namespace Game
{
    public interface IRepository<TKey, TValue>
    {
        IReadOnlyDictionary<TKey, TValue> Collection { get; }
    }
}
