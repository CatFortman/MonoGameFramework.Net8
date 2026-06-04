using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameEntry.ECS.Components;
using MonoGameEntry.ECS.Enums;
using MonoGameLibrary;
using MonoGameLibrary.ECS.Systems;
using MonoGameLibrary.Scenes;

namespace MonoGameEntry.ECS.Systems;

public class AnimationStateSystem : IGameSystem
{
    public void Update(
        GameContext context,
        GameTime gameTime,
        IEcsScene scene)
    {
        foreach (var entity in scene.Entities
            .Query<VelocityComponent, AnimationComponent, AnimationStateComponent, DirectionComponent, ActionStateComponent>())
        {
            ref var velocity =
                ref scene.Entities.GetRef<VelocityComponent>(entity.Id);

            ref var animationState =
                ref scene.Entities.GetRef<AnimationStateComponent>(entity.Id);

            ref var facing =
               ref scene.Entities.GetRef<DirectionComponent>(entity.Id);


            ref var effects = ref scene.Entities.GetRef<SpriteEffectsComponent>(entity.Id);

            if (facing.State == Direction.Left)
            {
                effects.Effects = SpriteEffects.FlipHorizontally;
            }
            else
            {
                effects.Effects = SpriteEffects.None;
            }

            ref var actionState = ref scene.Entities.GetRef<ActionStateComponent>(entity.Id);

            if (actionState.State == ActionState.Attack)
            {
                animationState.State = GetAttackAnimation(facing.State);
            }
            else if (velocity.Value.LengthSquared() > 0)
            {
                animationState.State = GetWalkAnimation(facing.State);
            }
            else
            {
                animationState.State = GetIdleAnimation(facing.State);
            }
        }
    }

    private AnimationState GetAttackAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => AnimationState.AttackUp,
            Direction.Left => AnimationState.AttackRight,
            Direction.Right => AnimationState.AttackRight,
            _ => AnimationState.AttackDown
        };
    }

    private AnimationState GetWalkAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => AnimationState.WalkUp,
            Direction.Left => AnimationState.WalkRight,
            Direction.Right => AnimationState.WalkRight,
            _ => AnimationState.WalkDown
        };
    }

    private AnimationState GetIdleAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => AnimationState.IdleUp,
            Direction.Left => AnimationState.IdleRight,
            Direction.Right => AnimationState.IdleRight,
            _ => AnimationState.IdleDown
        };
    }

    public void Draw(GameContext context, GameTime gameTime, IEcsScene scene)
    {
    }
}