using MonoGameLibrary;
using MonoGameLibrary.Bootstrap.Interfaces;
using MonoGameLibrary.Scenes;
using MonoGameEntry.OOP.Game.Scenes;

namespace MonoGameEntry.OOP.Game.Bootstrap;

public class OopBootstrap : IGameBootstrap
{
    public IScene CreateInitialScene(GameContext context)
    {
        var factory = new SceneFactory();
        var root = new SceneCompositionRoot(factory, context);

        return root.Create(SceneType.Menu, context);
    }
}