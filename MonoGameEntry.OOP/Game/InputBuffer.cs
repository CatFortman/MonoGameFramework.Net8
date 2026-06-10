using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameEntry.OOP.Entities;

public class InputBuffer
{
     private const float WALK_SPEED = 2f;
    private const float RUN_SPEED = 4f;

    private bool isWalking = false;
        private bool isRunning = false;

    public PlayerInput Current { get; private set; }

    public void Capture(GameContext context)
    {
        var keyboard = context.Input.Keyboard;
  var gamePad = GamePad.GetState(PlayerIndex.One);
        var thumbstick = gamePad.ThumbSticks.Left;

                    Vector2 direction = Vector2.Zero;


        Current = new PlayerInput
        {
            Sprint = keyboard.IsKeyDown(Keys.Space),
            Attack = keyboard.IsKeyDown(Keys.J),
             isRunning =
                keyboard.IsKeyDown(Keys.LeftShift) || keyboard.IsKeyDown(Keys.RightShift) ||
                gamePad.Buttons.LeftShoulder == ButtonState.Pressed;
            Jump = keyboard.IsKeyDown(Keys.K),
            Interact = keyboard.IsKeyDown(Keys.L),
            Movement = new Vector2(
                (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right) ? 1 : 0) -
                (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left) ? 1 : 0),

                (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down) ? 1 : 0) -
                (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up) ? 1 : 0)
            )
        };
    }
}