namespace MonoGameLibrary.Scenes;

using System;
using System.Collections.Generic;

/// <summary>
/// Registry for managing scene creation and lifecycle.
/// </summary>
public class SceneRegistry
{
    private readonly Dictionary<SceneKey, Func<GameContext, IScene>> registry = new ();

    /// <summary>
    /// Registers a scene factory for the specified scene key.
    /// </summary>
    /// <param name="key">The key identifying the scene.</param>
    /// <param name="factory">The factory used to create the scene instance.</param>
    public void Register(SceneKey key, Func<GameContext, IScene> factory)
    {
        this.registry[key] = factory;
    }

    /// <summary>
    /// Creates a scene instance for the specified scene key.
    /// </summary>
    /// <param name="key">The key identifying the scene to create.</param>
    /// <param name="context">The game context used to initialize the scene.</param>
    /// <returns>The created scene instance.</returns>
    /// <exception cref="Exception">Thrown when the scene key is not registered.</exception>
    public IScene Create(SceneKey key, GameContext context)
    {
        if (!this.registry.TryGetValue(key, out var factory))
        {
            throw new Exception($"Scene '{key}' not registered.");
        }

        return factory(context);
    }
}