using Microsoft.Xna.Framework;
using MonoGameLibrary.Bootstrap.Interfaces;
using MonoGameEntry.ECS.Game.Bootstrap;

namespace MonoGameEntry.ECS.Game1;

public class Game1 : Core
{
    public Game1()
        : base("MonoGameEntry.ECS", 1280, 720, false)
    {
    }

    protected override void Initialize()
    {
        base.Initialize();

        IGameBootstrap bootstrap = new EcsBootstrap();

        SceneManager.ChangeScene(
            bootstrap.CreateInitialScene(Context)
        );
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
    }
}