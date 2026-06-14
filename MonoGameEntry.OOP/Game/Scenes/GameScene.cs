using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MonoGameLibrary.Scenes;

namespace MonoGameEntry.OOP.Game.Scenes;

public class GameScene : IScene
{
    private GameSceneContext _context;
    private InputBuffer _inputBuffer = new InputBuffer();
    private bool _playerEnemyCollisionLastFrame = false;

    public GameScene(GameSceneContext context)
    {
        _context = context;
    }

    public void Load()
    {
    }

    public void OnEnter()
    {
        if (MediaPlayer.State == MediaState.Paused)
        {
            MediaPlayer.Resume();
        }
        else
        {
            MediaPlayer.Play(_context.Theme);
            MediaPlayer.IsRepeating = true;
        }
    }
    public void OnExit()
    {
        if (MediaPlayer.State == MediaState.Playing)
            MediaPlayer.Pause();
    }

    public void Unload()
    {
        throw new System.NotImplementedException();
    }

    public void Update(GameTime gameTime)
    {
        _inputBuffer.Capture(_context.Game);

        _context.Player.MovePlayer(_inputBuffer.Current, _context.WorldBounds);
        _context.Player.Update(gameTime);

        _context.Enemy.MoveEnemy(_context.WorldBounds);
        _context.Enemy.Update(gameTime);

        if (_context.Enemy.DidBounce)
        {
            _context.Interaction.HandleEnemyWallCollision(_context.Enemy);
        }

        bool isColliding = _context.Collision.Intersects(_context.Player, _context.Enemy);

        if (isColliding && !_playerEnemyCollisionLastFrame)
        {
            _context.Interaction.HandlePlayerEnemyCollision(_context.Player, _context.Enemy);
        }

        _playerEnemyCollisionLastFrame = isColliding;
    }

    public void Draw(GameTime gameTime)
    {
        _context.Game.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        _context.Tilemap.Draw(_context.Game.SpriteBatch);

        _context.Player.Draw(_context.Game.SpriteBatch);
        _context.Enemy.Draw(_context.Game.SpriteBatch);

        _context.Game.SpriteBatch.DrawString(
            _context.Font,
            "Use WASD or Arrow Keys. Hold Space to sprint.",
            new Vector2(25, 25),
            Color.MonoGameOrange
        );

        _context.Game.SpriteBatch.End();
    }
}