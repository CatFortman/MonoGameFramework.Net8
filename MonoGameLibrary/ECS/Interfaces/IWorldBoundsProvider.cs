namespace MonoGameEntry.ECS.Interfaces;

using Microsoft.Xna.Framework;

/// <summary>
/// A scene interface that provides world bounds.
/// </summary>
public interface IWorldBoundsProvider
{
    /// <summary>
    /// Gets bounds of the game space.
    /// </summary>
    Rectangle WorldBounds { get; }
}