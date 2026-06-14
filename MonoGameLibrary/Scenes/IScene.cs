namespace MonoGameLibrary.Scenes;

using Microsoft.Xna.Framework;

/// <summary>
/// Defines the interface for a game scene, which represents a distinct state or screen in the game (e.g., main menu, gameplay, pause menu). Scenes are responsible for managing their own content, handling input, updating game logic, and rendering. The <see cref="SceneManager"/> class is responsible for managing the active scene and facilitating transitions between scenes.
/// </summary>
public interface IScene
{
    /// <summary>
    /// Loads the scene's content and initializes any necessary resources. This method is called when the scene is first created or when it becomes active after being inactive. It should be used to load assets, set up game entities, and perform any initialization logic required for the scene to function properly.
    /// </summary>
    void Load();

    /// <summary>
    /// Unloads the scene's content and releases any resources that are no longer needed. This method is called when the scene is being removed or replaced by another scene. It should be used to clean up resources, save any necessary state, and perform any teardown logic required for the scene to be properly disposed of.
    /// </summary>
    void Unload();

    /// <summary>
    /// Called when the scene becomes the active scene. This method can be used to reset any necessary state, start background music, or perform any actions that should occur when the scene is entered. It is called after the scene has been loaded and is ready to be updated and drawn.
    /// </summary>
    void OnEnter();

    /// <summary>
    /// Called when the scene is no longer the active scene. This method can be used to pause any ongoing actions, stop background music, or perform any actions that should occur when the scene is exited. It is called before the scene is unloaded or replaced by another scene.
    /// </summary>
    void OnExit();

    /// <summary>
    /// Updates the scene's game logic. This method is called every frame while the scene is active, and should be used to update game entities, handle input, and perform any necessary calculations for the scene's behavior. The <see cref="GameTime"/> parameter provides timing information that can be used to ensure smooth and consistent updates regardless of frame rate.
    /// </summary>
    /// <param name="gameTime">The game time information.</param>
    void Update(GameTime gameTime);

    /// <summary>
    /// Draws the scene's content. This method is called every frame while the scene is active, and should be used to render the scene's visuals to the screen. The <see cref="GameTime"/> parameter provides timing information that can be used to ensure smooth and consistent rendering regardless of frame rate.
    /// </summary>
    /// <param name="gameTime">The game time information.</param>
    void Draw(GameTime gameTime);
}