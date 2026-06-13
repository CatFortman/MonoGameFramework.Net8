namespace MonoGameLibrary.Graphics;

/// <summary>
/// Defines the properties of a sprite sheet, which is a texture that contains multiple frames of animation arranged in a grid. The <see cref="SpriteSheetDefinition"/> class specifies the width and height of each frame, as well as the number of columns and rows in the sprite sheet. This information can be used to extract individual frames from the sprite sheet when creating animations or rendering sprites.
/// </summary>
public class SpriteSheetDefinition
{
    /// <summary>
    /// Gets the width, in pixels, of each frame in this sprite sheet.
    /// </summary>
    public int FrameWidth { get; init; }

    /// <summary>
    /// Gets the height, in pixels, of each frame in this sprite sheet.
    /// </summary>
    public int FrameHeight { get; init; }

    /// <summary>
    /// Gets the total number of columns in this sprite sheet. This represents how many frames are arranged horizontally in the sprite sheet texture.
    /// </summary>
    public int Columns { get; init; }

    /// <summary>
    /// Gets the total number of rows in this sprite sheet. This represents how many frames are arranged vertically in the sprite sheet texture.
    /// </summary>
    public int Rows { get; init; }
}