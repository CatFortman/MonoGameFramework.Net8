// <copyright file="EntityManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using MonoGameLibrary.ECS.Interfaces;

namespace MonoGameLibrary.ECS;

public class EntityManager
{
    private int nextId = 0;

    private readonly Dictionary<int, Entity> entities = new ();
    private readonly Dictionary<Type, IComponentStore> stores = new ();

    // -------------------------
    // ENTITY LIFECYCLE
    // -------------------------
    public Entity CreateEntity()
    {
        int id = this.nextId++;
        var entity = new Entity(id, this);

        this.entities[id] = entity;

        return entity;
    }

    public void DestroyEntity(int entityId)
    {
        this.entities.Remove(entityId);

        foreach (var store in this.stores.Values)
        {
            store.Remove(entityId);
        }
    }

    // -------------------------
    // COMPONENT API
    // -------------------------
    public void AddComponent<T>(int entityId, T component)
    {
        this.GetOrCreateStore<T>().Set(entityId, component);
    }

    public bool HasComponent<T>(int entityId)
    {
        return this.stores.TryGetValue(typeof(T), out var store) &&
               ((ComponentStore<T>)store).Has(entityId);
    }

    public T Get<T>(int entityId)
    {
        return this.GetStore<T>().Get(entityId);
    }

    public ref T GetRef<T>(int entityId)
    {
        return ref this.GetStore<T>().GetRef(entityId);
    }

    public void RemoveComponent<T>(int entityId)
    {
        if (this.stores.TryGetValue(typeof(T), out var store))
        {
            ((ComponentStore<T>)store).Remove(entityId);
        }
    }

    // -------------------------
    // QUERY API (GLOBAL)
    // -------------------------
    public IEnumerable<Entity> GetAll()
    {
        return this.entities.Values;
    }

    public IEnumerable<Entity> With<T1>()
    {
        foreach (var entity in this.entities.Values)
        {
            if (this.HasComponent<T1>(entity.Id))
            {
                yield return entity;
            }
        }
    }

    public IEnumerable<Entity> With<T1, T2>()
    {
        foreach (var entity in this.entities.Values)
        {
            if (this.HasComponent<T1>(entity.Id) &&
                this.HasComponent<T2>(entity.Id))
            {
                yield return entity;
            }
        }
    }

    public IEnumerable<Entity> With<T1, T2, T3>()
    {
        foreach (var entity in this.entities.Values)
        {
            if (this.HasComponent<T1>(entity.Id) &&
                this.HasComponent<T2>(entity.Id) &&
                this.HasComponent<T3>(entity.Id))
            {
                yield return entity;
            }
        }
    }

    public IEnumerable<Entity> With<T1, T2, T3, T4>()
    {
        foreach (var entity in this.entities.Values)
        {
            if (entity.Has<T1>() &&
                entity.Has<T2>() &&
                entity.Has<T3>() &&
                entity.Has<T4>())
            {
                yield return entity;
            }
        }
    }

    public IEnumerable<Entity> Query<T1>()
    {
        foreach (var entity in this.entities.Values)
        {
            if (entity.Has<T1>())
            {
                yield return entity;
            }
        }
    }

    public IEnumerable<Entity> Query<T1, T2>()
    {
        foreach (var entity in this.entities.Values)
        {
            if (entity.Has<T1>() &&
                entity.Has<T2>())
            {
                yield return entity;
            }
        }
    }

    public IEnumerable<Entity> Query<T1, T2, T3>()
    {
        foreach (var entity in this.entities.Values)
        {
            if (entity.Has<T1>() &&
                entity.Has<T2>() &&
                entity.Has<T3>())
            {
                yield return entity;
            }
        }
    }

    public IEnumerable<Entity> Query<T1, T2, T3, T4>()
    {
        foreach (var entity in this.entities.Values)
        {
            if (entity.Has<T1>() &&
                entity.Has<T2>() &&
                entity.Has<T3>() &&
                entity.Has<T4>())
            {
                yield return entity;
            }
        }
    }

    public IEnumerable<Entity> Query<T1, T2, T3, T4, T5>()
    {
        foreach (var entity in this.entities.Values)
        {
            if (entity.Has<T1>() &&
                entity.Has<T2>() &&
                entity.Has<T3>() &&
                entity.Has<T4>() &&
                entity.Has<T5>())
            {
                yield return entity;
            }
        }
    }

    public IEnumerable<Entity> Query<T1, T2, T3, T4, T5, T6>()
    {
        foreach (var entity in this.entities.Values)
        {
            if (entity.Has<T1>() &&
                entity.Has<T2>() &&
                entity.Has<T3>() &&
                entity.Has<T4>() &&
                entity.Has<T5>() &&
                entity.Has<T6>())
            {
                yield return entity;
            }
        }
    }

    // -------------------------
    // INTERNAL STORAGE
    // -------------------------
    private ComponentStore<T> GetStore<T>()
    {
        return (ComponentStore<T>)this.stores[typeof(T)];
    }

    private ComponentStore<T> GetOrCreateStore<T>()
    {
        if (!this.stores.TryGetValue(typeof(T), out var store))
        {
            store = new ComponentStore<T>();
            this.stores[typeof(T)] = store;
        }

        return (ComponentStore<T>)store;
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }
}