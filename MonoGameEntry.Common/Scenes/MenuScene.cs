using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Scenes;

namespace MonoGameEntry.Common.Scenes;

public class MenuScene : IScene
{
    private readonly GameContext _game;
    private readonly ISceneRouter _router;
    private readonly SceneKey _playScene;
    private readonly string _title;

    private SpriteFont _font;

    public MenuScene(GameContext game, ISceneRouter router, SceneKey playScene, string title)
    {
        _game = game;
        _router = router;
        _playScene = playScene;
        _title = title;
    }

    public void Load()
    {
        _font = _game.Content.Load<SpriteFont>("Fonts/default");
    }

    public void Unload() { }

    public void OnEnter() { }

    public void OnExit() { }

    public void Update(GameTime gameTime)
    {
        if (_game.Input.Keyboard.WasKeyJustPressed(Keys.Enter))
        {
            _router.GoTo(_playScene);
        }
    }

    public void Draw(GameTime gameTime)
    {
        var viewport = _game.GraphicsDevice.Viewport;
        var center = new Vector2(viewport.Width / 2f, viewport.Height / 2f);

        _game.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        SceneText.DrawCentered(_game.SpriteBatch, _font, _title, center + new Vector2(0, -80), 2f, Color.White);
        SceneText.DrawCentered(_game.SpriteBatch, _font, "Press Enter to play", center + new Vector2(0, 20), 1f, Color.White);
        SceneText.DrawCentered(_game.SpriteBatch, _font, "P: pause    Q while paused: back to menu", center + new Vector2(0, 60), 1f, Color.White);

        _game.SpriteBatch.End();
    }
}
