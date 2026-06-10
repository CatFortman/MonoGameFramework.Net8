using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGameEntry.OOP.Enums;
using MonoGameEntry.OOP.Game.Bootstrap;
using MonoGameLibrary.Graphics;

public static class PlayerAnimationFactory
{
    public static AnimationSet Create(TextureAtlasConfiguration config)
    {
        var animations =
            new Dictionary<AnimationState, AnimatedSprite>();

        AddIdleAnimations(
            animations,
            config.PlayerAtlases[AnimationName.Idle]);

        AddWalkAnimations(
            animations,
            config.PlayerAtlases[AnimationName.Walk]);

        AddAttackAnimations(
            animations,
            config.PlayerAtlases[AnimationName.Attack]);

        AddJumpAnimations(
            animations,
            config.PlayerAtlases[AnimationName.Jump]);

        AddInteractAnimations(
            animations,
            config.PlayerAtlases[AnimationName.Interact]);

        AddRunAnimations(
            animations,
            config.PlayerAtlases[AnimationName.Run]);

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

    private static void AddRunAnimations(
        Dictionary<AnimationState, AnimatedSprite> animations,
        TextureAtlas atlas)
    {
        animations[AnimationState.RunDown] =
            CreateScaledSprite(atlas, "RunDown");

        animations[AnimationState.RunDownRight] =
            CreateScaledSprite(atlas, "RunDownRight");

        animations[AnimationState.RunRight] =
            CreateScaledSprite(atlas, "RunRight");

        animations[AnimationState.RunUpRight] =
            CreateScaledSprite(atlas, "RunUpRight");

        animations[AnimationState.RunUp] =
            CreateScaledSprite(atlas, "RunUp");
    }

    private static void AddJumpAnimations(
        Dictionary<AnimationState, AnimatedSprite> animations,
        TextureAtlas atlas)
    {
        animations[AnimationState.JumpDown] =
            CreateScaledSprite(atlas, "JumpDown");

        animations[AnimationState.JumpDownRight] =
            CreateScaledSprite(atlas, "JumpDownRight");

        animations[AnimationState.JumpRight] =
            CreateScaledSprite(atlas, "JumpRight");

        animations[AnimationState.JumpUpRight] =
            CreateScaledSprite(atlas, "JumpUpRight");

        animations[AnimationState.JumpUp] =
            CreateScaledSprite(atlas, "JumpUp");
    }

    private static void AddInteractAnimations(
       Dictionary<AnimationState, AnimatedSprite> animations,
       TextureAtlas atlas)
    {
        animations[AnimationState.InteractDown] =
            CreateScaledSprite(atlas, "InteractDown");

        animations[AnimationState.InteractDownRight] =
            CreateScaledSprite(atlas, "InteractDownRight");

        animations[AnimationState.InteractRight] =
            CreateScaledSprite(atlas, "InteractRight");

        animations[AnimationState.InteractUpRight] =
            CreateScaledSprite(atlas, "InteractUpRight");

        animations[AnimationState.InteractUp] =
            CreateScaledSprite(atlas, "InteractUp");
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