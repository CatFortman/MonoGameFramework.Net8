namespace MonoGameLibrary.Scenes;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Input;

/// <summary>
/// Provides access to scene-specific services and resources.
/// </summary>
public interface ISceneContext
{
    /// <summary>
    /// Gets the shared game context.
    /// </summary>
    GameContext Game { get; }

    /// <summary>
    /// Gets the graphics device used for rendering.
    /// </summary>
    GraphicsDevice GraphicsDevice { get; }

    /// <summary>
    /// Gets the content manager used to load assets.
    /// </summary>
    ContentManager Content { get; }

    /// <summary>
    /// Gets the input manager used to process input events.
    /// </summary>
    InputManager Input { get; }
}