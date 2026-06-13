namespace MonoGameLibrary;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Input;
using MonoGameLibrary.Scenes;

/// <summary>
/// 
/// </summary>
public class GameContext
{
    public GraphicsDevice GraphicsDevice { get; set; }

    public SpriteBatch SpriteBatch { get; set; }

    public ContentManager Content { get; set; }

    public InputManager Input { get; set; }

    public IScene CurrentScene { get; set; }
}