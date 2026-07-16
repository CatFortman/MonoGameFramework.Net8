using MonoGameLibrary;
using MonoGameLibrary.Bootstrap.Interfaces;
using MonoGameLibrary.Scenes;
using MonoGameEntry.ECS.Game.Scenes;

namespace MonoGameEntry.ECS.Game.Bootstrap;

public class EcsBootstrap : IGameBootstrap
{
    public IScene CreateInitialScene(GameContext context)
    {
        var factory = new SceneFactory();
        var root = new SceneCompositionRoot(factory, context);

        return root.Create(SceneType.Menu, context);
    }
}