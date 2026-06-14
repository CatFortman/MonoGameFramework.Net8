namespace MonoGameLibrary.Graphics;

using System;
using Microsoft.Xna.Framework;

/// <summary>
/// Represents a sprite that can play an animation.
/// </summary>
public class AnimatedSprite : Sprite
{
    /// <summary>
    /// The index of the current frame being displayed in the animation. This value is used to determine which texture region from the animation's frames should be rendered for this animated sprite. As the animation plays, this index is updated to cycle through the frames of the animation based on the specified delay between frames.
    /// </summary>
    private int currentFrame;

    /// <summary>
    /// The amount of time that has elapsed since the last frame change in the animation. This value is used to track how long the current frame has been displayed and to determine when to advance to the next frame in the animation based on the animation's specified delay between frames.
    /// </summary>
    private TimeSpan elapsed;

    /// <summary>
    /// The animation that this animated sprite will play. The <see cref="Animation"/> class contains the frames of the animation and the delay between frames.
    /// </summary>
    private Animation animation;

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
