namespace MonoGameLibrary.Scenes;

/// <summary>
/// Defines a factory interface for creating game scenes. This interface is used by the game bootstrap process to create the scenes that make up the game. Implementations of this interface should provide logic for initializing each scene, which may involve setting up game entities, loading content, and configuring scene-specific services. Each method takes a <see cref="GameContext"/> parameter that provides access to shared game services and resources, and an <see cref="ISceneRouter"/> parameter that the created scene can use to trigger transitions to other scenes.
/// </summary>
public interface ISceneFactory
{
    /// <summary>
    /// Creates the menu scene. This is the scene displayed when the game starts, from which the player can start gameplay. The <see cref="ISceneRouter"/> parameter allows the menu to transition to the gameplay scene.
    /// </summary>
    /// <param name="context">The game context.</param>
    /// <param name="router">The scene router used to transition to other scenes.</param>
    /// <returns>The menu scene.</returns>
    IScene CreateMenuScene(GameContext context, ISceneRouter router);

    /// <summary>
    /// Creates the gameplay scene. The <see cref="GameContext"/> parameter provides access to shared game services and resources that can be used to initialize the scene, such as content loading, input handling, and graphics rendering. The <see cref="ISceneRouter"/> parameter allows the scene to transition back to the menu. The returned <see cref="IScene"/> instance will become the active scene in the game, and its update and draw methods will be called every frame until a scene change occurs.
    /// </summary>
    /// <param name="context">The game context.</param>
    /// <param name="router">The scene router used to transition to other scenes.</param>
    /// <returns>The gameplay scene.</returns>
    IScene CreateGameScene(GameContext context, ISceneRouter router);
}
