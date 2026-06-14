namespace MonoGameLibrary.Bootstrap.Interfaces;

using MonoGameLibrary.Scenes;

/// <summary>
/// Interace to bootstrap game setup.
/// </summary>
public interface IGameBootstrap
{
    /// <summary>
    /// Creates the initial scene used in the bootstrap entry class.
    /// </summary>
    /// <param name="context">The game context.</param>
    /// <returns>A new scene.</returns>
    IScene CreateInitialScene(GameContext context);
}