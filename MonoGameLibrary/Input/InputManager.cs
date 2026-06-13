using Microsoft.Xna.Framework;

namespace MonoGameLibrary.Input;

public class InputManager
{
    /// <summary>
    /// Gets the state information of keyboard input.
    /// </summary>
    public KeyboardInfo Keyboard { get; private set; }

    /// <summary>
    /// Gets the state information of mouse input.
    /// </summary>
    public MouseInfo Mouse { get; private set; }

    /// <summary>
    /// Gets the state information of a gamepad.
    /// </summary>
    public GamePadInfo[] GamePads { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="InputManager"/> class.
    /// Creates a new InputManager.
    /// </summary>
    public InputManager()
    {
        this.Keyboard = new KeyboardInfo();
        this.Mouse = new MouseInfo();

        this.GamePads = new GamePadInfo[4];
        for (int i = 0; i < 4; i++)
        {
            this.GamePads[i] = new GamePadInfo((PlayerIndex)i);
        }
    }

    /// <summary>
    /// Updates the state information for the keyboard, mouse, and gamepad inputs.
    /// </summary>
    /// <param name="gameTime">A snapshot of the timing values for the current frame.</param>
    public void Update(GameTime gameTime)
    {
        this.Keyboard.Update();
        this.Mouse.Update();

        for (int i = 0; i < 4; i++)
        {
            this.GamePads[i].Update(gameTime);
        }
    }
}
