using System;
using System.Collections.Generic;

namespace MonoGameLibrary.Scenes;

public class SceneRegistry
{
    private readonly Dictionary<SceneKey, Func<GameContext, IScene>> registry = new ();

    public void Register(SceneKey key, Func<GameContext, IScene> factory)
    {
        this.registry[key] = factory;
    }

    public IScene Create(SceneKey key, GameContext context)
    {
        if (!this.registry.TryGetValue(key, out var factory))
        {
            throw new Exception($"Scene '{key}' not registered.");
        }

        return factory(context);
    }
}