using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MonoGameEntry.OOP.Enums;
using MonoGameLibrary.Graphics;

namespace MonoGameEntry.OOP.Entities.Abstractions;

public abstract class AnimatedGameObject
{
    protected Dictionary<AnimationState, AnimatedSprite> Animations;

    protected AnimationState CurrentAnimation;

    protected AnimatedSprite Sprite;

    protected SpriteEffects Effects = SpriteEffects.None;

    protected void SetAnimation(AnimationState state)
    {
        if (CurrentAnimation == state)
            return;

        CurrentAnimation = state;
        Sprite = Animations[state];
    }
}