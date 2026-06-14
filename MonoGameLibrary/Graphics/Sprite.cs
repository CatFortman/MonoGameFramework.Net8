namespace MonoGameLibrary.Graphics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Represents a drawable sprite that can be rendered on the screen. A sprite is a 2D image that can be drawn using a source texture region, along with various properties such as color, rotation, scale, and effects. The <see cref="Sprite"/> class provides methods for submitting the sprite for drawing to a SpriteBatch, allowing it to be rendered in the current batch of draw calls. This class serves as a convenient wrapper around a texture region, encapsulating common properties and behaviors associated with rendering sprites in a 2D game.
/// </summary>
public class Sprite
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Sprite"/> class.
    /// Creates a new sprite.
    /// </summary>
    public Sprite()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sprite"/> class.
    /// Creates a new sprite using the specified source texture region.
    /// </summary>
    /// <param name="region">The texture region to use as the source texture region for this sprite.</param>
    public Sprite(TextureRegion region)
    {
        this.Region = region;
    }

    /// <summary>
    /// Gets or Sets the source texture region represented by this sprite.
    /// </summary>
    public TextureRegion Region { get; set; }

    /// <summary>
    /// Gets or Sets the color mask to apply when rendering this sprite.
    /// </summary>
    /// <remarks>
    /// Default value is Color.White.
    /// </remarks>
    public Color Color { get; set; } = Color.White;

    /// <summary>
    /// Gets or Sets the amount of rotation, in radians, to apply when rendering this sprite.
    /// </summary>
    /// <remarks>
    /// Default value is 0.0f.
    /// </remarks>
    public float Rotation { get; set; } = 0.0f;

    /// <summary>
    /// Gets or Sets the scale factor to apply to the x- and y-axes when rendering this sprite.
    /// </summary>
    /// <remarks>
    /// Default value is Vector2.One.
    /// </remarks>
    public Vector2 Scale { get; set; } = Vector2.One;

    /// <summary>
    /// Gets or Sets the xy-coordinate origin point, relative to the top-left corner, of this sprite.
    /// </summary>
    /// <remarks>
    /// Default value is Vector2.Zero.
    /// </remarks>
    public Vector2 Origin { get; set; } = Vector2.Zero;

    /// <summary>
    /// Gets or Sets the sprite effects to apply when rendering this sprite.
    /// </summary>
    /// <remarks>
    /// Default value is SpriteEffects.None.
    /// </remarks>
    public SpriteEffects Effects { get; set; } = SpriteEffects.None;

    /// <summary>
    /// Gets or Sets the layer depth to apply when rendering this sprite.
    /// </summary>
    /// <remarks>
    /// Default value is 0.0f.
    /// </remarks>
    public float LayerDepth { get; set; } = 0.0f;

    /// <summary>
    /// Gets the width, in pixels, of this sprite.
    /// </summary>
    /// <remarks>
    /// Width is calculated by multiplying the width of the source texture region by the x-axis scale factor.
    /// </remarks>
    public float Width => this.Region.Width * this.Scale.X;

    /// <summary>
    /// Gets the height, in pixels, of this sprite.
    /// </summary>
    /// <remarks>
    /// Height is calculated by multiplying the height of the source texture region by the y-axis scale factor.
    /// </remarks>
    public float Height => this.Region.Height * this.Scale.Y;

    /// <summary>
    /// Sets the origin of this sprite to the center.
    /// </summary>
    public void CenterOrigin()
    {
        this.Origin = new Vector2(this.Region.Width, this.Region.Height) * 0.5f;
    }

    /// <summary>
    /// Submit this sprite for drawing to the current batch.
    /// </summary>
    /// <param name="spriteBatch">The SpriteBatch instance used for batching draw calls.</param>
    /// <param name="position">The xy-coordinate position to render this sprite at.</param>
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        this.Region.Draw(spriteBatch, position, this.Color, this.Rotation, this.Origin, this.Scale, this.Effects, this.LayerDepth);
    }

    /// <summary>
    /// Submit this sprite for drawing to the current batch.
    /// </summary>
    /// <param name="spriteBatch">The SpriteBatch instance used for batching draw calls.</param>
    /// <param name="position">The xy-coordinate position to render this sprite at.</param>
    /// <param name="effects">The sprite effects to apply when rendering this sprite.</param>
    public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effects)
    {
        this.Region.Draw(spriteBatch, position, this.Color, this.Rotation, this.Origin, this.Scale, effects, this.LayerDepth);
    }
}
