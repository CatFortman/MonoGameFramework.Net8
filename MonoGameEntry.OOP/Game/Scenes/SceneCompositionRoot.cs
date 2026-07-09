using MonoGameLibrary;
using MonoGameLibrary.Scenes;
using MonoGameEntry.OOP.Game.Bootstrap;

namespace MonoGameEntry.OOP.Game.Scenes;

public class SceneCompositionRoot : ISceneRouter
{
    private readonly SceneRegistry _registry = new();
    private readonly SceneFactory _factory;
    private readonly GameContext _context;

    public SceneCompositionRoot(SceneFactory factory, GameContext context)
    {
        _factory = factory;
        _context = context;
        RegisterScenes();
    }

    private void RegisterScenes()
    {
        _registry.Register(ToKey(SceneType.Menu), ctx => _factory.CreateMenuScene(ctx, this));
        _registry.Register(ToKey(SceneType.Game), ctx => _factory.CreateGameScene(ctx, this));
    }

    private static SceneKey ToKey(SceneType type)
        => new SceneKey(type);

    public IScene Create(SceneType type, GameContext context)
        => _registry.Create(ToKey(type), context);

    public void GoTo(SceneKey key)
        => _context.SceneManager.ChangeScene(_registry.Create(key, _context));
}
