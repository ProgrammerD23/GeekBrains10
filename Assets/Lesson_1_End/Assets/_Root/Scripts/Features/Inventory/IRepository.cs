using System;
using System.Collections.Generic;

internal interface IRepositoryContext : IDisposable
{

}

internal abstract class BaseRepositoryContext<TKey, TValue, TConfig> : IRepositoryContext
{
    private readonly Dictionary<TKey, TValue> _items;
    public IReadOnlyDictionary<TKey, TValue> Items => _items;


    protected BaseRepositoryContext(IEnumerable<TConfig> configs) =>
        _items = CreteItems(configs);

    public void Dispose() =>
        _items.Clear();


    private Dictionary<TKey, TValue> CreteItems(IEnumerable<TConfig> configs)
    {
        var items = new Dictionary<TKey, TValue>();

        foreach (TConfig config in configs)
            items[GetKey(config)] = CreateItem(config);

        return items;
    }

    protected abstract TKey GetKey(TConfig config);
    protected abstract TValue CreateItem(TConfig config);
}
