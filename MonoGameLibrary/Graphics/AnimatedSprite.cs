// -----------------------------------------------------------------------
// <copyright file="AnimatedSprite.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace MonoGameLibrary.Graphics;

using System;
using Microsoft.Xna.Framework;

/// <summary>
/// Represents a sprite that can play an animation.
/// </summary>
public class AnimatedSprite : Sprite
{
    private int currentFrame;
    private TimeSpan elapsed;
    private Animation animation;

    /// <summary>
    /// Gets or Sets the animation for this animated sprite.
    /// </summary>
    public Animation Animation
    {
        get => this.animation;
        set
        {
            this.animation = value;
            this.Region = this.animation.Frames[0];
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimatedSprite"/> class.
    /// Creates a new animated sprite.
    /// </summary>
    public AnimatedSprite()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimatedSprite"/> class.
    /// Initializes a new animated sprite with the specified frames and delay.
    /// </summary>
    /// <param name="animation">The animation for this animated sprite.</param>
    public AnimatedSprite(Animation animation)
    {
        this.Animation = animation;
    }

    /// <summary>
    /// Updates this animated sprite.
    /// </summary>
    /// <param name="gameTime">A snapshot of the game timing values provided by the framework.</param>
    public void Update(GameTime gameTime)
    {
        this.elapsed += gameTime.ElapsedGameTime;

        if (this.elapsed >= this.animation.Delay)
        {
            this.elapsed -= this.animation.Delay;
            this.currentFrame++;

            if (this.currentFrame >= this.animation.Frames.Count)
            {
                this.currentFrame = 0;
            }

            this.Region = this.animation.Frames[this.currentFrame];
        }
    }
}
