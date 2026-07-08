using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MonoGameEntry.Common.Enums;
using MonoGameLibrary.Graphics;

namespace MonoGameEntry.OOP.Entities.Abstractions;

public abstract class AnimatedGameObject
{
    protected Dictionary<AnimationKey, AnimatedSprite> Animations;

    protected AnimationKey CurrentAnimation;

    protected AnimatedSprite Sprite;

    protected SpriteEffects Effects = SpriteEffects.None;

    protected void SetAnimation(AnimationKey state)
    {
        if (CurrentAnimation == state)
            return;

        CurrentAnimation = state;
        Sprite = Animations[state];
    }
}