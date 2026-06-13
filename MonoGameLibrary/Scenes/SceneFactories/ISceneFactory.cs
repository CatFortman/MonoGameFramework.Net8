namespace MonoGameLibrary.Scenes;

/// <summary>
/// Defines a factory interface for creating game scenes. This interface is used by the game bootstrap process to create the initial scene that will be displayed when the game starts. Implementations of this interface should provide logic for initializing the first scene, which may involve setting up game entities, loading content, and configuring scene-specific services. The <see cref="CreateGameScene"/> method takes a <see cref="GameContext"/> parameter that provides access to shared game services and resources, allowing the factory to properly initialize the scene with the necessary dependencies. The returned <see cref="IScene"/> instance will become the active scene in the game, and its update and draw methods will be called every frame until a scene change occurs.
///
/// </summary>
public interface ISceneFactory
{
    /// <summary>
    /// Creates the initial game scene. This method is called by the game bootstrap process to create the first scene that will be displayed when the game starts. The <see cref="GameContext"/> parameter provides access to shared game services and resources that can be used to initialize the scene, such as content loading, input handling, and graphics rendering. The returned <see cref="IScene"/> instance will become the active scene in the game, and its update and draw methods will be called every frame until a scene change occurs.
    /// </summary>
    /// <param name="context">The game context.</param>
    /// <returns>The initial game scene.</returns>
    IScene CreateGameScene(GameContext context);
}
