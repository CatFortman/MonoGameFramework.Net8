namespace MonoGameLibrary;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Input;
using MonoGameLibrary.Scenes;

/// <summary>
/// Provides shared game services and resources for scenes and systems.
/// </summary>
public class GameContext
{
    /// <summary>
    /// Gets or sets the active graphics device.
    /// </summary>
    public GraphicsDevice GraphicsDevice { get; set; }

    /// <summary>
    /// Gets or sets the sprite batch used for rendering.
    /// </summary>
    public SpriteBatch SpriteBatch { get; set; }

    /// <summary>
    /// Gets or sets the content manager used to load game assets.
    /// </summary>
    public ContentManager Content { get; set; }

    /// <summary>
    /// Gets or sets the input manager for keyboard and mouse state.
    /// </summary>
    public InputManager Input { get; set; }

    /// <summary>
    /// Gets or sets the currently active scene.
    /// </summary>
    public IScene CurrentScene { get; set; }
}