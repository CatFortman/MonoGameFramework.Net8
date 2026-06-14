namespace MonoGameLibrary;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Input;
using MonoGameLibrary.Scenes;

/// <summary>
/// Core game class that manages the game lifecycle and global resources.
/// </summary>
public class Core : Game
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Core"/> class with the specified title, width, height, and full screen mode.
    /// </summary>
    /// <param name="title">The title of the game window.</param>
    /// <param name="width">The width of the game window.</param>
    /// <param name="height">The height of the game window.</param>
    /// <param name="fullScreen">A value indicating whether the game should run in full screen mode.</param>
    public Core(string title, int width, int height, bool fullScreen)
    {
        Instance = this;

        Graphics = new GraphicsDeviceManager(this);

        Graphics.PreferredBackBufferWidth = width;
        Graphics.PreferredBackBufferHeight = height;
        Graphics.IsFullScreen = fullScreen;
        Graphics.ApplyChanges();

        this.Window.Title = title;
        this.Content.RootDirectory = "Content";

        this.IsMouseVisible = true;
    }

    /// <summary>
    /// Gets the singleton instance of the Core class.
    /// </summary>
    public static Core Instance { get; private set; }

    /// <summary>
    /// Gets the graphics device manager.
    /// </summary>
    public static GraphicsDeviceManager Graphics { get; private set; }

    /// <summary>
    /// Gets the graphics device.
    /// </summary>
    public static GraphicsDevice Device { get; private set; }

    /// <summary>
    /// Gets the sprite batch.
    /// </summary>
    public static SpriteBatch SpriteBatch { get; private set; }

    /// <summary>
    /// Gets the content manager.
    /// </summary>
    public static ContentManager ContentManager { get; private set; }

    /// <summary>
    /// Gets the input manager.
    /// </summary>
    public static InputManager Input { get; private set; }

    /// <summary>
    /// Gets the game context.
    /// </summary>
    public static GameContext Context { get; private set; }

    /// <summary>
    /// Gets the scene manager.
    /// </summary>
    public static SceneManager SceneManager { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the game should exit when the Escape key is pressed.
    /// </summary>
    public bool ExitOnEscape { get; set; }

    /// <inheritdoc/>
    protected override void Initialize()
    {
        base.Initialize();

        Device = this.GraphicsDevice;
        SpriteBatch = new SpriteBatch(Device);
        Input = new InputManager();

        ContentManager = this.Content;

        Context = new GameContext
        {
            GraphicsDevice = Device,
            SpriteBatch = SpriteBatch,
            Content = ContentManager,
            Input = Input,
        };

        SceneManager = new SceneManager(Context);
    }

    /// <inheritdoc/>
    protected override void Update(GameTime gameTime)
    {
        Input.Update(gameTime);

        if (this.ExitOnEscape && Input.Keyboard.IsKeyDown(Keys.Escape))
        {
            this.Exit();
        }

        SceneManager.Update(gameTime);

        base.Update(gameTime);
    }

    /// <inheritdoc/>
    protected override void Draw(GameTime gameTime)
    {
        Device.Clear(Color.MonoGameOrange);

        SceneManager.Draw(gameTime);

        base.Draw(gameTime);
    }
}