namespace MonoGameLibrary.ECS.Interfaces;

/// <summary>
/// Defines functionality common to all component stores, regardless of
/// the component type they contain.
/// </summary>
internal interface IComponentStore
{
    /// <summary>
    /// Removes the component associated with the specified entity.
    /// </summary>
    /// <param name="entityId">The identifier of the entity.</param>
    void Remove(int entityId);
}