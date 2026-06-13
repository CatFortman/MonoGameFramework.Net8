namespace MonoGameLibrary.Input;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// Contains the mouse controls and state information.
/// </summary>
public class MouseInfo
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MouseInfo"/> class.
    /// Creates a new MouseInfo.
    /// </summary>
    public MouseInfo()
    {
        this.PreviousState = default(MouseState);
        this.CurrentState = Mouse.GetState();
    }

    /// <summary>
    /// Gets the state of mouse input during the previous update cycle.
    /// </summary>
    public MouseState PreviousState { get; private set; }

    /// <summary>
    /// Gets the state of mouse input during the current update cycle.
    /// </summary>
    public MouseState CurrentState { get; private set; }

    /// <summary>
    /// Gets or Sets the current position of the mouse cursor in screen space.
    /// </summary>
    public Point Position
    {
        get => this.CurrentState.Position;
        set => this.SetPosition(value.X, value.Y);
    }

    /// <summary>
    /// Gets or Sets the current x-coordinate position of the mouse cursor in screen space.
    /// </summary>
    public int X
    {
        get => this.CurrentState.X;
        set => this.SetPosition(value, this.CurrentState.Y);
    }

    /// <summary>
    /// Gets or Sets the current y-coordinate position of the mouse cursor in screen space.
    /// </summary>
    public int Y
    {
        get => this.CurrentState.Y;
        set => this.SetPosition(this.CurrentState.X, value);
    }

    /// <summary>
    /// Gets the difference in the mouse cursor position between the previous and current frame.
    /// </summary>
    public Point PositionDelta => this.CurrentState.Position - this.PreviousState.Position;

    /// <summary>
    /// Gets the difference in the mouse cursor x-position between the previous and current frame.
    /// </summary>
    public int XDelta => this.CurrentState.X - this.PreviousState.X;

    /// <summary>
    /// Gets the difference in the mouse cursor y-position between the previous and current frame.
    /// </summary>
    public int YDelta => this.CurrentState.Y - this.PreviousState.Y;

    /// <summary>
    /// Gets a value indicating whether gets a value that indicates if the mouse cursor moved between the previous and current frames.
    /// </summary>
    public bool WasMoved => this.PositionDelta != Point.Zero;

    /// <summary>
    /// Gets the cumulative value of the mouse scroll wheel since the start of the game.
    /// </summary>
    public int ScrollWheel => this.CurrentState.ScrollWheelValue;

    /// <summary>
    /// Gets the value of the scroll wheel between the previous and current frame.
    /// </summary>
    public int ScrollWheelDelta => this.CurrentState.ScrollWheelValue - this.PreviousState.ScrollWheelValue;

    /// <summary>
    /// Updates the state information about mouse input.
    /// </summary>
    public void Update()
    {
        this.PreviousState = this.CurrentState;
        this.CurrentState = Mouse.GetState();
    }

    /// <summary>
    /// Returns a value that indicates whether the specified mouse button is currently down.
    /// </summary>
    /// <param name="button">The mouse button to check.</param>
    /// <returns>true if the specified mouse button is currently down; otherwise, false.</returns>
    public bool IsButtonDown(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return this.CurrentState.LeftButton == ButtonState.Pressed;
            case MouseButton.Middle:
                return this.CurrentState.MiddleButton == ButtonState.Pressed;
            case MouseButton.Right:
                return this.CurrentState.RightButton == ButtonState.Pressed;
            case MouseButton.XButton1:
                return this.CurrentState.XButton1 == ButtonState.Pressed;
            case MouseButton.XButton2:
                return this.CurrentState.XButton2 == ButtonState.Pressed;
            default:
                return false;
        }
    }

    /// <summary>
    /// Returns a value that indicates whether the specified mouse button is current up.
    /// </summary>
    /// <param name="button">The mouse button to check.</param>
    /// <returns>true if the specified mouse button is currently up; otherwise, false.</returns>
    public bool IsButtonUp(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return this.CurrentState.LeftButton == ButtonState.Released;
            case MouseButton.Middle:
                return this.CurrentState.MiddleButton == ButtonState.Released;
            case MouseButton.Right:
                return this.CurrentState.RightButton == ButtonState.Released;
            case MouseButton.XButton1:
                return this.CurrentState.XButton1 == ButtonState.Released;
            case MouseButton.XButton2:
                return this.CurrentState.XButton2 == ButtonState.Released;
            default:
                return false;
        }
    }

    /// <summary>
    /// Returns a value that indicates whether the specified mouse button was just pressed on the current frame.
    /// </summary>
    /// <param name="button">The mouse button to check.</param>
    /// <returns>true if the specified mouse button was just pressed on the current frame; otherwise, false.</returns>
    public bool WasButtonJustPressed(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return this.CurrentState.LeftButton == ButtonState.Pressed && this.PreviousState.LeftButton == ButtonState.Released;
            case MouseButton.Middle:
                return this.CurrentState.MiddleButton == ButtonState.Pressed && this.PreviousState.MiddleButton == ButtonState.Released;
            case MouseButton.Right:
                return this.CurrentState.RightButton == ButtonState.Pressed && this.PreviousState.RightButton == ButtonState.Released;
            case MouseButton.XButton1:
                return this.CurrentState.XButton1 == ButtonState.Pressed && this.PreviousState.XButton1 == ButtonState.Released;
            case MouseButton.XButton2:
                return this.CurrentState.XButton2 == ButtonState.Pressed && this.PreviousState.XButton2 == ButtonState.Released;
            default:
                return false;
        }
    }

    /// <summary>
    /// Returns a value that indicates whether the specified mouse button was just released on the current frame.
    /// </summary>
    /// <param name="button">The mouse button to check.</param>
    /// <returns>true if the specified mouse button was just released on the current frame; otherwise, false.</returns>
    public bool WasButtonJustReleased(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return this.CurrentState.LeftButton == ButtonState.Released && this.PreviousState.LeftButton == ButtonState.Pressed;
            case MouseButton.Middle:
                return this.CurrentState.MiddleButton == ButtonState.Released && this.PreviousState.MiddleButton == ButtonState.Pressed;
            case MouseButton.Right:
                return this.CurrentState.RightButton == ButtonState.Released && this.PreviousState.RightButton == ButtonState.Pressed;
            case MouseButton.XButton1:
                return this.CurrentState.XButton1 == ButtonState.Released && this.PreviousState.XButton1 == ButtonState.Pressed;
            case MouseButton.XButton2:
                return this.CurrentState.XButton2 == ButtonState.Released && this.PreviousState.XButton2 == ButtonState.Pressed;
            default:
                return false;
        }
    }

    /// <summary>
    /// Sets the current position of the mouse cursor in screen space and updates the CurrentState with the new position.
    /// </summary>
    /// <param name="x">The x-coordinate location of the mouse cursor in screen space.</param>
    /// <param name="y">The y-coordinate location of the mouse cursor in screen space.</param>
    public void SetPosition(int x, int y)
    {
        Mouse.SetPosition(x, y);
        this.CurrentState = new MouseState(
            x,
            y,
            this.CurrentState.ScrollWheelValue,
            this.CurrentState.LeftButton,
            this.CurrentState.MiddleButton,
            this.CurrentState.RightButton,
            this.CurrentState.XButton1,
            this.CurrentState.XButton2);
    }
}
