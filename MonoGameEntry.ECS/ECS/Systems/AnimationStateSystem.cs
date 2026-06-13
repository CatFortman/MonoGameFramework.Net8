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
            .Query<VelocityComponent, AnimationComponent, AnimationStateComponent, DirectionComponent, ActionStateComponent, RunComponent>())
        {
            if (!entity.Has<PlayerTag>())
                continue;

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

            ref var runState = ref scene.Entities.GetRef<RunComponent>(entity.Id);

            if (actionState.State == ActionState.Attack)
            {
                animationState.State = GetAttackAnimation(facing.State);
            }
            else if (actionState.State == ActionState.Jump)
            {
                animationState.State = GetJumpAnimation(facing.State);
            }
            else if (actionState.State == ActionState.Interact)
            {
                animationState.State = GetInteractAnimation(facing.State);
            }
            else if (velocity.Value.LengthSquared() > 0)
            {
                if (runState.Enabled)
                {
                    animationState.State = GetRunAnimation(facing.State);
                }
                else
                {
                    animationState.State = GetWalkAnimation(facing.State);
                }
            }
            else
            {
                animationState.State = GetIdleAnimation(facing.State);
            }
        }
    }

    private PlayerAnimationState GetAttackAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => PlayerAnimationState.AttackUp,
            Direction.Left => PlayerAnimationState.AttackRight,
            Direction.Right => PlayerAnimationState.AttackRight,
            _ => PlayerAnimationState.AttackDown
        };
    }

    private PlayerAnimationState GetJumpAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => PlayerAnimationState.JumpUp,
            Direction.Left => PlayerAnimationState.JumpRight,
            Direction.Right => PlayerAnimationState.JumpRight,
            _ => PlayerAnimationState.JumpDown
        };
    }

    private PlayerAnimationState GetRunAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => PlayerAnimationState.RunUp,
            Direction.Left => PlayerAnimationState.RunRight,
            Direction.Right => PlayerAnimationState.RunRight,
            _ => PlayerAnimationState.RunDown
        };
    }

    private PlayerAnimationState GetInteractAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => PlayerAnimationState.InteractUp,
            Direction.Left => PlayerAnimationState.InteractRight,
            Direction.Right => PlayerAnimationState.InteractRight,
            _ => PlayerAnimationState.InteractDown
        };
    }

    private PlayerAnimationState GetWalkAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => PlayerAnimationState.WalkUp,
            Direction.Left => PlayerAnimationState.WalkRight,
            Direction.Right => PlayerAnimationState.WalkRight,
            _ => PlayerAnimationState.WalkDown
        };
    }

    private PlayerAnimationState GetIdleAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => PlayerAnimationState.IdleUp,
            Direction.Left => PlayerAnimationState.IdleRight,
            Direction.Right => PlayerAnimationState.IdleRight,
            _ => PlayerAnimationState.IdleDown
        };
    }

    public void Draw(GameContext context, GameTime gameTime, IEcsScene scene)
    {
    }
}