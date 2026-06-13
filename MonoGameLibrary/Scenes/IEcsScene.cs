namespace MonoGameLibrary.Scenes;

using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.ECS;

/// <summary>
/// Represents a scene that uses an entity-component-system for managing game entities.
/// </summary>
public interface IEcsScene : IScene
{
    /// <summary>
    /// Gets the entity manager for this scene.
    /// </summary>
    EntityManager Entities { get; }

    /// <summary>
    /// Gets the font used for rendering text in this scene.
    /// </summary>
    SpriteFont Font { get; }
}