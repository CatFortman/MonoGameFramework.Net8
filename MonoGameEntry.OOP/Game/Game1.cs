using Microsoft.Xna.Framework;
using MonoGameLibrary.Bootstrap.Interfaces;
using MonoGameLibrary.Scenes;
using MonoGameEntry.OOP.Game.Bootstrap;
using MonoGameLibrary;

namespace MonoGameEntry.OOP.Game1;

public class Game1 : Core
{
    public Game1() : base("MonoGameEntry.OOP", 1280, 720, false)
    {        
    }
    
    protected override void Initialize()
    {
        base.Initialize();

        IGameBootstrap bootstrap = new OopBootstrap();

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