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
            new Dictionary<AnimationKey, AnimatedSprite>();

        AddIdleAnimations(
            animations,
            config.PlayerAtlases[PlayerAnimationName.Idle]);

        AddWalkAnimations(
            animations,
            config.PlayerAtlases[PlayerAnimationName.Walk]);

        AddAttackAnimations(
            animations,
            config.PlayerAtlases[PlayerAnimationName.Attack]);

        AddJumpAnimations(
            animations,
            config.PlayerAtlases[PlayerAnimationName.Jump]);

        AddInteractAnimations(
            animations,
            config.PlayerAtlases[PlayerAnimationName.Interact]);

        AddRunAnimations(
            animations,
            config.PlayerAtlases[PlayerAnimationName.Run]);

        return new AnimationSet
        {
            Animations = animations
        };
    }

    private static void AddIdleAnimations(
    Dictionary<AnimationKey, AnimatedSprite> animations,
    TextureAtlas atlas)
    {
        animations[PlayerAnimations.IdleDown] =
            CreateScaledSprite(atlas, "IdleDown");

        animations[PlayerAnimations.IdleDownRight] =
            CreateScaledSprite(atlas, "IdleDownRight");

        animations[PlayerAnimations.IdleRight] =
            CreateScaledSprite(atlas, "IdleRight");

        animations[PlayerAnimations.IdleUpRight] =
            CreateScaledSprite(atlas, "IdleUpRight");

        animations[PlayerAnimations.IdleUp] =
            CreateScaledSprite(atlas, "IdleUp");
    }

    private static void AddWalkAnimations(
        Dictionary<AnimationKey, AnimatedSprite> animations,
        TextureAtlas atlas)
    {
        animations[PlayerAnimations.WalkDown] =
            CreateScaledSprite(atlas, "WalkDown");

        animations[PlayerAnimations.WalkDownRight] =
            CreateScaledSprite(atlas, "WalkDownRight");

        animations[PlayerAnimations.WalkRight] =
            CreateScaledSprite(atlas, "WalkRight");

        animations[PlayerAnimations.WalkUpRight] =
            CreateScaledSprite(atlas, "WalkUpRight");

        animations[PlayerAnimations.WalkUp] =
            CreateScaledSprite(atlas, "WalkUp");
    }

    private static void AddAttackAnimations(
        Dictionary<AnimationKey, AnimatedSprite> animations,
        TextureAtlas atlas)
    {
        animations[PlayerAnimations.AttackDown] =
            CreateScaledSprite(atlas, "AttackDown");

        animations[PlayerAnimations.AttackDownRight] =
            CreateScaledSprite(atlas, "AttackDownRight");

        animations[PlayerAnimations.AttackRight] =
            CreateScaledSprite(atlas, "AttackRight");

        animations[PlayerAnimations.AttackUpRight] =
            CreateScaledSprite(atlas, "AttackUpRight");

        animations[PlayerAnimations.AttackUp] =
            CreateScaledSprite(atlas, "AttackUp");
    }

    private static void AddRunAnimations(
        Dictionary<AnimationKey, AnimatedSprite> animations,
        TextureAtlas atlas)
    {
        animations[PlayerAnimations.RunDown] =
            CreateScaledSprite(atlas, "RunDown");

        animations[PlayerAnimations.RunDownRight] =
            CreateScaledSprite(atlas, "RunDownRight");

        animations[PlayerAnimations.RunRight] =
            CreateScaledSprite(atlas, "RunRight");

        animations[PlayerAnimations.RunUpRight] =
            CreateScaledSprite(atlas, "RunUpRight");

        animations[PlayerAnimations.RunUp] =
            CreateScaledSprite(atlas, "RunUp");
    }

    private static void AddJumpAnimations(
        Dictionary<AnimationKey, AnimatedSprite> animations,
        TextureAtlas atlas)
    {
        animations[PlayerAnimations.JumpDown] =
            CreateScaledSprite(atlas, "JumpDown");

        animations[PlayerAnimations.JumpDownRight] =
            CreateScaledSprite(atlas, "JumpDownRight");

        animations[PlayerAnimations.JumpRight] =
            CreateScaledSprite(atlas, "JumpRight");

        animations[PlayerAnimations.JumpUpRight] =
            CreateScaledSprite(atlas, "JumpUpRight");

        animations[PlayerAnimations.JumpUp] =
            CreateScaledSprite(atlas, "JumpUp");
    }

    private static void AddInteractAnimations(
       Dictionary<AnimationKey, AnimatedSprite> animations,
       TextureAtlas atlas)
    {
        animations[PlayerAnimations.InteractDown] =
            CreateScaledSprite(atlas, "InteractDown");

        animations[PlayerAnimations.InteractDownRight] =
            CreateScaledSprite(atlas, "InteractDownRight");

        animations[PlayerAnimations.InteractRight] =
            CreateScaledSprite(atlas, "InteractRight");

        animations[PlayerAnimations.InteractUpRight] =
            CreateScaledSprite(atlas, "InteractUpRight");

        animations[PlayerAnimations.InteractUp] =
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