using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonoGameLibrary;
using MonoGameLibrary.Scenes;

namespace MonoGameEntry.Common.Scenes;

public class ScenePause
{
    private readonly GameContext _game;
    private readonly ISceneRouter _router;
    private readonly SceneKey _menuScene;

    public bool IsPaused { get; private set; }

    public ScenePause(GameContext game, ISceneRouter router, SceneKey menuScene)
    {
        _game = game;
        _router = router;
        _menuScene = menuScene;
    }

    // Returns true when the scene should skip its world update this frame.
    public bool Update()
    {
        var keyboard = _game.Input.Keyboard;

        if (keyboard.WasKeyJustPressed(Keys.P))
        {
            IsPaused = !IsPaused;

            if (IsPaused && MediaPlayer.State == MediaState.Playing)
            {
                MediaPlayer.Pause();
            }
            else if (!IsPaused && MediaPlayer.State == MediaState.Paused)
            {
                MediaPlayer.Resume();
            }
        }

        if (IsPaused && keyboard.WasKeyJustPressed(Keys.Q))
        {
            _router.GoTo(_menuScene);
            return true;
        }

        return IsPaused;
    }

    // Must be called between SpriteBatch.Begin and End.
    public void Draw(SpriteFont font)
    {
        if (!IsPaused)
        {
            return;
        }

        var viewport = _game.GraphicsDevice.Viewport;
        var center = new Vector2(viewport.Width / 2f, viewport.Height / 2f);

        SceneText.DrawCentered(_game.SpriteBatch, font, "Paused", center + new Vector2(0, -30), 2f, Color.White);
        SceneText.DrawCentered(_game.SpriteBatch, font, "P: resume    Q: back to menu", center + new Vector2(0, 30), 1f, Color.White);
    }
}
