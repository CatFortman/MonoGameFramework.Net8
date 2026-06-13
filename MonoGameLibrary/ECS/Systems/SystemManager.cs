namespace MonoGameLibrary.ECS.Systems;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Scenes;

/// <summary>
/// Manages the collection of ECS systems for a scene and coordinates
/// their update and draw execution.
/// </summary>
public class SystemManager
{
    /// <summary>
    /// The systems currently registered with the manager.
    /// </summary>
    private readonly List<IGameSystem> systems = new();

    /// <summary>
    /// Adds a system to the manager.
    /// </summary>
    /// <param name="system">
    /// The system to register for update and draw processing.
    /// </param>
    public void Add(IGameSystem system)
    {
        this.systems.Add(system);
    }

    /// <summary>
    /// Updates all registered systems for the current frame.
    /// </summary>
    /// <param name="context">Shared game services and state.</param>
    /// <param name="gameTime">Timing information for the current frame.</param>
    /// <param name="scene">The active ECS scene.</param>
    public void Update(GameContext context, GameTime gameTime, IEcsScene scene)
    {
        foreach (var system in this.systems)
        {
            system.Update(context, gameTime, scene);
        }
    }

    /// <summary>
    /// Draws all registered systems for the current frame.
    /// </summary>
    /// <param name="context">Shared game services and state.</param>
    /// <param name="gameTime">Timing information for the current frame.</param>
    /// <param name="scene">The active ECS scene.</param>
    public void Draw(GameContext context, GameTime gameTime, IEcsScene scene)
    {
        foreach (var system in this.systems)
        {
            system.Draw(context, gameTime, scene);
        }
    }

    /// <summary>
    /// Removes all registered systems from the manager.
    /// </summary>
    public void Clear()
    {
        this.systems.Clear();
    }
}