using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MonoGameEntry.OOP.Enums;
using MonoGameLibrary.Graphics;

namespace MonoGameEntry.OOP.Entities.Abstractions;

public abstract class AnimatedGameObject
{
    protected Dictionary<PlayerAnimationState, AnimatedSprite> Animations;

    protected PlayerAnimationState CurrentAnimation;

    protected AnimatedSprite Sprite;

    protected SpriteEffects Effects = SpriteEffects.None;

    protected void SetAnimation(PlayerAnimationState state)
    {
        if (CurrentAnimation == state)
            return;

        CurrentAnimation = state;
        Sprite = Animations[state];
    }
}