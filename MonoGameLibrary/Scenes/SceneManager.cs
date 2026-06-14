namespace MonoGameLibrary.Scenes;

using Microsoft.Xna.Framework;

/// <summary>
/// Manages the active game scene, handling scene transitions and forwarding update and draw calls.
/// </summary>
public class SceneManager
{
    /// <summary>
    /// The current active scene. This is the scene that will receive update and draw calls, and will be responsible for handling input and managing game entities. When changing scenes, the current scene will be unloaded and the new scene will be loaded and entered.
    /// </summary>
    private IScene current;

    // private readonly GameContext context;

    /// <summary>
    /// Initializes a new instance of the <see cref="SceneManager"/> class with the specified game context.
    /// </summary>
    /// <param name="context">The game context.</param>
    public SceneManager(GameContext context)
    {
        // this.context = context;
    }

    /// <summary>
    /// Gets the current active scene.
    /// </summary>
    public IScene CurrentScene => this.current;

    /// <summary>
    /// Changes the current scene to the specified scene, handling the necessary lifecycle events such as unloading the previous scene and loading the new scene.
    /// </summary>
    /// <param name="scene">The scene to change to.</param>
    public void ChangeScene(IScene scene)
    {
        this.current?.OnExit();
        this.current?.Unload();

        this.current = scene;

        this.current.Load();
        this.current.OnEnter();
    }

    /// <summary>
    /// Updates the current scene.
    /// </summary>
    /// <param name="gameTime">The game time.</param>
    public void Update(GameTime gameTime)
    {
        this.current?.Update(gameTime);
    }

    /// <summary>
    /// Draws the current scene.
    /// </summary>
    /// <param name="gameTime">The game time.</param>
    public void Draw(GameTime gameTime)
    {
        this.current?.Draw(gameTime);
    }
}