namespace MonoGameLibrary.ECS;

using System;
using System.Collections.Generic;
using MonoGameLibrary.ECS.Interfaces;

/// <summary>
/// Manages the lifecycle of entities and their associated components in an entity-component-system architecture. The <see cref="EntityManager"/> class provides methods for creating and destroying entities, adding and removing components from entities, and querying entities based on their components. It maintains internal storage for entities and their components, allowing for efficient management and retrieval of entity data. This class serves as the central hub for managing game entities and their behaviors within a scene or game context.
/// </summary>
public class EntityManager
{
    /// <summary>
    /// Manages the lifecycle of entities and their associated components in an entity-component-system architecture. The <see cref="EntityManager"/> class provides methods for creating and destroying entities, adding and removing components from entities, and querying entities based on their components. It maintains internal storage for entities and their components, allowing for efficient management and retrieval of entity data. This class serves as the central hub for managing game entities and their behaviors within a scene or game context.
    /// </summary>
    private readonly Dictionary<int, Entity> entities = new();

    /// <summary>
    /// Manages the lifecycle of entities and their associated components in an entity-component-system architecture. The <see cref="EntityManager"/> class provides methods for creating and destroying entities, adding and removing components from entities, and querying entities based on their components. It maintains internal storage for entities and their components, allowing for efficient management and retrieval of entity data. This class serves as the central hub for managing game entities and their behaviors within a scene or game context.
    /// </summary>
    private readonly Dictionary<Type, IComponentStore> stores = new();

    /// <summary>
    /// Manages the lifecycle of entities and their associated components in an entity-component-system architecture. The <see cref="EntityManager"/> class provides methods for creating and destroying entities, adding and removing components from entities, and querying entities based on their components. It maintains internal storage for entities and their components, allowing for efficient management and retrieval of entity data. This class serves as the central hub for managing game entities and their behaviors within a scene or game context.
    /// </summary>
    private int nextId = 0;

    /// <summary>
    /// Creates a new entity with a unique identifier and adds it to the entity manager. The entity is initialized with the specified ID and a reference to the entity manager, allowing it to manage its own components and interact with other entities. The newly created entity is stored in the internal dictionary of entities, making it available for component management and querying within the entity-component-system architecture.
    /// </summary>
    /// <returns>The newly created entity.</returns>
    public Entity CreateEntity()
    {
        int id = this.nextId++;
        var entity = new Entity(id, this);

        this.entities[id] = entity;

        return entity;
    }

    /// <summary>
    /// Destroys the entity with the specified ID and removes it from the entity manager. The entity is removed from the internal dictionary of entities, and all its associated components are also removed from their respective stores.
    /// </summary>
    /// <param name="entityId">The ID of the entity to destroy.</param>
    public void DestroyEntity(int entityId)
    {
        this.entities.Remove(entityId);

        foreach (var store in this.stores.Values)
        {
            store.Remove(entityId);
        }
    }

    /// <summary>
    /// Adds a component of the specified type to the entity with the given ID. The component is stored in the appropriate component store based on its type, allowing for efficient retrieval and management of components associated with entities. If the component store for the specified type does not exist, it will be created automatically when adding the component. This method enables entities to have various behaviors and properties by associating them with different components in the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T">The type of the component to add.</typeparam>
    /// <param name="entityId">The ID of the entity to which to add the component.</param>
    /// <param name="component">The component to add.</param>
    public void AddComponent<T>(int entityId, T component)
    {
        this.GetOrCreateStore<T>().Set(entityId, component);
    }

    /// <summary>
    /// Checks if the entity with the specified ID has a component of the given type. This method queries the appropriate component store based on the type parameter to determine if the entity has an associated component of that type. It returns true if the component exists for the entity, and false otherwise. This functionality is essential for systems that need to operate on entities with specific components, allowing for efficient filtering and processing of entities within the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T">The type of the component to check for.</typeparam>
    /// <param name="entityId">The ID of the entity to check.</param>
    /// <returns>true if the entity has the component; otherwise, false.</returns>
    public bool HasComponent<T>(int entityId)
    {
        return this.stores.TryGetValue(typeof(T), out var store) &&
               ((ComponentStore<T>)store).Has(entityId);
    }

    /// <summary>
    /// Retrieves the component of the specified type associated with the entity that has the given ID. This method accesses the appropriate component store based on the type parameter to fetch the component instance for the specified entity. If the entity does not have a component of that type, an exception may be thrown or a default value may be returned, depending on the implementation of the component store. This functionality allows systems to access and manipulate the data and behavior of entities by working with their associated components in the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T">The type of the component to retrieve.</typeparam>
    /// <param name="entityId">The ID of the entity from which to retrieve the component.</param>
    /// <returns>The component instance if it exists; otherwise, a default value.</returns>
    public T Get<T>(int entityId)
    {
        return this.GetStore<T>().Get(entityId);
    }

    /// <summary>
    /// Retrieves a reference to the component of the specified type associated with the entity that has the given ID. This method accesses the appropriate component store based on the type parameter to fetch a reference to the component instance for the specified entity. By returning a reference, this method allows for direct modification of the component's data without needing to retrieve and set it back into the store, enabling more efficient updates to components within the entity-component-system architecture. If the entity does not have a component of that type, an exception may be thrown or a default value may be returned, depending on the implementation of the component store.
    /// </summary>
    /// <typeparam name="T">The type of the component to retrieve.</typeparam>
    /// <param name="entityId">The ID of the entity from which to retrieve the component.</param>
    /// <returns>A reference to the component instance if it exists; otherwise, a default value.</returns>
    public ref T GetRef<T>(int entityId)
    {
        return ref this.GetStore<T>().GetRef(entityId);
    }

    /// <summary>
    /// Removes the component of the specified type from the entity with the given ID. This method accesses the appropriate component store based on the type parameter to remove the component instance associated with the specified entity. If the entity does not have a component of that type, this method may do nothing or throw an exception, depending on the implementation of the component store. Removing components from entities allows for dynamic changes to their behaviors and properties within the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T">The type of the component to remove.</typeparam>
    /// <param name="entityId">The ID of the entity from which to remove the component.</param>
    public void RemoveComponent<T>(int entityId)
    {
        if (this.stores.TryGetValue(typeof(T), out var store))
        {
            ((ComponentStore<T>)store).Remove(entityId);
        }
    }

    /// <summary>
    /// Retrieves all entities currently managed by the entity manager. This method returns an enumerable collection of all entities, allowing for iteration and processing of every entity within the entity-component-system architecture. This can be useful for systems that need to operate on all entities or for debugging purposes to inspect the current state of all entities in the game.
    /// </summary>
    /// <returns>An enumerable collection of all entities.</returns>
    public IEnumerable<Entity> GetAll()
    {
        return this.entities.Values;
    }

    /// <summary>
    /// Retrieves all entities that have a component of the specified type. This method iterates through all entities managed by the entity manager and yields those that have an associated component of the given type. It checks for the presence of the component using the <see cref="HasComponent{T}"/> method, allowing for efficient filtering of entities based on their components. This functionality is essential for systems that need to operate on specific subsets of entities that share certain components within the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T1">The type of the component to filter by.</typeparam>
    /// <returns>An enumerable collection of entities that have the specified component.</returns>
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

    /// <summary>
    /// Retrieves all entities that have components of the specified types. This method iterates through all entities managed by the entity manager and yields those that have associated components of all the given types. It checks for the presence of each component using the <see cref="HasComponent{T}"/> method, allowing for efficient filtering of entities based on multiple components. This functionality is essential for systems that need to operate on specific subsets of entities that share certain combinations of components within the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T1">The type of the first component to filter by.</typeparam>
    /// <typeparam name="T2">The type of the second component to filter by.</typeparam>
    /// <returns>An enumerable collection of entities that have the specified components.</returns>
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

    /// <summary>
    /// Retrieves all entities that have components of the specified types. This method iterates through all entities managed by the entity manager and yields those that have associated components of all the given types. It checks for the presence of each component using the <see cref="HasComponent{T}"/> method, allowing for efficient filtering of entities based on multiple components. This functionality is essential for systems that need to operate on specific subsets of entities that share certain combinations of components within the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T1">The type of the first component to filter by.</typeparam>
    /// <typeparam name="T2">The type of the second component to filter by.</typeparam>
    /// <typeparam name="T3">The type of the third component to filter by.</typeparam>
    /// <returns>An enumerable collection of entities that have the specified components.</returns>
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

    /// <summary>
    /// Retrieves all entities that have components of the specified types. This method iterates through all entities managed by the entity manager and yields those that have associated components of all the given types. It checks for the presence of each component using the <see cref="HasComponent{T}"/> method, allowing for efficient filtering of entities based on multiple components. This functionality is essential for systems that need to operate on specific subsets of entities that share certain combinations of components within the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T1">The type of the first component to filter by.</typeparam>
    /// <typeparam name="T2">The type of the second component to filter by.</typeparam>
    /// <typeparam name="T3">The type of the third component to filter by.</typeparam>
    /// <typeparam name="T4">The type of the fourth component to filter by.</typeparam>
    /// <returns>An enumerable collection of entities that have the specified components.</returns>
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

    /// <summary>
    /// Retrieves all entities that have components of the specified types. This method iterates through all entities managed by the entity manager and yields those that have associated components of all the given types. It checks for the presence of each component using the <see cref="HasComponent{T}"/> method, allowing for efficient filtering of entities based on multiple components. This functionality is essential for systems that need to operate on specific subsets of entities that share certain combinations of components within the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T1">The type of the first component to filter by.</typeparam>
    /// <returns>An enumerable collection of entities that have the specified component.</returns>
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

    /// <summary>
    /// Retrieves all entities that have components of the specified types. This method iterates through all entities managed by the entity manager and yields those that have associated components of all the given types. It checks for the presence of each component using the <see cref="HasComponent{T}"/> method, allowing for efficient filtering of entities based on multiple components. This functionality is essential for systems that need to operate on specific subsets of entities that share certain combinations of components within the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T1">The type of the first component to filter by.</typeparam>
    /// <typeparam name="T2">The type of the second component to filter by.</typeparam>
    /// <returns>An enumerable collection of entities that have the specified components.</returns>
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

    /// <summary>
    /// Retrieves all entities that have components of the specified types. This method iterates through all entities managed by the entity manager and yields those that have associated components of all the given types. It checks for the presence of each component using the <see cref="HasComponent{T}"/> method, allowing for efficient filtering of entities based on multiple components. This functionality is essential for systems that need to operate on specific subsets of entities that share certain combinations of components within the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T1">The type of the first component to filter by.</typeparam>
    /// <typeparam name="T2">The type of the second component to filter by.</typeparam>
    /// <typeparam name="T3">The type of the third component to filter by.</typeparam>
    /// <returns>An enumerable collection of entities that have the specified components.</returns>
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

    /// <summary>
    /// Retrieves all entities that have components of the specified types. This method iterates through all entities managed by the entity manager and yields those that have associated components of all the given types. It checks for the presence of each component using the <see cref="HasComponent{T}"/> method, allowing for efficient filtering of entities based on multiple components. This functionality is essential for systems that need to operate on specific subsets of entities that share certain combinations of components within the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T1">The type of the first component to filter by.</typeparam>
    /// <typeparam name="T2">The type of the second component to filter by.</typeparam>
    /// <typeparam name="T3">The type of the third component to filter by.</typeparam>
    /// <typeparam name="T4">The type of the fourth component to filter by.</typeparam>
    /// <returns>An enumerable collection of entities that have the specified components.</returns>
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

    /// <summary>
    /// Retrieves all entities that have components of the specified types. This method iterates through all entities managed by the entity manager and yields those that have associated components of all the given types. It checks for the presence of each component using the <see cref="HasComponent{T}"/> method, allowing for efficient filtering of entities based on multiple components. This functionality is essential for systems that need to operate on specific subsets of entities that share certain combinations of components within the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T1">The type of the first component to filter by.</typeparam>
    /// <typeparam name="T2">The type of the second component to filter by.</typeparam>
    /// <typeparam name="T3">The type of the third component to filter by.</typeparam>
    /// <typeparam name="T4">The type of the fourth component to filter by.</typeparam>
    /// <typeparam name="T5">The type of the fifth component to filter by.</typeparam>
    /// <returns>An enumerable collection of entities that have the specified components.</returns>
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

    /// <summary>
    /// Retrieves all entities that have components of the specified types. This method iterates through all entities managed by the entity manager and yields those that have associated components of all the given types. It checks for the presence of each component using the <see cref="HasComponent{T}"/> method, allowing for efficient filtering of entities based on multiple components. This functionality is essential for systems that need to operate on specific subsets of entities that share certain combinations of components within the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T1">The type of the first component to filter by.</typeparam>
    /// <typeparam name="T2">The type of the second component to filter by.</typeparam>
    /// <typeparam name="T3">The type of the third component to filter by.</typeparam>
    /// <typeparam name="T4">The type of the fourth component to filter by.</typeparam>
    /// <typeparam name="T5">The type of the fifth component to filter by.</typeparam>
    /// <typeparam name="T6">The type of the sixth component to filter by.</typeparam>
    /// <returns>Ienumerable entities.</returns>
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

    /// <summary>
    /// Removes all entities and their associated components from the entity manager. This method clears the internal dictionary of entities, effectively removing all entities from management. It also iterates through all component stores and clears them, ensuring that all components associated with the removed entities are also cleared from their respective stores. This functionality is useful for resetting the state of the entity manager, such as when transitioning between scenes or restarting a game, allowing for a clean slate of entities and components to be managed going forward.
    /// </summary>
    /// <exception cref="NotImplementedException">Throws NotImplementedException exception.</exception>
    public void Clear()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves the component store for the specified component type. This method accesses the internal dictionary of component stores to fetch the store associated with the given type parameter. If the store does not exist, an exception may be thrown, depending on the implementation. This method is used internally by the entity manager to manage components of different types and allows for efficient retrieval and manipulation of components associated with entities in the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T">The type of the component for which to retrieve the store.</typeparam>
    /// <returns>The component store for the specified type.</returns>
    private ComponentStore<T> GetStore<T>()
    {
        return (ComponentStore<T>)this.stores[typeof(T)];
    }

    /// <summary>
    /// Retrieves the component store for the specified component type, creating it if it does not already exist. This method checks the internal dictionary of component stores for the presence of a store associated with the given type parameter. If the store does not exist, it creates a new instance of the component store for that type and adds it to the dictionary. This ensures that a component store is always available for managing components of the specified type, allowing for efficient retrieval and manipulation of components associated with entities in the entity-component-system architecture.
    /// </summary>
    /// <typeparam name="T">The type of the component for which to retrieve or create the store.</typeparam>
    /// <returns>The component store for the specified type.</returns>
    private ComponentStore<T> GetOrCreateStore<T>()
    {
        if (!this.stores.TryGetValue(typeof(T), out var store))
        {
            store = new ComponentStore<T>();
            this.stores[typeof(T)] = store;
        }

        return (ComponentStore<T>)store;
    }
}