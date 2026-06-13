// <copyright file="ComponentStore.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using MonoGameLibrary.ECS.Interfaces;

namespace MonoGameLibrary.ECS;

/// <summary>
/// Stores components of a specific type for entities.
/// </summary>
/// <typeparam name="T">The component type.</typeparam>
internal class ComponentStore<T> : IComponentStore
{
    private T[] data = new T[1024];
    private bool[] hasValue = new bool[1024];

    public void Set(int entityId, T value)
    {
        this.EnsureCapacity(entityId);
        this.data[entityId] = value;
        this.hasValue[entityId] = true;
    }

    public T Get(int entityId)
    {
        return this.data[entityId];
    }

    public ref T GetRef(int entityId)
    {
        this.EnsureCapacity(entityId);
        return ref this.data[entityId];
    }

    public bool Has(int entityId)
    {
        return entityId < this.hasValue.Length && this.hasValue[entityId];
    }

    /// <inheritdoc/>
    public void Remove(int entityId)
    {
        if (entityId < this.hasValue.Length)
        {
            this.hasValue[entityId] = false;
            this.data[entityId] = default;
        }
    }

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