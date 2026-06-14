namespace MonoGameLibrary.ECS.Systems;

using Microsoft.Xna.Framework;
using MonoGameLibrary.Scenes;

/// <summary>
/// Defines the contract implemented by ECS systems that participate
/// in the game update and rendering pipeline.
/// </summary>
public interface IGameSystem
{
    /// <summary>
    /// Updates the state of the system for the current frame.
    /// </summary>
    /// <param name="context">Shared game services and state.</param>
    /// <param name="gameTime">Timing information for the current frame.</param>
    /// <param name="scene">The active ECS scene being processed.</param>
    void Update(GameContext context, GameTime gameTime, IEcsScene scene);

    /// <summary>
    /// Renders the system's visual output for the current frame.
    /// </summary>
    /// <param name="context">Shared game services and state.</param>
    /// <param name="gameTime">Timing information for the current frame.</param>
    /// <param name="scene">The active ECS scene being rendered.</param>
    void Draw(GameContext context, GameTime gameTime, IEcsScene scene);
}