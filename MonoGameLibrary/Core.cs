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
        this.Graphics = new GraphicsDeviceManager(this);

        this.Graphics.PreferredBackBufferWidth = width;
        this.Graphics.PreferredBackBufferHeight = height;
        this.Graphics.IsFullScreen = fullScreen;
        this.Graphics.ApplyChanges();

        this.Window.Title = title;
        this.Content.RootDirectory = "Content";

        this.IsMouseVisible = true;
    }

    /// <summary>
    /// Gets the graphics device manager.
    /// </summary>
    public GraphicsDeviceManager Graphics { get; private set; }

    /// <summary>
    /// Gets the graphics device.
    /// </summary>
    public GraphicsDevice Device { get; private set; }

    /// <summary>
    /// Gets the sprite batch.
    /// </summary>
    public SpriteBatch SpriteBatch { get; private set; }

    /// <summary>
    /// Gets the content manager.
    /// </summary>
    public ContentManager ContentManager { get; private set; }

    /// <summary>
    /// Gets the input manager.
    /// </summary>
    public InputManager Input { get; private set; }

    /// <summary>
    /// Gets the game context.
    /// </summary>
    public GameContext Context { get; private set; }

    /// <summary>
    /// Gets the scene manager.
    /// </summary>
    public SceneManager SceneManager { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the game should exit when the Escape key is pressed.
    /// </summary>
    public bool ExitOnEscape { get; set; }

    /// <inheritdoc/>
    protected override void Initialize()
    {
        base.Initialize();

        this.Device = this.GraphicsDevice;
        this.SpriteBatch = new SpriteBatch(this.Device);
        this.Input = new InputManager();

        this.ContentManager = this.Content;

        this.Context = new GameContext
        {
            GraphicsDevice = this.Device,
            SpriteBatch = this.SpriteBatch,
            Content = this.ContentManager,
            Input = this.Input,
        };

        this.SceneManager = new SceneManager();
    }

    /// <inheritdoc/>
    protected override void Update(GameTime gameTime)
    {
        this.Input.Update(gameTime);

        if (this.ExitOnEscape && this.Input.Keyboard.IsKeyDown(Keys.Escape))
        {
            this.Exit();
        }

        this.SceneManager.Update(gameTime);

        base.Update(gameTime);
    }

    /// <inheritdoc/>
    protected override void Draw(GameTime gameTime)
    {
        this.Device.Clear(Color.MonoGameOrange);

        this.SceneManager.Draw(gameTime);

        base.Draw(gameTime);
    }
}