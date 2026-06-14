using System;
using Microsoft.Xna.Framework;
using MonoGameEntry.ECS.Components;
using MonoGameEntry.ECS.Enums;
using MonoGameLibrary;
using MonoGameLibrary.ECS.Systems;
using MonoGameLibrary.Scenes;

namespace MonoGameEntry.ECS.Systems;

public class DirectionSystem : IGameSystem
{
    public void Update(
        GameContext context,
        GameTime gameTime,
        IEcsScene scene)
    {
        foreach (var entity in scene.Entities
            .Query<VelocityComponent, DirectionComponent>())
        {
            ref var velocity =
                ref scene.Entities.GetRef<VelocityComponent>(entity.Id);

            ref var direction =
                ref scene.Entities.GetRef<DirectionComponent>(entity.Id);

            if (velocity.Value == Vector2.Zero)
                continue;

            if (MathF.Abs(velocity.Value.X) >
                MathF.Abs(velocity.Value.Y))
            {
                direction.State =
                    velocity.Value.X > 0
                        ? Direction.Right
                        : Direction.Left;
            }
            else
            {
                direction.State =
                    velocity.Value.Y > 0
                        ? Direction.Down
                        : Direction.Up;
            }
        }
    }

    public void Draw(
        GameContext context,
        GameTime gameTime,
        IEcsScene scene)
    {
    }
}