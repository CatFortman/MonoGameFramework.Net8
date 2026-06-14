using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameEntry.OOP.Entities;

public class InputBuffer
{
    public PlayerInput Current { get; private set; }

    public void Capture(GameContext context)
    {
        var keyboard = context.Input.Keyboard;
        var gamePad = GamePad.GetState(PlayerIndex.One);

        Current = new PlayerInput
        {
            Movement = new Vector2(
                (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right) ? 1 : 0) -
                (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left) ? 1 : 0),

                (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down) ? 1 : 0) -
                (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up) ? 1 : 0)
            ),
            Run = keyboard.IsKeyDown(Keys.LeftShift) || keyboard.IsKeyDown(Keys.RightShift) ||
                gamePad.Buttons.LeftShoulder == ButtonState.Pressed,
            Attack = keyboard.IsKeyDown(Keys.J) ||
                gamePad.Buttons.X == ButtonState.Pressed,
            Jump = keyboard.IsKeyDown(Keys.Space) ||
                gamePad.Buttons.A == ButtonState.Pressed,
            Interact = keyboard.IsKeyDown(Keys.E) ||
                gamePad.Buttons.B == ButtonState.Pressed            
        };
    }
}