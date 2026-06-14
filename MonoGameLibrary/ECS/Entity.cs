namespace MonoGameLibrary.ECS;

/// <summary>
/// Represents a lightweight handle to an entity in the ECS.
/// Component operations are delegated to the associated
/// <see cref="EntityManager"/>.
/// </summary>
public readonly struct Entity
{
    /// <summary>
    /// The handle to the EntityManager.
    /// </summary>
    private readonly EntityManager manager;

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> struct.
    /// </summary>
    /// <param name="id">The unique identifier for the entity.</param>
    /// <param name="manager">
    /// The entity manager responsible for storing and managing the entity's components.
    /// </param>
    internal Entity(int id, EntityManager manager)
    {
        this.Id = id;
        this.manager = manager;
    }

    /// <summary>
    /// Gets the unique identifier for the entity.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Adds a component to the entity.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <param name="component">The component instance to add.</param>
    public void Add<T>(T component) => this.manager.AddComponent(this.Id, component);

    /// <summary>
    /// Gets the component of the specified type attached to the entity.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <returns>The requested component.</returns>
    public T Get<T>() => this.manager.Get<T>(this.Id);

    /// <summary>
    /// Gets a reference to the component of the specified type attached to the entity.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <returns>
    /// A reference to the requested component, allowing in-place modification.
    /// </returns>
    public ref T GetRef<T>() => ref this.manager.GetRef<T>(this.Id);

    /// <summary>
    /// Determines whether the entity contains a component of the specified type.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <returns>
    /// <see langword="true"/> if the component exists; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Has<T>() => this.manager.HasComponent<T>(this.Id);
}