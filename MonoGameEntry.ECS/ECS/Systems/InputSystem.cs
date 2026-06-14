using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.ECS.Systems;
using MonoGameLibrary.Scenes;
using MonoGameEntry.ECS.Components;

namespace MonoGameEntry.ECS.Systems;

public class InputSystem : IGameSystem
{
    private const float WALK_SPEED = 2f;
    private const float RUN_SPEED = 4f;
    private bool isWalking = false;

    public void Update(GameContext context, GameTime gameTime, IEcsScene scene)
    {
        var entities = scene.Entities;
        var keyboard = context.Input.Keyboard;
        var gamePad = GamePad.GetState(PlayerIndex.One);
        var thumbstick = gamePad.ThumbSticks.Left;

        foreach (var entity in entities.Query<VelocityComponent>())
        {
            if (!entity.Has<PlayerTag>())
                continue;

            ref var velocity = ref entities.GetRef<VelocityComponent>(entity.Id);

            Vector2 direction = Vector2.Zero;

            if (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up))
            {
                direction.Y -= 1;
                isWalking = true;
            }

            if (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))
            {
                direction.Y += 1;
                isWalking = true;
            }

            if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
            {
                direction.X -= 1;
                isWalking = true;
            }

            if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
            {
                direction.X += 1;
                isWalking = true;
            }

            if (direction != Vector2.Zero)
                direction.Normalize();

            if (gamePad.IsConnected)
            {
                thumbstick.Y *= -1;
                float deadZone = 0.4f;

                if (thumbstick.LengthSquared() > deadZone)
                {
                    direction = thumbstick;
                }
            }

            ref var isRunning = ref entities.GetRef<RunComponent>(entity.Id);

            isRunning.Enabled =
                keyboard.IsKeyDown(Keys.LeftShift) || keyboard.IsKeyDown(Keys.RightShift) ||
                gamePad.Buttons.LeftShoulder == ButtonState.Pressed;

            float speed = isRunning.Enabled ? RUN_SPEED : isWalking ? WALK_SPEED : 0f;

            velocity.Value = direction * speed;
        }

        foreach (var entity in entities.Query<ActionRequestComponent>())
        {
            if (!entity.Has<PlayerTag>())
                continue;

            ref var request =
                ref entities.GetRef<ActionRequestComponent>(entity.Id);

            request.AttackRequested =
                keyboard.IsKeyDown(Keys.J) ||
                gamePad.Buttons.X == ButtonState.Pressed;

            request.JumpRequested =
                keyboard.IsKeyDown(Keys.Space) ||
                gamePad.Buttons.A == ButtonState.Pressed;

            request.InteractRequested =
                keyboard.IsKeyDown(Keys.E) ||
                gamePad.Buttons.B == ButtonState.Pressed;

        }
    }

    public void Draw(GameContext context, GameTime gameTime, IEcsScene scene) { }
}