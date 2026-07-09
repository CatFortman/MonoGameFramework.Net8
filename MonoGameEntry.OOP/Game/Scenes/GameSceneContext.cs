using Microsoft.Xna.Framework.Graphics;
using MonoGameEntry.OOP.Entities;
using MonoGameEntry.OOP.Services;
using Microsoft.Xna.Framework.Content;
using MonoGameLibrary.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Scenes;
using MonoGameLibrary;
using MonoGameEntry.Common.Scenes;

namespace MonoGameEntry.OOP.Game.Scenes;

public class GameSceneContext : ISceneContext
{
    // Game Data
    public GameContext Game { get; init; }

    public Player Player { get; init; }
    public Enemy Enemy { get; init; }

    public CollisionService Collision { get; init; }
    public GameInteractionService Interaction { get; init; }

    public GraphicsDevice GraphicsDevice => Game.GraphicsDevice;
    public ContentManager Content => Game.Content;

    public AudioService Audio { get; init; }

    public InputManager Input => Game.Input;

    public Tilemap Tilemap { get; init; }
    public Rectangle WorldBounds { get; init; }
    public SpriteFont Font { get; init; }
    public Song Theme { get; init; }
    public ScenePause Pause { get; init; }

}