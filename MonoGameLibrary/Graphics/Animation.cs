namespace MonoGameLibrary.Graphics;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents an animation consisting of a sequence of texture regions (frames) and a delay between each frame. The <see cref="Animation"/> class is used to define the properties of an animation, including the frames that make up the animation and the timing for how long each frame should be displayed before moving to the next frame.
/// </summary>
public class Animation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Animation"/> class.
    /// Creates a new animation.
    /// </summary>
    public Animation()
    {
        this.Frames = new List<TextureRegion>();
        this.Delay = TimeSpan.FromMilliseconds(100);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Animation"/> class.
    /// Creates a new animation with the specified frames and delay.
    /// </summary>
    /// <param name="frames">An ordered collection of the frames for this animation.</param>
    /// <param name="delay">The amount of time to delay between each frame of this animation.</param>
    public Animation(List<TextureRegion> frames, TimeSpan delay)
    {
        this.Frames = frames;
        this.Delay = delay;
    }

    /// <summary>
    /// Gets or sets the texture regions that make up the frames of this animation.  The order of the regions within the collection
    /// are the order that the frames should be displayed in.
    /// </summary>
    public List<TextureRegion> Frames { get; set; }

    /// <summary>
    /// Gets or sets the amount of time to delay between each frame before moving to the next frame for this animation.
    /// </summary>
    public TimeSpan Delay { get; set; }
}
