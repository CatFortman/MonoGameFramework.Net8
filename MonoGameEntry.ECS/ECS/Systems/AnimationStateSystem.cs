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

    private AnimationKey GetAttackAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => PlayerAnimations.AttackUp,
            Direction.Left => PlayerAnimations.AttackRight,
            Direction.Right => PlayerAnimations.AttackRight,
            _ => PlayerAnimations.AttackDown
        };
    }

    private AnimationKey GetJumpAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => PlayerAnimations.JumpUp,
            Direction.Left => PlayerAnimations.JumpRight,
            Direction.Right => PlayerAnimations.JumpRight,
            _ => PlayerAnimations.JumpDown
        };
    }

    private AnimationKey GetRunAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => PlayerAnimations.RunUp,
            Direction.Left => PlayerAnimations.RunRight,
            Direction.Right => PlayerAnimations.RunRight,
            _ => PlayerAnimations.RunDown
        };
    }

    private AnimationKey GetInteractAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => PlayerAnimations.InteractUp,
            Direction.Left => PlayerAnimations.InteractRight,
            Direction.Right => PlayerAnimations.InteractRight,
            _ => PlayerAnimations.InteractDown
        };
    }

    private AnimationKey GetWalkAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => PlayerAnimations.WalkUp,
            Direction.Left => PlayerAnimations.WalkRight,
            Direction.Right => PlayerAnimations.WalkRight,
            _ => PlayerAnimations.WalkDown
        };
    }

    private AnimationKey GetIdleAnimation(Direction facing)
    {
        return facing switch
        {
            Direction.Up => PlayerAnimations.IdleUp,
            Direction.Left => PlayerAnimations.IdleRight,
            Direction.Right => PlayerAnimations.IdleRight,
            _ => PlayerAnimations.IdleDown
        };
    }

    public void Draw(GameContext context, GameTime gameTime, IEcsScene scene)
    {
    }
}