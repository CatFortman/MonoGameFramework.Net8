using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGameEntry.ECS.Enums;
using MonoGameEntry.ECS.Game.Bootstrap;
using MonoGameLibrary.Graphics;

public static class PlayerAnimationFactory
{
    public static AnimationSet Create(TextureAtlasConfiguration config)
    {
        var animations =
            new Dictionary<AnimationState, AnimatedSprite>();

        AddIdleAnimations(
            animations,
            config.PlayerAtlases[ActionState.Idle]);

        AddWalkAnimations(
            animations,
            config.PlayerAtlases[ActionState.Walking]);

        AddAttackAnimations(
            animations,
            config.PlayerAtlases[ActionState.Attack]);

        return new AnimationSet
        {
            Animations = animations
        };
    }

    private static void AddIdleAnimations(
    Dictionary<AnimationState, AnimatedSprite> animations,
    TextureAtlas atlas)
    {
        animations[AnimationState.IdleDown] =
            CreateScaledSprite(atlas, "IdleDown");

        animations[AnimationState.IdleDownRight] =
            CreateScaledSprite(atlas, "IdleDownRight");

        animations[AnimationState.IdleRight] =
            CreateScaledSprite(atlas, "IdleRight");

        animations[AnimationState.IdleUpRight] =
            CreateScaledSprite(atlas, "IdleUpRight");

        animations[AnimationState.IdleUp] =
            CreateScaledSprite(atlas, "IdleUp");
    }

    private static void AddWalkAnimations(
        Dictionary<AnimationState, AnimatedSprite> animations,
        TextureAtlas atlas)
    {
        animations[AnimationState.WalkDown] =
            CreateScaledSprite(atlas, "WalkDown");

        animations[AnimationState.WalkDownRight] =
            CreateScaledSprite(atlas, "WalkDownRight");

        animations[AnimationState.WalkRight] =
            CreateScaledSprite(atlas, "WalkRight");

        animations[AnimationState.WalkUpRight] =
            CreateScaledSprite(atlas, "WalkUpRight");

        animations[AnimationState.WalkUp] =
            CreateScaledSprite(atlas, "WalkUp");
    }

    private static void AddAttackAnimations(
        Dictionary<AnimationState, AnimatedSprite> animations,
        TextureAtlas atlas)
    {
        animations[AnimationState.AttackDown] =
            CreateScaledSprite(atlas, "AttackDown");

        animations[AnimationState.AttackDownRight] =
            CreateScaledSprite(atlas, "AttackDownRight");

        animations[AnimationState.AttackRight] =
            CreateScaledSprite(atlas, "AttackRight");

        animations[AnimationState.AttackUpRight] =
            CreateScaledSprite(atlas, "AttackUpRight");

        animations[AnimationState.AttackUp] =
            CreateScaledSprite(atlas, "AttackUp");
    }

    private static AnimatedSprite CreateScaledSprite(
        TextureAtlas atlas,
        string animationName)
    {
        var sprite = atlas.CreateAnimatedSprite(animationName);
        sprite.Scale = new Vector2(4f, 4f);

        return sprite;
    }
}