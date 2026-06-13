// <copyright file="Entity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MonoGameLibrary.ECS;
public readonly struct Entity
{
    public int Id { get; }

    private readonly EntityManager manager;

    internal Entity(int id, EntityManager manager)
    {
        this.Id = id;
        this.manager = manager;
    }

    public void Add<T>(T component) => this.manager.AddComponent(this.Id, component);

    public T Get<T>() => this.manager.Get<T>(this.Id);

    public ref T GetRef<T>() => ref this.manager.GetRef<T>(this.Id);

    public bool Has<T>() => this.manager.HasComponent<T>(this.Id);
}