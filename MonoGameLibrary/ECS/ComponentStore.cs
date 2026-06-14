namespace MonoGameLibrary.ECS;

using System;
using MonoGameLibrary.ECS.Interfaces;

/// <summary>
/// Stores components of a single type indexed by entity identifier.
/// Uses parallel arrays to store component values and track component existence.
/// </summary>
/// <typeparam name="T">The type of component stored by this component store.</typeparam>
internal class ComponentStore<T> : IComponentStore
{
    /// <summary>
    /// Stores component values indexed by entity identifier.
    /// </summary>
    private T[] data = new T[1024];

    /// <summary>
    /// Tracks whether a component value exists for each entity identifier.
    /// </summary>
    private bool[] hasValue = new bool[1024];

    /// <summary>
    /// Assigns a component value to the specified entity.
    /// </summary>
    /// <param name="entityId">The identifier of the entity.</param>
    /// <param name="value">The component value to assign.</param>
    public void Set(int entityId, T value)
    {
        this.EnsureCapacity(entityId);
        this.data[entityId] = value;
        this.hasValue[entityId] = true;
    }

    /// <summary>
    /// Gets the component value assigned to the specified entity.
    /// </summary>
    /// <param name="entityId">The identifier of the entity.</param>
    /// <returns>The component value assigned to the entity.</returns>
    public T Get(int entityId)
    {
        return this.data[entityId];
    }

    /// <summary>
    /// Gets a mutable reference to the component value assigned to the specified entity.
    /// </summary>
    /// <param name="entityId">The identifier of the entity.</param>
    /// <returns>A mutable reference to the component value assigned to the entity.</returns>
    public ref T GetRef(int entityId)
    {
        this.EnsureCapacity(entityId);
        return ref this.data[entityId];
    }

    /// <summary>
    /// Determines whether the specified entity has a component value in this store.
    /// </summary>
    /// <param name="entityId">The identifier of the entity.</param>
    /// <returns>
    /// <see langword="true"/> if the entity has a component value; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Has(int entityId)
    {
        return entityId < this.hasValue.Length && this.hasValue[entityId];
    }

    /// <summary>
    /// Removes the component value assigned to the specified entity.
    /// </summary>
    /// <param name="entityId">The identifier of the entity.</param>
    public void Remove(int entityId)
    {
        if (entityId < this.hasValue.Length)
        {
            this.hasValue[entityId] = false;
            this.data[entityId] = default;
        }
    }

    /// <summary>
    /// Expands the internal storage arrays when the specified entity identifier exceeds the current capacity.
    /// </summary>
    /// <param name="entityId">The entity identifier that must fit within the storage arrays.</param>
    private void EnsureCapacity(int entityId)
    {
        if (entityId < this.data.Length)
        {
            return;
        }

        int newSize = this.data.Length * 2;

        while (newSize <= entityId)
        {
            newSize *= 2;
        }

        Array.Resize(ref this.data, newSize);
        Array.Resize(ref this.hasValue, newSize);
    }
}