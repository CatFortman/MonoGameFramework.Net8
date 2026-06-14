namespace MonoGameEntry.ECS.Scenes;

using System.Collections.Generic;
using MonoGameLibrary.ECS;
using MonoGameLibrary.Scenes;

/// <summary>
/// Represents a scene that tracks collision events between entities. This interface extends <see cref="IEcsScene"/> and adds a property for storing collision events, which are represented as pairs of entities that have collided. This allows the scene to manage and respond to collisions between game entities, such as triggering effects, applying damage, or updating game state based on the interactions between entities.
/// </summary>
public interface ICollisionEventScene : IEcsScene
{
    /// <summary>
    /// Gets the list of collision events that have occurred in the current frame. Each collision event is represented as a tuple containing the two entities that collided. This property allows the scene to access and process collision events, enabling game logic to respond to interactions between entities, such as applying damage, triggering animations, or updating game state based on collisions.
    /// </summary>
    List<(Entity A, Entity B)> CollisionEvents { get; }
}