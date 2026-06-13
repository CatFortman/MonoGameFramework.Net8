// <copyright file="Animation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace MonoGameLibrary.Graphics;

public class Animation
{
    /// <summary>
    /// Gets or sets the texture regions that make up the frames of this animation.  The order of the regions within the collection
    /// are the order that the frames should be displayed in.
    /// </summary>
    public List<TextureRegion> Frames { get; set; }

    /// <summary>
    /// Gets or sets the amount of time to delay between each frame before moving to the next frame for this animation.
    /// </summary>
    public TimeSpan Delay { get; set; }

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
}
