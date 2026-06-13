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
            new Dictionary<IAnimationState, AnimatedSprite>();

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
    Dictionary<IAnimationState, AnimatedSprite> animations,
    TextureAtlas atlas)
    {
        animations[PlayerAnimationState.IdleDown] =
            CreateScaledSprite(atlas, "IdleDown");

        animations[PlayerAnimationState.IdleDownRight] =
            CreateScaledSprite(atlas, "IdleDownRight");

        animations[PlayerAnimationState.IdleRight] =
            CreateScaledSprite(atlas, "IdleRight");

        animations[PlayerAnimationState.IdleUpRight] =
            CreateScaledSprite(atlas, "IdleUpRight");

        animations[PlayerAnimationState.IdleUp] =
            CreateScaledSprite(atlas, "IdleUp");
    }

    private static void AddWalkAnimations(
        Dictionary<IAnimationState, AnimatedSprite> animations,
        TextureAtlas atlas)
    {
        animations[PlayerAnimationState.WalkDown] =
            CreateScaledSprite(atlas, "WalkDown");

        animations[PlayerAnimationState.WalkDownRight] =
            CreateScaledSprite(atlas, "WalkDownRight");

        animations[PlayerAnimationState.WalkRight] =
            CreateScaledSprite(atlas, "WalkRight");

        animations[PlayerAnimationState.WalkUpRight] =
            CreateScaledSprite(atlas, "WalkUpRight");

        animations[PlayerAnimationState.WalkUp] =
            CreateScaledSprite(atlas, "WalkUp");
    }

    private static void AddAttackAnimations(
        Dictionary<IAnimationState, AnimatedSprite> animations,
        TextureAtlas atlas)
    {
        animations[PlayerAnimationState.AttackDown] =
            CreateScaledSprite(atlas, "AttackDown");

        animations[PlayerAnimationState.AttackDownRight] =
            CreateScaledSprite(atlas, "AttackDownRight");

        animations[PlayerAnimationState.AttackRight] =
            CreateScaledSprite(atlas, "AttackRight");

        animations[PlayerAnimationState.AttackUpRight] =
            CreateScaledSprite(atlas, "AttackUpRight");

        animations[PlayerAnimationState.AttackUp] =
            CreateScaledSprite(atlas, "AttackUp");
    }

    private static void AddRunAnimations(
        Dictionary<IAnimationState, AnimatedSprite> animations,
        TextureAtlas atlas)
    {
        animations[PlayerAnimationState.RunDown] =
            CreateScaledSprite(atlas, "RunDown");

        animations[PlayerAnimationState.RunDownRight] =
            CreateScaledSprite(atlas, "RunDownRight");

        animations[PlayerAnimationState.RunRight] =
            CreateScaledSprite(atlas, "RunRight");

        animations[PlayerAnimationState.RunUpRight] =
            CreateScaledSprite(atlas, "RunUpRight");

        animations[PlayerAnimationState.RunUp] =
            CreateScaledSprite(atlas, "RunUp");
    }

    private static void AddJumpAnimations(
        Dictionary<IAnimationState, AnimatedSprite> animations,
        TextureAtlas atlas)
    {
        animations[PlayerAnimationState.JumpDown] =
            CreateScaledSprite(atlas, "JumpDown");

        animations[PlayerAnimationState.JumpDownRight] =
            CreateScaledSprite(atlas, "JumpDownRight");

        animations[PlayerAnimationState.JumpRight] =
            CreateScaledSprite(atlas, "JumpRight");

        animations[PlayerAnimationState.JumpUpRight] =
            CreateScaledSprite(atlas, "JumpUpRight");

        animations[PlayerAnimationState.JumpUp] =
            CreateScaledSprite(atlas, "JumpUp");
    }

     private static void AddInteractAnimations(
         Dictionary<IAnimationState, AnimatedSprite> animations,
       TextureAtlas atlas)
    {
        animations[PlayerAnimationState.InteractDown] =
            CreateScaledSprite(atlas, "InteractDown");

        animations[PlayerAnimationState.InteractDownRight] =
            CreateScaledSprite(atlas, "InteractDownRight");

        animations[PlayerAnimationState.InteractRight] =
            CreateScaledSprite(atlas, "InteractRight");

        animations[PlayerAnimationState.InteractUpRight] =
            CreateScaledSprite(atlas, "InteractUpRight");

        animations[PlayerAnimationState.InteractUp] =
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